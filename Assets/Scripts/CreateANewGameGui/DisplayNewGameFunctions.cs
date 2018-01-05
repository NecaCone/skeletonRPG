using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DisplayNewGameFunctions {
    
    private StatAllocationModule statAllocationModuler = new StatAllocationModule(); // instanca stat allocation modula

    private int classSelection;  //za biranje klase
    private string[] classSelectionNames = new string[]{"Mage","Warrior","Spearmen"}; // sve dostupne klase

    private CreateNewGameGui createNewGameGui;

	public static bool mageSet; 
	public static bool warriorSet; 
	public static bool spearmanSet;

    public string playerName="Enter name!";
	private string playerBio="";
    private bool checkCharacterCreated = false;

    public void DisplayClassSelection()
    {
        classSelection = GUI.SelectionGrid(new Rect(50, 50, 250, 300), classSelection, classSelectionNames, 1); //gleda koja je klasa izabrana  na selectionom gridu
        GUI.Label(new Rect(450, 50, 300, 300), FindClassDescription(classSelection)); //trazi opis klase 
        GUI.Label(new Rect(450, 100, 300, 300), FindClassStatValues(classSelection)); // Vrednosti klase
        CheckWitchClassIsSelected(classSelection); //gleda koja je klasa selektovana da bi kamerom u nju upro
        checkCharacterCreated = false;
    }

	private string FindClassDescription(int classSelection)// trazi opis klase na osnovu selektovane klase i grid selecionog bara
	{
		if (classSelection == 0) {
			BaseCharacterClass tempClass = new BaseMageClass ();
			return tempClass.CharacterClassDescription;
		} else if (classSelection == 1) {
			BaseCharacterClass tempClass = new BaseWarriorClass ();
			return tempClass.CharacterClassDescription;
		}else if (classSelection == 2) {
			BaseCharacterClass tempClass = new BaseSpearClass ();
			return tempClass.CharacterClassDescription;
		}
		return "No class selected";
	}
	private string FindClassStatValues(int classSelection) // trazi koleke su stat poeni na odredjenikm klasam ispisuje ih i vraca 
	{
		if (classSelection == 0) {
			BaseCharacterClass tempClass = new BaseMageClass ();
			string tempStat = "Stamina: "+tempClass.Stamina+"\n"+"Endurance: "+tempClass.Endurance+"\n"+"Strenght: "+tempClass.Strenght+ "\n"+"Agility: "+tempClass.Agility+"\n"+"Intelect: "+ tempClass.Intelect+"\n"+"Resistance: "+tempClass.Resistance+"\n"+"Magic resistance :"+tempClass.MagicResistance;
			return tempStat;
		} else if (classSelection == 1) {
			BaseCharacterClass tempClass = new BaseWarriorClass ();
			string tempStat = "Stamina: "+tempClass.Stamina+"\n"+"Endurance: "+tempClass.Endurance+"\n"+"Strenght: "+tempClass.Strenght+ "\n"+"Agility: "+tempClass.Agility+"\n"+"Intelect: "+ tempClass.Intelect+"\n"+"Resistance: "+tempClass.Resistance+"\n"+"Magic resistance :"+tempClass.MagicResistance;
			return tempStat;
		}else if (classSelection == 2) {
			BaseCharacterClass tempClass = new BaseSpearClass ();
			string tempStat = "Stamina: "+tempClass.Stamina+"\n"+"Endurance: "+tempClass.Endurance+"\n"+"Strenght: "+tempClass.Strenght+ "\n"+"Agility: "+tempClass.Agility+"\n"+"Intelect: "+ tempClass.Intelect+"\n"+"Resistance: "+tempClass.Resistance+"\n"+"Magic resistance :"+tempClass.MagicResistance;
			return tempStat;
		}
		return "No stats";
	}
	public void CheckWitchClassIsSelected(int classSelection)//koja klasa je izabrana
	{
		mageSet = true;
		if (classSelection == 0) {
			warriorSet=false;
			spearmanSet=false;
			mageSet = true;
		} else if (classSelection == 1) {
			mageSet = false;
			spearmanSet=false;
			warriorSet=true;
		} else if (classSelection == 2) {
			mageSet = false;
			warriorSet=false;
			spearmanSet=true;
		}
	}


	public void DisplayStatAllocation()
	{
		statAllocationModuler.DisplayStatAllocationModule ();
	}

	public void DisplayFinalSetup() //poslednji setup prikaz
	{
		string tempBioShow = CharacterClassBio(classSelection); // salje calss selection i ocekuje biorafiju klase
		float sredina = (Screen.width / 2 - 75);
		//new Rect(sredina,30,150,30),playerName,12
		playerName = GUI.TextArea(new Rect(sredina, 35, 150,30), playerName, 200);
			
		playerBio = GUI.TextArea(new Rect(30, 40,300,400), tempBioShow, 900);

        if (checkCharacterCreated == true)
        {
                SceneManager.LoadScene("PlayMode");   
        }
    }

	private void ChooseClass(int classSelection) // igrac bira klasu i ona se upisuje u memoriji game information scripti
	{
		if (classSelection == 0) {
			GameInformation.PlayerClass=new BaseMageClass();
		} else if (classSelection == 1) {
			GameInformation.PlayerClass = new BaseWarriorClass();
		} else if (classSelection == 2) {
			GameInformation.PlayerClass = new BaseSpearClass();
		}
	}

	public string CharacterClassBio(int classSelection) //dohvara biografiju klase
	{
		string temp = "No class selected for showing bio";
		if (classSelection == 0) {
		return temp = new BaseMageClass().CharacterBio;
		} else if (classSelection == 1) {
		return	temp = new BaseWarriorClass().CharacterBio;
		} else if (classSelection == 2) {
		 return	temp = new BaseSpearClass().CharacterBio;
		}
		return temp;
	}

	public void DisplayMain() //glavni prikaz celog CreateNewPotion bew Game Guia 
	{
		Transform spearman = GameObject.FindGameObjectWithTag("skeletonFresh").transform;
		Transform warrior = GameObject.FindGameObjectWithTag("skeletonDark").transform;
		Transform mage = GameObject.FindGameObjectWithTag("skeletonMage").transform;
        
		GUI.Label (new Rect (Screen.width / 2-75,10, 150, 20), "Create new player");
		if (mageSet) {
			if (GUI.Button (new Rect (550,550,50,50), "<<<")) {
					//turn transform player to the left;
				mage.Rotate(Vector3.up * 10);
			}
			if (GUI.Button (new Rect (750,550,50,50), ">>>")) {
					//turn transform player to the right
				mage.Rotate(Vector3.down * 10);
			}
		} else if (warriorSet) {
			if (GUI.Button (new Rect (550,550,50,50), "<<<")) {
					//turn transform player to the left;
				warrior.Rotate(Vector3.up * 10);
			}
			if (GUI.Button (new Rect (750,550,50,50), ">>>")) {
					//turn transform player to the right
				warrior.Rotate(Vector3.down * 10);
			}		
		} else if (spearmanSet) {
			if (GUI.Button (new Rect (550,550,50,50), "<<<")){
				//turn transform player to the left;
				spearman.Rotate(Vector3.up  * 10);
			}
			if (GUI.Button (new Rect(750,550,50,50),">>>")){
				//turn transform player to the right
				spearman.Rotate(Vector3.down * 10);
			}
		}


        // click next it goes to statallocation 
        if (CreateNewGameGui.currentState != CreateNewGameGui.CreatePlayerStates.FINALSETUP)
        {
            if (GUI.Button(new Rect(1100, 550, 50, 50), "Next"))
            {
                if (CreateNewGameGui.currentState == CreateNewGameGui.CreatePlayerStates.CLASSSELECTION)
                {
                    ChooseClass(classSelection);
                    CreateNewGameGui.currentState = CreateNewGameGui.CreatePlayerStates.STATALLOCATION;
                }
                else if (CreateNewGameGui.currentState == CreateNewGameGui.CreatePlayerStates.STATALLOCATION)
                {
                    GameInformation.Stamina = statAllocationModuler.pointsToAllcoate[0];
                    GameInformation.Endurance = statAllocationModuler.pointsToAllcoate[1];
                    GameInformation.Strenght = statAllocationModuler.pointsToAllcoate[2];
                    GameInformation.Agility = statAllocationModuler.pointsToAllcoate[3];
                    GameInformation.Intelect = statAllocationModuler.pointsToAllcoate[4];
                    GameInformation.Resistance = statAllocationModuler.pointsToAllcoate[5];
                    GameInformation.MagicResistance = statAllocationModuler.pointsToAllcoate[6];

                    CreateNewGameGui.currentState = CreateNewGameGui.CreatePlayerStates.FINALSETUP;
                }
            }
        }
        else if (CreateNewGameGui.currentState == CreateNewGameGui.CreatePlayerStates.FINALSETUP)
        {
            if (checkCharacterCreated != true)
            {
                if (GUI.Button(new Rect(1100, 550, 50, 50), "Creation"))
                {
                    GameInformation.PlayerName = playerName;
                    GameInformation.PlayerLevel = 1;
                    GameInformation.Gold = 100;
                    GameInformation.CurrentXP = 0;
                    GameInformation.RequiredXP = 600;
                    GameInformation.AvailableLevelPoints = 0;
                    SaveInformation.SaveAllInformation();

                    checkCharacterCreated = true;

                    Debug.Log("Player name: " + GameInformation.PlayerName);
                    Debug.Log("Player class: " + GameInformation.PlayerClass.CharacterClassName);
                    Debug.Log("Player level: " + GameInformation.PlayerLevel);
                    Debug.Log("Player currentXP: " + GameInformation.CurrentXP);
                    Debug.Log("Player requiredXP: " + GameInformation.RequiredXP);
                    Debug.Log("Player gold: " + GameInformation.Gold);
                    Debug.Log("Player stamina: " + GameInformation.Stamina);
                    Debug.Log("Player endurance: " + GameInformation.Endurance);
                    Debug.Log("Player stremght: " + GameInformation.Strenght);
                    Debug.Log("Player agility: " + GameInformation.Agility);
                    Debug.Log("Player resistance: " + GameInformation.Resistance);
                    Debug.Log("Player magicresistance: " + GameInformation.MagicResistance);
                    Debug.Log("Final save");
                }
            }
        }
		if (CreateNewGameGui.currentState != CreateNewGameGui.CreatePlayerStates.CLASSSELECTION) {
			if (GUI.Button (new Rect (1000, 550, 50, 50), "Back")) {
					if (CreateNewGameGui.currentState == CreateNewGameGui.CreatePlayerStates.STATALLOCATION) {
							GameInformation.PlayerClass=null;
							statAllocationModuler.didRunOnce=false;
                            checkCharacterCreated = false;
							CreateNewGameGui.currentState = CreateNewGameGui.CreatePlayerStates.CLASSSELECTION;
					} else if (CreateNewGameGui.currentState == CreateNewGameGui.CreatePlayerStates.FINALSETUP) {
                            checkCharacterCreated = false;
                            CreateNewGameGui.currentState = CreateNewGameGui.CreatePlayerStates.STATALLOCATION;						
					} 
			}
		}
	}
        
}

