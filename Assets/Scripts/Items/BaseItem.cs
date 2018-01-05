using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class BaseItem{

	private string itemName;
	private string itemDescription;
	private int itemID;

	private int stamina; //ima ulogu u health
	private int endurance; // ima ulogu u energiji
	private int strenght; //pojacava napad
	private int intelect; //pojacava napad magijom
	private int agility; // povecava brzinu kretanja
	private int resistance; //povecava odbranu na 
	private int magicResistance; // 


	public enum ItemTypes
	{
		EQUIPMENT,
		WEAPON,
		SCROLL,
		POTION
	};

	private ItemTypes itemType;

	public BaseItem (){}

	public BaseItem(string itemName,string itemDescription, int itemId, int stamina,int endurance, int strenght, int intelect,int agility,int resistane,int magicResistance)
	{
		itemName = this.itemName;
		itemDescription = this.ItemDescription;
		itemId = this.itemID;
		stamina = this.stamina;
		endurance = this.endurance;
		strenght = this.strenght;
		intelect = this.intelect;
		agility = this.agility;
		resistane = this.resistance;
		magicResistance = this.magicResistance;
	}


	public string ItemName {
				get{ return itemName;}
				set{ itemName = value;}
	}



	public string ItemDescription {
		get{ return itemDescription;}
		set{ itemDescription = value;}
	}
	public int ItemID {
		get{ return itemID;}
		set{ itemID = value;}
	}
	public ItemTypes ItemType
	{
		get{return itemType;}
		set{itemType = value;}
	}
	 


	public int Stamina {
		get{return stamina;}
		set{stamina = value;}
	}
	public int Endurance {
		get{return endurance;}
		set{endurance = value;}
	}
	public int Strenght {
		get{return strenght;}
		set{strenght = value;}
	}
	public int Intelect {
		get{return intelect;}
		set{intelect = value;}
	}
	public int Agility {
		get{return agility;}
		set{agility = value;}
	}
	public int Resistance {
		get{return resistance;}
		set{resistance = value;}
	}
	public int MagicResistance {
		get{return magicResistance;}
		set{magicResistance = value;}
	}

}
