using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class ItemsList : MonoBehaviour {

	public List<BaseEquipmentItem> equipmentList = new List<BaseEquipmentItem> ();
}

//public CreateNewEquipment(int indexSpellId,int indexLevelName, string ItemName, string ItemDescription, string spellEffectNameForMe,int Strenght, int Agility, int Intelect)
//{
//	indexSpellId = this.indexSpellId;
//	indexLevelName = this.indexLevelName;
//	ItemName = this.newEquipment.ItemName;
//	ItemDescription = this.newEquipment.ItemDescription;
//	spellEffectNameForMe = spellEffectNameForMe;
//	Strenght = this.newEquipment.Strenght;
//	Agility = this.newEquipment.Agility;
//	Intelect = this.newEquipment.Intelect;
	
//}