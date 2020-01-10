using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenPinsBowlingGameHdcp.Utilities;

namespace TenPinsBowlingGameHdcp.Modules
{
    public class GameBase
    {
        public List<int> ListOfKickedPins { get; private set; }

        public GameBase()
        {
        }

        public GameBase(string gameInput)
        {
            ListOfKickedPins = new List<int>();
            var gameParser = new GameParser();
            ListOfKickedPins = gameParser.ParseGameInputString(gameInput);
        }
    }
}
