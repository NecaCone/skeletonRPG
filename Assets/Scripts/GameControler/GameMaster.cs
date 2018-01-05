using Assets.Scripts.GameControler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    private BasePlayer basePlayer = new BasePlayer();

    //private PlayerStatsData playerStatsData = new PlayerStatsData();
    private Vector3 positionOfPlayer;

    GameObject prefab = null;
    GameObject go = null;
    BasePlayer player = null;

    public const string magePath = "Prefabs/skeletonMage";
    public const string warriorPath = "Prefabs/skeletonDark";
    public const string spearmanPath = "Prefabs/skeletonFresh";
    private string pathToPlayer = string.Empty;

    // Use this for initialization
    void Start () {
    }

    private void Awake()
    {
        basePlayer.PlayerName = GameInformation.PlayerName;
        basePlayer.PlayerLevel = GameInformation.PlayerLevel;
        basePlayer.PlayerClass = GameInformation.PlayerClass;

        basePlayer.Stamina = GameInformation.Stamina;
        basePlayer.Endurance = GameInformation.Endurance;
        basePlayer.Strenght = GameInformation.Strenght;
        basePlayer.Agility = GameInformation.Agility;
        basePlayer.Resistance = GameInformation.Resistance;
        basePlayer.MagicResistance = GameInformation.MagicResistance;

        basePlayer.CurrentXP = GameInformation.CurrentXP;
        basePlayer.RequiredXP = GameInformation.RequiredXP;

        basePlayer.Gold = GameInformation.Gold;
        basePlayer.PointsToAllocate = GameInformation.AvailableLevelPoints;
        basePlayer.PlayerPosX = 4.17f;
        basePlayer.PlayerPosY = 0.1174861f;
        basePlayer.PlayerPosZ = 4.82f;

        //playerStatsData.playerName = GameInformation.PlayerName;
        //playerStatsData.playerClass = GameInformation.PlayerClass.ToString();
        //playerStatsData.playerLevel = GameInformation.PlayerLevel;

        //playerStatsData.currentXP = GameInformation.CurrentXP;
        //playerStatsData.requiredXP = GameInformation.RequiredXP;

        //playerStatsData.stamina = GameInformation.Stamina;
        //playerStatsData.endurance = GameInformation.Endurance;
        //playerStatsData.strenght = GameInformation.Strenght;
        //playerStatsData.agility = GameInformation.Agility;
        //playerStatsData.resistance = GameInformation.Resistance;
        //playerStatsData.magicResistance = GameInformation.MagicResistance;

        //playerStatsData.gold = GameInformation.Gold;

        //playerStatsData.playerPosX = 4.17f;
        //playerStatsData.playerPosY = 0.1174861f;
        //playerStatsData.playerPosZ = 4.82f;


        if (basePlayer.PlayerClass.ToString() == "BaseWarriorClass")
        {
            pathToPlayer = warriorPath;
        }
        if (basePlayer.PlayerClass.ToString() == "BaseMageClass")
        {
            pathToPlayer = magePath;
        }
        if (basePlayer.PlayerClass.ToString() == "BaseSpearmanClass")
        {
            pathToPlayer = spearmanPath;
        }
        positionOfPlayer.x = basePlayer.PlayerPosX;
        positionOfPlayer.y = basePlayer.PlayerPosY;
        positionOfPlayer.z = basePlayer.PlayerPosZ;

        CreatePlayer(basePlayer, pathToPlayer, positionOfPlayer, Quaternion.identity);

    }

    public BasePlayer CreatePlayer(BasePlayer data, string playerPath, Vector3 position, Quaternion rotation) //  ovo je overloaded
    {
        if (playerPath == "")
        {
            playerPath = "Prefabs/skeletonFresh";
        }
            prefab = Resources.Load<GameObject>(playerPath);
            
            go = GameObject.Instantiate(prefab, position, rotation) as GameObject;
            
            player = go.GetComponent<BasePlayer>();
            player = data;
            return player;
    }

}
