using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

	private BasePotionItem newPotion;
	private string[] potionLevelName = new string[7]{"Common","Good","Medium","Very good","Nice","Impresive","Exelent"};

	void Start()
	{
		CreatePotion ();
	}

	private void CreatePotion()
	{
		newPotion = new BasePotionItem ();
			
		string typePotion = ChoosePotionType ();
		int indexLevelName = Random.Range (0, (potionLevelName.Length));

		if (indexLevelName == 0) {
			newPotion.ItemDescription = "Common " + typePotion + " most of poor people use it mob and helots";		
		} else if (indexLevelName == 1) {
			newPotion.ItemDescription = "Good " + typePotion + " use by milit and light infantry";
		} else if (indexLevelName == 2) {
			newPotion.ItemDescription = "Medium " + typePotion + " veri useful";
		} else if (indexLevelName == 3) {
			newPotion.ItemDescription = "Very good " + typePotion + " used by medium troops";
		} else if (indexLevelName == 4) {
			newPotion.ItemDescription = "Nice " + typePotion + " used by legio protectores";
		} else if (indexLevelName == 5) {
			newPotion.ItemDescription = "Impresive " + typePotion + " wore by generals and centurions";
		} else if (indexLevelName == 6) {
			newPotion.ItemDescription = "Exelend " + typePotion + " is epic pice of art work";
		}
		
		newPotion.ItemName = potionLevelName[indexLevelName];


		Debug.Log(indexLevelName);
		Debug.Log(newPotion.ItemName);
		Debug.Log(newPotion.ItemDescription);

	}


	public string ChoosePotionType()
	{
		int tempPT = Random.Range (1, 4);
		switch (tempPT){
		case 1:
			newPotion.PotionType = BasePotionItem.PotionTypes.HEALTH;
			break;
		case 2: 
			newPotion.PotionType = BasePotionItem.PotionTypes.AGILITY;
			break;
		case 3: 
			newPotion.PotionType = BasePotionItem.PotionTypes.ENDURANCE;
			break;
		case 4: 
			newPotion.PotionType = BasePotionItem.PotionTypes.STRENGHT;
			break;
		}
		if (tempPT == 1) {
			return "Health";
		} else if (tempPT == 2) {
			return "Agility";
		} else if (tempPT == 3) {
			return "Endurance";
		} else if (tempPT == 4) {
			return "Strenght";
		}
		return "No potion";
	}
}
