using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Fight
{
    public static class  ManaModifier
    {
        public static int maxMana = 40;

        public static void manaLevelIncrease(int playerLevel)
        {
            maxMana += playerLevel / 2 * 20;
        }
        public static void manaIntelectlIncrease()
        {
            double intelectMana = GameInformation.Intelect * 0.3;
            maxMana += Convert.ToInt32(Math.Floor(intelectMana * 1));
        }
    }
}
