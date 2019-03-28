using System;

namespace GuessMyNumber.Models
{
    public class Game
    {
        /// <summary>
        /// Minimum number
        /// </summary>
        private int _minimum;

        /// <summary>
        /// Maximum number
        /// </summary>
        private int _maximum;

        /// <summary>
        /// The number
        /// </summary>
        private int _theNumber;

        /// <summary>
        /// Game bots
        /// </summary>
        private Bot[] _bots;

        /// <summary>
        /// The player
        /// </summary>
        private Player _player;

        /// <summary>
        /// Random number generator
        /// </summary>
        private static Random _rnd = new Random();

        public Bot[] Bots => _bots;

        /// <summary>
        /// Game constructor
        /// </summary>
        public Game()
        {
            _minimum = 0;
            _maximum = 100;
            _theNumber = _rnd.Next(_minimum, _maximum + 1);
        }

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="max">Maximum number</param>
        public Game(int max)
        {
            _minimum = 0;
            _maximum = max;
        }

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        public Game(int min, int max)
        {
            _minimum = min;
            _maximum = max;
            _theNumber = _rnd.Next(_minimum, _maximum + 1);
        }

        /// <summary>
        /// Create game bots
        /// </summary>
        /// <param name="count"></param>
        public void CreateBots(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                //todo: create bots
            }
        }
    }
}