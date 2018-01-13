using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseEquipmentItem : BaseItem {


    private int resistance; //povecava odbranu na 
    private int magicResistance; // 


    public enum EquipmentTypes
	{
		HEAD,
		CHEST,
		LEGS,
		HANDS
	}
	
	private EquipmentTypes equipmentType;
	private int spellEffect;

	public EquipmentTypes EquipmentType {
		get{ return equipmentType;}
		set{ equipmentType = value;}
	}
	
	public int SpellEffect {
		get{ return spellEffect;}
		set{ spellEffect = value;}
	}

    public int Resistance
    {
        get
        {
            return resistance;
        }

        set
        {
            resistance = value;
        }
    }

    public int MagicResistance
    {
        get
        {
            return magicResistance;
        }

        set
        {
            magicResistance = value;
        }
    }

    public BaseEquipmentItem(){}
	public BaseEquipmentItem (string itemName,string itemDescription, int itemId, int stamina,int endurance, int strenght, int intelect,int agility,EquipmentTypes equipmentType,int spellEffect, int resistance, int magicResistance, ItemTypes itemType,int stackSize, Sprite spriteNeutral, Sprite spriteHighlighted)
		: base (itemName, itemDescription,itemId,stamina,endurance,strenght,agility,intelect,itemType,stackSize, spriteNeutral, spriteHighlighted)
	{
        resistance = this.resistance;
        magicResistance = this.magicResistance;
		equipmentType = this.equipmentType;
		spellEffect = this.spellEffect;
	} 
}
