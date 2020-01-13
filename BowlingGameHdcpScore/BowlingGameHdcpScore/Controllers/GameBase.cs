using System.Collections.Generic;
using TenPinsBowlingGameHdcp.Utilities;

namespace TenPinsBowlingGameHdcp.Controllers
{
    public abstract class GameBase
    {
        public List<int> ListOfKickedPins { get; private set; }

        protected GameBase()
        {
        }

        protected GameBase(string gameInput)
        {
            ListOfKickedPins = new List<int>();
            var gameParser = new GameParser();
            ListOfKickedPins = gameParser.ParseGameInputString(gameInput);
        }

        public abstract int Bowl(int kickedPins);
    }
}
