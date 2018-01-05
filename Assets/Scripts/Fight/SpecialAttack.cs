using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {

    GameObject player;
    private GameObject particleEffect;

    private Combat combat;
    private int lossOfEnergy;
    private int lossOfMana;
    private double damageProcentage;
    private int stunedTime;
    private bool inAction;
    private int projectiles;
    private bool opponentBased;
    private KeyCode key;
	// Use this for initialization
	void Start () {
         player = GameObject.FindGameObjectWithTag("Player");
         combat = player.GetComponent<Combat>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1) && !combat.specialAttack)
        {
            
            if (Combat.energy >= lossOfEnergy)
            {
                key = KeyCode.Alpha1;
                StunedAttack();
            }
        }
        if (GameInformation.PlayerClass.CharacterClassName == "Mage")
        {
            
            if (Input.GetKeyDown(KeyCode.Q) && !combat.specialAttack)
            {
                if (Combat.mana >= lossOfMana)
                {
                    key = KeyCode.Q;
                    MagickAttackFire();
                }
            }
        }
        if (inAction)
        {
            if (combat.Attack(stunedTime, damageProcentage,key,particleEffect,projectiles, opponentBased, lossOfEnergy,lossOfMana))
            {

            }
            else
            {
                inAction = false;
                Combat.disturbedDamage = false;
            }
        }

       
    }

    void StunedAttack()
    {
        combat.ResetAttackFunction();
        combat.specialAttack = true;
        damageProcentage = 1.3;
        lossOfMana = 0;
        lossOfEnergy = 20;
        particleEffect = null;
        projectiles = 0;
        stunedTime = 5;
        inAction = true;
        opponentBased = true;
    }
    void MagickAttackFire()
    {
        combat.ResetAttackFunction();
        combat.specialAttack = true;
        lossOfMana = 30;
        lossOfEnergy = 0;
        damageProcentage = 0;
        particleEffect = Resources.Load("Explosion07") as GameObject;
        projectiles = 1;
        inAction = true;
        opponentBased = false;
    }
}
