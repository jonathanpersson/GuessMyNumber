using System;
using System.Collections.Generic;

namespace GuessMyNumber.Models
{
    public class Menu
    {
        /// <summary>
        /// Menu items
        /// </summary>
        private List<string> _items;

        /// <summary>
        /// Max selection
        /// </summary>
        private int _maxSelection;

        /// <summary>
        /// Construct menu
        /// </summary>
        /// <param name="items">Menu items to display</param>
        public Menu(List<string> items)
        {
            _items = items;
            _maxSelection = items.Count - 1;
        }

        /// <summary>
        /// Render menu
        /// </summary>
        /// <returns>Index of menu selection (starting from 0)</returns>
        public int Render()
        {
            if (_maxSelection <= 0) throw new Exception("Menu must contain at least one item!");
            
            int current = 0;
            bool selectionMade = false;
            ConsoleKey key;

            // loop until a selection is made
            // inverted because it is nicer to say "until selection is made"
            // than to say "while no item has been selected"
            while (!selectionMade)
            {
                Console.Clear();

                // cursor should loop back around if current is below zero or above max
                if (current < 0) current = _maxSelection;
                else if (current > _maxSelection) current = 0; 
                
                // render menu items
                for (int i = 0; i <= _maxSelection; i++)
                {
                    if (i == current) Console.Write(">");
                    Console.WriteLine(_items[i]);
                }

                // get console key input
                key = Console.ReadKey().Key;

                // check input
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        current--;
                        break;
                    case ConsoleKey.DownArrow:
                        current++;
                        break;
                    case ConsoleKey.Enter:
                        selectionMade = true;
                        break;
                }
            }

            return current;
        }
    }
}