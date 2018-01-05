using UnityEngine;
using System.Collections;

public class BaseSpearClass : BaseCharacterClass {

	public BaseSpearClass()
	{
		CharacterClassName = "Spearman";
		CharacterClassDescription = "Spearman class description";
		Stamina = 15;
		Endurance = 13;
		Strenght = 13;
		Intelect = 12;
		Agility = 15;
		Resistance = 15;
		MagicResistance = 5;
		CharacterBio = "A spearman (also known as a meat shield) is a style of character in gaming, often associated with a " +
			"character class. A common convention in real-time strategy games, role-playing games, fighting games, multiplayer " +
			"online battle arenas and MUDs, tanks redirect enemy attacks or attention toward themselves in order to protect" +
			"other characters or units. Since this role often requires them to suffer large amounts of damage, they rely on" +
			"large amounts of vitality or armor, healing by other party members, evasiveness and misdirection, or self " +
			"regeneration.";
	}
}
