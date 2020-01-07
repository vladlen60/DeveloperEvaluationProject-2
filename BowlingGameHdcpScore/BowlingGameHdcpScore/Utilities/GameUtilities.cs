using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinsBowlingGameHdcp.Utilities
{
    public class GameUtilities
    {
        public List<int> ParseGameInputString(string gameInput)
        {
            if (string.IsNullOrWhiteSpace(gameInput))
                throw new ArgumentException($"You have an invalid input `{gameInput}`. Pls check.");
            var stringsListOfGameInput = gameInput.Split(',');
            List<int> intListOfGameInput = new List<int>();
            
            foreach (var input in stringsListOfGameInput)
            {
                input.Trim();
                int intConvertedFromCharInput = Convert.ToInt32(input);
                intListOfGameInput.Add(intConvertedFromCharInput);
            }

            return intListOfGameInput;
        }
    }
}
