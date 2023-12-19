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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : UserControl
    {
        public Results()
        {
            InitializeComponent();
            LoadGameResults();
        }

        private void LoadGameResults()
        {
            // Путь к вашему файлу с результатами игры
            string filePath = "ResultsData/GamersResult";

            try
            {
                // Чтение всех строк из файла
                string[] lines = filePat.ReadAllLines(filePath);

                // Обработка строк (возможно, добавление их в таблицу данных или другие операции)
                foreach (string line in lines)
                {
                    // Ваш код для обработки каждой строки
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений, если возникнут проблемы при чтении файла
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }

}
