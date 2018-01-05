using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Fight
{
    public class DamageModifier
    {
        public static int damageModifier=30;
        public static int damageModifierMage = 20;
        public static int damageRangeModifier=30;
        public static void DamageClassStat()
        {
            string className = GameInformation.PlayerClass.CharacterClassName;
            switch(className)
            {
                case "Mage":
                    damageIntelectIncrease();
                    break;
                case "Warrior":
                    damageStrenghtIncrease();
                    break;
                case "Spearman":
                    damageStrenghtAgilityIncrease();
                    break;
            }
        }
        private static void damageStrenghtIncrease()
        {
            double strenghtDamage = GameInformation.Strenght * 0.5; ;
            damageModifier += Convert.ToInt32(Math.Floor(strenghtDamage * 1));
        }
        private static void damageIntelectIncrease()
        {
            double strenghtDamage = GameInformation.Strenght * 0.2;
            damageModifierMage += Convert.ToInt32(Math.Floor(strenghtDamage * 1));
        }

        private static void damageStrenghtAgilityIncrease()
        {
            double strenghtAgilityDamage = GameInformation.Strenght * 0.25 + GameInformation.Agility * 0.25;
            damageModifier += Convert.ToInt32(Math.Floor(strenghtAgilityDamage * 1));
        }

        public static void RangeAttackDamage()
        {
            double intelectDamage = GameInformation.Intelect * 0.8;
            damageRangeModifier += Convert.ToInt32(Math.Floor(intelectDamage * 1));
        }
    }
}
