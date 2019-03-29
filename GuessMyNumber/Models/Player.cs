using System;
using GuessMyNumber.Controllers;

namespace GuessMyNumber.Models
{
    public class Player
    {
        /// <summary>
        /// Get player guess
        /// </summary>
        /// <returns>Player guessed number</returns>
        public int Guess()
        {
            int guess = 0;
            bool parseSuccessful = false;

            // get guess
            while (!parseSuccessful)
            {
                Console.Write($"Make your guess ({Games.CurrentGame.Minimum} - {Games.CurrentGame.Maximum}): ");
                parseSuccessful = int.TryParse(Console.ReadLine(), out guess);
            }

            return guess;
        }
    }
}