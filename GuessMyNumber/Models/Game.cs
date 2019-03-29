using System;
using System.Collections.Generic;

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
        /// Amount of bots to generate
        /// </summary>
        private int _botCount;

        /// <summary>
        /// Whether current game is a solo game
        /// </summary>
        private bool _isSoloGame;

        /// <summary>
        /// Previous guesses made by both bots and player that were too low
        /// </summary>
        private List<int> _lowGuesses = new List<int>();

        /// <summary>
        /// Previous guesses made by both bots and player that were too high
        /// </summary>
        private List<int> _highGuesses = new List<int>();

        /// <summary>
        /// Game bots
        /// </summary>
        private List<Bot> _bots;

        /// <summary>
        /// The player
        /// </summary>
        private Player _player;

        /// <summary>
        /// Random number generator
        /// </summary>
        private static Random _rnd = new Random();

        /// <summary>
        /// Minimum number
        /// </summary>
        public int Minimum => _minimum;

        /// <summary>
        /// Maximum number
        /// </summary>
        public int Maximum => _maximum;

        /// <summary>
        /// Previous guesses made by both bots and player that were too low
        /// Could be replaced with single int, but having it as a collection
        /// allows you to create multiple difficulty levels
        /// </summary>
        public List<int> LowGuesses => _lowGuesses;
        
        /// <summary>
        /// Previous guesses made by both bots and player that were too high
        /// Could be replaced with single int, but having it as a collection
        /// allows you to create multiple difficulty levels
        /// </summary>
        public List<int> HighGuesses => _highGuesses;
        
        /// <summary>
        /// Game bots
        /// </summary>
        public List<Bot> Bots => _bots;

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="soloGame">Whether game should be a solo game or not</param>
        /// <param name="botCount">The amount of bots to create</param>
        public Game(bool soloGame = true, int botCount = 1)
        {
            _minimum = 0;
            _maximum = 100;
            _theNumber = _rnd.Next(_minimum, _maximum + 1);
            _isSoloGame = soloGame;
            _botCount = botCount;
        }

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="max">Maximum number</param>
        /// <param name="soloGame">Whether game should be a solo game or not</param>
        /// <param name="botCount">The amount of bots to create</param>
        public Game(int max, bool soloGame = true, int botCount = 1)
        {
            _minimum = 0;
            _maximum = max;
            _theNumber = _rnd.Next(_minimum, _maximum + 1);
            _isSoloGame = soloGame;
            _botCount = botCount;
        }

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <param name="soloGame">Whether game should be a solo game or not</param>
        /// <param name="botCount">The amount of bots to create</param>
        public Game(int min, int max, bool soloGame = true, int botCount = 1)
        {
            _minimum = min;
            _maximum = max;
            _theNumber = _rnd.Next(_minimum, _maximum + 1);
            _isSoloGame = soloGame;
            _botCount = botCount;
        }

        /// <summary>
        /// Create game bots
        /// </summary>
        private void CreateBots()
        {
            // instantiate bots list
            _bots = new List<Bot>();
            
            // create all bots
            for (int i = 1; i <= _botCount; i++)
            {
                _bots.Add(new Bot(i));
            }
        }

        /// <summary>
        /// Start playing current game.
        /// </summary>
        public void Play()
        {
            bool gameRunning = true;

            // instantiate player
            _player = new Player();
            
            // create bots
            if (!_isSoloGame) CreateBots();
            
            // clear console
            Console.Clear();

            // GO!
            while (gameRunning)
            {
                bool playerWon;
                bool botWon;
                int playerGuess = _player.Guess();
                
                // announce player guess
                Console.WriteLine($"<Player> The number is {playerGuess}!");
                
                // check player guess
                playerWon = CheckGuess(playerGuess);

                // maybe do bot guess
                if (playerWon)
                {
                    Win("Player");
                    gameRunning = false;
                }
                else if (!_isSoloGame)
                {
                    foreach (Bot bot in _bots)
                    {
                        int botGuess = bot.Guess();
                        
                        // announce bot guess
                        Console.WriteLine($"<Bot #{bot.Id}> The number is {botGuess}!");

                        // check bot guess
                        botWon = CheckGuess(botGuess);
                        
                        if (botWon)
                        {
                            Win($"Bot #{bot.Id}");
                            gameRunning = false;
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private bool CheckGuess(int guess)
        {
            if (guess == _theNumber) return true;

            // check if guess is too high or too low
            if (guess < _theNumber)
            {
                Console.WriteLine("Guess was too low!");
                _lowGuesses.Add(guess);
            } 
            else if (guess > _theNumber)
            {
                Console.WriteLine("Guess was too high!");
                _highGuesses.Add(guess);
            }
            
            _lowGuesses.Sort();
            _highGuesses.Sort();

            return false;
        }

        /// <summary>
        /// Announce a win
        /// </summary>
        /// <param name="name"></param>
        private void Win(string name)
        {
            Console.WriteLine($"{name} guessed the right number and won the game!");
        }
    }
}