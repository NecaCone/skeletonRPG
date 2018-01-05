using Assets.Scripts.Fight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {

    public float energyPrecentage;

    private GameObject Player;
    private Combat player;

    public Texture2D playerEnergyFrame;
    public Rect playerEnergyFramePosition;

    public Texture2D playerEnergyBar;
    public Rect playerEnergyBarPosition;

    float widthPlayerBar = 0.739f;
    float heightPlayerBar = 0.07f;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Combat>();
    }
	
	// Update is called once per frame
	void Update () {

        energyPrecentage = (float)Combat.energy / (float)EnergyModifier.maxEnergy;

    }
    private void OnGUI()
    {
        if (GameInformation.PlayerClass.CharacterClassName != "Mage")
        {
            DrawEnergyFrame();
            DrawEnergyBar();
        }
    }

    void DrawEnergyFrame()
    {
        playerEnergyFramePosition.x = (Screen.width - playerEnergyFramePosition.width)* 0.9f;
        playerEnergyFramePosition.y = (Screen.height - playerEnergyFramePosition.height) * 0.95f;

        float width = 0.183f;
        float height = 0.18f;

        playerEnergyFramePosition.height = Screen.height * height;
        playerEnergyFramePosition.width = Screen.width * width;
        // dajemo poziciju i dajemo sliku koja se crta po poziciji
        GUI.DrawTexture(playerEnergyFramePosition, playerEnergyFrame);
    }

    void DrawEnergyBar()
    {

        playerEnergyBarPosition.x = playerEnergyFramePosition.x + playerEnergyFramePosition.width * 0.12f;
        playerEnergyBarPosition.y = playerEnergyFramePosition.y + playerEnergyFramePosition.height * 0.439f;

        playerEnergyBarPosition.width = playerEnergyFramePosition.width * widthPlayerBar * energyPrecentage;
        playerEnergyBarPosition.height = playerEnergyFramePosition.height * heightPlayerBar;

        GUI.DrawTexture(playerEnergyBarPosition, playerEnergyBar);
    }

}
