﻿using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {


	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

		public static BaseEquipmentItem EquipmentOne{ get; set;}
		
		public static string PlayerName{ get; set; }
		public static int PlayerLevel{ get; set; }
		public static BaseCharacterClass PlayerClass{ get; set; }
		public static int Stamina{ get; set; }
		public static int Endurance{ get; set; }
		public static int Strenght{ get; set; }
		public static int Agility{ get; set; }
		public static int Intelect{ get; set; }
		public static int Resistance{ get; set; }
		public static int MagicResistance{ get; set; }
		public static int Gold{ get; set; }
		public static int RequiredXP{ get; set; }
		public static int CurrentXP{ get; set; }
        public static int AvailableLevelPoints { get; set; }


}