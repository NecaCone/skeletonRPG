using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class CreateNewEquipment : MonoBehaviour{

	private BaseEquipmentItem newEquipment;
	private GameItemDataBase gameItemDataBase = new GameItemDataBase();
	private ItemsList itemList = new ItemsList();

	private string spellEffectNameForMe;
	private string[] equipmentLevelName = new string[7]{"Common","Good","Medium","Very good","Nice","Impresive","Exelent"};
	private int[] spellEffectId = new int[5]{0,1,2,3,4};
	private string[] spellEffectName = new string[5]{"None","Fire","Frost","Poisen","Bleed"};
	private int strPlus = 0;
	private int agiPlus = 0;
	private int intPlus = 0;

	private int indexSpellId;

	private bool checkToSee=false;


	 void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 150, 50), "Create Item")) {
			CreateEquipment ();
		}
		if (GUI.Button (new Rect (60, 100, 150, 50), "Save all items")) {
			SaveEquipmentItems();
			Debug.Log("All items are saved");
			itemList.equipmentList = new List<BaseEquipmentItem>();
		}
		if (GUI.Button (new Rect (60, 200, 150, 50), "Load Items")) {
			LoadEquipmentItems();
			DisplayEquipmentItems();
		}

	}

	public void CreateEquipment()
	{
		newEquipment = new BaseEquipmentItem ();


		string typeEquiplemt = ChooseEquipmentType ();
		int indexLevelName = Random.Range (0, (equipmentLevelName.Length));

		if (indexLevelName == 0) {
				newEquipment.ItemDescription = "Common " + typeEquiplemt + " most of poor people use it mob and helots";		
		} else if (indexLevelName == 1) {
				newEquipment.ItemDescription = "Good " + typeEquiplemt + " use by milit and light infantry";
		} else if (indexLevelName == 2) {
				newEquipment.ItemDescription = "Medium " + typeEquiplemt + " veri useful";
		} else if (indexLevelName == 3) {
				newEquipment.ItemDescription = "Very good " + typeEquiplemt + " used by medium troops";
		} else if (indexLevelName == 4) {
				newEquipment.ItemDescription = "Nice " + typeEquiplemt + " used by legio protectores";
		} else if (indexLevelName == 5) {
				newEquipment.ItemDescription = "Impresive " + typeEquiplemt + " wore by generals and centurions";
		} else if (indexLevelName == 6) {
				newEquipment.ItemDescription = "Exelend " + typeEquiplemt + " is epic pice of art work";
		}

		newEquipment.ItemName = equipmentLevelName [indexLevelName] +" "+ typeEquiplemt;
		indexSpellId = Random.Range (0, (spellEffectId.Length));
		spellEffectNameForMe = spellEffectName [indexSpellId];  

		if (typeEquiplemt == "Head" || typeEquiplemt == "Hands" || typeEquiplemt == "Legs") {
			switch (indexLevelName) {
			case 0:
					strPlus = 0; 
					agiPlus = 0;
					break;
			case 1:
					strPlus = 2;
					agiPlus = 2;
					break;
			case 2:
					strPlus = 6;
					agiPlus = 6;
					break;
			case 3:
					strPlus = 10;
					agiPlus = 10;
					break;
			case 4:
					strPlus = 14;
					agiPlus = 14;
					break;
			case 5:
					strPlus = 18;
					agiPlus = 18;
					break;
			case 6:
					strPlus = 22;
					agiPlus = 22;
					break;
			}
	}
	if (typeEquiplemt == "Chest") {
			switch (indexLevelName) {
			case 0:
					strPlus = 0;
					agiPlus = 0;
					break;
			case 1:
					strPlus = 6;
					agiPlus = 6;
					break;
			case 2:
					strPlus = 12;
					agiPlus = 12;
					break;
			case 3:
					strPlus = 18;
					agiPlus = 18;
					break;
			case 4:
					strPlus = 24;
					agiPlus = 24;
					break;
			case 5:
					strPlus = 29;
					agiPlus = 29;
					break;
			case 6:
					strPlus = 33;
					agiPlus = 33;
					break;
			}
		}
	
		newEquipment.Strenght = strPlus + Random.Range (1, 11);
		newEquipment.Agility = agiPlus + Random.Range (1, 11);
		newEquipment.Intelect = intPlus + Random.Range (1, 11);


			Debug.Log(indexSpellId);
			Debug.Log(indexLevelName);
			Debug.Log(newEquipment.ItemName);
			Debug.Log(newEquipment.ItemDescription);
			Debug.Log(spellEffectNameForMe);
			Debug.Log(newEquipment.Strenght);
			Debug.Log(newEquipment.Agility );
			Debug.Log(newEquipment.Intelect);

		InsertIntoList(newEquipment);

	}
	public string ChooseEquipmentType()
	{
		int tempET = Random.Range (1, 5);
		switch (tempET){
		case 1:
			newEquipment.EquipmentType = BaseEquipmentItem.EquipmentTypes.HANDS;
			break;
		case 2: 
			newEquipment.EquipmentType = BaseEquipmentItem.EquipmentTypes.HEAD;
			break;
		case 3: 
			newEquipment.EquipmentType = BaseEquipmentItem.EquipmentTypes.LEGS;
			break;
		case 4: 
			newEquipment.EquipmentType = BaseEquipmentItem.EquipmentTypes.CHEST;
			break;
		}
		if (tempET == 1) {
			return "Hands";
		} else if (tempET == 2) {
			return "Head";
		} else if (tempET == 3) {
			return "Legs";
		} else if (tempET == 4) {
			return "Chest";
		}
		return "No equipmet";
	}

	public void InsertIntoList(BaseEquipmentItem equipment)
	{

		itemList.equipmentList.Add(equipment);
		checkToSee = true;
		if (checkToSee) {
			Debug.Log ("Uspesno");
		}
	}

	public void SaveEquipmentItems()
	{
		XmlSerializer serializer = new XmlSerializer (typeof(ItemsList));
		FileStream stream = new FileStream (Application.dataPath + "/Scripts/Items/ItemDatabase.xml",FileMode.Open);
		serializer.Serialize(stream, itemList);
		stream.Close ();
	}
	public void LoadEquipmentItems()
	{
		XmlSerializer serializer = new XmlSerializer (typeof(ItemsList));
		FileStream stream = new FileStream (Application.dataPath + "/Scripts/Items/ItemDatabase.xml",FileMode.Open);
		itemList = serializer.Deserialize (stream) as ItemsList;
		stream.Close();
	}

	public void DisplayEquipmentItems()
	{
		for (int i = 0; i < itemList.equipmentList.Count; i++) {
			string itemName = itemList.equipmentList[i].ItemName;
			string itemType = itemList.equipmentList[i].EquipmentType.ToString();
			string itemLevel = itemList.equipmentList[i].Strenght.ToString();
			Debug.Log(itemName);
			Debug.Log(itemType);
			Debug.Log(itemLevel);
		}
	}
}



