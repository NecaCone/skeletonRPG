using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseScrollItem : BaseItem {

	public enum ScrollTypes
	{
		INTELECT,
		ENDURANCE,
		AGILITY
	}
	
	private ScrollTypes scrollType;
	private int spellEffect;
	
	public ScrollTypes ScrollType {
		get{ return scrollType;}
		set{ scrollType = value;}
	}
	
	public int SpellEffect {
		get{ return spellEffect;}
		set{ spellEffect = value;}
	}
}
