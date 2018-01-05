using UnityEngine;
using System.Collections;

public static class IncreaseExperience {

	private static int xpToGive;
	private static LevelUp levelUpScript = new LevelUp();


	public static void AddExperience()
	{	
		xpToGive = GameInformation.PlayerLevel * 100;
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLevel ();
	}
    public static void AddDefeatedEnemyExperience(int enemyExperience)
    {
        xpToGive = enemyExperience;
        GameInformation.CurrentXP += xpToGive;
        CheckToSeeIfPlayerLevel();
    }

    public static void AddExplorationExperience()
	{
		xpToGive = GameInformation.PlayerLevel * 20;
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLevel ();
	}

	private static void CheckToSeeIfPlayerLevel()
	{
		if (GameInformation.CurrentXP >= GameInformation.RequiredXP) {
			levelUpScript.LevelUpCharacter();
		}
	}

}
