using Assets.Scripts.Fight;
using Assets.Scripts.Mob;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStrike : MonoBehaviour {

    private float speedProjectile;
    private int damage;
    public static bool checkRangeDamage;
    public GameObject particleEffect;
    GameObject player;
    private Combat combat;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        combat = player.GetComponent<Combat>();
        speedProjectile = 10;
        if (GameInformation.PlayerClass.CharacterClassName == "Mage")
        {
            checkRangeDamage = false;
        }

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * speedProjectile * Time.deltaTime);
        if (checkRangeDamage == false)
        {
            ProjectileDamage();
            checkRangeDamage = true;
        }
        Debug.Log(damage);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            particleEffect = Resources.Load("Explosion07") as GameObject;
            Instantiate(particleEffect, new Vector3(combat.opponent.transform.position.x, combat.opponent.transform.position.y + 1.5f, combat.opponent.transform.position.z), Quaternion.identity);
            if (other.GetComponent<Mob>() != null)
            {
                other.GetComponent<Mob>().GetHit(damage);
            }
            else if (other.GetComponent<RangeMob>() != null)
            {
                other.GetComponent<RangeMob>().GetHit(damage);
            }

            Destroy(gameObject);
        }
    }

    void ProjectileDamage()
    {
        damage = 0;
        DamageModifier.RangeAttackDamage();
        damage = DamageModifier.damageRangeModifier;
    }
}
