using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum ItemTypes
{
    EQUIPMENT,
    SCROLL,
    POTION
};

[System.Serializable]
public abstract class BaseItem : MonoBehaviour{

	private string itemName;
	private string itemDescription;
	private int itemID;

	
    private int stackSize;
    private ItemTypes itemType;
    private Sprite spriteNeutral;
    private Sprite spriteHighlighted;



    public BaseItem ()
    {
    }

	public BaseItem(
        string itemName,
        string itemDescription, 
        int itemId, 
        ItemTypes itemType,
        int stackSize,
        Sprite spriteNeutral, 
        Sprite spriteHighlighted
        )
	{
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemID = ItemID;
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
