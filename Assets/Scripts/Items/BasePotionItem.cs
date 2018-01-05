using UnityEngine;
using System.Collections;
[System.Serializable]
public class BasePotionItem : BaseItem{

	public enum PotionTypes
	{
		HEALTH,
		ENDURANCE,
		STRENGHT,
		AGILITY
	}

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

}
