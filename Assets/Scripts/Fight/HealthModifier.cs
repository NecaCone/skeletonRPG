using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Fight
{
     public static class HealthModifier
    {
        public static int maxHealth=1000;

        public static void healthLevelIncrease(int playerLevel)
        {
            maxHealth += playerLevel / 2 * 200; 
        }
        public static void healthStaminalIncrease()
        {
            double staminaHealth = GameInformation.Stamina * 0.5;
            maxHealth += Convert.ToInt32(Math.Floor(staminaHealth * 1));
        }


    }
}
