using UnityEngine;

[CreateAssetMenu(fileName = "EquipFieldScrObj", menuName = "Scriptable Objects/EquipFieldScrObj")]
public class EquipFieldScrObj : ScriptableObject
{
    public EquipField equipField;
    public EquipFields equipFields;
}
public enum EquipFields
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
    �onsumables,
    Upgrade,
    None
}
