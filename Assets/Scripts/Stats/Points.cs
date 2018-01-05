using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Stats
{
    public static class Points
    {
        //ovde upisujem broj poena kad god se levelujem i sa ovim poenima cu da odradjujem dal se menjaju i to
        public static int LevelPoints;

        public static void LevelUpPoints(int numPoints)
        {
            LevelPoints += numPoints;
        }


    }
}
