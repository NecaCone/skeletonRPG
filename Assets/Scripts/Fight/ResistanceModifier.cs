using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Fight
{
     public static class ResistanceModifier
    {
        public static int Resistance;

        public static void resistanceArrmorModifier()
        {
            double resistanceArrmor = GameInformation.Resistance * 0.3;
            Resistance += Convert.ToInt32(Math.Floor(resistanceArrmor * 1));
        }

    }
}
