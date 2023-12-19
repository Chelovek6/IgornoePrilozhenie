using IgornoePrilozhenie.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для RussianRullet.xaml
    /// </summary>
    public partial class RussianRullet : UserControl
    {
        private RussianRouletteLogic gameLogic;
        public RussianRullet()
        {
            InitializeComponent();
            gameLogic = new RussianRouletteLogic();
            DataContext = gameLogic;
            UpdateUI();
        }
        private void OnPlayTurnClick(object sender, RoutedEventArgs e)
        {
            gameLogic.PlayTurn();
            UpdateUI();
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            LocatorView.CurrentView.UserControl.Content = new UserControl1();
        }
        
        public class ViewModel
        {
            public string GameInfo => $"Очки игрока: {logic.GamersPoint}, Побед соперника: {logic.OpponentDefeated}";

            private RussianRouletteLogic logic;

            public ViewModel(RussianRouletteLogic logic)
            {
                this.logic = logic;
            }
        }
        private void UpdateUI()
        {
            TxtchamberCount.Text = $"1/{gameLogic.СhamberCount}";
            TxtOpponentDefeated.Text = $"{gameLogic.OpponentDefeated}";
            TxtGamersPoint.Text = $"{gameLogic.GamersPoint}";
        }
    }
}
