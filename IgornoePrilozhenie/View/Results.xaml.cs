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
using System.IO;


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
            ReadAllLinesFromFile();
        }

        private void ReadAllLinesFromFile()
        {
            try
            {
                string filePath = "ResultsData/GamersResult.txt";
                string[] lines = File.ReadAllLines(filePath);

                List<GameResult> results = new List<GameResult>();

                foreach (string line in lines)
                {
                    string[] values = line.Split('\t'); // предполагается, что данные разделены табуляцией
                    if (values.Length == 3)
                    {
                        results.Add(new GameResult
                        {
                            PlayerName = values[0],
                            OpponentsDefeated = int.Parse(values[1]),
                            GamerPoint = int.Parse(values[2])
                        });
                    }
                }

                dataGrid1.ItemsSource = results; // привязываем коллекцию к DataGrid
            }
            catch (Exception ex)
            {
                // Обработка исключений при чтении файла.
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }


    }
}
