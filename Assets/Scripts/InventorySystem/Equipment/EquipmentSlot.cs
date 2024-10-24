
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class EquipmentSlot : InventorySlot
{ 
    public EquipFieldScrObj equipField;
    public override void AddItemInSlot(ItemInSlot item, ItemScrObj data)
    {
        base.AddItemInSlot(item, data);
    }
    public override void RemoveItemInSlot(ItemInSlot item)
    {
        base.RemoveItemInSlot(item);
    }
    public override void OnDrop(PointerEventData eventData)
    {
        ItemInSlot dropItem = eventData.pointerDrag.GetComponent<ItemInSlot>();
        if((byte)dropItem.dataItem.itemType == (byte)equipField.fieldType)
        {
            base.OnDrop(eventData);
        }
        else
        {
            Debug.Log("Item cannot be equipped in this slot!");
        }
    } 
}
