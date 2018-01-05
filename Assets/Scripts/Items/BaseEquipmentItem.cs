using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseEquipmentItem : BaseItem {

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


	public BaseEquipmentItem(){}
	public BaseEquipmentItem (string itemName,string itemDescription, int itemId, int stamina,int endurance, int strenght, int intelect,int agility,int resistane,int magicResistance,EquipmentTypes equipmentType,int spellEffect)
		: base (itemName, itemDescription,itemId,stamina,endurance,strenght,agility,intelect,resistane,magicResistance)
	{
		equipmentType = this.equipmentType;
		spellEffect = this.spellEffect;
	
	} 
}
