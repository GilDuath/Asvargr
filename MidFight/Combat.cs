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


        /// <summary>
        /// Fügt einen neuen Gegener in die Gegnerliste hinzu
        /// </summary>
        /// <param name="newOpponent"></param>
        public void AddOpponent(Opponent newOpponent)
        {
            opponents.Add(newOpponent);
            OnPropertyChanged("GesLP");
			OnPropertyChanged("OpponentsCount");
			OnPropertyChanged("OpponentsAlive");

		}

		public void NextRound()
        {
            round++;
			OnPropertyChanged("Round");
			opponents.ForEach(o => o.NextRound());
			OnPropertyChanged("OpponentsAlive");
		}

		public void Reset()
		{
			Opponents.ForEach(b => b.Reset());
			round = 1;
			OnPropertyChanged("GesLP");
			OnPropertyChanged("OpponentsCount");
			OnPropertyChanged("OpponentsAlive");

		}
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
