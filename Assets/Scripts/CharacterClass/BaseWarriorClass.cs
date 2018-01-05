using UnityEngine;
using System.Collections;

public class BaseWarriorClass : BaseCharacterClass {

	public BaseWarriorClass()
	{
				CharacterClassName = "Warrior";
				CharacterClassDescription = "Warrior class description";
				Stamina = 13;
				Endurance = 13;
				Strenght = 15;
				Intelect = 10;
				Agility = 14;
				Resistance = 13;
				MagicResistance = 0;
				CharacterBio = "Warrior is a character class (or job) found in many role-playing games. " +
				"This class may also be referred to as Fighter, as in Dungeons & Dragons. The class is " +
				"sometimes also referred to as a Knight, although in some games this is a separate class " +
				"with a more chivalric aspect. The Warrior is skilled in combat, and usually can make use " +
				"of some of the most powerful heavy armor and weaponry in the game. As such, the warrior is a" +
				"well-rounded physical combatant. In some games, the Warrior (or more often the Knight, if it" +
				"is a separate class) may be able to learn basic magic, but its capabilities in this field are " +
				"somewhat limited. Because of the class's reliance on heavy plate armor and expensive weaponry, " +
				"the cost of managing the Warrior's equipment is typically very high.";
		}
}
