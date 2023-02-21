using System;
using System.Windows;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Player = 0;
        int Pc = 0;
        int Triumphs = 0;
        int Loses = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private int Rand(int min, int max)
        {
            return (int)Math.Floor(new Random().NextDouble() * (max - min + 1) + min);
        }

        public static string Decision(int jugada)
        {
            string resultado = "";

            if (jugada == 1)
            {
                resultado = "Piedra 🧱";
            }
            else if (jugada == 2)
            {
                resultado = "Papel 📄";
            }
            else if (jugada == 3)
            {
                resultado = "Tijera ✂";
            }
            else
            {
                resultado = "Decisión incorrecta";
            }

            return resultado;
        }

        public void OperationsCheck()
        {
            if (int.TryParse(promptUser.Text, out Player) && Player >= 1 && Player <= 3)
            {
                Pc = Rand(1, 3);

                WinAlertRound customMessageBox = new WinAlertRound();
                customMessageBox.SetMessagePC("La PC elige " + Decision(Pc));
                customMessageBox.ShowDialog();

                customMessageBox = new WinAlertRound();
                customMessageBox.SetMessagePlayer("Tú eliges " + Decision(Player));
                customMessageBox.ShowDialog();

                if (Pc == Player)
                {
                    customMessageBox = new WinAlertRound();
                    customMessageBox.SetMessageTie("EMPATADOS");
                    customMessageBox.ShowDialog();
                }
                else if (Player == 1 && Pc == 3)
                {
                    customMessageBox = new WinAlertRound();
                    customMessageBox.SetMessageWin("GANASTE");
                    customMessageBox.ShowDialog();
                    Triumphs++;
                }
                else if (Player == 2 && Pc == 1)
                {
                    customMessageBox = new WinAlertRound();
                    customMessageBox.SetMessageWin("GANASTE");
                    customMessageBox.ShowDialog();
                    Triumphs++;
                }
                else if (Player == 3 && Pc == 2)
                {
                    customMessageBox = new WinAlertRound();
                    customMessageBox.SetMessageWin("GANASTE");
                    customMessageBox.ShowDialog();
                    Triumphs++;
                }
                else
                {
                    customMessageBox = new WinAlertRound();
                    customMessageBox.SetMessageLose("PERDISTE");
                    customMessageBox.ShowDialog();
                    Loses++;
                }
            }
            else if (promptUser.Text == "")
            {
                MessageBox.Show("La caja de texto no puede estar vacía, elige uno de los números", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("No puedes ingresar letras ni simbolos, solo números", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            pcPuntosEtiqueta.Content = "Puntaje del PC: " + Loses;
            jugadorPuntosEtiqueta.Content = "Tu puntaje: " + Triumphs;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OperationsCheck();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void rulesbtn_Click(object sender, RoutedEventArgs e)
        {
            ReglasForm newReglasForm = new();
            newReglasForm.Show();
        }

        private void Aboutbtn_Click(object sender, RoutedEventArgs e)
        {
            About newabout = new();
            newabout.ShowDialog();
        }

        private void promptUser_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(promptUser.Text, out int number))
            {
                NumberDescriptionTextBlock.Text = GetNumberDescription(number);
            }
            else
            {
                NumberDescriptionTextBlock.Text = "";
            }
        }

        private string GetNumberDescription(int number)
        {
            switch (number)
            {
                case 1:
                    return "Haz seleccionado piedra 🧱";
                case 2:
                    return "Haz seleccionado papel 📄";
                case 3:
                    return "Haz seleccionado tijera ✂";
                // Agrega más casos según sea necesario
                default:
                    return "";
            }
        }
    }
}

