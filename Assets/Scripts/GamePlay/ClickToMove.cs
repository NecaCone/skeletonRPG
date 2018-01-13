using UnityEngine;
using System.Collections;
using Assets.Scripts.Fight;
using Assets.Scripts.Items;

public class ClickToMove : MonoBehaviour
{
    private float speed;
    public Vector3 position;
    public static Vector3 currsorPosition;

    private float rangeItemPick = 2f;

    public Inventory inventory;
    public BasePotionItem basePotionItem;
    public GameObject item;
    private GameObject InventoryObject;
    private Transform itemPosition;

    public CharacterController controller;
    public AnimationClip runAnimation;
    public AnimationClip idleAnimation;
    public AnimationClip dieAnimation;

    public static bool attackMode;
    public static bool dieMode;
    public static bool pickingMode;
    public static bool ifIsBusy;

    public static bool checkSpeedOnce;

    // Use this for initialization
    void Start()
    {
        InventoryObject = GameObject.FindGameObjectWithTag("Inventory");
        inventory = InventoryObject.GetComponent<Inventory>();
        position = transform.position; // da se ne krece kad igra pocne da ne ludi ko retard
        checkSpeedOnce = false;
        ifIsBusy = false;
    }

    // Update is called once per frame
    void Update()
    {
        CurrsosLocatePosition();
        if (!ifIsBusy)
        {
            if (!attackMode && !dieMode && !pickingMode)
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
                if (pickingMode)
                {
                    PickUpItem();
                    pickingMode =false;
                }
            }
            if (!checkSpeedOnce)
            {
                CheckSpeed();
                checkSpeedOnce = true;
            }
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

    void PickUpItem()
    {
        itemPosition = item.transform;
        if (InRange())
        {
            basePotionItem = item.GetComponent<Item>().basePotionItem;
            transform.LookAt(item.transform.position);
            inventory.AddItem(basePotionItem);
        }
    }
    bool InRange()
    {
        if (Vector3.Distance(itemPosition.position, transform.position) <= rangeItemPick)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void CheckSpeed()
    {
        speed = 0;
        AgilityModifier.agilitySpeedIncrease();
        speed = AgilityModifier.Speed;
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                