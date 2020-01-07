using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TenPinsBowlingGameHdcp.Common;

namespace TenPinsBowlingGameHdcp
{
    public enum FrameStatus
    {
        Regular,
        Strike,
        Spare,
        TenthFrameWithBonus
    }

    public class Frame
    {
        private readonly int _maxFramesNumber = CommonGameData.MaxFramesNumber;
        private readonly int _startingPinsNumber = CommonGameData.StartingPinsNumber;

        public FrameStatus FrameStatus { get; private set; }

        public int FirstBowlScore { get; private set; } = -1;
        public int SecondBowlScore { get; private set; } = -1;
        public int ThirdBowlBonusScore { get; private set; } = -1;

        public bool IsFrameClose { get; private set; } = false;
        public bool IsFrameRedyForScore { get; private set; } = false;
        public bool IsFinalFrame { get; private set; } = false;



        public void SetFirstBowlScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= _startingPinsNumber)
            {
                FirstBowlScore = kickedPinsCount;
            }
            else
            {
                throw new ArgumentException($"The kicked pins count for 1st throw is '{kickedPinsCount}', but has to be between 0 and {_maxFramesNumber}.");
            }
        }

        public void SetSecondBowlScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= _startingPinsNumber)
            {
                SecondBowlScore = kickedPinsCount;
            }
            else
            {
                throw new ArgumentException($"The kicked pins count for 2nd throw is '{kickedPinsCount}', but has to be between 0 and {_maxFramesNumber}.");
            }
        }

        public void SetThirdBowlBonusScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= _startingPinsNumber)
            {
                ThirdBowlBonusScore = kickedPinsCount;
            }
            else
            {
                throw new ArgumentException($"The kicked pins count for 3rd (Bonus) throw is '{kickedPinsCount}', but has to be between 0 and {_maxFramesNumber}.");
            }
        }

        public void SetIsFrameClosed(bool isSet)
        {
            IsFrameClose = isSet;
        }

        public void SetIsFrameReadyForScore(bool isSet)
        {
            IsFrameRedyForScore = isSet;
        }

        public void SetIsFinalFrame(bool isSet)
        {
            IsFinalFrame = isSet;
        }

        public void SetStatusForCurrentFrame(FrameStatus frameStatus)
        {
            if (frameStatus == null)
                throw new ArgumentNullException("The FrameStatus provided, is Null. Pls check.");
            FrameStatus = frameStatus;
        }
    }
}
