using GalaSoft.MvvmLight.Command;
using IgornoePrilozhenie.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace IgornoePrilozhenie
{
    public class BlackJackLogic 
    {
        

        private List<Card> deck;
        private int playerScore;
        private int opponentScore;
       
        private bool developerMode; // Флаг для отслеживания очков противника (разработчик)
        public bool defeat = false;
        public static int GamerPoint = 0;
        public static int OpponentsDefeated = 0;
        private int currentCardIndex;

       
        public BlackJackLogic()
        {
            deck = GenerateDeck();
            ShuffleDeck();
            playerScore = 0;
            opponentScore = 0;
            developerMode = true;
        }
        
        public int PlayerScore => playerScore;
        public int OpponentScore => opponentScore;
        public bool DeveloperMode => developerMode;

        public void Start()
        {
            //MessageBox.Show("Начинаем новую игру!");

            // Раздача начальных карт
            playerScore += DrawCard();
            opponentScore += DrawCard();
        }

        public void PlayerDrawCard()
        {
            playerScore += DrawCard();
        }

        public void OpponentTurn()
        {
            //MessageBox.Show("Ход противника...");

            // Логика хода противника
            while ((opponentScore < 10 || opponentScore == 11) || (opponentScore < 17 && opponentScore != 11))
            {
                int cardValue = DrawCard();
                if (cardValue == 0)
                {
                    //MessageBox.Show("Карты закончились!");
                    break;
                }
                opponentScore += cardValue;
            }

           // MessageBox.Show($"Противник закончил ход со счетом {opponentScore}");
            if (opponentScore > 21)
            {
                //MessageBox.Show("Противник перебрал. Вы побеждаете!");
            }
        }

        public void DeclareWinner()
        {
            // Логика объявления победителя
            if (playerScore > 21 && opponentScore > 21)
            {
                // Оба игрока перебрали, побеждает тот, кто ближе к 21
                if (Math.Abs(21 - playerScore) < Math.Abs(21 - opponentScore))
                {
                    //MessageBox.Show("Вы побеждаете!");
                    RestartGame();
                    OpponentsDefeated++;
                    GamerPoint = GamerPoint + 500;
                }
                else
                {
                    //MessageBox.Show("Противник побеждает.");
                    
                    LocatorView.CurrentView.UserControl.Content = new Defeat();
                }
            }
            else if ((playerScore == 21 && opponentScore != 21) || (playerScore < 21 && opponentScore > 21) || (playerScore > opponentScore && playerScore <= 21))
            {
                //MessageBox.Show("Вы побеждаете!");
                RestartGame();
                OpponentsDefeated++;
                GamerPoint = GamerPoint + 1000;
            }
            else if (playerScore == opponentScore)
            {
                //MessageBox.Show("Ничья. Игра перезапускается.");
                RestartGame();
                GamerPoint = GamerPoint + 100;
            }
            else
            {
               // MessageBox.Show("Противник побеждает.");
                
                
                LocatorView.CurrentView.UserControl.Content = new Defeat();
            }
           
        }

        public void RestartGame()
        {
           // MessageBox.Show($"Вы победили {OpponentsDefeated} противников.");
           // Console.WriteLine("Начинаем новую игру!");
            playerScore = 0;
            opponentScore = 0;
            deck = GenerateDeck();
            ShuffleDeck();
        }

        private List<Card> GenerateDeck()
        {
            List<Card> newDeck = new List<Card>();

            for (int i = 1; i <= 11; i++)
            {
                newDeck.Add(new Card { Value = i });
            }

            return newDeck;
        }

        private void ShuffleDeck()
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        private int DrawCard()
        {
            if (deck.Count > 0)
            {
                int cardValue = deck[0].Value;
                deck.RemoveAt(0);
                return cardValue;
            }
            else
            {
                //MessageBox.Show("Карты закончились!");
                return 0;
            }
        }
        
    }
}
