using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asvargr
{
    public class Weapon
    {
        public String Name { get;}
        public int SuccessValue { get; }
        public int DiceCount { get; }
        public int DiceSides { get; }
        public int DiceBonus { get; }

        public Weapon(string name, int successValue, int diceCount, int diceSides, int diceBonus)
        {
            this.Name = name;
            this.SuccessValue = successValue;
            this.DiceCount = diceCount;
            this.DiceSides = diceSides;
            this.DiceBonus = diceBonus;
        }

        public override string ToString()
        {
            string ret = string.Empty;
            ret=string.Format("{0}  EW {1} W{2}", Name, DiceCount, DiceSides);
            if (DiceBonus != 0)
            {
                if (DiceBonus < 0) { ret = ret + DiceBonus.ToString(); }
                else { ret = ret + "+" + DiceBonus.ToString(); }
            }

            return ret;
        }


    }
}
