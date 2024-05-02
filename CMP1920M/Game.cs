using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1920M
{
    internal class Game : GameBase
    {
        public Game() : base()
        {
        }

        public override void Play()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Sevens Out Game");
                Console.WriteLine("2. Three or More Game");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Perform Testing");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InstantiateSevensOut();
                        break;
                    case "2":
                        InstantiateThreeOrMore();
                        break;
                    case "3":
                        ViewStatisticsData();
                        break;
                    case "4":
                        PerformTests();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (exit)
                {
                    break;
                }
            }
        }

        private void InstantiateSevensOut()
        {
            Console.WriteLine("Sevens Out Game:");

            int totalScore = 0;
            bool doubles = false;

            while (true)
            {
                int roll1 = die.Roll(); // Roll the first die
                int roll2 = die.Roll(); // Roll the second die

                int total = roll1 + roll2;
                Console.WriteLine($"You rolled: {roll1}, {roll2}. Total: {total}");

                if (total == 7)
                {
                    Console.WriteLine("Sevens Out! Your total score is: " + totalScore);
                    if (doubles)
                    {
                        totalScore *= 2; // Double the total score if doubles were rolled
                        Console.WriteLine("Score doubled! New total score: " + totalScore);
                    }
                    break;
                }
                else
                {
                    totalScore += total; // Add total to the score
                    if (roll1 == roll2)
                    {
                        doubles = true; // Set doubles flag to true if a double is rolled
                    }
                }
            }

            // Update statistics
            statistics.IncrementSevensOutPlays();
            statistics.UpdateHighestSevensOutScore(totalScore);

            // Offer to play again or return to main menu
            Console.WriteLine("Do you want to play again? (Y/N)");
            string choice = Console.ReadLine().ToUpper();
            while (choice != "Y" && choice != "N")
            {
                Console.WriteLine("Please input a valid option (Y/N).");
                choice = Console.ReadLine().ToUpper();
            }
            if (choice == "Y")
            {
                InstantiateSevensOut(); // Play again
            }
            else
            {
                MainMenu(); // Return to main menu
            }
        }

        private void InstantiateThreeOrMore()
        {
            Console.WriteLine("Three or More Game:");

            int totalScore = 0;
            bool stop = false;

            while (!stop)
            {
                int[] dice = new int[5]; // Array to store the values of the 5 dice

                // Roll all 5 dice
                for (int i = 0; i < dice.Length; i++)
                {
                    dice[i] = die.Roll();
                    Console.Write($"{dice[i]} ");
                }
                Console.WriteLine();

                // Check for 3-of-a-kind, 4-of-a-kind, or 5-of-a-kind
                if (dice.Distinct().Count() == 1)
                {
                    if (dice[0] == 1)
                    {
                        totalScore += 12; // 5-of-a-kind
                    }
                    else
                    {
                        totalScore += 6; // 4-of-a-kind
                    }
                }
                else if (dice.GroupBy(x => x).Any(g => g.Count() >= 3))
                {
                    totalScore += 3; // 3-of-a-kind
                }

                Console.WriteLine($"Total Score: {totalScore}");

                if (totalScore >= 20)
                {
                    stop = true; // Stop the game if total score reaches 20 or more
                }
                else
                {
                    Console.WriteLine("Press Enter to roll again or type 'stop' to end the game.");
                    string input = Console.ReadLine();
                    while (input.ToLower() != "" && input.ToLower() != "stop")
                    {
                        Console.WriteLine("Please input a valid option (press [Enter] or type 'stop').");
                        input = Console.ReadLine();
                    }
                    if (input.ToLower() == "stop")
                    {
                        stop = true; // Stop the game if the player decides to end it
                    }
                }
            }

            // Update statistics
            statistics.IncrementThreeOrMorePlays();
            statistics.UpdateHighestThreeOrMoreScore(totalScore);
        }


        private void ViewStatisticsData()
        {
            Console.WriteLine("Statistics:");
            statistics.DisplayStatistics();
            // Display statistics data for each game type
        }

        private void PerformTests()
        {
            Console.WriteLine("Testing:");
            Testing testing = new Testing();
            testing.TestSevensOut();
            testing.TestThreeOrMore();
            Console.WriteLine("Tests completed."); // This line should be executed after the tests
        }

        private void MainMenu()
        {
            Play();
        }

        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}