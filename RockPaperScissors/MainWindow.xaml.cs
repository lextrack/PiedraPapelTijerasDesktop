using System;
using System.Windows;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int jugador = 0;
        int pc = 0;
        int triunfos = 0;
        int perdidas = 0;

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

            if (int.TryParse(promptUser.Text, out jugador) && jugador >= 1 && jugador <= 3)
            {
                pc = Aleatorio(1, 3);
                MessageBox.Show("PC elige " + Eleccion(pc), "🎮");
                MessageBox.Show("Tú eliges " + Eleccion(jugador), "🎮");

                if (pc == jugador)
                {
                    MessageBox.Show("EMPATADOS", "‼");
                }
                else if (jugador == 1 && pc == 3)
                {
                    MessageBox.Show("GANASTE", "🏆");
                    triunfos++;
                }
                else if (jugador == 2 && pc == 1)
                {
                    MessageBox.Show("GANASTE", "🏆");
                    triunfos++;
                }
                else if (jugador == 3 && pc == 2)
                {
                    MessageBox.Show("GANASTE", "🏆");
                    triunfos++;
                }
                else
                {
                    MessageBox.Show("PERDISTE", "💢");
                    perdidas++;
                }
            }
            else
            {
                MessageBox.Show("Solo puedes ingrear numeros (1 para piedra, 2 para papel, 3 para tijera)");
            }
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
    }
}

