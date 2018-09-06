using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asvargr
{
    class DiceRoll
    {
        public int DiceCount { get; }
        public int DiceSides { get; }
        public int DiceBonus { get; }

        public DiceRoll(int diceCount, int diceSides, int diceBonus)
        {
            this.DiceCount = diceCount;
            this.DiceSides = diceSides;
            this.DiceBonus = diceBonus;
        }

        /// <summary>
        /// Führ einen Wurf mit der definierten Anzahl Würfel aus und gibt das Ergebniss zurück
        /// </summary>
        /// <returns></returns>
        public int RollDice()
        {
            int result = DiceBonus;
            Random roll = new Random();

            for (int i = 1; i <= DiceCount; i++)
            {
                result += roll.Next(1, DiceSides + 1);
            }
          
            if (result < 1 ) { result = 1; }

            return result;
        }
    }
}
