using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateNewGameGui : MonoBehaviour {

	public  Transform mage; //dohvaramo polozaj mage
	public  Transform warrior;  //dohvaramo polozaj warrior
	public  Transform spearman; //dohvaramo polozaj spearman
	private  Transform myCamera;  //dohvaramo polozaj myCamera

    public static float CameraTurnSpeed = 9f;

    //public string dataPath = string.Empty;


    public enum CreatePlayerStates{
		CLASSSELECTION, //izaberi clasu
		STATALLOCATION, //raspodeli poene
		FINALSETUP // ime 
	}

	private DisplayNewGameFunctions displayFunctions  = new DisplayNewGameFunctions(); // pravim istancu klase 
	public static CreatePlayerStates currentState; // staticni metod trenutnog stanja da bi mgao da mu pristupim preko drugih scripti i promenim ga

	// Use this for initialization
	void Start () {
		currentState = CreatePlayerStates.CLASSSELECTION; // postavljam trenutno stanje na ClassSelection
		myCamera = transform.Find("Main Camera"); //dohvatam cameru da bi mogao da pristupim njenom trasform
       
    }
	
	// Update is called once per frame
	void Update () {
	//kad gd se promeni stanje (currentState) prelazi se na sledecu funkciju
		switch (currentState) {
		case(CreatePlayerStates.CLASSSELECTION):		
			break;
		case(CreatePlayerStates.STATALLOCATION):		
			break;
		case(CreatePlayerStates.FINALSETUP):		
			break;
		}
		LookClass (); // gleda ka izabranoj klasi
	}
    //void Awake()
    //{
    //    dataPath = System.IO.Path.Combine(Application.dataPath, "NewGame.xml");
    //}

    private void LookClass()
	{
		if (DisplayNewGameFunctions.mageSet) { 
				Vector3 targetDir = mage.position - transform.position;
				float step = CreateNewGameGui.CameraTurnSpeed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
				Quaternion rotateTo = Quaternion.LookRotation(newDir);
				rotateTo.x = 0f; 
				rotateTo.z = 0f; 
				transform.rotation = Quaternion.Slerp(transform.rotation,rotateTo,step);
				//CreateNewGameGui.myCamera.transform 
		} else if (DisplayNewGameFunctions.warriorSet) {
				Vector3 targetDir = warrior.position - transform.position;
				float step = CreateNewGameGui.CameraTurnSpeed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
				Quaternion rotateTo = Quaternion.LookRotation(newDir);
				rotateTo.x = 0f; 
				rotateTo.z = 0f; 
				transform.rotation = Quaternion.Slerp(transform.rotation,rotateTo,step);
		} else if (DisplayNewGameFunctions.spearmanSet) {
				Vector3 targetDir = spearman.position - transform.position;
				float step = CreateNewGameGui.CameraTurnSpeed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
				Quaternion rotateTo = Quaternion.LookRotation(newDir);
				rotateTo.x = 0f; 
				rotateTo.z = 0f; 
				transform.rotation = Quaternion.Slerp(transform.rotation,rotateTo,step);
		}
	}

	void OnGUI()
	{
		if (currentState == CreatePlayerStates.CLASSSELECTION) {
			displayFunctions.DisplayClassSelection();//prikazuje sve klase
			displayFunctions.DisplayMain();
		}
		if (currentState == CreatePlayerStates.STATALLOCATION) {
			displayFunctions.DisplayStatAllocation(); // prikazuje stat poene i da mozemo da ih modifikujemo
			displayFunctions.DisplayMain();
		}
		if (currentState == CreatePlayerStates.FINALSETUP) {
			displayFunctions.DisplayFinalSetup(); // finalni pogled
			displayFunctions.DisplayMain();
        }
	}
    


}
