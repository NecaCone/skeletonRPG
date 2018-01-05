using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameItemDataBase{

	public ItemsList itemList;

	public void SaveEquipmentItems()
	{
		XmlSerializer serializer = new XmlSerializer (typeof(ItemsList));
		FileStream stream = new FileStream (Application.dataPath + "/Scripts/Items/ItemDatabase.xml",FileMode.Open);
		serializer.Serialize (stream, itemList);
		stream.Close ();
	}




	//public TextAsset itemInventory;
	//public static List<BaseItem> inventoryItems = new List<BaseItem>();

	//private List<Dictionary<string,string>> inventoryItemsDictonary = new List<Dictionary<string,string>>();

	//private Dictionary<string,string> inventoryDictonary;


	//void Awake()
//	{
	//	ReadItemsFromDatabase ();
	//	for(int i = 0 ; i< inventoryItemsDictonary.Count;i++)
	//	{
//			inventoryItems.Add(new BaseItem(inventoryItemsDictonary[i]));

	//	}
	//}


	//public void ReadItemsFromDatabase()
	//{
	//	XmlDocument xmlDocument = new XmlDocument ();
	//	xmlDocument.LoadXml (itemInventory.text);
	//	/XmlNodeList itemList = xmlDocument.GetElementsByTagName ("Item");
	//	foreach (XmlNode itemInfo in itemList) {
	//	XmlNodeList itemContent = itemInfo.ChildNodes;
		//	inventoryDictonary = new Dictionary <string, string>();
		//	foreach(XmlNode content in itemContent)
		//	{
		//		switch(content.Name)
		//		{
			//		case "ItemName":
			//		inventoryDictonary.Add("ItemName",content.InnerText);
			//		break;
			//		case "ItemId":
			//		inventoryDictonary.Add("ItemId",content.InnerText);
				//	break;
				//	case "ItemType":
			//		inventoryDictonary.Add("ItemType",content.InnerText);
				//	break;
			//	}
	//		}
			//
	//		inventoryItemsDictonary.Add(inventoryDictonary);
	//	}
	//}

}
