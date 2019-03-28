using System;
using System.Collections.Generic;
using GuessMyNumber.Models;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string>() {"test1", "test2", "test3"};
            Menu menu = new Menu(test);

            Console.WriteLine(menu.Render());
        }
    }
}