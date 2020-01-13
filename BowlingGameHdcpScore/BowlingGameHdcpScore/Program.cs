using System;
using System.Collections.Generic;
using TenPinsBowlingGameHdcp.Controllers;
using TenPinsBowlingGameHdcp.Utilities;

namespace TenPinsBowlingGameHdcp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-- Option 1: The whole game input as one (using built-in parser). --");
            TenPinsGame tenPinsGame = new TenPinsGame("10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1");

            int count = 1;
            int score = 0;
            foreach (var input in tenPinsGame.ListOfKickedPins)
            {
                score = tenPinsGame.Bowl(input);
                Console.WriteLine($"Total Score till current Throw (#{count}) is: {score}");
                count++;
            }
            // =======

            Console.WriteLine("-- Option 2: The whole game input as one (can use 3rd party parcer). --");
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1");

            int count2 = 1;
            int score2 = 0;
            TenPinsGame tenPinsGame2 = new TenPinsGame();
            foreach (var input in intInputList)
            {
                score2 = tenPinsGame2.Bowl(input);
                Console.WriteLine($"Total Score till current Throw (#{count2}) is: {score2}");
                count2++;
            }

            // =======

            Console.WriteLine("-- Option 3: New game to enter input one-by-one. --");
            TenPinsGame game = new TenPinsGame();
            string consoleInput;
            do
            {
                Console.WriteLine("Please Enter Kicked Pins count for the current Bowl or 'q' to quit:");
                consoleInput = Console.ReadLine();
                if (consoleInput == "q" || consoleInput == "Q")
                    break;
                try
                {
                    score = game.Bowl(Convert.ToInt32(consoleInput));
                    if (score != 0)
                        Console.WriteLine($"Your current score is: {score}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (consoleInput != "q");

            Console.WriteLine("Hit any key to Quit.");
            Console.ReadKey();
        }
    }
}
