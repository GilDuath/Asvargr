using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asvargr
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Combat combat = new Combat("Oger Überfall");

        public MainWindow()
        {
            InitializeComponent();

            lbOpponents.ItemsSource = combat.Opponents;
            spDetailInfo.DataContext = combat.GetActiveOpponent();
            spHeader.DataContext = combat;

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid myX = (System.Windows.Controls.Grid)sender;
            combat.SetOpponent( (Opponent)myX.DataContext);

            this.spDetailInfo.DataContext = combat.GetActiveOpponent();
        }


        private void LoadDemo1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            combat = new Combat("Oger Überfall");
            combat.AddOpponent(new Opponent(1, "Grubenunhold", 24, 36) { LP = 20, AP = 10 });
            combat.AddOpponent(new Opponent(2, "Grubenunhold", 24, 36) { LP = 18, AP = 30 });
            combat.AddOpponent(new Opponent(3, "Grubenunhold", 24, 36) { LP = 23, AP = 36 });
            combat.AddOpponent(new Opponent(4, "Oger", 44, 36) { LP = 23, AP = 36 });
            combat.AddOpponent(new Opponent(5, "Oger", 44, 36) { LP = 23, AP = 36 });
            combat.AddOpponent(new Opponent(6, "Höllenhund", 64, 0) { LP = 50, AP = 0 });
            combat.AddOpponent(new Opponent(7, "Höllenhund", 64, 0) { LP = 60, AP = 0 });
            combat.AddOpponent(new Opponent(8, "Höllenhund", 64, 0) { LP = 64, AP = 0 });

            combat.Opponents[2].AddBuff(new Buff(Bufftype.Angriff, -2, 6));
            combat.Opponents[2].AddBuff(new Buff(Bufftype.Abwehr, -2, 6));
            combat.Opponents[2].AddBuff(new Buff(Bufftype.Schaden, 4, 3));
            combat.Opponents[4].AddBuff(new Buff(Bufftype.Angriff, 2, 6));
            combat.Opponents[4].AddBuff(new Buff(Bufftype.Abwehr, 2, 6));
            combat.Opponents[5].AddBuff(new Buff(Bufftype.Aktionen, -2, 6));
            combat.Opponents[5].AddBuff(new Buff(Bufftype.Schaden, -2, 4));
            combat.Opponents[5].AddBuff(new Buff(Bufftype.AP, -3, 2));
            combat.Opponents[6].AddBuff(new Buff(Bufftype.Aktionen, 1, 6));

            lbOpponents.ItemsSource = combat.Opponents;
            spDetailInfo.DataContext = combat.Opponents[0];
            spHeader.DataContext = combat;

        }

        private void LoadDemo2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            combat = new Combat("Sir Adalbert treibt steuern ein");
            combat.AddOpponent(new Opponent(1, "Sir Adalbert", 24, 46) { LP = 20, AP = 40 });
            combat.AddOpponent(new Opponent(2, "Knecht", 24, 36) { LP = 18, AP = 30 });
            combat.AddOpponent(new Opponent(3, "Knecht", 24, 36) { LP = 23, AP = 36 });
            combat.AddOpponent(new Opponent(4, "Knecht", 44, 36) { LP = 23, AP = 36 });
            combat.AddOpponent(new Opponent(5, "Bogenschütze", 19, 36) { LP = 17, AP = 36 });
            combat.AddOpponent(new Opponent(6, "Bogenschütze", 19, 30) { LP = 10, AP = 13 });
            combat.AddOpponent(new Opponent(7, "Bogenschütze", 19, 30) { LP = 10, AP = 6 });
            combat.AddOpponent(new Opponent(8, "Jagdhund", 17, 20) { LP = 2, AP = 0 });
            combat.AddOpponent(new Opponent(9, "Jagdhund", 17, 20) { LP = 6, AP = 2 });

            combat.Opponents[1].AddBuff(new Buff(Bufftype.Angriff, -2, 6));
            combat.Opponents[2].AddBuff(new Buff(Bufftype.Abwehr, -2, 6));
            combat.Opponents[2].AddBuff(new Buff(Bufftype.Schaden, 4, 3));
            combat.Opponents[4].AddBuff(new Buff(Bufftype.Angriff, 2, 6));
            combat.Opponents[4].AddBuff(new Buff(Bufftype.Abwehr, 2, 6));
            combat.Opponents[5].AddBuff(new Buff(Bufftype.Aktionen, -2, 6));
            combat.Opponents[5].AddBuff(new Buff(Bufftype.Schaden, -2, 4));
            combat.Opponents[5].AddBuff(new Buff(Bufftype.AP, -3, 2));
            combat.Opponents[6].AddBuff(new Buff(Bufftype.Aktionen, 1, 6));
            combat.Opponents[0].AddBuff(new Buff(Bufftype.Angriff, -2, 2));
            combat.Opponents[7].AddBuff(new Buff(Bufftype.Aktionen, 1, 6));
            combat.Opponents[8].AddBuff(new Buff(Bufftype.Aktionen, 1, 3));
            combat.Opponents[8].AddBuff(new Buff(Bufftype.Angriff, 1, 4));

            lbOpponents.ItemsSource = combat.Opponents;
            spDetailInfo.DataContext = combat.Opponents[0];
            spHeader.DataContext = combat;

        }

    	private void Scene1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //combat.NextRound();
            combat.Opponents[2].HasAction = false;
			combat.Opponents[2].LP = 0;
			combat.Opponents[2].IsAlive = false;
        }

        private void Scene2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            combat.NextRound();
            combat.Opponents[3].HasAction = false;
            combat.Opponents[4].HasAction = false;
        }

		private void btnNextRound_Click(object sender, RoutedEventArgs e)
		{
			combat.NextRound();
		}

		private void btnWeapon1_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnSetDamage_Click(object sender, RoutedEventArgs e)
		{
            combat.DamageOrHeal(-5, -5, combat.GetActiveOpponent());
        }

        private void btnSetBuff_Click(object sender, RoutedEventArgs e)
		{
            combat.AddBuff(new Buff(Bufftype.Angriff, -2, 4), combat.GetActiveOpponent());
            combat.AddBuff(new Buff(Bufftype.LP, -2, 4), combat.GetActiveOpponent());
		}

		private void btnSetHeal_Click(object sender, RoutedEventArgs e)
		{
            combat.DamageOrHeal(7, 7, combat.GetActiveOpponent());
		}

		private void btnResetBattle_Click(object sender, RoutedEventArgs e)
		{
			combat.Reset();
		}
	}
}
