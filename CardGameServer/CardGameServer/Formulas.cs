using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGameServer
{
    public class Formulas
    {
        public static int CalculateDamage(int dmgStat, int defStat)
        {
            return dmgStat - (int)(defStat / 1.5); //def div
        }

        public static int CalculateCritDamage(int dmg)
        {
            double tmp = dmg * 1.4; //crit mul
            int result = (int)tmp;
            if ((tmp % 1) >= 0.5) result += 1;

            return result;
        }

        public static int CalculateCritDamage(int dmg, double critMul)
        {
            double tmp = dmg * critMul; //crit mul
            int result = (int)tmp;
            if ((tmp % 1) >= 0.5) result += 1;

            return result;
        }
    }
}
