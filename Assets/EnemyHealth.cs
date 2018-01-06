using Assets.Scripts.Mob;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public Combat player;
    public GameObject Player;

    public Mob targetMele;
    public RangeMob targetRange;
    public float healthPrecentage;

    public Texture2D frame;
    public Rect framePosition;
    //public float horizontalDistance = ;
    //public float verticalDistance= 0.2f;
     float widthBar= 0.79f;
     float heightBar = 0.46f;

    public Texture2D healthBar;
    public Rect healthBarPosition;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Combat>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.opponent != null)
        {
            if (player.opponent.GetComponent<Mob>() != null)
            {
                targetMele = player.opponent.GetComponent<Mob>();
                healthPrecentage = (float)targetMele.healthMob / (float)targetMele.mobMaxHealth;
            }
            else if(player.opponent.GetComponent<RangeMob>() != null)
            {
                targetRange = player.opponent.GetComponent<RangeMob>();
                healthPrecentage = (float)targetRange.healthMob / (float)targetRange.mobMaxHealth;
            }
        }
        else
        {
            targetMele = null;
            targetRange = null;

            healthPrecentage = 0;
        }
    }

    private void OnMouseOver()
    {
        
    }

    private void OnGUI()
    {
        if ((targetMele != null || targetRange !=null )&& player.countDown > 0)
        {
            DrawFrame();
            DrawBar();
        }
    }

    void DrawFrame()
    {
        framePosition.x = (Screen.width - framePosition.width) / 2;
        framePosition.y = 10;

        float width = 0.183f;
        float height = 0.045f;

        framePosition.height = Screen.height * height;
        framePosition.width = Screen.width * width;
        // dajemo poziciju i dajemo sliku koja se crta po poziciji
        GUI.DrawTexture(framePosition, frame);
    }

    void DrawBar()
    {

        healthBarPosition.x = framePosition.x + framePosition.width * 0.1f;
        healthBarPosition.y = framePosition.y + framePosition.height * 0.22f;

        healthBarPosition.width = framePosition.width * widthBar * healthPrecentage;
        healthBarPosition.height = framePosition.height * heightBar;

        GUI.DrawTexture(healthBarPosition, healthBar); 
    }
}
