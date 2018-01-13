using UnityEngine;
using System.Collections;

public enum PotionTypes
{
    HEALTH,
    ENDURANCE,
    STRENGHT,
    AGILITY
}

[System.Serializable]
public class BasePotionItem : BaseItem  {

    private int stamina;
    private int endurance;
    private int strenght;
    private int agility;

    private PotionTypes potionType;
	
	public PotionTypes PotionType {
		get{ return potionType;}
		set{ potionType = value;}
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

    public BasePotionItem() { }

    public BasePotionItem(
        string itemName,
        string itemDescription,
        int itemId,
        ItemTypes itemType,
        int stackSize,
        Sprite spriteNeutral,
        Sprite spriteHighlighted,
        PotionTypes potionType,
        int stamina,
        int endurance,
        int agility,
        int strenght
        )
        : base(itemName, itemDescription, itemId, itemType,stackSize, spriteNeutral, spriteHighlighted)
    {
        this.stamina = stamina;
        this.strenght = strenght;
        this.agility = agility;
        this.endurance = endurance;
        this.potionType = potionType;
    }

    public void Use()
    {
        switch (PotionType)
        {
            case PotionTypes.HEALTH:
                Debug.Log("Used health");
                break;
            case PotionTypes.ENDURANCE:
                Debug.Log("Used endurance");
                break;
            case PotionTypes.STRENGHT:
                break;
            case PotionTypes.AGILITY:
                break;
        }
    }

}
