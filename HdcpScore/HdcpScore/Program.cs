using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameHdcp
{
    public class Program
    {
        private static BowlingGame class1 = new BowlingGame();

        public static void Main(string[] args)
        {
            //var gameInput = "1;
            //var gameInput = "1, 1";
            //var gameInput = "1, 1, 5";
            //var gameInput = "10, 1, 5";
            //var gameInput = "9, 0, 9,0, 9,0,9, 0, 9, 0, 9, 0, 9,0 , 9,0, 9,0, 9,0";
            //var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1";
            //var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 2";
            //var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 7,3, 8";
            var gameInput = "10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 7,3, 8, 1";

            var inputListFrom = gameInput.Split(',');
            List<int> intInputList = new List<int>();

            

            foreach (var input in inputListFrom)
            {
                input.Trim();
                int charIntoIntInput = Convert.ToInt32(input);
                intInputList.Add(charIntoIntInput);
            }

            int count = 1;
            foreach (var i in intInputList)
            {
                var score = class1.Bowl(i);
                Console.WriteLine($"Current Total Score of ALL Trows is ({count}): {score}");
                count++;
            }


            Console.ReadKey();
        }
    }
}
