using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for WinAlertRound.xaml
    /// </summary>
    public partial class WinAlertRound : Window
    {
        private DispatcherTimer timer;

        public WinAlertRound()
        {
            InitializeComponent();
        }

        public void TimerAnimation()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        public void SetMessagePC(string message)
        {
            messageLabelPC.Content = message;
        }

        public void SetMessagePlayer(string message)
        {
            messageLabelPlayer.Content = message;
        }

        public void SetMessageWin(string message)
        {
            messageText.Text = message;
            messageImage.Source = new BitmapImage(new Uri("/Resources/winner.png", UriKind.Relative));
        }

        public void SetMessageLose(string message)
        {
            messageText.Text = message;
            messageImage.Source = new BitmapImage(new Uri("/Resources/lose.png", UriKind.Relative));
        }

        public void SetMessageTie(string message)
        {
            messageText.Text = message;
            messageImage.Source = new BitmapImage(new Uri("/Resources/tied.png", UriKind.Relative));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TimerAnimation();
            Storyboard sb2 = (Storyboard)FindResource("SweepAnimationLabelPC");
            sb2.Completed += OnLabelPCAnimationCompleted;
            sb2.Begin();
        }

        private void OnLabelPCAnimationCompleted(object sender, EventArgs e)
        {
            TimerAnimation();
            Storyboard sb = (Storyboard)FindResource("SweepAnimationLabelPlayer");
            sb.Completed += OnLabelPlayerAnimationCompleted;
            sb.Begin();
        }

        private void OnLabelPlayerAnimationCompleted(object sender, EventArgs e)
        {
            TimerAnimation();
            Storyboard sb = (Storyboard)FindResource("SweepAnimationImg");
            sb.Completed += OnImageAnimationCompleted;
            sb.Begin();
        }

        private void OnImageAnimationCompleted(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}