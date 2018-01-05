using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Fight
{
    public static class AgilityModifier
    {

        public static float Speed=5;

        public static void agilitySpeedIncrease()
        {
            double agilitySpeed= GameInformation.Agility * 0.2;
            Speed += Convert.ToInt32(Math.Floor(agilitySpeed * 1));

        }

    }
}
