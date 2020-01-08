using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Modules;

namespace TenPinsBowlingGameHdcp.Handlers
{
    public class FrameHandler
    {
        private readonly int _initialValueForBowlThrow = ConstTenPinsGameData.InitialValueForTheBowlThrow;


        public void SetFirstBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            frame.SetFirstBowlScore(kickedPins);
        }

        public void SetSecondBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            if (frame.SecondBowlScore == _initialValueForBowlThrow)
            {
                frame.SetSecondBowlScore(kickedPins);
            }
        }

        public void SetThirdBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            if (frame.ThirdBowlBonusScore == _initialValueForBowlThrow)
            {
                frame.SetThirdBowlBonusScore(kickedPins);
            }
        }

        public void SetIsReadyToScoreForFrameToTrue(Frame frame)
        {
            ValidateForNull(frame);
            if (frame.ThirdBowlBonusScore != _initialValueForBowlThrow)
            {
                frame.SetIsFrameReadyForScore(true);
            }
        }

        public void SetIsFrameClosedFlagToTrue(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetIsFrameClosed(true);
        }

        public void SetStatusForFrame(Frame frame, FrameStatus frameStatus)
        {
            ValidateForNull(frame);
            frame.SetFrameStatus(frameStatus);
        }

        public void SetIsFinalFrameFlagToTrue(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetIsFinalFrame(true);
        }



        private void ValidateForNull(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException("The Frame is Null. Pls check.");
        }
    }
}
