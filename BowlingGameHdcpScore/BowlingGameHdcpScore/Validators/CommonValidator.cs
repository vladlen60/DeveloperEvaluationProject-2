using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;

namespace TenPinsBowlingGameHdcp.Validators
{
    internal class CommonValidator
    {
        internal bool IsSecondBowlScoreNotRecordedFor(Frame frame)
        {
            return frame.SecondBowlScore == ConstTenPinsGameData.InitialValueForTheBowlThrow;
        }

        internal bool IsThirdBowlScoreNotRecordedFor(Frame frame)
        {
            return frame.ThirdBowlBonusScore == ConstTenPinsGameData.InitialValueForTheBowlThrow;
        }
        
        internal void ValidateFrameIsNotNull(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException($"The Frame provided {frame} is Null. Pls check.");
        }

        internal void ValidateKickedPinsCount(int kickedPinsCount)
        {
            if (kickedPinsCount < 0 || kickedPinsCount > ConstTenPinsGameData.StartingPinsNumber)
                throw new ArgumentException($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {ConstTenPinsGameData.StartingPinsNumber}. Pls check.");
        }
    }
}
