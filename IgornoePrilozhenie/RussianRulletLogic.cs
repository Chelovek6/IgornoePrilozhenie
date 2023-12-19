using IgornoePrilozhenie.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IgornoePrilozhenie
{
    public class RussianRouletteLogic
    {
        private int chamberCount;
        private double currentChance;
        private Random random;
        private bool isPlayerTurn; // Переменная, определяющая, чей ход

        public int GamersPoint { get; private set; }
        public int OpponentDefeated { get; private set; }
        private bool isFirstTurn = true;
        public int СhamberCount { get { return chamberCount; } }

        public RussianRouletteLogic()
        {
            random = new Random();
            GamersPoint = 0;
            OpponentDefeated = 0;
            StartGame(); // Добавляем вызов метода StartGame
        }

        public void StartGame()
        {
            chamberCount = 6;
            currentChance = 1.0 / chamberCount;
            isPlayerTurn = random.Next(2) == 0;
            if (isFirstTurn)
            {
                isFirstTurn = false;
                isPlayerTurn = random.Next(2) == 0;
            }
            else
            {
                isPlayerTurn = false; // В последующих ходах играет всегда противник
            }
        }

        public void PlayTurn()
        {
            // Ход игрока
            if (isPlayerTurn)
            {
                if (random.NextDouble() < currentChance)
                {
                    ShowDefeatScreen();
                    return;
                }

                chamberCount--;

                if (chamberCount == 0)
                {
                    GamersPoint += CalculatePoints(1.0 / chamberCount);
                    OpponentDefeated++;
                    StartGame();
                    return;
                }
            }

            // Ход противника
            else
            {
               MessageBox.Show("Соперник ходит");
                if (random.NextDouble() < currentChance)
                {
                    GamersPoint += CalculatePoints(1.0 / chamberCount);
                    OpponentDefeated++;
                    StartGame();
                    return;
                }

                chamberCount--;

                if (chamberCount == 0)
                {
                    ShowDefeatScreen();
                    return;
                }
            }

            isPlayerTurn = !isPlayerTurn; // Меняем ход
        }

        private int CalculatePoints(double chance)
        {
            if (Math.Abs(chance - 1.0 / 6) < 1e-10) return 1000;
            if (Math.Abs(chance - 1.0 / 5) < 1e-10) return 800;
            if (Math.Abs(chance - 1.0 / 4) < 1e-10) return 600;
            if (Math.Abs(chance - 1.0 / 3) < 1e-10) return 400;
            if (Math.Abs(chance - 1.0 / 2) < 1e-10) return 200;
            return 100;
        }

        private void ShowDefeatScreen()
        {
            LocatorView.CurrentView.UserControl.Content = new Defeat();
        }
    }

}
