using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    GameObject Player;

    private Combat opponent;
    public Transform playerPosition;
    public CharacterController mobControler;


    public AnimationClip mobAttack;
    public AnimationClip mobRun;
    public AnimationClip mobIdle;
    public AnimationClip mobDie;

    public float speed;
    public float range;
    public float rangeForChase;
    public int damage = 20;

    private bool impacted;
    private bool gotHited;

    public double impactTime = 0.3;

    public int mobMaxHealth = 50;
    public int healthMob;

    private double fullAttackAnimationLength;
    private double impactLength;

    private int stunedTime;

    private void Start()
    {
        gotHited = true;
        impactLength = GetComponent<Animation>()[mobAttack.name].length * impactTime;
        fullAttackAnimationLength = 0.9 * GetComponent<Animation>()[mobAttack.name].length;
        healthMob = mobMaxHealth;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = Player.transform;
        opponent = Player.GetComponent<Combat>();
    }

    private void Update()
    {
        //pitamo dal je mob mrtav ako nije mozemo sa operacijama
        if (!IsDead())
        {
            //dal je mob slogiran ako nije  nastavljam sa operacijama
            if (stunedTime <= 0)
            {
                //dal je igrac u odredjenom radiusu sa mobom da bi mob krenuo da ga juri
                if (!InRangeForChase())
                {
                    // ako jeste mob ga juri dok mu ne pridje dovoljno
                    if (!InRange())
                    {
                        Chase();
                    }
                    // ako je u dometu mob ga napada
                    else
                    {
                        // GetComponent<Animation>().Play(mobIdle.name);
                        GetComponent<Animation>().Play(mobAttack.name);
                        Attack();
                        if (GetComponent<Animation>()[mobAttack.name].time > fullAttackAnimationLength)
                        {
                            impacted = false;
                        }
                    }
                }
                //u slucaju da nije dovoljno blizu  za jurenje mob kulira
                else
                {
                    GetComponent<Animation>().Play(mobIdle.name);
                }
                // ako je pogodjen ili udaren sa distance da krene da juri
                if (!gotHited)
                {
                    // ako jeste mob ga juri dok mu ne pridje dovoljno
                    if (!InRange())
                    {
                        Chase();
                    }
                    // ako je u dometu mob ga napada
                    else
                    {
                        // GetComponent<Animation>().Play(mobIdle.name);
                        GetComponent<Animation>().Play(mobAttack.name);
                        Attack();
                        if (GetComponent<Animation>()[mobAttack.name].time > fullAttackAnimationLength)
                        {
                            impacted = false;
                        }
                    }
                }
            }
            else
            {


            }
            

        

        }
        else
        {
            DeathMob();
        }
    }

    //dohvata objekat moba 
    void OnMouseOver()
    {
        Player.GetComponent<Combat>().opponent = gameObject;
        Debug.Log("Mis je preko skeletora");
    }

    //ispituje dal je  player  u dometu za jurenje
    private bool InRangeForChase()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) > rangeForChase)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private bool InRange()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

     // metod koji se poziva da krene da juri player prvo se okrece ka njemu zatim krece se
     // i poziva animaciju za trcanje
    private void Chase()
    {
        transform.LookAt(playerPosition.position);
        mobControler.SimpleMove(transform.forward * speed);
        GetComponent<Animation>().CrossFade(mobRun.name);
    }


    void Attack()
    {
        if (GetComponent<Animation>()[mobAttack.name].time > impactLength && !impacted && GetComponent<Animation>()[mobAttack.name].time < fullAttackAnimationLength)
        {
            opponent.GetHitPlayer(damage);
            impacted = true;
        }
    }

    public void GetHit(int damage)
    {
        gotHited = false;
        healthMob = healthMob - damage;
        if (healthMob < 0)
        {
            healthMob = 0;
        }
    }


    public void GetStuned(int seconds)
    {
        CancelInvoke("StunedCountDown");
        stunedTime = seconds;
        InvokeRepeating("StunedCountDown", 0f,1f);
    }

    void StunedCountDown()
    {
        stunedTime = stunedTime - 1;
        if (stunedTime <= 0)
        {
            CancelInvoke("StunedCountDown");
        }
    }

     bool IsDead()
    {
        if (healthMob <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DeathMob()
    {
        GetComponent<Animation>().CrossFade(mobDie.name);
        if (GetComponent<Animation>()[mobDie.name].time > GetComponent<Animation>()[mobDie.name].length * 0.9)
        {
            IncreaseExperience.AddDefeatedEnemyExperience(350);
            Destroy(gameObject);
        }

    }

}
