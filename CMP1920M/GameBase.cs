using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1920M
{
    /// <summary>
    /// Represents a base class for different types of games.
    /// </summary>
    internal abstract class GameBase
    {
        // Fields to hold instances of Die and Statistics classes
        protected Die die;
        protected Statistics statistics;

        /// <summary>
        /// Constructor for GameBase class.
        /// </summary>
        public GameBase()
        {
            // Initialize instances of Die and Statistics classes
            die = new Die();
            statistics = new Statistics();
        }

        /// <summary>
        /// Abstract method to be implemented by derived classes to define game-specific logic.
        /// </summary>
        public abstract void Play();
    }
}