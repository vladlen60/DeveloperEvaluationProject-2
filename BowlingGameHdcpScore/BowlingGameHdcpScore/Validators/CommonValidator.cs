using System;
using TenPinsBowlingGameHdcp.Common;

namespace TenPinsBowlingGameHdcp.Validators
{
    internal class CommonValidator
    {
        internal bool IsValidKickedPinsCount(int kickedPinsCount)
        {
            return kickedPinsCount >= 0 && kickedPinsCount <= ConstTenPinsGameData.StartingPinsNumber;
        }
    }
}
