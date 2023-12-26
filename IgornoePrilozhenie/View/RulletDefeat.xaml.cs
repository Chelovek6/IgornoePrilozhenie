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
    /// Логика взаимодействия для RulletDefeat.xaml
    /// </summary>
    public partial class RulletDefeat : UserControl
    {
        public RulletDefeat()
        {
            InitializeComponent();
            UpdateUI();
        }
        private RussianRouletteLogic _russianRouletteLogic;
        public RussianRouletteLogic RussianRouletteLogicInstance
        {

            get { return _russianRouletteLogic; }
            set
            {
                if (_russianRouletteLogic != value)
                {
                    _russianRouletteLogic = value;
                    // OnPropertyChanged(nameof(BlackJackLogicInstance));
                }
            }
        }
        private void UpdateUI()
        {

            
            
            txtOpponentsDefeated.Text = $"{RussianRouletteLogic.OpponentDefeated}";
            txtGamerPlus.Text = $"{RussianRouletteLogic.GamersPoint}";
        }
        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            
            RussianRouletteLogic.OpponentDefeated = 0;
            RussianRouletteLogic.GamersPoint = 0;
        }
    }
}
