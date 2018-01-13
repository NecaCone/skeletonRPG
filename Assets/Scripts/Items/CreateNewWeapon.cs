using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {
	private BaseWeaponItem newWeapon;
	private string spellEffectNameForMe;
	private string[] weaponLevelName = new string[7]{"Common","Good","Medium","Very good","Nice","Impresive","Exelent"};

	private int[] spellEffectId = new int[5]{0,1,2,3,4};
	private string[] spellEffectName = new string[5]{"None","Fire","Frost","Poisen","Bleed"};


	void Start()
	{
		//CreateWeapon();

	}

	public void CreateWeapon(){
		newWeapon = new BaseWeaponItem();
		int strPlus = 0;
		int agiPlus = 0;
		int intPlus = 0;

		string typeWeapon =  ChooseWeaponType();
		int indexLevelName = Random.Range(0,(weaponLevelName.Length));

		if (indexLevelName == 0) {
			newWeapon.ItemDescription = "Common "+typeWeapon+" most of poor people use it mob and helots";		
		} else if (indexLevelName == 1) {
			newWeapon.ItemDescription = "Good "+typeWeapon+" use by milit and light infantry";
		} else if (indexLevelName == 2) {
			newWeapon.ItemDescription = "Medium "+typeWeapon+" veri useful";
		} else if (indexLevelName == 3) {
			newWeapon.ItemDescription = "Very good "+typeWeapon+" used by medium troops";
		} else if (indexLevelName == 4) {
			newWeapon.ItemDescription = "Nice "+typeWeapon+" used by legio protectores";
		}else if (indexLevelName == 5) {
			newWeapon.ItemDescription = "Impresive "+typeWeapon+" wore by generals and centurions";
		}else if (indexLevelName == 6) {
			newWeapon.ItemDescription = "Exelend "+typeWeapon+" is epic pice of art work";
		}

		newWeapon.ItemName = weaponLevelName[indexLevelName];
		int indexSpellId = Random.Range (0,(spellEffectId.Length));
		spellEffectNameForMe = spellEffectName[indexSpellId];

		if (typeWeapon == "Sword"||typeWeapon == "Spear"||typeWeapon=="Sheald") {
			switch(indexLevelName)
			{
			case 0:
				strPlus=0;
				agiPlus=0;
				break;
			case 1:
				strPlus=5;
				agiPlus=5;
				break;
			case 2:
				strPlus=10;
				agiPlus=10;
				break;
			case 3:
				strPlus=15;
				agiPlus=15;
				break;
			case 4:
				strPlus=20;
				agiPlus=20;
				break;
			case 5:
				strPlus=23;
				agiPlus=23;
				break;
			case 6:
				strPlus=26;
				agiPlus=26;
				break;
			}
		}
		if (typeWeapon == "Staff") {
			switch(indexLevelName)
			{
			case 0:
				intPlus=0;
				agiPlus=0;
				break;
			case 1:
				intPlus=5;
				agiPlus=5;
				break;
			case 2:
				intPlus=10;
				agiPlus=10;
				break;
			case 3:
				intPlus=15;
				agiPlus=15;
				break;
			case 4:
				intPlus=20;
				agiPlus=20;
				break;
			case 5:
				intPlus=23;
				agiPlus=23;
				break;
			case 6:
				intPlus=26;
				agiPlus=26;
				break;
			}
		}

		newWeapon.Strenght = strPlus + Random.Range (1, 11);
		newWeapon.Agility = agiPlus + Random.Range (1, 11);
		newWeapon.Intelect = intPlus + Random.Range (1, 11);

		Debug.Log(indexSpellId);
		Debug.Log(indexLevelName);
		Debug.Log(newWeapon.ItemName);
		Debug.Log(newWeapon.ItemDescription);
		Debug.Log(spellEffectNameForMe);
		Debug.Log(newWeapon.Strenght);
		Debug.Log(newWeapon.Agility );
		Debug.Log(newWeapon.Intelect);

	}

	public string ChooseWeaponType()
	{
		int tempWT = Random.Range (1, 5);
		switch (tempWT){
		case 1:
				newWeapon.WeaponType = BaseWeaponItem.WeaponTypes.SWORD;
			break;
		case 2: 
				newWeapon.WeaponType = BaseWeaponItem.WeaponTypes.SHEALD;
			break;
		case 3: 
				newWeapon.WeaponType = BaseWeaponItem.WeaponTypes.SPEAR;
			break;
		case 4: 
				newWeapon.WeaponType = BaseWeaponItem.WeaponTypes.STAFF;
			break;
		}
		if (tempWT == 1) {
				return "Sword";
		} else if (tempWT == 2) {
				return "Sheald";
		} else if (tempWT == 3) {
				return "Spear";
		} else if (tempWT == 4) {
				return "Staff";
		}
		return "No weapon";
	}

}
