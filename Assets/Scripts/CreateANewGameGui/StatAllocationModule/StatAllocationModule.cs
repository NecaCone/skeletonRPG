using UnityEngine;
using System.Collections;

public class StatAllocationModule {
	private string[] statNames = new string[7]{"Stamina","Endurance","Strenght","Agility","Intelect","Resistance","Magic Resistance"};
	private string[] statDescription = new string[7]{"Health modifier.","Energy modifier.","Damage modifier.","Haste and critical attack increase.","Spell,staff and scroll modifier.","Resistance to melee modifier.","Rsistance to spell and scroll attack."};
	private bool[] statSelections = new bool[7];
	public  int[] pointsToAllcoate = new int[7]; //starting start values for chosing class, but used for modifier 
	private int[] baseStatPoints = new int[7]; //starting start values for chosing class

	private int availPoints = 5;

	public bool didRunOnce;

	public void DisplayStatAllocationModule()
	{
		if (!didRunOnce) {//dohbata stat poene jedon sve dok se ne prebaci na false tj da se korisnik vrati na klass selection
				RetrieveStatBaseStatPoints ();
			didRunOnce=true;
		}
		DisplayStatToogleSwitches ();
        DisplayStatIncreaseDecreaseButtons ();
        
	}

	private void DisplayStatToogleSwitches()
	{ // prikazuje sta znaci strenght endurance  intelect 
		for (int i = 0; i < statNames.Length; i++) {
			statSelections[i]= GUI.Toggle(new Rect(30,60*i+10,100,50),statSelections[i],statNames[i]);
			GUI.Label(new Rect(140,60*i+10,50,50), pointsToAllcoate[i].ToString());

			if (statSelections [i]) {
				GUI.Label (new Rect (40,60*i+30,160,100), statDescription[i]);
			}
		}
	}
	private void DisplayStatIncreaseDecreaseButtons()
	{//povecava i smanjuje stat poene u zavisnosti koliko smo ih stavili
		for (int i = 0; i < pointsToAllcoate.Length; i++) {
			if(pointsToAllcoate[i] >= baseStatPoints[i] && availPoints>0)
			if(GUI.Button(new Rect(200,60*i+7,30,30),"+"))
			{
				pointsToAllcoate[i]+=1;
				--availPoints;
			}
			if(pointsToAllcoate[i]>baseStatPoints[i])
			{
				if(GUI.Button(new Rect(260,60*i+7,30,30),"-"))
				{
					pointsToAllcoate[i]-=1;
					++availPoints;
				}
			}
		}
	}
	//dohvata poene za odredjenu klasu i upisuje ih u niz koji se zatim prikazuje na  guiu i pravi niz koji cemo da editujemo i cuvamo u bazi
	private void RetrieveStatBaseStatPoints()
	{
		BaseCharacterClass cClass = GameInformation.PlayerClass;
		pointsToAllcoate [0] = cClass.Stamina;
		baseStatPoints [0] = cClass.Stamina;
		pointsToAllcoate [1] = cClass.Endurance;
		baseStatPoints [1] = cClass.Endurance;
		pointsToAllcoate [2] = cClass.Strenght;
		baseStatPoints [2] = cClass.Strenght;
		pointsToAllcoate [3] = cClass.Agility;
		baseStatPoints [3] = cClass.Agility;
		pointsToAllcoate [4] = cClass.Intelect;
		baseStatPoints [4] = cClass.Intelect;
		pointsToAllcoate [5] = cClass.Resistance;
		baseStatPoints [5] = cClass.Resistance;
		pointsToAllcoate [6] = cClass.MagicResistance;
		baseStatPoints [6] = cClass.MagicResistance;

	}
}
