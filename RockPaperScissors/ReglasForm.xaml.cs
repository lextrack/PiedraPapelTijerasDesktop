﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for ReglasForm.xaml
    /// </summary>
    public partial class ReglasForm : Window
    {
        public ReglasForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.From = 0;
            fadeAnimation.To = 1;
            fadeAnimation.Duration = TimeSpan.FromMilliseconds(300);
            fadeAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.From = -500;
            moveAnimation.To = 0;
            moveAnimation.Duration = TimeSpan.FromMilliseconds(300);
            moveAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            TranslateTransform moveTransform = new TranslateTransform();
            GroupTextBlockReglas.RenderTransform = moveTransform;

            Storyboard sb = new Storyboard();
            sb.Children.Add(fadeAnimation);
            sb.Children.Add(moveAnimation);
            Storyboard.SetTarget(fadeAnimation, GroupTextBlockReglas);
            Storyboard.SetTarget(moveAnimation, GroupTextBlockReglas);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(UIElement.Opacity)"));
            Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            sb.Begin();
        }
    }
}
