using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace DnDDiceGame
{
    public class ConfirmBox
    {

        Window Box = new Window();//window for the inputbox
        FontFamily font = new FontFamily("Tahoma");//font for the whole inputbox
        int FontSize = 30;//fontsize for the input
        StackPanel sp1 = new StackPanel();// items container
        string title = "ConfirmBox";//title as heading
        string boxcontent;//title
        string defaulttext = "";//default textbox content     
        string nobuttontext = "NO";
        string yesbuttontext = "Yes";
        Brush BoxBackgroundColor = Brushes.GreenYellow;// Window Background
        Brush InputBackgroundColor = Brushes.Ivory;// Textbox Background
        bool clicked = false;
        TextBox confirm = new TextBox();
        Button yes = new Button();
        Button no = new Button();
        bool confirmed = false;
        

        public ConfirmBox(string content)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            windowdef();
        }


        public ConfirmBox(string content, string Htitle, string DefaultText)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            try
            {
                title = Htitle;
            }
            catch
            {
                title = "Error!";
            }
            try
            {
                defaulttext = DefaultText;
            }
            catch
            {
                DefaultText = "Error!";
            }
            windowdef();
        }

        public ConfirmBox(string content, string Htitle, string Font, int Fontsize)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            try
            {
                font = new FontFamily(Font);
            }
            catch { font = new FontFamily("Tahoma"); }
            try
            {
                title = Htitle;
            }
            catch
            {
                title = "Error!";
            }
            if (Fontsize >= 1)
                FontSize = Fontsize;
            windowdef();
        }


        private void windowdef()// window building - check only for window size
        {
            Box.Height = 300;// Box Height
            Box.Width = 300;// Box Width
            Box.Background = BoxBackgroundColor;
            Box.HorizontalAlignment= HorizontalAlignment.Center; 
            Box.VerticalAlignment= VerticalAlignment.Center;
            Box.Title = title;
            Box.Content = sp1;
            Box.Closing += Box_Closing;
            TextBlock content = new TextBlock();
            content.TextWrapping = TextWrapping.Wrap;
            content.Background = null;
            content.HorizontalAlignment = HorizontalAlignment.Center;            
            content.Text = boxcontent;
            content.FontFamily = font;
            content.FontSize = FontSize;
            sp1.Children.Add(content);

            no.Width = 70;
            no.Height = 30;
            no.Click += no_Click;
            no.Content = nobuttontext;
            no.HorizontalAlignment = HorizontalAlignment.Center;
            sp1.Children.Add(no);
            yes.Width = 70;
            yes.Height = 30;
            yes.Click += yes_Click;
            yes.Content = yesbuttontext;
            yes.HorizontalAlignment = HorizontalAlignment.Center;
            sp1.Children.Add(yes);

        }

        void Box_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!clicked)
                e.Cancel = true;
        }

        //private void input_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if ((sender as TextBox).Text == defaulttext )
        //    {
        //        (sender as TextBox).Text = null;
                
        //    }
        //}

        void yes_Click(object sender, RoutedEventArgs e)
        {
            clicked = true;
            confirmed= true;
            Box.Close();
            clicked = false;
        }

        void no_Click(object sender, RoutedEventArgs e)
        {
            clicked = true;
            confirmed = false;
            Box.Close();            
            clicked = false;
        }
        

        public bool ShowDialog()
        {
            Box.ShowDialog();
            return confirmed;
        }
    }
}