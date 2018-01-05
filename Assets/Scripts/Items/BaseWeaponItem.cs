using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseWeaponItem : BaseItem {

	public enum WeaponTypes
	{
		SWORD,
		SPEAR,
		SHEALD,
		STAFF
	}

	private WeaponTypes weaponType;
	private int spellEffect;

	public WeaponTypes WeaponType {
		get{ return weaponType;}
		set{ weaponType = value;}
	}

	public int SpellEffect {
		get{ return spellEffect;}
		set{ spellEffect = value;}
	}
}
