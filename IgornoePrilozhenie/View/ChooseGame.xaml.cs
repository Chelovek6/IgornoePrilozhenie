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
using System.Windows.Shapes;

namespace IgornoePrilozhenie
{
    /// <summary>
    /// Логика взаимодействия для ChooseGame.xaml
    /// </summary>
    public partial class ChooseGame : Window
    {
        public ChooseGame()
        {
            InitializeComponent();
        }
        private void BlackJackButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь вы можете добавить логику для режима BlackJack
        }

        private void RussianRouletteButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь вы можете добавить логику для режима Русская Рулетка
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
            Menu menuWindow = new Menu();
            menuWindow.Show();
            this.Close();
        }
    }
}
