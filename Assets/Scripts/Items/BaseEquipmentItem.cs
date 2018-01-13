using UnityEngine;
using System.Collections;

public enum EquipmentTypes
{
    ARMOR,
    WEAPON,
}
[System.Serializable]
public abstract class BaseEquipmentItem : BaseItem {
    
	private EquipmentTypes equipmentType;

    private int stamina;
    private int strenght;
    private int agility;
    private int endurance;
    private int intelect;
    private int resistance;
    private int magicResistance;


    public EquipmentTypes EquipmentType {
		get{ return equipmentType;}
		set{ equipmentType = value;}
	}

    public BaseEquipmentItem(){}
	public BaseEquipmentItem (
        string itemName,
        string itemDescription, 
        int itemId, 
        EquipmentTypes equipmentType,
        ItemTypes itemType,
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
		: base (itemName, itemDescription,itemId,itemType,stackSize, spriteNeutral, spriteHighlighted)
	{
		equipmentType = this.equipmentType;
        this.stamina = stamina;
        this.strenght = strenght;
        this.agility = agility;
        this.endurance = endurance;
        this.intelect = intelect;
        this.resistance = resistance;
        this.magicResistance = magicResistance;
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

    public int Intelect
    {
        get
        {
            return intelect;
        }

        set
        {
            intelect = value;
        }
    }

    public int Endurance
    {
        get
        {
            return endurance;
        }

        set
        {
            endurance = value;
        }
    }

    public int Agility
    {
        get
        {
            return agility;
        }

        set
        {
            agility = value;
        }
    }

    public int Strenght
    {
        get
        {
            return strenght;
        }

        set
        {
            strenght = value;
        }
    }

    public int Stamina
    {
        get
        {
            return stamina;
        }

        set
        {
            stamina = value;
        }
    }
}
