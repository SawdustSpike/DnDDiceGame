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
                                   
            for (int i = 0; i < Player.players.Count;i++) 
            {                
                switch (Player.players[i].Number) 
                {
                    case 1: Top_Player.Visibility= Visibility.Visible; TopText.Visibility = Visibility.Visible; PlayerController.p1 = true; break;
                    case 2: Bottom_Player.Visibility= Visibility.Visible; BottomText.Visibility = Visibility.Visible; PlayerController.p2 = true; break;
                    case 3: Left_Player.Visibility = Visibility.Visible; LeftText.Visibility = Visibility.Visible; PlayerController.p3 = true; break;
                    case 4: Right_Player.Visibility = Visibility.Visible; RightText.Visibility = Visibility.Visible; PlayerController.p4 = true; break;
                }
            }
            UpdatePot();
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
        private void GameStart_Click(object sender, RoutedEventArgs e)
        {
            GameStart.Visibility = Visibility.Collapsed;
            GameController.StartBetting();
            if (Player.players.Count == 1) 
            { 
                WinnerFold(Player.players[0]); 
            }
            UpdatePot();
            FlopButton();
        }
        
        public void UpdatePot()
        {
            CenterBox.Visibility = Visibility.Visible;
            string txt = $"Pot Currently at {GameController.pot} Gold";
            if (GameController.flop)
            {
                txt += "<br> Community Dice:" ;
                foreach(var dice in GameController.commDice)
                {
                    txt += $" {dice}";
                }
            }
            CenterBox.Text = txt;
            if (PlayerController.p1) TopText.Text = PlayerController.RetrievePlayer(1).Name + " " + PlayerController.RetrievePlayer(1).Gold + "Gold";
            if (PlayerController.p2) BottomText.Text = PlayerController.RetrievePlayer(2).Name + " " + PlayerController.RetrievePlayer(2).Gold + "Gold";
            if (PlayerController.p3) LeftText.Text = PlayerController.RetrievePlayer(3).Name + " " + PlayerController.RetrievePlayer(3).Gold + "Gold";
            if (PlayerController.p4) RightText.Text = PlayerController.RetrievePlayer(4).Name + " " + PlayerController.RetrievePlayer(4).Gold + "Gold"; 
        }

        private void WinnerFold(Player player)
        {
            player.Gold += GameController.pot;
            MessageBox.Show($"All Player but {player.Name} have folded. {player.Name} wins {GameController.pot} and now has {player.Gold}. Congratulations!!");
        }
        private void FlopButton()
        {
            Flop.Visibility = Visibility.Visible;
        }

        private void TurnButton()
        {
            Turn.Visibility = Visibility.Visible;
        }

        private void RiverButton()
        { 
            River.Visibility = Visibility.Visible;
        }
        private void Flop_Click(object sender, RoutedEventArgs e)
        {
            Flop.Visibility = Visibility.Collapsed;
            GameController.FlopRoll();
            GameController.flop = true;
            UpdatePot();
            FlopStart.Visibility = Visibility.Visible;
        }

        private void FlopStart_Click(object sender, RoutedEventArgs e)
        {
            FlopStart.Visibility=Visibility.Collapsed;          
            GameController.StartBetting();
            if (Player.players.Count == 1)
            {
                WinnerFold(Player.players[0]);
            }
            UpdatePot();
            TurnButton();

        }
        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            Turn.Visibility=Visibility.Collapsed;
            GameController.TurnRoll();
            UpdatePot();
            TurnStart.Visibility=Visibility.Visible;
        }
        private void TurnStart_Click(object sender, RoutedEventArgs e) 
        { 
            TurnStart.Visibility=Visibility.Collapsed;            
            GameController.StartBetting();
            if (Player.players.Count == 1)
            {
                WinnerFold(Player.players[0]);
            }
            UpdatePot();
            RiverButton();
        }

        private void River_Click(object sender, RoutedEventArgs e)
        {
            River.Visibility = Visibility.Collapsed;
            GameController.RiverRoll();
            UpdatePot();
            RiverStart.Visibility=Visibility.Visible;

        }

        private void RiverStart_Click(object sender, RoutedEventArgs e)
        {
            RiverStart.Visibility=Visibility.Collapsed;
            GameController.StartBetting();
            if (Player.players.Count == 1)
            {
                WinnerFold(Player.players[0]);
            }
            UpdatePot();
        }
    }
}
