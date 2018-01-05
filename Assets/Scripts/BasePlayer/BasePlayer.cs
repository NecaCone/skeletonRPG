using UnityEngine;
using System.Collections;
using Assets.Scripts.GameControler;

public class BasePlayer : MonoBehaviour
{    
        private string playerName;
        private int playerLevel;
        private BaseCharacterClass playerClass;

	    private int stamina;
	    private int endurance;
	    private int strenght;
	    private int intelect;
	    private int agility;
	    private int resistance;
	    private int magicResistance;
	    private int gold;

	    private string characterBio;

	    private int pointsToAllocate;

	    private int currentXP;
	    private int requiredXP;

        private float playerPosX;
        private float playerPosY;
        private float playerPosZ;

    public string CharacterBio
	{
		get{return characterBio;}
		set{ characterBio = value;}
	}

	public int PointsToAllocate {
		get{return pointsToAllocate;}
		set{pointsToAllocate = value;}
	}

	public string PlayerName {
		get{return playerName;}
		set{playerName = value;}
	}

	public int PlayerLevel {
		get{return playerLevel;}
		set{playerLevel = value;}
	}
	public BaseCharacterClass PlayerClass {
		get{return playerClass;}
		set{playerClass = value;}
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
	public int Gold {
		get{return gold;}
		set{gold = value;}
	}
	public int CurrentXP {
		get{return currentXP;}
		set{currentXP = value;}
	}
	public int RequiredXP {
		get{return requiredXP;}
		set{requiredXP = value;}
	}

    public float PlayerPosX
    {
        get { return playerPosX; }
        set{playerPosX = value;}
    }

    public float PlayerPosY
    {
        get{ return playerPosY;}
        set {playerPosY = value; }
    }

    public float PlayerPosZ
    {
        get{ return playerPosZ; }
        set{ playerPosZ = value; }
    }
}

