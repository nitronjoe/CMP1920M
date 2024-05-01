using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1920M
{
    internal class Statistics
    {
        private int sevensOutPlays;
        private int highestSevensOutScore;

        private int threeOrMorePlays;
        private int highestThreeOrMoreScore;

        public void IncrementSevensOutPlays()
        {
            sevensOutPlays++;
        }

        public void UpdateHighestSevensOutScore(int score)
        {
            if (score > highestSevensOutScore)
            {
                highestSevensOutScore = score;
            }
        }

        public void IncrementThreeOrMorePlays()
        {
            threeOrMorePlays++;
        }

        public void UpdateHighestThreeOrMoreScore(int score)
        {
            if (score > highestThreeOrMoreScore)
            {
                highestThreeOrMoreScore = score;
            }
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("Statistics:");
            Console.WriteLine("Sevens Out Games Played: " + sevensOutPlays);
            Console.WriteLine("Highest Sevens Out Score: " + highestSevensOutScore);
            Console.WriteLine("Three or More Games Played: " + threeOrMorePlays);
            Console.WriteLine("Highest Three or More Score: " + highestThreeOrMoreScore);
        }
    }
}