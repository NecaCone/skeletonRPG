using UnityEngine;
using System.Collections;

public enum ScrollTypes
{
    INTELECT,
    ENDURANCE,
    AGILITY
}

[System.Serializable]
public class BaseScrollItem : BaseItem {

	
	
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
