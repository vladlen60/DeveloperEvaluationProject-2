using System;
using TenPinsBowlingGameHdcp.Common;

namespace TenPinsBowlingGameHdcp.Modules
{
    internal enum FrameStatus
    {
        Regular,
        Strike,
        Spare,
        TenthFrameWithBonus
    }

    internal class Frame
    {
        public FrameStatus FrameStatus { get; private set; }

        public int FirstBowlScore { get; private set; } = ConstTenPinsGameData.InitialValueForTheBowlThrow;
        public int SecondBowlScore { get; private set; } = ConstTenPinsGameData.InitialValueForTheBowlThrow;
        public int ThirdBowlBonusScore { get; private set; } = ConstTenPinsGameData.InitialValueForTheBowlThrow;

        public bool IsFrameClose { get; private set; } = false;
        public bool IsFrameReadyForScore { get; private set; } = false;
        public bool IsFinalFrame { get; private set; } = false;


        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;

        public void SetFirstBowlScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= _startingPinsNumber)
                FirstBowlScore = kickedPinsCount;
            else
                throw new ArgumentException($"The kicked pins count for 1st throw is '{kickedPinsCount}', but has to be between 0 and {_startingPinsNumber}.");
        }

        public void SetSecondBowlScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= _startingPinsNumber)
                SecondBowlScore = kickedPinsCount;
            else
                throw new ArgumentException($"The kicked pins count for 2nd throw is '{kickedPinsCount}', but has to be between 0 and {_startingPinsNumber}.");
        }

        public void SetThirdBowlBonusScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= _startingPinsNumber)
                ThirdBowlBonusScore = kickedPinsCount;
            else
                throw new ArgumentException($"The kicked pins count for 3rd (Bonus) throw is '{kickedPinsCount}', but has to be between 0 and {_startingPinsNumber}.");
        }

        public void SetIsFrameClosed(bool isSet)
        {
            IsFrameClose = isSet;
        }

        public void SetIsFrameReadyForScore(bool isSet)
        {
            IsFrameReadyForScore = isSet;
        }

        public void SetIsFinalFrame(bool isSet)
        {
            IsFinalFrame = isSet;
        }

        public void SetFrameStatus(FrameStatus frameStatus)
        {
            if (frameStatus == null)
                throw new ArgumentNullException("The FrameStatus provided, is Null. Pls check.");
            FrameStatus = frameStatus;
        }
    }
}
