using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TenPinsBowlingGameHdcp
{
    public enum FrameStatus
    {
        Points,
        TenthFrameWithBonus
    }

    public class Frame
    {
        private readonly int maxFramesNumber = CommonGameData.MaxFramesNumber;

        public FrameStatus FrameStatus;

        public int FirstBowlScore { get; private set; } = -1;
        public int SecondBowlScore { get; private set; } = -1;
        public int ThirdBowlBonusScore { get; private set; } = -1;

        public bool IsFrameClose { get; private set; } = false;
        public bool IsFrameRedyForScore { get; private set; } = false;


        public void SetFirstBowlScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= 10)
            {
                FirstBowlScore = kickedPinsCount;
            }
            else
            {
                throw new ArgumentException($"The kicked pins count for 1st throw is '{kickedPinsCount}', but has to be between 0 and {maxFramesNumber}.");
            }
        }

        public void SetSecondBowlScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= 10)
            {
                SecondBowlScore = kickedPinsCount;
            }
            else
            {
                throw new ArgumentException($"The kicked pins count for 2nd throw is '{kickedPinsCount}', but has to be between 0 and {maxFramesNumber}.");
            }
        }

        public void SetThirdBowlBonusScore(int kickedPinsCount)
        {
            if (kickedPinsCount >= 0 && kickedPinsCount <= 10)
            {
                ThirdBowlBonusScore = kickedPinsCount;
            }
            else
            {
                throw new ArgumentException($"The kicked pins count for 3rd (Bonus) throw is '{kickedPinsCount}', but has to be between 0 and {maxFramesNumber}.");
            }
        }

        private void ValidateKickedPinsInput(int kickedPinsCount)
        {

        }


        public void SetIsFrameClosed(bool isSet)
        {
            IsFrameClose = isSet;
        }

        public void SetIsFrameReadyForScore(bool isSet)
        {
            IsFrameRedyForScore = isSet;
        }

        public void SetBonusStatusForFinalFrame(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException("The Frame is Null. Pls check.");
            frame.FrameStatus = FrameStatus.TenthFrameWithBonus;
        }
    }
}
