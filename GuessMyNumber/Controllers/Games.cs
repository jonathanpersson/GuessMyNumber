using System;
using GuessMyNumber.Models;

namespace GuessMyNumber.Controllers
{
    public static class Games
    {
        /// <summary>
        /// Currently active game
        /// </summary>
        private static Game _currentGame;

        /// <summary>
        /// Currently active game
        /// </summary>
        public static Game CurrentGame => _currentGame;
        
        /// <summary>
        /// Start and play new game
        /// </summary>
        public static void New()
        {
            Console.Clear();
            SetupGame();
        }

        /// <summary>
        /// Set up a game
        /// </summary>
        private static void SetupGame()
        {
            int selection;
            int maxNumber = 100;
            bool parseSuccessful = false;
            Menu gameTypeMenu = new Menu(Views.Menus.GameTypeSelection, 
                "What kind of game would you like to play?");
            
            // get max number
            while (!parseSuccessful)
            {
                Console.Write("Enter the maximum number: ");
                parseSuccessful = int.TryParse(Console.ReadLine(), out maxNumber);
            }
            
            // render menu and get selection
            selection = gameTypeMenu.Render();

            // set up different game type depending on selection
            switch (selection)
            {
                case 0:
                    SetupSoloGame(maxNumber);
                    break;
                case 1:
                    SetupVSGame(maxNumber);
                    break;
            }
            
            // play game!
            _currentGame.Play();
        }

        /// <summary>
        /// Set up a standard solo game
        /// </summary>
        /// <param name="maxNumber">Maximum generated number</param>
        private static void SetupSoloGame(int maxNumber)
        {
            _currentGame = new Game(maxNumber);
        }

        /// <summary>
        /// Set up a VS. bots game
        /// </summary>
        /// <param name="maxNumber">Maximum generated number</param>
        private static void SetupVSGame(int maxNumber)
        {
            int botCount = 1;
            bool parseSuccessful = false;

            Console.Clear();
            
            // get bot count
            while (!parseSuccessful)
            {
                Console.Write("How many bots do you want to play against? ");
                parseSuccessful = int.TryParse(Console.ReadLine(), out botCount);
            }
            
            _currentGame = new Game(maxNumber, false, botCount);
        }
    }
}