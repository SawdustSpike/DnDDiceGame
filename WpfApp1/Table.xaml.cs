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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        public Table()
        {
            InitializeComponent();
            GameController.IndividualRoll();
            UpdatePot();
            for (int i = 0; i < Player.players.Count;i++) 
            {                
                switch (Player.players[i].Number) 
                {
                    case 1: Top_Player.Visibility= Visibility.Visible; break;
                    case 2: Bottom_Player.Visibility= Visibility.Visible; break;
                    case 3: Left_Player.Visibility = Visibility.Visible;  break;
                    case 4: Right_Player.Visibility = Visibility.Visible; break;
                }
            }
        }
        private void Top_Player_Click(object sender, RoutedEventArgs e)
        {
            var player = PlayerController.RetrievePlayer(1);
            MessageBox.Show($"You Rolled a {player.Dice[0]} {player.Dice[1]}");
        }

        private void Bottom_Player_Click(object sender, RoutedEventArgs e)
        {
            var player = PlayerController.RetrievePlayer(2);
            MessageBox.Show($"You Rolled a {player.Dice[0]} {player.Dice[1]}");
        }

        private void Left_Player_Click(object sender, RoutedEventArgs e)
        {
            var player = PlayerController.RetrievePlayer(3);
            MessageBox.Show($"You Rolled a {player.Dice[0]} {player.Dice[1]}");
        }       

        private void Right_Player_Click(object sender, RoutedEventArgs e)
        {
            var player = PlayerController.RetrievePlayer(4);
            MessageBox.Show($"You Rolled a {player.Dice[0]} {player.Dice[1]}");
        }
        private void GameStart(object sender, RoutedEventArgs e)
        {
            var bet =new BetBox("Enter your starting bet").ShowDialog();
        }
        private void UpdatePot()
        {
            CenterBox.Visibility = Visibility.Visible;
            CenterBox.Text = $"Pot Currently at {GameController.pot} Gold";
        }
    }
}
