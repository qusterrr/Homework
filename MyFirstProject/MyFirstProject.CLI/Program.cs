using System;
using System.Linq;

namespace MyFirstProject.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // информация об очках игроков
            byte myScore = 0;
            byte enemyScore = 0;

            // информация о том, сколько дает каждая карта
            byte[] cards = new byte[]
            {
                6, 7, 8, 9, 10,
                10, 10, 10,
                11,
                6, 7, 8, 9, 10,
                10, 10, 10,
                11,
                6, 7, 8, 9, 10,
                10, 10, 10,
                11,
                6, 7, 8, 9, 10,
                10, 10, 10,
                11,
            };

            // Перемешали карты
            Random random = new Random();
            cards = cards
                .OrderBy(x => random.Next())
                .OrderBy(x => random.Next())
                .OrderBy(x => random.Next())
                .ToArray();

            byte upperCardNumber = 0;
            bool DoIContinuePickCards = true;
            bool DoEnemyContinuePickCards = true;

            do
            {
                // Брать или не брать?
                if (DoIContinuePickCards)
                {
                    Console.WriteLine("Do you want to continue pick cards? (y/n)");
                    string answer = Console.ReadLine();

                    // Если брать
                    if (answer.ToLower() == "y")
                    {
                        byte card = cards[upperCardNumber];
                        upperCardNumber++;
                        { if (cards == 11) and (myScore > 10)
                            cards = 1
                                }
                        myScore += card;
                    }

                    if (answer.ToLower() == "n")
                    {
                        DoIContinuePickCards = false;
                    }
                }

                if (upperCardNumber > 35)
                {
                    break;
                }

                if (DoEnemyContinuePickCards)
                {
                    // Брать или не брать?
                    string answer = random.Next(0, 1) == 0 && enemyScore < 16 ? "y" : "n";

                    if (answer.ToLower() == "y")
                    {
                        byte card = cards[upperCardNumber];
                        upperCardNumber++;

                        enemyScore += card;
                    }

                    if (answer.ToLower() == "n")
                    {
                        DoEnemyContinuePickCards = false;
                    }
                }

                if (upperCardNumber > 35)
                {
                    break;
                }

                Console.WriteLine($"My Score: {myScore} Enemy Score: {enemyScore}");

            } while ((DoIContinuePickCards && myScore < 22) || (DoEnemyContinuePickCards && enemyScore < 22));

            if (myScore <= 21 && myScore > enemyScore)
            {
                Console.WriteLine("I win!");
            }
            else if (enemyScore <= 21 && enemyScore > myScore)
            {
                Console.WriteLine("Enemy win!");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}
