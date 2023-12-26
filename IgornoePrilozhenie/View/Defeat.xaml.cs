using System;
using System.Collections.Generic;
using System.IO;
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
using System.Text.Json;
using IOPath = System.IO.Path;

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

        //private RussianRouletteLogic _russianRouletteLogic;
        //public RussianRouletteLogic RussianRouletteLogicInstance
        //{

        //    get { return _russianRouletteLogic; }
        //    set
        //    {
        //        if (_russianRouletteLogic != value)
        //        {
        //            _russianRouletteLogic = value;
        //            // OnPropertyChanged(nameof(BlackJackLogicInstance));
        //        }
        //    }
        //}
       

        













        private void UpdateUI()
        {
            
            // lblOpponentScore.Content = $"Очки противника: {(blackJackLogic.DeveloperMode ? blackJackLogic.OpponentScore.ToString() : "скрыто")}";
            txtOpponentsDefeated.Text = $"{BlackJackLogic.OpponentsDefeated}";
            txtGamerPlus.Text = $"{BlackJackLogic.GamerPoint}";
            //txtOpponentsDefeated.Text = $"{RussianRouletteLogic.OpponentDefeated}";
            //txtGamerPlus.Text = $"{RussianRouletteLogic.GamersPoint}";
        }
        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            BlackJackLogic.GamerPoint = 0;
            BlackJackLogic.OpponentsDefeated = 0;
            //RussianRouletteLogic.OpponentDefeated = 0;
            //RussianRouletteLogic.GamersPoint = 0;
        }
        public Defeat()
        {
            InitializeComponent();
            
            UpdateUI();
            
        }
    }
}
