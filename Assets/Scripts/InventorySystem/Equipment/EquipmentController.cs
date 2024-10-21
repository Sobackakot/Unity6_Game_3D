
using System;
using System.Collections.Generic; 
using Zenject;

public class EquipmentController  : IInitializable, IDisposable
{   
    private IInventoryUI<int> equipmentUI;
    public event Func<ItemScrObj, bool> onEquipItemOnPerson;

    public readonly List<ItemScrObj> equipmentItem;
    public EquipmentController([Inject(Id = "equipmentUI")] IInventoryUI<int> equipmentUI)
    {
        this.equipmentUI = equipmentUI;

        int indexSlot = System.Enum.GetNames(typeof(EquipItem)).Length; //get the number of slots for equipmentUI items
        equipmentItem = new List<ItemScrObj>(indexSlot);
        for (int i = 0; i < indexSlot; i++)
        {
            equipmentItem.Add(null); //initialize item equipmentUI slots
        }
    }
    public void Initialize()
    {
        equipmentUI.onSetNewItem += GetEquipmentItems;
    } 
    public void Dispose()
    {
        equipmentUI.onSetNewItem -= GetEquipmentItems;
    }
    public void ActiveEquipmentPanel()
    {
        equipmentUI.UpdateInventorySlots();
    }
    public void EquipItem(ItemScrObj newItem) //coll from ItemInSlot
    {
        int currentIndex = (int)newItem.IndexOfSlot; // convert from EquipmentScrObj Slot to index 
        ItemScrObj oldItem = null;
        if (equipmentItem[currentIndex] != null) //if such an item is already equipped
        {
            oldItem = equipmentItem[currentIndex]; //return the item back to inventory
            onEquipItemOnPerson?.Invoke(oldItem);
        } 
        equipmentItem[currentIndex] = newItem;//equip pick item  from inventory cell
        equipmentUI.SetNewItemByInventoryCell(currentIndex); 
    }
   
    private void UnEquipItem(int currentIndex)
    {
        if (equipmentItem[currentIndex] != null)//if such an item is already equipped
        {
            ItemScrObj oldItem = equipmentItem[currentIndex];//return the item back to inventory
            onEquipItemOnPerson?.Invoke(oldItem);
            equipmentItem[currentIndex] = null;//reset an item's equipmentUI slot 
        }
        equipmentUI.ResetItemByInventoryCell(currentIndex);
    }
    public List<ItemScrObj> GetEquipmentItems()
    {
        return equipmentItem;
    }
    private void UnEquipItemsAll() //....
    {
       for(int i = 0; i< equipmentItem.Count; i++)
       {
            UnEquipItem(i);
       }
    }

}
