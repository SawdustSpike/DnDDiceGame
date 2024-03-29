﻿using System;
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

namespace BauldersHoldem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //creates the opening window. if this is your second game it will autoload characters from last game.
            InitializeComponent();
            DisplayNames();
            if (Player.players.Count > 1) { StartReady(); }
        }      
        private void Bottom_RollDice(object sender, RoutedEventArgs e)
        {
            // one for each character, Alternates between creating character and deleting them.
            // If two characters are created it will give you the option to start the game
            if (PlayerController.p3)
            {
                var player = PlayerController.RetrievePlayer(3);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p3 = false;
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
                PlayerController.p3 = true;
                string name = new InputBox("Enter Players Name").ShowDialog();
                int gold = GameController.GoldGetter();
                var player3 = new Player() { Name = name, Gold = gold, Number = 3 };
                bottomText.Text = player3.Name + " " + player3.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }
        }
        public void DisplayNames()
        {
            //adds names to center text box
            CenterBox.Visibility = Visibility.Visible;
            string ready = "Players Ready:";
            foreach (var player in Player.players) { ready += " " + player.Name + ","; };
            CenterBox.Text = ready.TrimEnd(',');
        }
        private void GameStart(object sender, RoutedEventArgs e)
        {
            //sets up the game and send user to next window, with some animation effects
            GameController.IndividualRoll(); //rolls seceret dice for every player            
            GameController.AssignStartingPlayer(); //Randomly Assigns starting Player
            Player.players = Player.players.OrderBy(p => p.Number).ToList(); // orders player by player number to help rotation
            var newForm = new Table(); // Creates game table
            newForm.Opacity = 0; // starts new table out as black
            newForm.Show();
            DoubleAnimation da = new DoubleAnimation(); //animation to fade table into view
            da.From = 0;
            da.To = 1;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            newForm.BeginAnimation(OpacityProperty, da);
            this.Close();
        }
        private void Left_RollDice(object sender, RoutedEventArgs e)
        {
            if (PlayerController.p4)
            {
                var player = PlayerController.RetrievePlayer(4);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p4 = false;
                    leftText.Text = "Click Here to Join";
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
                leftText.Text = player4.Name + " " + player4.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }
        }
        private void Right_RollDice(object sender, RoutedEventArgs e)
        {
            if (PlayerController.p2)
            {
                var player = PlayerController.RetrievePlayer(2);
                if (new ConfirmBox($"Are you sure you want to remove {player.Name} from the game?").ShowDialog())
                {
                    PlayerController.p2 = false;
                    rightText.Text = "Click Here to Join";
                    Player.players.Remove(player);
                    DisplayNames();
                    if (Player.players.Count < 2) StopReady();
                }
                else return;

            }
            else
            {
                PlayerController.p2 = true;
                string name = new InputBox("Enter Players Name").ShowDialog();
                int gold = GameController.GoldGetter();
                var player2 = new Player() { Name = name, Gold = gold, Number = 2 };
                rightText.Text = player2.Name + " " + player2.Gold + " Gold" + Environment.NewLine + "Click to Remove Player";
                if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
            }
        }
        public void StartReady()
        {
            // makes start button appear
            DisplayNames();
            gameStart.Visibility = Visibility.Visible;
        }
        public void StopReady()
        {
            //if player is deleted, hides the start button
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
