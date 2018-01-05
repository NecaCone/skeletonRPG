using Assets.Scripts.Fight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    private float manaPrecentage;

    private GameObject Player;
    private Combat player;

    public Texture2D playerManaFrame;
    public Rect playerManaFramePosition;

    public Texture2D playerManaBar;
    public Rect playerManaBarPosition;

    float widthPlayerBar = 0.739f;
    float heightPlayerBar = 0.07f;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        manaPrecentage = (float)Combat.mana / (float)ManaModifier.maxMana;

    }
    private void OnGUI()
    {
        if (GameInformation.PlayerClass.CharacterClassName == "Mage")
        {
            DrawManaFrame();
            DrawManaBar();
        }
    }

    void DrawManaFrame()
    {
        playerManaFramePosition.x = (Screen.width - playerManaFramePosition.width) * 0.9f;
        playerManaFramePosition.y = (Screen.height - playerManaFramePosition.height) * 0.95f;

        float width = 0.183f;
        float height = 0.18f;

        playerManaFramePosition.height = Screen.height * height;
        playerManaFramePosition.width = Screen.width * width;
        // dajemo poziciju i dajemo sliku koja se crta po poziciji
        GUI.DrawTexture(playerManaFramePosition, playerManaFrame);
    }

    void DrawManaBar()
    {

        playerManaBarPosition.x = playerManaFramePosition.x + playerManaFramePosition.width * 0.12f;
        playerManaBarPosition.y = playerManaFramePosition.y + playerManaFramePosition.height * 0.439f;

        playerManaBarPosition.width = playerManaFramePosition.width * widthPlayerBar * manaPrecentage;
        playerManaBarPosition.height = playerManaFramePosition.height * heightPlayerBar;

        GUI.DrawTexture(playerManaBarPosition, playerManaBar);
    }
}
