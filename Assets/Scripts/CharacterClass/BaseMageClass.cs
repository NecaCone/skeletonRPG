using UnityEngine;
using System.Collections;

public class BaseMageClass : BaseCharacterClass {

	public BaseMageClass()
	{
		CharacterClassName = "Mage";
		CharacterClassDescription = "Mage class description";
		Stamina = 11;
		Endurance = 12;
		Strenght = 10;
		Intelect = 15;
		Agility = 11;
		Resistance = 12;
		MagicResistance = 15;
		CharacterBio = "The Wizard is a type of magical character class in certain role-playing games," +
			"including role-playing video games. Wizards are considered to be spellcasters who wield powerful " +
			"spells, but are often physically weak as a trade-off. Wizards are commonly confused with similar" +
			"offensive spellcasting classes such as the Warlock and the Necromancer. However, a Wizard's power is " +
			"based on the arcane and a Warlock or Necromancer's power is based on darkness or death. Wizards are " +
			"primarily based on wizards from assorted fantasy literature. Other terms used to describe the classification " +
			"include Mage, Magician, and Magic User.";
	}

}
