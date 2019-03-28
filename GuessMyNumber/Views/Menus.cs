using System.Collections.Generic;

namespace GuessMyNumber.Views
{
    /// <summary>
    /// Stores all menus.
    /// Maybe not the prettiest method of storing views.
    /// </summary>
    public static class Menus
    {
        /// <summary>
        /// Menu items for game type selection screen
        /// </summary>
        public static readonly List<string> GameTypeSelection = new List<string>()
        {
            "Solo", "VS. Bots"
        };
    }
}