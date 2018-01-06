using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Mob
{
    public class RangeMob : MonoBehaviour
    {

        GameObject Player;

        private Combat opponent;
        private Transform playerPosition;
        public CharacterController mobControler;


        public AnimationClip mobAttack;
        public AnimationClip mobRun;
        public AnimationClip mobIdle;
        public AnimationClip mobDie;

        //mob stats
        public float rangeForMelee;
        public float rangeForRangeAttack;
        public float rangeForChase;

        public float speed;
        private int damage = 15;
        private int stunedTime;
        public int mobMaxHealth = 50;
        public int healthMob;
        private int numOfProjectiles;

        //mob checks
        private bool impacted;
        private bool gotHited;

        // moment of impact
        private double impactTime = 0.3;
        
        private double fullAttackAnimationLength;
        private double impactLength;
        
        

        private void Start()
        {
            gotHited = true;
            healthMob = mobMaxHealth;
            impactLength = GetComponent<Animation>()[mobAttack.name].length * impactTime;
            fullAttackAnimationLength = 0.9 * GetComponent<Animation>()[mobAttack.name].length;
            Player = GameObject.FindGameObjectWithTag("Player");
            playerPosition = Player.transform;
            opponent = Player.GetComponent<Combat>();
            Debug.Log("Range skeleton health" + healthMob.ToString());
        }

        private void Update()
        {
            if (!IsDead())
            {
                //dal je mob slogiran ako nije  nastavljam sa operacijama
                if (stunedTime <= 0)
                {
                    //dal je igrac u odredjenom radiusu sa mobom da bi mob krenuo da ga juri
                    if (!InRangeForChase())
                    {
                        if (!InRangeRangeAttack())
                        {
                            
                            // ako jeste mob ga juri dok mu ne pridje dovoljno
                            if (!InRangeMele())
                            {
                                Chase();
                            }
                            // ako je u dometu mob ga napada
                            else
                            {
                                transform.LookAt(playerPosition.position);
                                playerPosition = Player.transform;
                                // GetComponent<Animation>().Play(mobIdle.name);
                                GetComponent<Animation>().Play(mobAttack.name);
                                Attack();
                                if (GetComponent<Animation>()[mobAttack.name].time > fullAttackAnimationLength)
                                {
                                    impacted = false;
                                }
                            }
                        }
                        else
                        {
                            transform.LookAt(playerPosition.position);
                            playerPosition = Player.transform;
                            GetComponent<Animation>().Play(mobAttack.name);
                            NumOfProjectiles();
                            RangeAttack(numOfProjectiles);
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
                        if (!InRangeMele())
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




        void OnMouseOver()
        {
            Player.GetComponent<Combat>().opponent = gameObject;
            Debug.Log("Mis je preko skeletora range");
        }

        // ispituje dal je  player  u dometu za jurenje
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


        private bool InRangeMele()
        {
            if (Vector3.Distance(transform.position, playerPosition.position) < rangeForMelee)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InRangeRangeAttack()
        {
            if (Vector3.Distance(transform.position, playerPosition.position) < rangeForRangeAttack)
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

        void RangeAttack(int numOfProjectiles)
        {
            if (GetComponent<Animation>()[mobAttack.name].time > impactLength && !impacted && GetComponent<Animation>()[mobAttack.name].time < fullAttackAnimationLength)
            {
                    //opponent.GetHitPlayer(damage);
                    impacted = true;
                if (numOfProjectiles > 0)
                {
                    //Quaternion rot = transform.rotation;
                    //rot.x = 0f;
                    //rot.z = 0f;
                    Quaternion newRotation = Quaternion.LookRotation(playerPosition.position - transform.position, Vector3.forward);
                    // pravimo projektile strele vatrene lopte ledene lopte itd
                    if (numOfProjectiles == 0)
                    {
                        Instantiate(Resources.Load("Arrow_Piercing"), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), newRotation);
                    }
                    else
                    {
                        for (int i = 0; i < numOfProjectiles; i++)
                        {
                            Instantiate(Resources.Load("Arrow_Piercing"), new Vector3(transform.position.x + i * 2.3f, transform.position.y + 1.5f, transform.position.z + i * 2.3f), newRotation);
                        }
                    }
                }
            }
        }
        // uzimamo radnom broj projektila koje protivnik baca na igraca
        void NumOfProjectiles()
        {
           numOfProjectiles = UnityEngine.Random.Range(1,3);
        }

        public void GetHit(int damage)
        {
            gotHited = false;
            Debug.Log("Range skeleton recive damage" + damage.ToString());

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
            InvokeRepeating("StunedCountDown", 0f, 1f);
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
}
