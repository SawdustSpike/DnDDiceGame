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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }      

    private void Top_RollDice(object sender, RoutedEventArgs e)
        {
            
            string name = new InputBox("Enter Players Name").ShowDialog();
            int gold = GameController.GoldGetter();            
            var player1 = new Player() { Name= name, Gold = gold, Number = 1, };
            topText.Text = player1.Name + " " + player1.Gold + "Gold";
            if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }

        }
        private void Bottom_RollDice(object sender, RoutedEventArgs e)
        {
            string name = new InputBox("Enter Players Name").ShowDialog();
            int gold = GameController.GoldGetter();            
            var player2 = new Player() { Name = name, Gold = gold, Number = 2 };
            bottomText.Text = player2.Name + " " + player2.Gold + "Gold";
            if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
        }
        private void Left_RollDice(object sender, RoutedEventArgs e)
        {
            string name = new InputBox("Enter Players Name").ShowDialog();            
            int gold = GameController.GoldGetter();            
            var player3 = new Player() { Name = name, Gold = gold, Number = 3 };
            leftText.Text = player3.Name + " " + player3.Gold + "Gold";
            if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
        }
        private void Right_RollDice(object sender, RoutedEventArgs e)
        {
            string name = new InputBox("Enter Players Name").ShowDialog();
            int gold = GameController.GoldGetter();
            var player4 = new Player() { Name = name, Gold = gold, Number = 4 };
            rightText.Text = player4.Name + " " + player4.Gold + "Gold";
            if (Player.players.Count > 1) { StartReady(); } else { DisplayNames(); }
        }
        public void DisplayNames()
        {
            CenterBox.Visibility = Visibility.Visible;
            string ready = "Players Ready:";
            foreach (var player in Player.players) { ready += " " + player.Name + ","; };
            CenterBox.Text = ready;
        }
        public void StartReady()
        {
            DisplayNames();
            gameStart.Visibility= Visibility.Visible;
            

        }
        private void GameStart(object sender, RoutedEventArgs e)
        {
            var newForm = new Table(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
        //private void YesButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // YesButton Clicked! Let's hide our InputBox and handle the input text.
        //    InputBox.Visibility = System.Windows.Visibility.Collapsed;

        //    // Do something with the Input
        //    String input = InputTextBox.Text;
        //     // Add Input to our ListBox.

        //    // Clear InputBox.
        //    InputTextBox.Text = String.Empty;
            
        //}

        //private void NoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // NoButton Clicked! Let's hide our InputBox.
        //    InputBox.Visibility = System.Windows.Visibility.Collapsed;

        //    // Clear InputBox.
        //    InputTextBox.Text = String.Empty;
        //}
    }
}
