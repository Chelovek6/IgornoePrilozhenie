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
        private bool isSaving = false;

        private async void BtnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка, чтобы избежать множественных вызовов
                if (isSaving)
                    return;

                isSaving = true;

                string userName = NameTextBox.Text;
                int score1 = BlackJackLogic.OpponentsDefeated;
                int score2 = BlackJackLogic.GamerPoint;

                // Определение абсолютного пути к файлу
                string directoryPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsData");
                string filePath = System.IO.Path.Combine(directoryPath, "user.json");

                // Создание директории, если она не существует
                Directory.CreateDirectory(directoryPath);

                // Создайте экземпляр PlayerData с полученными данными
                GameResults playerData = new GameResults(userName, score1, score2);

                // Сохранение данных
                string jsonData = JsonSerializer.Serialize(playerData);

                // Логирование данных для отладки
                Console.WriteLine($"UserName: {userName}, Score1: {score1}, Score2: {score2}");

                // Явный сброс буфера и закрытие файла
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    await sw.WriteAsync(jsonData);
                }

                Console.WriteLine("Data has been saved to file");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            finally
            {
                isSaving = false;
            }
        }












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
            BtnSaveResult.Click += BtnSaveResult_Click;
        }
    }
}
