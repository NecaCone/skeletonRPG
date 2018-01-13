using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum ItemTypes
{
    EQUIPMENT,
    WEAPON,
    SCROLL,
    POTION
};

[System.Serializable]
public abstract class BaseItem{

	private string itemName;
	private string itemDescription;
	private int itemID;

	private int stamina; //ima ulogu u health
	private int endurance; // ima ulogu u energiji
	private int strenght; //pojacava napad
	private int intelect; //pojacava napad magijom
	private int agility; // povecava brzinu kretanja
	private int resistance; //povecava odbranu na 
	private int magicResistance; // 

    private int stackSize;
    private ItemTypes itemType;
    private Sprite spriteNeutral;
    private Sprite spriteHighlighted;



    public BaseItem (){}

	public BaseItem(
        string itemName,
        string itemDescription, 
        int itemId, 
        int stamina,
        int endurance,
        int strenght, 
        int intelect,
        int agility,
        ItemTypes itemType,
        int stackSize,
        Sprite spriteNeutral, 
        Sprite spriteHighlighted
        )
	{
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemID = ItemID;
        this.stamina = stamina;
        this.endurance = endurance;
        this.strenght = strenght;
        this.intelect = intelect;
        this.agility = agility;
        this.itemType = itemType;
        this.stackSize = stackSize;
        this.spriteNeutral = spriteNeutral;
        this.spriteHighlighted = spriteHighlighted;
    }


	public string ItemName {
				get{ return itemName;}
				set{ itemName = value;}
	}

    public int StackSize
    {
        get
        {
            return stackSize;
        }

        set
        {
            stackSize = value;
        }
    }

    public string ItemDescription {
		get{ return itemDescription;}
		set{ itemDescription = value;}
	}
	public int ItemID {
		get{ return itemID;}
		set{ itemID = value;}
	}
	public ItemTypes ItemType
	{
		get{return itemType;}
		set{itemType = value;}
	}
	 


	public int Stamina {
		get{return stamina;}
		set{stamina = value;}
	}
	public int Endurance {
		get{return endurance;}
		set{endurance = value;}
	}
	public int Strenght {
		get{return strenght;}
		set{strenght = value;}
	}
	public int Intelect {
		get{return intelect;}
		set{intelect = value;}
	}
	public int Agility {
		get{return agility;}
		set{agility = value;}
	}

    //dohvat  sliku tj prefab itema kako on izgleda u inventaru preko njegovog objekta
    public Sprite SpriteNeutral
    {
        get
        {
            return spriteNeutral;
        }

        set
        {
            spriteNeutral = value;
        }
    }

    public Sprite SpriteHighlighted
    {
        get
        {
            return spriteHighlighted;
        }

        set
        {
            spriteHighlighted = value;
        }
    }
}
