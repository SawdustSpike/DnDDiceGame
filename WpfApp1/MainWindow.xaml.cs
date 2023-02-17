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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DisplayNames();
            if (Player.players.Count > 1) { StartReady(); }
        }      
        private void Bottom_RollDice(object sender, RoutedEventArgs e)
        {
            if (PlayerController.p2)
            {
                var player = PlayerController.RetrievePlayer(2);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p2 = false;
                    bottomText.Text = "Click Here to Join";
                    Player.players.Remove(player);
                    DisplayNames();
                    if (Player.players.Count < 2) StopReady();
                }
                else
                    return;
            }
            else
            {
                PlayerController.p2 = true;
                string name = new InputBox("Enter Players Name").ShowDialog();
                int gold = GameController.GoldGetter();
                var player2 = new Player() { Name = name, Gold = gold, Number = 2 };
                bottomText.Text = player2.Name + " " + player2.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }
        }
        public void DisplayNames()
        {
            CenterBox.Visibility = Visibility.Visible;
            string ready = "Players Ready:";
            foreach (var player in Player.players) { ready += " " + player.Name + ","; };
            CenterBox.Text = ready.TrimEnd(',');
        }
        private void GameStart(object sender, RoutedEventArgs e)
        {
            GameController.IndividualRoll();
            var newForm = new Table();
            newForm.Opacity = 0;
            newForm.Show();
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            newForm.BeginAnimation(OpacityProperty, da);
            this.Close();
        }
        private void Left_RollDice(object sender, RoutedEventArgs e)
        {
            if (PlayerController.p3)
            {
                var player = PlayerController.RetrievePlayer(3);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p3 = false;
                    leftText.Text = "Click Here to Join";
                    Player.players.Remove(player);
                    DisplayNames();
                    if (Player.players.Count < 2) StopReady();
                }
                else return;
            }
            else
            {
                PlayerController.p3 = true;
                string name = new InputBox("Enter Players Name").ShowDialog();
                int gold = GameController.GoldGetter();
                var player3 = new Player() { Name = name, Gold = gold, Number = 3 };
                leftText.Text = player3.Name + " " + player3.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }
        }
        private void Right_RollDice(object sender, RoutedEventArgs e)
        {
            if (PlayerController.p4)
            {
                var player = PlayerController.RetrievePlayer(4);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p4 = false;
                    rightText.Text = "Click Here to Join";
                    Player.players.Remove(player);
                    DisplayNames();
                    if (Player.players.Count < 2) StopReady();
                }
                else return;

            }
            else
            {
                PlayerController.p4 = true;
                string name = new InputBox("Enter Players Name").ShowDialog();
                int gold = GameController.GoldGetter();
                var player4 = new Player() { Name = name, Gold = gold, Number = 4 };
                rightText.Text = player4.Name + " " + player4.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }
        }
        public void StartReady()
        {
            DisplayNames();
            gameStart.Visibility = Visibility.Visible;


        }
        public void StopReady()
        {
            gameStart.Visibility = Visibility.Collapsed;
        }
        private void Top_RollDice(object sender, RoutedEventArgs e)
        {
            if (PlayerController.p1)
            {
                var player = PlayerController.RetrievePlayer(1);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p1 = false;
                    topText.Text = "Click Here to Join";
                    Player.players.Remove(player);
                    DisplayNames();
                    if (Player.players.Count < 2) StopReady();
                }
                else return;
            }
            else
            {
                PlayerController.p1 = true;
                string name = new InputBox("Enter Players Name").ShowDialog();
                int gold = GameController.GoldGetter();
                var player1 = new Player() { Name = name, Gold = gold, Number = 1, };
                topText.Text = player1.Name + " " + player1.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }

        }        
    }
}
