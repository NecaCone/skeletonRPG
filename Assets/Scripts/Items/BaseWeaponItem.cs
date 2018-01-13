using UnityEngine;
using System.Collections;

public enum WeaponTypes
{
    SWORD,
    SPEAR,
    SHEALD,
    STAFF
}
[System.Serializable]
public class BaseWeaponItem : BaseEquipmentItem {


	private WeaponTypes weaponType;
	public WeaponTypes WeaponType {
		get{ return weaponType;}
		set{ weaponType = value;}
	}

    public BaseWeaponItem()
    {
    }
    public BaseWeaponItem(
        string itemName,
        string itemDescription,
        int itemId,
        EquipmentTypes equipmentType,
        ItemTypes itemType,
        WeaponTypes weaponType,
        int stackSize,
        Sprite spriteNeutral,
        Sprite spriteHighlighted,
        int stamina,
        int strenght,
        int agility,
        int endurance,
        int intelect,
        int resistance,
        int magicResistance
        )
        : base(
            itemName,
            itemDescription,
            itemId,
            equipmentType,
            itemType,
            stackSize,
            spriteNeutral,
            spriteHighlighted,
            stamina,
            strenght,
            agility,
            endurance,
            intelect,
            resistance,
            magicResistance
         )
    {
        this.weaponType = weaponType;
    }


}
