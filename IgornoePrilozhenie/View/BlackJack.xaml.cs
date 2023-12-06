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


namespace IgornoePrilozhenie
{
    /// <summary>
    /// Логика взаимодействия для BlackJack.xaml
    /// </summary>
    public partial class BlackJack : UserControl
    {
        private BlackJackLogic blackJackLogic;
        public BlackJack()
        {
            InitializeComponent();
            blackJackLogic = new BlackJackLogic();
           

        }
        private void BtnDrawCard_Click(object sender, RoutedEventArgs e)
        {
            blackJackLogic.PlayerDrawCard();
            UpdateUI();
        }
        

        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            blackJackLogic.OpponentTurn();
            blackJackLogic.DeclareWinner();
            UpdateUI();
        }
        private void OnOpponentWins(object sender, EventArgs e)
        {
            // Логика для случая победы противника
            Defeat userControl4 = new Defeat();
            // ... (отобразите userControl4 в вашем UI)
        }
        
        private void UpdateUI()
        {
            txtPlayerScore.Text = $"Ваши очки: {blackJackLogic.PlayerScore}";
            // lblOpponentScore.Content = $"Очки противника: {(blackJackLogic.DeveloperMode ? blackJackLogic.OpponentScore.ToString() : "скрыто")}";
            txtOpponentsDefeated.Text = $"{BlackJackLogic.OpponentsDefeated}";
            txtGamerPlus.Text = $"{BlackJackLogic.GamerPoint}";
        }
        private void StartNewGame()
        {
            blackJackLogic.Start();
            // Здесь можете обновить интерфейс согласно начальному состоянию игры
        }
        
        
       
    }

    public class Card
    {
        public int Value { get; set; }
    }

}
