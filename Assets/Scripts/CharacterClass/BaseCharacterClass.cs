using UnityEngine;
using System.Collections;

public class BaseCharacterClass{

	private string characterClassName; //dajemo naziv klasi u nasledjenim
	private string characterClassDescritpion;// dajemo opis

	private int stamina; //ima ulogu u health
	private int endurance; // ima ulogu u energiji
	private int strenght; //pojacava napad
	private int intelect; //pojacava napad magijom
	private int agility; // povecava brzinu kretanja
	private int resistance; //povecava odbranu na 
	private int magicResistance; // povecava odbranu za magije

	private string characterBio;

	public string CharacterClassName {
		get{return characterClassName;}
		set{characterClassName = value;}
	}
	public string CharacterBio {
		get{return characterBio;}
		set{characterBio = value;}
	}
	public string CharacterClassDescription {
		get{return characterClassDescritpion;}
		set{characterClassDescritpion = value;}
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
