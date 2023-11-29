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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие приложения
            Application.Current.Shutdown();
        }
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новое окно
            ChooseGame chooseGameWindow = new ChooseGame();

            // Закрываем текущее окно
            this.Close();

            // Открываем новое окно
            chooseGameWindow.Show();
        }
        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("sss");
            // Создайте новый экземпляр вашей страницы
            Results Res = new Results();

            // Получите NavigationService из текущего окна или фрейма
            NavigationService navigationService = NavigationService.GetNavigationService(this);

            // Перейдите на новую страницу
            if (navigationService != null)
            {
                navigationService.Navigate(Res);
            }
        }
        
    }
}
