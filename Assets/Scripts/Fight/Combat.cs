using Assets.Scripts.Fight;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    public GameObject opponent;
    public AnimationClip attackAnimation;
    public AnimationClip dieAnimaton;
    private Transform opponentPosition;

    public static bool healthCheckedOnce;
    public static bool energyCheckOnce;
    public static bool manaCheckOnce;
    public static bool damageCheckedOnce;
    public static bool resistanceCheckedOnce;
    public static bool disturbedDamage;

    public double impactTime = 0.34;
    public double impactLength;
    public double fullLengthOfAttackAnimation;
    public bool impacted;
    

    public int health;
    public static int energy;
    public static int mana;
    private int damage;
    private int arrmor;

    public static int normalDamage;
    public float range;

    private bool startedDie;
    private bool endedDie;


    private float combatEscapeTime=7;
    public float countDown;

    public bool specialAttack;
    public bool inAction;

    // Use this for initialization
    void Start ()
    {
        //duzina udarca
        impactLength = GetComponent<Animation>()[attackAnimation.name].length * impactTime;
        //duzina udarca 90%
        fullLengthOfAttackAnimation = 0.9 * GetComponent<Animation>()[attackAnimation.name].length;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A) && !specialAttack)
        {
            inAction = true;
        }
        if (!specialAttack)
        {
            if (inAction)
            {
                if (Attack(0, 1, KeyCode.A,null,0,true,0,0))
                {

                }
                else
                {
                    inAction = false;
                    
                }
            }
        }
        if (!healthCheckedOnce)
        {
            HealthCheck();
            healthCheckedOnce = true;
        }
        if (!disturbedDamage)
        {
            damage = normalDamage;
            disturbedDamage = true;
        }
        if (!damageCheckedOnce)
        {
            DamageCheck();
            damageCheckedOnce = true;
        }
        if (!resistanceCheckedOnce)
        {
            ResistanceChecked();
            resistanceCheckedOnce = true;
        }
        if (!energyCheckOnce)
        {
            EnergyChecked();
            energyCheckOnce = true;
        }
        if (!manaCheckOnce)
        {
            ManaChecked();
            manaCheckOnce = true;
        }
        Debug.Log(damage);
        Die();

    }

    public bool Attack(int seconds, double scaleDamage, KeyCode key, GameObject particleEffect,int numOfProjectiles,bool opponentBased, int lossOfEnergy,int lossOfMana)
    {
        if (opponentBased)
        {
            if (opponent != null)
            {
                opponentPosition = opponent.transform;
                if (Input.GetKey(key) && InRange())
                {
                    transform.LookAt(opponent.transform.position);
                    ClickToMove.attackMode = true;

                    GetComponent<Animation>().Play(attackAnimation.name);


                    countDown = combatEscapeTime;
                    CancelInvoke("combatEscapeCountDown");
                    InvokeRepeating("combatEscapeCountDown", 0, 1);
                }
            }
        }
        else
        {
            if (Input.GetKey(key))
                {
                    transform.LookAt(ClickToMove.currsorPosition);
                    ClickToMove.attackMode = true;

                    GetComponent<Animation>().Play(attackAnimation.name);


                    countDown = combatEscapeTime;
                    CancelInvoke("combatEscapeCountDown");
                    InvokeRepeating("combatEscapeCountDown", 0, 1);
                }
        }
        if (GetComponent<Animation>()[attackAnimation.name].time > fullLengthOfAttackAnimation)
        {
            ClickToMove.attackMode = false;
            impacted = false;
            if (specialAttack)
            {
                specialAttack = false;
            }
            return false;
        }
        Impact(seconds, scaleDamage,particleEffect,numOfProjectiles,opponentBased,lossOfEnergy,lossOfMana);
        return true;

    }

    public void ResetAttackFunction()
    {
        ClickToMove.attackMode = false;
        impacted = false;
        GetComponent<Animation>().Stop(attackAnimation.name);
    }


    void Impact(int seconds, double scaleDamage,GameObject particleEffect,int numOfProjectiles,bool opponentBased,int lossOfEnergy,int lossOfMana)
    {
        //&& (GetComponent<Animation>()[attackAnimation.name].time > 0.9 * GetComponent<Animation>()[attackAnimation.name].length)
        if ((!opponentBased || opponent != null) && GetComponent<Animation>().IsPlaying(attackAnimation.name)&&impacted==false)
        {
            if ((GetComponent<Animation>()[attackAnimation.name].time) > impactLength)
            {

                double someDamage = scaleDamage * damage;
                damage = Convert.ToInt32(Math.Floor(someDamage * 1));
                energy = energy - lossOfEnergy;
                mana = mana - lossOfMana;

                    opponent.GetComponent<Mob>().GetHit(damage);

                if (seconds > 0)
                {
                    opponent.GetComponent<Mob>().GetStuned(seconds);
                }
                // da bi prikazali eksloziju ka telo protivnika  gde prikazujemo eksploziju
                //ovde pustamo effecat napada
                //ovde cemo da saljemo sferu
               
                if (numOfProjectiles > 0)
                {
                    Quaternion rot = transform.rotation;
                    rot.x = 0f;
                    rot.z = 0f;
                    // pravimo projektile strele vatrene lopte ledene lopte itd
                    Instantiate(Resources.Load("Projectile"),new Vector3(transform.position.x,transform.position.y+1.5f, transform.position.z) , rot);
                }
                if (particleEffect != null && numOfProjectiles == 0)
                {
                    //Instantiate(Resources.Load("Explosion07"), new Vector3(opponent.transform.position.x, opponent.transform.position.y + 1.5f, opponent.transform.position.z), Quaternion.identity);
                    Instantiate(particleEffect, new Vector3(opponent.transform.position.x, opponent.transform.position.y + 1.5f, opponent.transform.position.z), Quaternion.identity);
                }
                impacted = true;
            }
        }
    }
    bool InRange()
    {
        if (Vector3.Distance(opponentPosition.position, transform.position) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GetHitPlayer(int damage)
    {
        int damageWithArrmor = damage - arrmor;
        health = health - damageWithArrmor;
        if(health<=0)
        {
            health = 0;
        }
    }
    bool IsDead()
    {
        if (health == 0)
        {
            return true;
        }
        return false;
    }
    void Die()
    {
        if (IsDead())
        {
            if (!startedDie)
            {
                ClickToMove.dieMode = true;
                GetComponent<Animation>().Play(dieAnimaton.name);
                startedDie = true;
            }
            if (startedDie && GetComponent<Animation>().IsPlaying(dieAnimaton.name))
            {
                Debug.Log("Crko");
                endedDie = true;
            }
        }
    }

    
    private void HealthCheck()
    {
        health = 0;
        HealthModifier.healthStaminalIncrease();
        health = HealthModifier.maxHealth;
    }
    private void ManaChecked()
    {
        mana = 0;
        ManaModifier.manaIntelectlIncrease();
        mana = ManaModifier.maxMana;
    }
    private void EnergyChecked()
    {
        energy = 0;
        EnergyModifier.healthStaminalIncrease();
        energy = EnergyModifier.maxEnergy;
    }
    private void ResistanceChecked()
    {
        arrmor = 0;
        ResistanceModifier.resistanceArrmorModifier();
        arrmor = ResistanceModifier.Resistance;
    }

    private void DamageCheck()
    {
        normalDamage = 0;
        DamageModifier.DamageClassStat();
        string className = GameInformation.PlayerClass.CharacterClassName;
        switch (className)
        {
            case "Mage":
                normalDamage = DamageModifier.damageModifierMage;
                damage = normalDamage;
                break;
            case "Warrior":
                normalDamage = DamageModifier.damageModifier;
                damage = normalDamage;
                break;
            case "Spearman":
                normalDamage = DamageModifier.damageModifier;
                damage = normalDamage;
                break;
        }
    }

    public void combatEscapeCountDown()
    {
        countDown = countDown - 1;
        if (countDown == 0)
        {
            CancelInvoke("combatEscapeCountDown");
        }
    }

}
