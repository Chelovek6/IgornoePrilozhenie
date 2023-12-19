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
    /// Логика взаимодействия для Defeat.xaml
    /// </summary>
    public partial class Defeat : UserControl
    {
        private BlackJackLogic _blackJackLogic;
        public BlackJackLogic BlackJackLogicInstance
        {

            get { return _blackJackLogic; }
            set
            {
                if (_blackJackLogic != value)
                {
                    _blackJackLogic = value;
                   // OnPropertyChanged(nameof(BlackJackLogicInstance));
                }
            }
        }
        private void UpdateUI()
        {
            
            // lblOpponentScore.Content = $"Очки противника: {(blackJackLogic.DeveloperMode ? blackJackLogic.OpponentScore.ToString() : "скрыто")}";
            txtOpponentsDefeated.Text = $"{BlackJackLogic.OpponentsDefeated}";
            txtGamerPlus.Text = $"{BlackJackLogic.GamerPoint}";
        }
        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            BlackJackLogic.GamerPoint = 0;
            BlackJackLogic.OpponentsDefeated = 0;   
        }
        public Defeat()
        {
            InitializeComponent();

            UpdateUI();
        }
    }
}
