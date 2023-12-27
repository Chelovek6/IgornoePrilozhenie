using IgornoePrilozhenie.DataContext;
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
        
        private int currentCardIndex = 0;
        private Image previousCardImage;
        private void BtnDrawCard_Click(object sender, RoutedEventArgs e)
        {
            if (currentCardIndex < 11)
            {
                // Скрываем предыдущую картинку
                if (previousCardImage != null)
                {
                    previousCardImage.Visibility = Visibility.Collapsed;
                }

                // Формируем имя текущей картинки
                string currentImageName = $"imgCard{currentCardIndex + 1}";

                // Находим элемент с этим именем и делаем его видимым
                Image currentCardImage = (Image)FindName(currentImageName);
                currentCardImage.Visibility = Visibility.Visible;

                previousCardImage = currentCardImage; // Сохраняем ссылку на текущую картинку
                currentCardIndex++; // Увеличиваем индекс для следующей карты

                // Вызываем соответствующий метод в BlackJackLogic
                blackJackLogic.PlayerDrawCard();
                imgPlayer.Source = new BitmapImage(new Uri("/IgornoePrilozhenie;component/Imeges/ManCards.png", UriKind.Relative));
                UpdateUI();
            }
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            BlackJackLogic.GamerPoint = 0;
            BlackJackLogic.OpponentsDefeated = 0;
            LocatorView.CurrentView.UserControl.Content = new UserControl1();
        }

        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            // Скрываем все картинки
            for (int i = 1; i <= 11; i++)
            {
                string imageName = $"imgCard{i}";
                Image cardImage = (Image)FindName(imageName);
                cardImage.Visibility = Visibility.Collapsed;
            }

            // Обнуляем переменную для предыдущей картинки
            previousCardImage = null;
             currentCardIndex = 0;
        // Вызываем соответствующий метод в BlackJackLogic
        blackJackLogic.OpponentTurn();
            blackJackLogic.DeclareWinner();
            UpdateUI();
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
