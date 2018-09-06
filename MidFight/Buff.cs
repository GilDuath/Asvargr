using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asvargr
{
    public enum Bufftype
    {
        Abwehr,
        Aktionen,
        Angriff,
        AP,
        LP,
        Schaden
    }

    public class Buff
    {
        private readonly Bufftype buffType;
        private int buffStack = 0;
        private readonly int buffValue = 0;
        bool hasAction = true;
        private bool isInit = true;

        public Buff(Bufftype bufftype, int bufvalue, int bufstack)
        {
            this.buffType = bufftype;
            this.buffStack = bufstack;    //  
            this.buffValue = bufvalue;
        }

        /// <summary>
        /// Reduziert den Buffstack um 1 und setzt gegebenenfalls HasAction
        /// </summary>
        public void NextRound()
        {
            if (isInit) { isInit = false; }
            else buffStack--;
            hasAction = !hasAction;
        }

        public int Value { get { return buffValue; } }
        public int Stack { get { return buffStack; } }
        public Bufftype Type {get { return buffType; } }

        public override string ToString()
        {
  
            switch (buffType)
            {
                case Bufftype.Abwehr:
                    {
                        return string.Format("Abw {0}({1})", buffValue, buffStack);
                    }
                case Bufftype.Aktionen:
                    {
                        if (buffValue >= 0)
                        { return string.Format("Beschl ({0})", buffStack); }
                        else
                        {
                            return string.Format("Verl ({0})", buffStack);
                        }
                    }
                case Bufftype.Angriff:
                    {
                        return string.Format("Ang {0}({1})", buffValue, buffStack);
                    }
                case Bufftype.AP:
                    {
                        return string.Format("AP {0}({1})", buffValue, buffStack);
                    }
                case Bufftype.LP:
                    {
                        return string.Format("LP {0}({1})", buffValue, buffStack);
                    }
                case Bufftype.Schaden:
                    {
                        return string.Format("Schaden {0}({1})", buffValue, buffStack);
                    }
                default:
                    break;
            }


            return "-*-";
        }
    }
}
