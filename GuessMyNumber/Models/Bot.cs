using System;
using System.Collections.Generic;
using System.Linq;
using GuessMyNumber.Controllers;

namespace GuessMyNumber.Models
{
    public class Bot
    {
        /// <summary>
        /// Bot ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Random number generator
        /// </summary>
        private Random _rnd = new Random();

        /// <summary>
        /// Bot ID
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Construct bot
        /// </summary>
        /// <param name="id">Bot ID</param>
        public Bot(int id)
        {
            _id = id;
        }

        /// <summary>
        /// Make guess
        /// </summary>
        /// <returns>Bot's guess</returns>
        public int Guess()
        {
            int guess;
            int lower = Games.CurrentGame.LowGuesses.Any() ? Games.CurrentGame.LowGuesses.Last() : Games.CurrentGame.Minimum;
            int higher = Games.CurrentGame.HighGuesses.Any() ? Games.CurrentGame.HighGuesses[0] : Games.CurrentGame.Maximum;

            // make guess
            guess = _rnd.Next(lower, higher + 1);
            
            return guess;
        }
    }
}