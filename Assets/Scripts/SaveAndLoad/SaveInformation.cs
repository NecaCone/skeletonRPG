using UnityEngine;
using System.Collections;

public class SaveInformation{
 
	public static void SaveAllInformation(){
		PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
		PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
		PlayerPrefs.SetInt("STAMINA", GameInformation.Stamina);
		PlayerPrefs.SetInt("ENDURANCE", GameInformation.Endurance);
		PlayerPrefs.SetInt("STRENGHT", GameInformation.Strenght);
		PlayerPrefs.SetInt("INTELECT", GameInformation.Intelect);
		PlayerPrefs.SetInt("AGILITY", GameInformation.Agility);
		PlayerPrefs.SetInt("RESISTANCE", GameInformation.Resistance);
		PlayerPrefs.SetInt("MAGICKRESISTANCE", GameInformation.MagicResistance);
		PlayerPrefs.SetInt("GOLD", GameInformation.Gold);
		PlayerPrefs.SetInt ("CURRENTXP", GameInformation.CurrentXP);
		PlayerPrefs.SetInt ("REQUIREDXP", GameInformation.RequiredXP);
        PlayerPrefs.SetInt("POINTS", GameInformation.AvailableLevelPoints);
        if (GameInformation.EquipmentOne != null) {
						PPSerialization.Save ("EQUIPMENT1", GameInformation.EquipmentOne);
		}
		Debug.Log("Saved all information");

	}
}
