using System;
using System.Collections.Generic;
using TenPinsBowlingGameHdcp.Modules;
using TenPinsBowlingGameHdcp.Utilities;

namespace TenPinsBowlingGameHdcp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TenPinsGame tenPinsGame = new TenPinsGame("10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1");

            int count = 1;
            int score = 0;
            foreach (var input in tenPinsGame.ListOfKickedPins)
            {
                score = tenPinsGame.Bowl(input);
                Console.WriteLine($"Current Total Score of ALL Trows is ({count}): {score}");
                count++;
            }

            string consoleInput;
            TenPinsGame game = new TenPinsGame();
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
                    //throw;
                }

            } while (consoleInput != "q");

            Console.WriteLine("Hit any key to Quit.");
            Console.ReadKey();
        }
    }
}
