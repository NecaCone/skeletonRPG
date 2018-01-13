//using UnityEngine;
//using System.Collections;

//public class CreateNewScroll : MonoBehaviour {

//	private BaseScrollItem newScroll;
//	private string spellEffectNameForMe;
//	private string[] ScrollLevelName = new string[7]{"Common","Good","Medium","Very good","Nice","Impresive","Exelent"};
//	private int[] spellEffectId = new int[5]{0,1,2,3,4};
//	private string[] spellEffectName = new string[5]{"None","Fire","Frost","Poisen","Bleed"};
	
//	void Start()
//	{
//		//CreateScroll();
//	}
	
//	public void CreateScroll()
//	{
//		newScroll = new BaseScrollItem ();

//		string typeScroll = ChooseScrollType ();
//		int indexLevelName = Random.Range (0, (ScrollLevelName.Length));
		
//		if (indexLevelName == 0) {
//			newScroll.ItemDescription = "Common " + typeScroll + " most of poor people use it mob and helots";		
//		} else if (indexLevelName == 1) {
//			newScroll.ItemDescription = "Good " + typeScroll + " use by milit and light infantry";
//		} else if (indexLevelName == 2) {
//			newScroll.ItemDescription = "Medium " + typeScroll + " veri useful";
//		} else if (indexLevelName == 3) {
//			newScroll.ItemDescription = "Very good " + typeScroll + " used by medium troops";
//		} else if (indexLevelName == 4) {
//			newScroll.ItemDescription = "Nice " + typeScroll + " used by legio protectores";
//		} else if (indexLevelName == 5) {
//			newScroll.ItemDescription = "Impresive " + typeScroll + " wore by generals and centurions";
//		} else if (indexLevelName == 6) {
//			newScroll.ItemDescription = "Exelend " + typeScroll + " is epic pice of art work";
//		}
		
//		newScroll.ItemName = ScrollLevelName[indexLevelName];
//		int indexSpellId = Random.Range (0, (spellEffectId.Length));
//		spellEffectNameForMe = spellEffectName [indexSpellId];

//		Debug.Log(indexSpellId);
//		Debug.Log(indexLevelName);
//		Debug.Log(newScroll.ItemName);
//		Debug.Log(newScroll.ItemDescription);
//		Debug.Log(spellEffectNameForMe);
//	}
//	public string ChooseScrollType()
//	{
//		int tempST = Random.Range (1, 3);
//		switch (tempST){
//		case 1:
//			newScroll.ScrollType = BaseScrollItem.ScrollTypes.AGILITY;
//			break;
//		case 2: 
//			newScroll.ScrollType = BaseScrollItem.ScrollTypes.ENDURANCE;
//			break;
//		case 3: 
//			newScroll.ScrollType = BaseScrollItem.ScrollTypes.INTELECT;
//			break;
//		}
//		if (tempST == 1) {
//				return "Agility scroll";
//		} else if (tempST == 2) {
//			return "Endurance scroll";
//		} else if (tempST == 3) {
//			return "Intelect scroll";
//		}
//		return "No scroll";
//	}
//}
