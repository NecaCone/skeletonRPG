using UnityEngine;
using System.Collections;

public class LoadInformation {
	public static void LoadAllInformation()
	{
		GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
		GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
		GameInformation.Stamina = PlayerPrefs.GetInt("STAMINA");
		GameInformation.Endurance = PlayerPrefs.GetInt("ENDURANCE");
		GameInformation.Strenght = PlayerPrefs.GetInt("STRENGHT");
		GameInformation.Intelect = PlayerPrefs.GetInt("INTELECT");
		GameInformation.Agility = PlayerPrefs.GetInt("AGILITY");
		GameInformation.Resistance = PlayerPrefs.GetInt("RESISTANCE");
		GameInformation.MagicResistance = PlayerPrefs.GetInt("MAGICKRESISTANCE");
		GameInformation.Gold = PlayerPrefs.GetInt("GOLD");
		GameInformation.CurrentXP = PlayerPrefs.GetInt("CURRENTXP");
		GameInformation.RequiredXP = PlayerPrefs.GetInt ("REQUIREDXP");
        GameInformation.AvailableLevelPoints = PlayerPrefs.GetInt("POINTS");

		if (PlayerPrefs.GetString ("EQUIPMENT1") != null) {
			GameInformation.EquipmentOne = (BaseEquipmentItem)PPSerialization.Load("EQUIPMENT1");	
		}

	}
}