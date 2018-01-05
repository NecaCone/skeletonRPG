using Assets.Scripts.Fight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float healthPrecentage;

    private Combat player;
    private GameObject Player;

    public Texture2D playerFrame;
    public Rect playerFramePosition;

     float widthPlayerBar= 0.73f;
     float heightPlayerBar=0.2f;

    public Texture2D healthPlayerBar;
    public Rect healthPlayerBarPosition;


    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Combat>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        healthPrecentage = (float)player.health/(float)HealthModifier.maxHealth;

    }

    private void OnGUI()
    {
            DrawFrame();
             DrawBar();
    }
    void DrawFrame()
    {
        playerFramePosition.x = (Screen.width - playerFramePosition.width) / 9;
        playerFramePosition.y = (Screen.height - playerFramePosition.height) * 0.95f;

        float width = 0.183f;
        float height = 0.125f;

        playerFramePosition.height = Screen.height * height;
        playerFramePosition.width = Screen.width * width;
        // dajemo poziciju i dajemo sliku koja se crta po poziciji
        GUI.DrawTexture(playerFramePosition, playerFrame);
    }

    void DrawBar()
    {

        healthPlayerBarPosition.x = playerFramePosition.x + playerFramePosition.width * 0.15f;
        healthPlayerBarPosition.y = playerFramePosition.y + playerFramePosition.height * 0.4f;

        healthPlayerBarPosition.width = playerFramePosition.width * widthPlayerBar * healthPrecentage;
        healthPlayerBarPosition.height = playerFramePosition.height * heightPlayerBar;

        GUI.DrawTexture(healthPlayerBarPosition, healthPlayerBar);
    }

}
