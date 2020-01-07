using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinsBowlingGameHdcp
{
    public class GameHandler
    {
        private readonly int _defaultValueForBowlThrow = CommonGameData.DefaultValueForTheBowlThrow;
        private readonly int _startingPinsNumber = CommonGameData.StartingPinsNumber;
        private readonly int _maxFramesNumberIndex = CommonGameData.MaxFramesNumber - 1;


        public void SetFirstBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            frame.SetFirstBowlScore(kickedPins);
        }

        public void SetSecondBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            if (frame.SecondBowlScore == _defaultValueForBowlThrow)
            {
                frame.SetSecondBowlScore(kickedPins);
            }
        }

        public void SetThirdBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            if (frame.ThirdBowlBonusScore == _defaultValueForBowlThrow)
            {
                frame.SetThirdBowlBonusScore(kickedPins);
            }
        }

        public void SetIsReadyToScoreForFrame(Frame frame)
        {
            ValidateForNull(frame);
            if (frame.ThirdBowlBonusScore != _defaultValueForBowlThrow)
            {
                frame.SetIsFrameReadyForScore(true);
            }
        }

        public void SetIsFrameClosedFlag(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetIsFrameClosed(true);
        }

        public void SetBonusFlagForFinalFrame(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetBonusStatusForFinalFrame(frame);
        }

        private void ValidateForNull(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException("The Frame is Null. Pls check.");
        }
}
}
