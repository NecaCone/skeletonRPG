using UnityEngine;
using System.Collections;
using Assets.Scripts.Fight;
using Assets.Scripts.Stats;

public class LevelUp {

	private int maxPlayerLevel = 10;
	public void LevelUpCharacter()
	{
		if (GameInformation.CurrentXP > GameInformation.RequiredXP) {
			GameInformation.CurrentXP -= GameInformation.RequiredXP;		
		}
		else
		{
			GameInformation.CurrentXP = 0;
		}
		if (GameInformation.PlayerLevel < maxPlayerLevel) {
						GameInformation.PlayerLevel += 1;		
		} else {
			GameInformation.PlayerLevel = maxPlayerLevel;
		}

        //plan je da dodam 5 poena svaki put kad se slevelujem 
        GameInformation.AvailableLevelPoints = GameInformation.AvailableLevelPoints + 5;
        // postavljam da kad se leveluje igrac poveca svoje helte za odredjeni nivo koliji he maxiumum
        Combat.healthCheckedOnce = false;
        Combat.energyCheckOnce = false;
        Combat.manaCheckOnce = false;
        //posalti level healthModifieru da bi povecali maximalni health    
        HealthModifier.healthLevelIncrease(GameInformation.PlayerLevel);

        EnergyModifier.energyLevelIncrease(GameInformation.PlayerLevel);

        ManaModifier.manaLevelIncrease(GameInformation.PlayerLevel);
        //saljem broj poena u staticku klasu kod koje cu moci da pristupim
        Points.LevelUpPoints(GameInformation.AvailableLevelPoints);

        DetermineRequiredXP();
        //Debug.Log(GameInformation.CurrentXP);
        //Debug.Log(GameInformation.RequiredXP);
        //Debug.Log(GameInformation.PlayerLevel);
    }

	private void DetermineRequiredXP()
	{
		int temp = GameInformation.PlayerLevel * 1000 + 250;
		GameInformation.RequiredXP = temp;
	}



}
