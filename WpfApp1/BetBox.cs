﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace WpfApp1
{
    public class BetBox
    {

        Window Box = new Window();//window for the inputbox
        FontFamily font = new FontFamily("Tahoma");//font for the whole inputbox
        int FontSize = 30;//fontsize for the input
        StackPanel sp1 = new StackPanel();// items container
        string title = "InputBox";//title as heading
        string boxcontent;//title
        string defaulttext = "";//default textbox content
        string errormessage = "Invalid answer";//error messagebox content
        string errortitle = "Error";//error messagebox heading title
        /*string okbuttontext = "OK";*///Ok button content
        string callbuttontext = "Call";
        string checkbuttontext = "Check";
        string raisebuttontext = "Raise";
        string foldbuttontext = "Fold";
        Brush BoxBackgroundColor = Brushes.GreenYellow;// Window Background
        Brush InputBackgroundColor = Brushes.Ivory;// Textbox Background
        bool clicked = false;
        TextBox input = new TextBox();        
        Button check = new Button();
        Button call = new Button();
        Button raise = new Button();
        Button fold = new Button();
        bool canCheck = true;
        bool inputreset = false;

        public BetBox(string content)
        {
            try
            {
                boxcontent = content;
            }
            catch { boxcontent = "Error!"; }
            Betwindowdef();
        }

        

        public BetBox(string content, string Htitle, string DefaultText)
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
            Betwindowdef();
        }

        public BetBox(string content, string Htitle, string Font, int Fontsize)
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
            Betwindowdef();
        }

        private void Betwindowdef()// window building - check only for window size
        {
            Box.Height = 300;// Box Height
            Box.Width = 300;// Box Width
            Box.Background = BoxBackgroundColor;
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

            input.Background = InputBackgroundColor;
            input.FontFamily = font;
            input.FontSize = FontSize;
            input.HorizontalAlignment = HorizontalAlignment.Center;
            input.VerticalAlignment = VerticalAlignment.Bottom;
            input.Text = defaulttext;
            input.MinWidth = 200;
            input.MouseEnter += input_MouseDown;
            sp1.Children.Add(input);
            check.Width = 70;
            check.Height = 30;
            check.Click += check_Click;
            check.Content = checkbuttontext;
            check.HorizontalAlignment = HorizontalAlignment.Right;
            check.VerticalAlignment = VerticalAlignment.Bottom;
            call.Width = 70;
            call.Height = 30;
            call.Click += call_Click;
            call.Content = callbuttontext;
            call.HorizontalAlignment = HorizontalAlignment.Right;
            call.VerticalAlignment = VerticalAlignment.Bottom;
            if (canCheck) sp1.Children.Add(check);
            else sp1.Children.Add(call);
            raise.Width = 70;
            raise.Height = 30;
            raise.Click += raise_Click;
            raise.Content = raisebuttontext;
            raise.HorizontalAlignment = HorizontalAlignment.Left;
            raise.VerticalAlignment = VerticalAlignment.Bottom;
            sp1.Children.Add(raise);
            fold.Width = 70;
            fold.Height = 30;
            fold.Click += fold_Click;
            fold.Content = foldbuttontext;
            fold.HorizontalAlignment = HorizontalAlignment.Center;
            fold.VerticalAlignment = VerticalAlignment.Bottom;
            sp1.Children.Add(fold);
        }

        void Box_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!clicked)
                e.Cancel = true;
        }

        private void input_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TextBox).Text == defaulttext && inputreset == false)
            {
                (sender as TextBox).Text = null;
                inputreset = true;
            }
        }
       
        void check_Click(object sender, RoutedEventArgs e)
        {

        }

        void raise_Click(object sender, RoutedEventArgs e)
        {

        }
        void call_Click(object sender, RoutedEventArgs e)
        {

        }

        void fold_Click(object sender, RoutedEventArgs e)
        {

        }

        public string ShowDialog()
        {
            Box.ShowDialog();
            return input.Text;
        }
    }
}