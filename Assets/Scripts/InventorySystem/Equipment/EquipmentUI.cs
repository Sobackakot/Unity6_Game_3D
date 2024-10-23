
using System;
using System.Collections.Generic;
using UnityEngine; 

public class EquipmentUI : MonoBehaviour, IInventoryUI<byte,ItemScrObj>
{ 
    private List<EquipmentSlot> slots = new List<EquipmentSlot>();
    private List<EquipmentItemInSlot> itemsInSlots = new List<EquipmentItemInSlot>();

    public event Func<List<ItemScrObj>> onSetNewItem;
     
    private void Awake()
    {
        slots.AddRange(GetComponentsInChildren<EquipmentSlot>(false));
        itemsInSlots.AddRange(GetComponentsInChildren<EquipmentItemInSlot>(false));
    } 
    public void SetNewItemByInventoryCell(byte index, ItemScrObj newItem) //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        for(byte i = 0; i < slots.Count; i++)
        {
            EquipFields equipFields = slots[i].equipField.fieldType;
            if((byte)newItem.itemType == (byte)equipFields)
            {
                slots[i].AddItemInSlot(itemsInSlots[i], newItem);
                return;
            }
        }
        Debug.Log("No matching slot found for item type: " + newItem.itemType);
    }
    public void ResetItemByInventoryCell(byte index, ItemScrObj item) //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        for(byte i = 0; i < slots.Count; i++)
        {
            EquipFields equipFields = slots[i].equipField.fieldType;
            if ((byte)item.itemType == (byte)equipFields)
            { 
                slots[i].RemoveItemInSlot(itemsInSlots[i]);
            }
        }
    }
    public void UpdateInventorySlots() //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        for (byte i = 0; i < slots.Count; i++) //Updates the inventory UI completely when changing characters
        {
            if (itemsInSlots[i].dataItem != null)
            {
                slots[i].RemoveItemInSlot(itemsInSlots[i]);
            }
            if (i < items.Count && items[i] != null)
            {
                slots[i].AddItemInSlot(itemsInSlots[i], items[i]);
            }
        }
    }
}
