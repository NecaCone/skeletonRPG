using Assets.Scripts.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    private static int[] levelPointsToAllocate = new int[7];
    private static int[] baseLevelPoints = new int[7];
    private static string nameClass;
    private static string name;
    private static string level;
    private static string points;
    private static string gold;
    private static string currentXP;
    private static string requiredXP;


    public static bool commitedPoints;
    public static bool baseStats;

    #region stat
    private Text staminaText;
    private Text enduranceText;
    private Text strenghtText;
    private Text agilityText;
    private Text intelectText;
    private Text resistanceText;
    private Text mResistanceText;
    #endregion
    #region base
    private Text classText;
    private Text levelText;
    private Text pointsText;
    private Text nameText;
    private Text experienceText;
    private Text goldText;
    #endregion

    #region buttons
    private Button staminaPositiveBTN;
    private Button staminaNegativeBTN;

    private Button endurancePositiveBTN;
    private Button enduranceNegativeBTN;

    private Button strenghtPositiveBTN;
    private Button strenghtNegativeBTN;

    private Button agilityPositiveBTN;
    private Button agilityNegativeBTN;

    private Button intelectPositiveBTN;
    private Button intelectNegativeBTN;

    private Button resistancePositiveBTN;
    private Button resistanceNegativeBTN;

    private Button mResistancePositiveBTN;
    private Button mResistanceNegativeBTN;

    private Button CommitBTN;
    #endregion
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void PopulatePanel()
    {
        if (commitedPoints == true)
        {
            CommitedPoints();
            commitedPoints = false;
        }
        if (baseStats == true)
        {
            GetBaseData();
            baseStats = false;
        }
        PrintBaseData();
        GetStatData();

        GetStatButtons();

        SetStaminaBtn();
        SetEnduranceBtn();
        SetStrenghtBtn();
        SetAgilityBtn();
        SetIntelectBtn();
        SetResistanceBtn();
        SetMagicResistanceBtn();
        SetCommitBtn();
    }
    public void PrintBaseData()
    {
        classText = GameObject.FindGameObjectWithTag("ClassText").GetComponent<Text>();
        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        pointsText = GameObject.FindGameObjectWithTag("PointsText").GetComponent<Text>();
        nameText = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<Text>();
        experienceText = GameObject.FindGameObjectWithTag("PlayerExperience").GetComponent<Text>();
        goldText = GameObject.FindGameObjectWithTag("PlayerGold").GetComponent<Text>();

        classText.text = nameClass;
        pointsText.text = Points.LevelPoints.ToString();
        levelText.text = level;
        nameText.text = name;
        experienceText.text =currentXP + " / " + requiredXP;
        goldText.text = gold;
    }
    public void GetBaseData()
    {
        nameClass = GameInformation.PlayerClass.CharacterClassName;
        level = GameInformation.PlayerLevel.ToString();
        name = GameInformation.PlayerName;
        currentXP = GameInformation.CurrentXP.ToString();
        requiredXP =  GameInformation.RequiredXP.ToString();
        gold = GameInformation.Gold.ToString();
    }

    public void GetStatData()
    {
        staminaText = GameObject.FindGameObjectWithTag("PlayerStamina").GetComponent<Text>();
        enduranceText = GameObject.FindGameObjectWithTag("PlayerEndurance").GetComponent<Text>();
        agilityText = GameObject.FindGameObjectWithTag("PlayerAgility").GetComponent<Text>();
        strenghtText = GameObject.FindGameObjectWithTag("PlayerStrenght").GetComponent<Text>();
        intelectText = GameObject.FindGameObjectWithTag("PlayerIntelect").GetComponent<Text>();
        resistanceText = GameObject.FindGameObjectWithTag("PlayerResistance").GetComponent<Text>();
        mResistanceText = GameObject.FindGameObjectWithTag("PlayerMagicResistance").GetComponent<Text>();

        staminaText.text = levelPointsToAllocate[0].ToString();
        enduranceText.text = levelPointsToAllocate[1].ToString();
        strenghtText.text = levelPointsToAllocate[2].ToString();
        agilityText.text = levelPointsToAllocate[3].ToString();
        intelectText.text = levelPointsToAllocate[4].ToString();
        resistanceText.text = levelPointsToAllocate[5].ToString();
        mResistanceText.text = levelPointsToAllocate[6].ToString();
    }

    public void GetStatButtons()
    {
        staminaPositiveBTN = GameObject.FindGameObjectWithTag("StaminaPositiveBTN").GetComponent<Button>();
        staminaNegativeBTN = GameObject.FindGameObjectWithTag("StaminaNegativeBTN").GetComponent<Button>();

        endurancePositiveBTN = GameObject.FindGameObjectWithTag("EndurancePositiveBTN").GetComponent<Button>();
        enduranceNegativeBTN = GameObject.FindGameObjectWithTag("EnduranceNegativeBTN").GetComponent<Button>();

        agilityPositiveBTN = GameObject.FindGameObjectWithTag("AgilityPositiveBTN").GetComponent<Button>();
        agilityNegativeBTN = GameObject.FindGameObjectWithTag("AgilityNegativeBTN").GetComponent<Button>();

        strenghtPositiveBTN = GameObject.FindGameObjectWithTag("StrenghtPositiveBTN").GetComponent<Button>();
        strenghtNegativeBTN = GameObject.FindGameObjectWithTag("StrenghtNegativeBTN").GetComponent<Button>();

        intelectPositiveBTN = GameObject.FindGameObjectWithTag("IntelectPositiveBTN").GetComponent<Button>();
        intelectNegativeBTN = GameObject.FindGameObjectWithTag("IntelectNegativeBTN").GetComponent<Button>();

        resistancePositiveBTN = GameObject.FindGameObjectWithTag("ResistancePositiveBTN").GetComponent<Button>();
        resistanceNegativeBTN = GameObject.FindGameObjectWithTag("ResistanceNegativeBTN").GetComponent<Button>();

        mResistancePositiveBTN = GameObject.FindGameObjectWithTag("MagicResPositiveBTN").GetComponent<Button>();
        mResistanceNegativeBTN = GameObject.FindGameObjectWithTag("MagicResNegativeBTN").GetComponent<Button>();

        CommitBTN = GameObject.FindGameObjectWithTag("CommitBtn").GetComponent<Button>();
    }

    private void CommitedPoints()
    {
        levelPointsToAllocate[0] = GameInformation.Stamina;
        baseLevelPoints[0] = GameInformation.Stamina;
        levelPointsToAllocate[1] = GameInformation.Endurance;
        baseLevelPoints[1] = GameInformation.Endurance;
        levelPointsToAllocate[2] = GameInformation.Strenght;
        baseLevelPoints[2] = GameInformation.Strenght;
        levelPointsToAllocate[3] = GameInformation.Agility;
        baseLevelPoints[3] = GameInformation.Agility;
        levelPointsToAllocate[4] = GameInformation.Intelect;
        baseLevelPoints[4] = GameInformation.Intelect;
        levelPointsToAllocate[5] = GameInformation.Resistance;
        baseLevelPoints[5] = GameInformation.Resistance;
        levelPointsToAllocate[6] = GameInformation.MagicResistance;
        baseLevelPoints[6] = GameInformation.MagicResistance;
    }
    //postavljanje dugmica
    private void SetStaminaBtn()
    {
        if ((levelPointsToAllocate[0] >= baseLevelPoints[0]) && Points.LevelPoints > 0)
        {
            staminaPositiveBTN.interactable = true;
        }
        else
        {
            staminaPositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[0] > baseLevelPoints[0])
        {
            staminaNegativeBTN.interactable = true;
        }
        else
        {
            staminaNegativeBTN.interactable = false;
        }
    }
    private void SetEnduranceBtn()
    {
        if ((levelPointsToAllocate[1] >= baseLevelPoints[1]) && Points.LevelPoints > 0)
        {
            endurancePositiveBTN.interactable = true;
        }
        else
        {
            endurancePositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[1] > baseLevelPoints[1])
        {
            enduranceNegativeBTN.interactable = true;
        }
        else
        {
            enduranceNegativeBTN.interactable = false;
        }
    }
    private void SetStrenghtBtn()
    {
        if ((levelPointsToAllocate[2] >= baseLevelPoints[2]) && Points.LevelPoints > 0)
        {
            strenghtPositiveBTN.interactable = true;
        }
        else
        {
            strenghtPositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[2] > baseLevelPoints[2])
        {
            strenghtNegativeBTN.interactable = true;
        }
        else
        {
            strenghtNegativeBTN.interactable = false;
        }
    }
    private void SetAgilityBtn()
    {
        if ((levelPointsToAllocate[3] >= baseLevelPoints[3]) && Points.LevelPoints > 0)
        {
            agilityPositiveBTN.interactable = true;
        }
        else
        {
            agilityPositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[3] > baseLevelPoints[3])
        {
            agilityNegativeBTN.interactable = true;
        }
        else
        {
            agilityNegativeBTN.interactable = false;
        }
    }
    private void SetIntelectBtn()
    {
        if ((levelPointsToAllocate[4] >= baseLevelPoints[4]) && Points.LevelPoints > 0)
        {
            intelectPositiveBTN.interactable = true;
        }
        else
        {
            intelectPositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[4] > baseLevelPoints[4])
        {
            intelectNegativeBTN.interactable = true;
        }
        else
        {
            intelectNegativeBTN.interactable = false;
        }
    }
    private void SetResistanceBtn()
    {
        if ((levelPointsToAllocate[5] >= baseLevelPoints[5]) && Points.LevelPoints > 0)
        {
            resistancePositiveBTN.interactable = true;
        }
        else
        {
            resistancePositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[5] > baseLevelPoints[5])
        {
            resistanceNegativeBTN.interactable = true;
        }
        else
        {
            resistanceNegativeBTN.interactable = false;
        }
    }
    private void SetMagicResistanceBtn()
    {
        if ((levelPointsToAllocate[6] >= baseLevelPoints[6]) && Points.LevelPoints > 0)
        {
            mResistancePositiveBTN.interactable = true;
        }
        else
        {
            mResistancePositiveBTN.interactable = false;
        }
        // ispitujem dal moze da se oduzme il ne 
        if (levelPointsToAllocate[6] > baseLevelPoints[6])
        {
            mResistanceNegativeBTN.interactable = true;
        }
        else
        {
            mResistanceNegativeBTN.interactable = false;
        }
    }
    private void SetCommitBtn()
    {
        if ((levelPointsToAllocate[0] > baseLevelPoints[0]) || (levelPointsToAllocate[1] > baseLevelPoints[1]) || (levelPointsToAllocate[2] > baseLevelPoints[2]) || (levelPointsToAllocate[3] > baseLevelPoints[3]) || (levelPointsToAllocate[4] > baseLevelPoints[4]) || (levelPointsToAllocate[5] > baseLevelPoints[5]) || (levelPointsToAllocate[6] > baseLevelPoints[6]))
        {
            CommitBTN.interactable = true;
        }
        else
        {
            CommitBTN.interactable = false;
        }
    }
    // funkcije dugmica
    public void AddStamina()
    {
        levelPointsToAllocate[0] = levelPointsToAllocate[0] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseStamina()
    {
        levelPointsToAllocate[0] = levelPointsToAllocate[0] - 1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void AddEndurance()
    {
        levelPointsToAllocate[1] = levelPointsToAllocate[1] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseEndurance()
    {
        levelPointsToAllocate[1] = levelPointsToAllocate[1] -1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void AddStrenght()
    {
        levelPointsToAllocate[2] = levelPointsToAllocate[2] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseStrenght()
    {
        levelPointsToAllocate[2] = levelPointsToAllocate[2] - 1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void AddAgility()
    {
        levelPointsToAllocate[3] = levelPointsToAllocate[3] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseAgility()
    {
        levelPointsToAllocate[3] = levelPointsToAllocate[3] - 1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void AddIntelect()
    {
        levelPointsToAllocate[4] = levelPointsToAllocate[4] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseIntelect()
    {
        levelPointsToAllocate[4] = levelPointsToAllocate[4] - 1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void AddResistance()
    {
        levelPointsToAllocate[5] = levelPointsToAllocate[5] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseResistance()
    {
        levelPointsToAllocate[5] = levelPointsToAllocate[5] - 1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void AddMagicResistance()
    {
        levelPointsToAllocate[6] = levelPointsToAllocate[6] + 1;
        Points.LevelPoints = Points.LevelPoints - 1;
        PopulatePanel();
    }
    public void DecreaseMagicResistance()
    {
        levelPointsToAllocate[6] = levelPointsToAllocate[6] - 1;
        Points.LevelPoints = Points.LevelPoints + 1;
        PopulatePanel();
    }

    public void Commit()
    {
        GameInformation.Stamina = levelPointsToAllocate[0];
        GameInformation.Endurance = levelPointsToAllocate[1];
        GameInformation.Strenght = levelPointsToAllocate[2];
        GameInformation.Agility = levelPointsToAllocate[3];
        GameInformation.Intelect = levelPointsToAllocate[4];
        GameInformation.Resistance = levelPointsToAllocate[5];
        GameInformation.MagicResistance = levelPointsToAllocate[6];
       
        GameInformation.PlayerName = name;
        GameInformation.PlayerLevel = Convert.ToInt32(level);
        GameInformation.Gold = Convert.ToInt32(gold);
        GameInformation.CurrentXP = Convert.ToInt32(currentXP);
        GameInformation.RequiredXP = Convert.ToInt32(requiredXP);
        GameInformation.AvailableLevelPoints = Points.LevelPoints;

        GameInformation.AvailableLevelPoints = Points.LevelPoints;
        SaveInformation.SaveAllInformation();
        commitedPoints = true;
        Combat.healthCheckedOnce = false;
        Combat.energyCheckOnce = false;
        Combat.manaCheckOnce = false;
        Combat.damageCheckedOnce = false;
        ClickToMove.checkSpeedOnce = false;
        ProjectileStrike.checkRangeDamage = false;
        PopulatePanel();
        
    }
}