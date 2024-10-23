
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]
public class ItemScrObj : ScriptableObject
{
    public Item item;
    public string Id { get; private set; }
    public string NameItem;
    public Sprite IconItem;
    public float Weight;
    public bool isDefaultItem;
    public bool isStackable;

    private bool isInstaled;

    public float Armor;
    public float Damage;
    public EquipItems itemType; //slots for equipping items
    
    public void SetIdFromNewItem()
    {
        if (isInstaled)
        {
            Id = Guid.NewGuid().ToString();
            isInstaled = true;
        }
    } 
}
public enum EquipItems : byte
{
    Helmet,
    ArmorVest,
    Backpack,
    Weapon_1,
    Weapon_2,
    Flashlight,
    Binoculars,
    Knife,
    Bolts,
    Grenades,
    PDA,
    Devices,
    Ñonsumables,
    Upgrade, 
    None
}
