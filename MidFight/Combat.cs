using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asvargr
{
    class Combat : INotifyPropertyChanged

    {
        private List<Opponent> opponents;

        private Opponent activeOpponent;

        private string name;
        private int round =1;
        private int maxLP;
        private int gesLP;

        #region Propertys

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Round
        {
            get { return round; }
        }

        public int MaxLP
        {
            get
            {
                maxLP = 0;
                opponents.ForEach(i => maxLP += i.MaxLP);
                return maxLP;
            }
        }
        public int GesLP
        {
            get
            {
                gesLP = 0;
                opponents.ForEach(i => gesLP += i.LP);
                return gesLP;
            }
        }

        public int OpponentsCount { get { return opponents.Count; } }

        public int OpponentsAlive {get  {return opponents.FindAll(o => o.IsAlive).Count; } }

        public List<Opponent> Opponents { get { return opponents; } }

        #endregion


      
		#region Konstruktoren

		public Combat()
        {
            this.name = "NewFight";
            opponents = new List<Opponent>();
        }

        public Combat(string name)
        {
            this.name = name;
            opponents = new List<Opponent>();
        }


        #endregion

        
        #region Öffentliche Methoden

        /// <summary>
        /// Fügt einen neuen Gegener in die Gegnerliste hinzu
        /// </summary>
        /// <param name="newOpponent"></param>
        public void AddOpponent(Opponent newOpponent)
        {
            opponents.Add(newOpponent);
            activeOpponent = newOpponent;
            OnPropertyChanged("GesLP");
            OnPropertyChanged("OpponentsCount");
            OnPropertyChanged("OpponentsAlive");
        }

        public void SetOpponent(Opponent activeOpponent)
        {
            this.activeOpponent = activeOpponent;
        }
        public Opponent GetActiveOpponent()
        {
            return activeOpponent;
        }

        /// <summary>
        /// Startet die nächste KampRunde (Resettet alle Activity Flags, Verarbeitet alle Buffs ...)
        /// </summary>
        public void NextRound()
        {
            round++;
            opponents.ForEach(o => o.NextRound());
            OnPropertyChanged("GesLP");
            OnPropertyChanged("OpponentsAlive");
            OnPropertyChanged("Round");
        }

        /// <summary>
        /// Setzt den Kampf komplett zurück auf die Ausgangswerte
        /// </summary>
        public void Reset()
        {
            Opponents.ForEach(b => b.Reset());
            round = 1;
            OnPropertyChanged("GesLP");
            OnPropertyChanged("OpponentsAlive");
            OnPropertyChanged("Round");
        }

        /// <summary>
        /// Schaden oder Heilung für den Gegner.  AP und LP müssen Positiv (für Heilung) oder Negativ (Schaden) eingegeben werden
        /// </summary>
        /// <param name="lpValue">Der zu verbuchende Schaden/Heal (evtl. Rüstung wird intern abgezogen)</param>
        /// <param name="apValue">Die zu verbuchende Erschöpfung/Erfrischung</param>
        /// <param name="opponent">Der Gegner den die Heilung/der Schaden trifft</param>
        public void DamageOrHeal(int lpValue, int apValue, Opponent opponent)
        {
            opponent.AP += apValue;
            opponent.LP += lpValue;
            OnPropertyChanged("GesLP");
            OnPropertyChanged("OpponentsAlive");
        }

        public void AddBuff(Buff newBuff, Opponent opponent)
        {
            opponent.AddBuff(newBuff);
        }


        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
    }
}
