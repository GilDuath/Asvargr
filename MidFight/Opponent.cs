using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace Asvargr
{
    /// <summary>
    /// Objekt zum definieren eines Gegners
    /// </summary>
    public class Opponent : INotifyPropertyChanged

    {
        private static  int id;
        private int number;
        private string name;

        private readonly int maxLP;
        private int lp;
        private readonly int maxAP;
        private  int ap;

        private bool hasAction = true;
        private bool isAlive = true;

        private string infoBuff;
        private string infoDeBuff;

        private List<Buff> buffList = new List<Buff>() ;


        #region //Propertys 

        public int Id { get { return id; } }

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int MaxLP { get { return maxLP; } }

        public int LP
        {
            get { return lp; }
            set
            {
                lp = value;
                OnPropertyChanged("LP");
            }
        }

        public int MaxAP { get { return maxAP; } }

        public int AP
        {
            get { return ap; }
            set
            {
                ap = value;
                OnPropertyChanged("AP");
            }
        }

       public bool IsAlive
       {
            get { return isAlive; }
            set
            {
                isAlive = value;
                OnPropertyChanged("IsAlive");
                OnPropertyChanged("LedBrush");
            }
        }

        public bool HasAction        {
            get { return hasAction; }
            set
            {
                hasAction = value;
                OnPropertyChanged("HasAction");
                OnPropertyChanged("LedBrush");
            }
        }

        public string InfoBuff
        {
            get
            {
                infoBuff = string.Empty;
                foreach (Buff fbuff in buffList)
                {
                    if (fbuff.Value >= 0)
                    {
                        infoBuff = string.Format("{0}{1}     ", infoBuff, fbuff.ToString());
                    }
                }
                return infoBuff;
            }
        }

        public string InfoDeBuff
        {
            get
            {
                infoDeBuff = string.Empty;
                foreach (Buff fbuff in buffList)
                {
                    if (fbuff.Value < 0)
                    {
                        infoDeBuff = string.Format("{0}{1}     ", infoDeBuff, fbuff.ToString());
                    }
                }
                return infoDeBuff;
            }
        }
        
        public SolidColorBrush LedBrush
        {
            get
            {
                if (!isAlive) { return Brushes.Black; }
                else if (hasAction) { return Brushes.DarkGreen; }
                else { return Brushes.DarkRed; }
            }
        }

        public DesignerSerializationVisibility IsAliveVisibility
        {
            get
            {
                if (isAlive) { return DesignerSerializationVisibility.Visible; }
                else { return DesignerSerializationVisibility.Hidden; }
            }
        }

        public DesignerSerializationVisibility HasActionVisibility
        {
            get
            {
                if (hasAction) { return DesignerSerializationVisibility.Visible; }
                else { return DesignerSerializationVisibility.Hidden; }
            }
        }

        #endregion

        #region //Konstruktoren
        public Opponent(int number, string name, int maxLP, int maxAP)
        {
            id = GetNextID();
            this.number = number;
            this.name = name;
            this.maxLP = maxLP;
            this.lp = maxLP;
            this.maxAP = maxAP;
            this.ap = maxAP;
        }
        #endregion



        /// <summary>
        /// Setzt den Gegner wieder auf Aktiv (HasAction=True), zählt alle BuffStacks eins runter und entfernt abgelaufene aus der Liste
        /// </summary>
        public void NextRound()
        {
            if (isAlive)
            {
                hasAction = true;
            }

            OnPropertyChanged("LedBrush");

            buffList.ForEach(b => b.NextRound());

            for (int i=buffList.Count-1; i>=0; i--)
            {
                if (buffList[i].Stack <= 0)
                {
                    buffList.Remove(buffList[i]);
                }
            }
            OnPropertyChanged("InfoBuff");
            OnPropertyChanged("InfoDeBuff");

            foreach (Buff buff in buffList)
            {
                switch (buff.Type)
                {
                    case Bufftype.AP:
                        AP = ap + buff.Value;
                        break;
                    case Bufftype. LP:
                        LP = lp + buff.Value;
                        break;
                    default:
                        break;

                }
            }
        }

        /// <summary>
        /// Fügt einen neuen Buff / DeBuff zur Liste hinzu
        /// </summary>
        /// <param name="newBuff"></param>
        public void AddBuff(Buff newBuff)
        {
            buffList.Add(newBuff);
            OnPropertyChanged("InfoBuff");
            OnPropertyChanged("InfoDeBuff");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        protected int GetNextID()
        {
            return ++id;
        }
    }
}
