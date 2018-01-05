using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Fight
{
    public static class EnergyModifier
    {

        public static int maxEnergy = 50;

        public static void energyLevelIncrease(int playerLevel)
        {
            maxEnergy += playerLevel / 2 * 10;
        }
        public static void healthStaminalIncrease()
        {
            double enduranceEnergy = GameInformation.Endurance * 0.5;
            maxEnergy += Convert.ToInt32(Math.Floor(enduranceEnergy * 1));
        }

    }
}
