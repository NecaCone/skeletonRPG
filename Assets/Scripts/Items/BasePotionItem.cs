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

    private PotionTypes potionType;
	private int spellEffect;
	
	public PotionTypes PotionType {
		get{ return potionType;}
		set{ potionType = value;}
	}
	
	public int SpellEffect {
		get{ return spellEffect;}
		set{ spellEffect = value;}
	}
    

    public BasePotionItem() { }

    public BasePotionItem(
        string itemName,
        string itemDescription, 
        int itemId, int stamina, 
        int endurance, int strenght,
        int intelect, 
        int agility, 
        PotionTypes potionTypes, 
        int spellEffect,
        ItemTypes itemType,
        Sprite spriteNeutral, 
        Sprite spriteHighlighted,
        int stackSize
        )
        : base(itemName, itemDescription, itemId, stamina, endurance, strenght, agility, intelect, itemType,stackSize, spriteNeutral, spriteHighlighted)
    {
        this.spellEffect = spellEffect;
        this.potionType = potionTypes;
    }



}
