using System;
using System.Collections.Generic;
using GuessMyNumber.Controllers;
using GuessMyNumber.Models;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            
            while (gameRunning)
            {
                Games.New();

                Console.Clear();
                Console.Write("Would you like to play again? (y/n)");
                string input = Console.ReadLine();

                // possibly unnecessary switch but ssh
                switch (input.ToLower())
                {
                    case "n":
                    case "no":
                        gameRunning = false;
                        break;
                }
            }
        }
    }
}