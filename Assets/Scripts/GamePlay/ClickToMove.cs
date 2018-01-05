using UnityEngine;
using System.Collections;
using Assets.Scripts.Fight;

public class ClickToMove : MonoBehaviour
{
    private float speed;
    public Vector3 position;
    public static Vector3 currsorPosition;

    public CharacterController controller;
    public AnimationClip runAnimation;
    public AnimationClip idleAnimation;
    public AnimationClip dieAnimation;

    public static bool attackMode;
    public static bool dieMode;

    public static bool checkSpeedOnce;

    // Use this for initialization
    void Start()
    {
        position = transform.position; // da se ne krece kad igra pocne da ne ludi ko retard
        checkSpeedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        CurrsosLocatePosition();

        if (!attackMode&&!dieMode)
        {
            if (Input.GetMouseButton(0))
            {
                //Lociraj gde je igrac kliknuo na ekranu 
                LocatePosition();
            }
            //Pomeri igraca gde je kliknuto		
            MoveToPosition();
        }
        else
        {
        }
        if (!checkSpeedOnce)
        {
            CheckSpeed();
            checkSpeedOnce = true;
        }
        Debug.Log(speed);
    }

    void LocatePosition()
    {
        //dozvoljava da uzmemo informacije iz Ray
        RaycastHit hit;
        //Ray je 3d prostor i mozemo da uzmemo poziciju koja se sece sa tim linijama x.y,z
        //U ovom slicaju Rac ce poceti od pozicije gde nam se nalazi kamera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.RayCast kazemo da Phisics class napravi ray od Raycast
        //kazemo trenutni ray na koji se nalazimo, i hit mesto gde je kliknuto su u 1000units rastojanja
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player"&&hit.collider.tag!="Enemy")
            { // ako nije kliknuo na sebe onda mu dodajem poziciju
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }
    void CurrsosLocatePosition()
    {
        //dozvoljava da uzmemo informacije iz Ray
        RaycastHit hit;
        //Ray je 3d prostor i mozemo da uzmemo poziciju koja se sece sa tim linijama x.y,z
        //U ovom slicaju Rac ce poceti od pozicije gde nam se nalazi kamera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.RayCast kazemo da Phisics class napravi ray od Raycast
        //kazemo trenutni ray na koji se nalazimo, i hit mesto gde je kliknuto su u 1000units rastojanja
        if (Physics.Raycast(ray, out hit, 1000))
        {
            currsorPosition = hit.point;
        }

    }

    void MoveToPosition()
    {
        // ako je distanca izmadju nas i pozicije gde hocemo da idemo veca od 1 onda idemo tamo
        //Game object is moveing
        if (Vector3.Distance(transform.position, position) > 2)
        {
            //dohvaramo ugao za koji treba da se rotira
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);
            newRotation.x = 0f; //zabranim da se rotira po x osi
            newRotation.z = 0f; // po z osi
                                //rotiramo ga u nofi ugao 
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * speed);
            GetComponent<Animation>().CrossFade(runAnimation.name);
        }
        //Game object is not moveing
        else
        {
            GetComponent<Animation>().Play(idleAnimation.name);
        }
    }

    void CheckSpeed()
    {
        speed = 0;
        AgilityModifier.agilitySpeedIncrease();
        speed = AgilityModifier.Speed;
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                