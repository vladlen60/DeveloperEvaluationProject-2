using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinsBowlingGameHdcp
{
    public class Program
    {
        private static TenPinsGame tenPinsGame = new TenPinsGame();

        public static void Main(string[] args)
        {
            //var gameInput = "1";
            //var gameInput = "1, 1";
            //var gameInput = "1, 1, 5";
            //var gameInput = "10, 1, 5";
            //var gameInput = "9, 0, 9,0, 9,0,9, 0, 9, 0, 9, 0, 9,0 , 9,0, 9,0, 9,0";
            var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1";
            //var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 2";
            //var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 7,3, 8";
            //var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 7,3, 8, 1";

 
            var inputListFrom = gameInput.Split(',');
            List<int> intInputList = new List<int>();

            

            foreach (var input in inputListFrom)
            {
                input.Trim();
                int charIntoIntInput = Convert.ToInt32(input);
                intInputList.Add(charIntoIntInput);
            }

            int count = 1;
            int score = 0;
            foreach (var i in intInputList)
            {
                score = tenPinsGame.Bowl(i);
                Console.WriteLine($"Current Total Score of ALL Trows is ({count}): {score}");
                count++;
            }



            var gameInputArray = new[]
            {
                "1",
                "1,1",
                "1, 1, 5",
                "10, 10",
                "10,10,10",
                "10,10,10,0",
                "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1",
                "9, 0, 9,0, 9,0,9, 0, 9, 0, 9, 0, 9,0 , 9,0, 9,0, 9,0",
                "5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5",
                //"5,0,5,0,5,0,5,0,5,0,5,0,5,0,5,0,5,0,5,0,5",
                "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0",
                "0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0",
                "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5",
                "0,0,0,0,0,0,10,0,0,0,0,10,0,0,0,0,0,0",
                //"0,0,0,0,0,0,10,0,0,0,0,10,0,0,0,0,0,0,0",
                "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,2",
                "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,2,0",
            };
            foreach (var singleGameInput in gameInputArray)
            {
                TenPinsGame class2 = new TenPinsGame();
                var inputListFrom2 = singleGameInput.Split(',');
                List<int> intInputList2 = new List<int>();



                foreach (var input2 in inputListFrom2)
                {
                    input2.Trim();
                    int charIntoIntInput2 = Convert.ToInt32(input2);
                    intInputList2.Add(charIntoIntInput2);
                }

                int score2 = 0;
                foreach (var i2 in intInputList2)
                {
                    score2 = class2.Bowl(i2);
                }
                Console.WriteLine($"Current game input: `{singleGameInput}`");
                Console.WriteLine($" \t\t\t\t\t\t\t Current Total Score: {score2}");
            }


            Console.WriteLine("Hit any key to Quit.");
            Console.ReadKey();
        }
    }
}
