using System;
using System.Windows;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Jugador = 0;
        int Pc = 0;
        int Triunfos = 0;
        int Perdidas = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private int Aleatorio(int min, int max)
        {
            return (int)Math.Floor(new Random().NextDouble() * (max - min + 1) + min);
        }

        public static string Eleccion(int jugada)
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
                resultado = "Elección incorrecta";
            }

            return resultado;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(promptUser.Text, out Jugador) && Jugador >= 1 && Jugador <= 3)
            {
                Pc = Aleatorio(1, 3);
                MessageBox.Show("La PC elige " + Eleccion(Pc), "🎮");
                MessageBox.Show("Tú eliges " + Eleccion(Jugador), "🎮");

                if (Pc == Jugador)
                {
                    MessageBox.Show("EMPATADOS", "‼");
                }
                else if (Jugador == 1 && Pc == 3)
                {
                    MessageBox.Show("GANASTE", "🏆");
                    Triunfos++;
                }
                else if (Jugador == 2 && Pc == 1)
                {
                    MessageBox.Show("GANASTE", "🏆");
                    Triunfos++;
                }
                else if (Jugador == 3 && Pc == 2)
                {
                    MessageBox.Show("GANASTE", "🏆");
                    Triunfos++;
                }
                else
                {
                    MessageBox.Show("PERDISTE", "💢");
                    Perdidas++;
                }
            }
            else if (promptUser.Text == "")
            {
                MessageBox.Show("La caja de texto no puede estar vacía, elige uno de los números", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Solo puedes ingrear números (1 para piedra, 2 para papel y 3 para tijera)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            pcPuntosEtiqueta.Content = "Puntos de la PC: " + Perdidas;
            jugadorPuntosEtiqueta.Content = "Tu puntaje: " + Triunfos;
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

        private void promptUser_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}

