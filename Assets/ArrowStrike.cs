using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStrike : MonoBehaviour {

    GameObject Player;
    Combat enemy;
    private int speedOfArrow = 18;
    private int damage=20;

    private int countDown=10;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy = Player.GetComponent<Combat>();


    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speedOfArrow * Time.deltaTime);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Combat>().GetHitPlayer(damage);
            Destroy(gameObject);
        }
        else
        {
            CancelInvoke("existenceOfProjectile");
            InvokeRepeating("existenceOfProjectile", 0, 1);
        }
    }

    private void existenceOfProjectile()
    {
        countDown = countDown - 1;
        if (countDown == 0)
        {
            CancelInvoke("existenceOfProjectile");
            Destroy(gameObject);
        }
    }
}
