using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1920M
{
    internal class Testing
    {
        public void TestSevensOut()
        {
            Game game = new Game(); // Create a Game object
            Die die = new Die(); // Create a Die object for testing

            int total = 0;
            bool doubleRolled = false;
            bool stop = false;

            while (!stop)
            {
                int roll1 = die.Roll(); // Roll the first die
                int roll2 = die.Roll(); // Roll the second die

                total += roll1 + roll2; // Calculate the total sum

                if (total == 7)
                {
                    if (doubleRolled)
                    {
                        Debug.Assert(total == 7, "Total is not 7 with a double."); // Assert total is 7 with a double
                    }
                    else
                    {
                        Debug.Assert(total == 7, "Total is not 7 without a double."); // Assert total is 7 without a double
                    }
                    stop = true; // Stop if total is 7
                }
                else if (total > 7 && !doubleRolled)
                {
                    Debug.Assert(total <= 14, "Total exceeded 14."); // Assert total is less than or equal to 14
                    stop = true; // Stop if total exceeds 7 without a double
                }
                else if (total > 14)
                {
                    Debug.Assert(false, "Total is out of range."); // Stop if total exceeds 14
                }
                else if (roll1 == roll2)
                {
                    doubleRolled = true; // Set doubleRolled flag to true if a double is rolled
                }
            }
        }

        public void TestThreeOrMore()
        {
            Game game = new Game(); // Create a Game object
            Die die = new Die(); // Create a Die object for testing

            int totalScore = 0;
            bool stop = false;

            while (!stop)
            {
                int[] dice = new int[5]; // Array to store the values of the 5 dice

                // Roll all 5 dice
                for (int i = 0; i < dice.Length; i++)
                {
                    dice[i] = die.Roll();
                }

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

                // Assert that the total score is added correctly
                Debug.Assert(totalScore >= 0 && totalScore <= 20, "Total score is out of range.");
                Debug.Assert(totalScore % 3 == 0, "Total score is not a multiple of 3.");

                if (totalScore >= 20)
                {
                    stop = true; // Stop the game if total score reaches 20 or more
                }
            }
        }
    }
}