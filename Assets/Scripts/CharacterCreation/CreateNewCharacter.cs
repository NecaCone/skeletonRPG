using UnityEngine;
using System.Collections;

public class CreateNewCharacter : MonoBehaviour {
	private BasePlayer newPlayer;
	private string playerName= "Enter name";
	private bool isMageClass;
	private bool isWarriorClass;
	private bool isSpearClass;

	// Use this for initialization
	void Start () {
		newPlayer = new BasePlayer ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnGUI()
	{
		playerName = GUILayout.TextArea (playerName,12);
		isMageClass = GUILayout.Toggle(isMageClass,"Mage!!!");
		isWarriorClass = GUILayout.Toggle(isWarriorClass,"Warrior!!!");
		isSpearClass = GUILayout.Toggle(isSpearClass,"Spearman!!!");
		if(GUILayout.Button("Create")) 
		{
			if(isMageClass)
			{
				newPlayer.PlayerClass = new BaseMageClass();
			}
			else if(isWarriorClass)
			{
				newPlayer.PlayerClass = new BaseWarriorClass();
			}
			else if(isSpearClass)
			{
				newPlayer.PlayerClass = new BaseSpearClass();
			}

			CreateNewPlayer();
			StoreNewPlayerInfo();
			SaveInformation.SaveAllInformation();


			Debug.Log("Player name: " + newPlayer.PlayerName);
			Debug.Log("Player class: " + newPlayer.PlayerClass.CharacterClassName);
			Debug.Log("Player level: " + newPlayer.PlayerLevel);
			Debug.Log("Player currentXP: " + newPlayer.CurrentXP);
			Debug.Log("Player requiredXP: " + newPlayer.RequiredXP);
			Debug.Log("Player gold: " + newPlayer.Gold);
			Debug.Log("Player stamina: " + newPlayer.Stamina);
			Debug.Log("Player endurance: " + newPlayer.Endurance);
			Debug.Log("Player stremght: " + newPlayer.Strenght);
			Debug.Log("Player agility: " + newPlayer.Agility);
			Debug.Log("Player resistance: " + newPlayer.Resistance);
			Debug.Log("Player magicresistance: " + newPlayer.MagicResistance);
		}

		if (GUILayout.Button ("Load")) {
            LoadInformation.LoadAllInformation();
            Debug.Log("Player name: " + GameInformation.PlayerName);
            Debug.Log("Player class: " + GameInformation.PlayerClass);
            Debug.Log("Player level: " + GameInformation.PlayerLevel);
        }

	}


	private void StoreNewPlayerInfo()
	{
		GameInformation.PlayerName = newPlayer.PlayerName;
		GameInformation.PlayerLevel = newPlayer.PlayerLevel;
		GameInformation.CurrentXP = newPlayer.CurrentXP;
		GameInformation.RequiredXP = newPlayer.RequiredXP;
		GameInformation.PlayerClass = newPlayer.PlayerClass;
		GameInformation.Gold = newPlayer.Gold;
		GameInformation.Stamina = newPlayer.Stamina;
		GameInformation.Endurance = newPlayer.Endurance;
		GameInformation.Strenght = newPlayer.PlayerClass.Strenght;
		GameInformation.Intelect = newPlayer.PlayerClass.Intelect;
		GameInformation.Agility = newPlayer.PlayerClass.Agility;
		GameInformation.Resistance = newPlayer.PlayerClass.Resistance;
		GameInformation.MagicResistance = newPlayer.PlayerClass.MagicResistance;

	}

	private void CreateNewPlayer()
	{
		newPlayer.PlayerLevel = 1;
		newPlayer.Gold = 100;
		newPlayer.CurrentXP=0;
		newPlayer.RequiredXP=100;
		newPlayer.Stamina = newPlayer.PlayerClass.Stamina;
		newPlayer.Endurance = newPlayer.PlayerClass.Endurance;
		newPlayer.Strenght = newPlayer.PlayerClass.Strenght;
		newPlayer.Intelect = newPlayer.PlayerClass.Intelect;
		newPlayer.Agility = newPlayer.PlayerClass.Agility;
		newPlayer.Resistance = newPlayer.PlayerClass.Resistance;
		newPlayer.MagicResistance= newPlayer.PlayerClass.MagicResistance;
		newPlayer.PlayerName = playerName;

	}
}
