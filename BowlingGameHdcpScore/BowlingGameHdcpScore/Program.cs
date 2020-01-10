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

            Console.WriteLine("Hit any key to Quit.");
            Console.ReadKey();
        }
    }
}
