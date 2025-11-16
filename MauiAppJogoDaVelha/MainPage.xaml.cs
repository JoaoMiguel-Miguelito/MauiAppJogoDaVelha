namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        int placarX = 0; // Cria uma variavel para os pontos do "X"
        int placarO = 0; // Cria uma variavel para os pontos do "O"
        int jogadas = 0; // Conta quantas rodadas foram jogadas

        public MainPage()
        {
            InitializeComponent();
            // Inicializa o label de vez
            lblVez.Text = $"Vez de {vez}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Veficação para saber se os botões estão vazios
            if (!string.IsNullOrEmpty(btn.Text))
            {
                return; 
            }

            btn.IsEnabled = false;

            if (vez == "X")
            {
                btn.Text = "X";
                jogadas++;

                // Verifica se "X" venceu
                if (VerificarGanhador("X"))
                {
                    DisplayAlert("Parabéns!", "O X ganhou!", "OK");
                    placarX++;
                    lblPlacar.Text = $"X: {placarX} | O: {placarO}";
                    Zerar();
                    return;
                }

                vez = "O";
            }
            else
            {
                btn.Text = "O";
                jogadas++;

                // Verifica se "O" venceu
                if (VerificarGanhador("O"))
                {
                    DisplayAlert("Parabéns!", "O O ganhou!", "OK");
                    placarO++;
                    lblPlacar.Text = $"X: {placarX} | O: {placarO}";
                    Zerar();
                    return;
                }

                vez = "X";
            }

            // Verifica Empate
            if (jogadas == 9)
            {
                DisplayAlert("Empate!", "Deu Velha! Ninguém ganhou.", "OK");
                Zerar();
            }

            // Mostra quem vai jogar naquela rodada
            lblVez.Text = $"Vez de {vez}";

        } // Fecha método

        //Faz a verifiação com base no jogar para uma maior precisão nos valores 
        private bool VerificarGanhador(string jogador)
        {
            
            if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) return true; 
            if (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) return true; 
            if (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) return true; 

            
            if (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) return true; 
            if (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) return true; 
            if (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) return true; 

            
            if (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) return true; 
            if (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador) return true;

            return false;
        }
        

        void Zerar()
        {
            
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";
            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;

            
            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";
            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;

            
            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";
            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            
            vez = "X";
            jogadas = 0;
            lblVez.Text = $"Vez de {vez}";
        }

    } // Fecha Classe
} // Fecha Namespace