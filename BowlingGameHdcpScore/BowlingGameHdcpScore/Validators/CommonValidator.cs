using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;

namespace TenPinsBowlingGameHdcp.Validators
{
    internal class CommonValidator
    {
        internal void ValidateFrameIsNotNull(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException($"The Frame provided {frame} is Null. Pls check.");
        }

        internal bool IsThirdBowlScoreNotRecordedFor(Frame frame)
        {
            //todo delete this method
            return frame.ThirdBowlBonusScore == -1;
        }

        internal bool IsValidKickedPinsCount(int kickedPinsCount)
        {
            return kickedPinsCount >= 0 && kickedPinsCount <= ConstTenPinsGameData.StartingPinsNumber;
        }

        internal bool IsSecondBowlScoreNotRecordedFor(Frame frame)
        {
            //todo delete this method
            return frame.SecondBowlScore == -1;
        }
    }
}
