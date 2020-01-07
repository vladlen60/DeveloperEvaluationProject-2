using System;
using TenPinsBowlingGameHdcp.Common;

namespace TenPinsBowlingGameHdcp.Handlers
{
    public class FrameHamdler
    {
        private readonly int _defaultValueForBowlThrow = CommonGameData.DefaultValueForTheBowlThrow;


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

        public void SetIsReadyToScoreForFrameToTrue(Frame frame)
        {
            ValidateForNull(frame);
            if (frame.ThirdBowlBonusScore != _defaultValueForBowlThrow)
            {
                frame.SetIsFrameReadyForScore(true);
            }
        }

        public void SetIsFrameClosedFlagToTrue(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetIsFrameClosed(true);
        }

        public void SetStatusForCurrentFrame(Frame frame, FrameStatus frameStatus)
        {
            ValidateForNull(frame);
            ValidateEnumValues(frameStatus);
            frame.SetStatusForCurrentFrame(frameStatus);
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

        private void ValidateEnumValues(FrameStatus frameStatus)
        {
            bool correctValue = Enum.IsDefined(typeof(FrameStatus), frameStatus);
            if (!correctValue)
                throw new ArgumentNullException("The FrameStatus provided, is incorect. Pls check.");
        }
    }
}
