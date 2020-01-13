using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Modules;

namespace TenPinsBowlingGameHdcp.Handlers
{
    internal class FrameHandler
    {
        private readonly int _initialValueForBowlThrow = ConstTenPinsGameData.InitialValueForTheBowlThrow;


        internal void SetFirstBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            frame.SetFirstBowlScore(kickedPins);
        }

        internal void SetSecondBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            if (IsSecondBowlScoreNotRecordedFor(frame))
            {
                frame.SetSecondBowlScore(kickedPins);
            }
        }

        internal void SetThirdBowlForFrame(Frame frame, int kickedPins)
        {
            ValidateForNull(frame);
            if (IsThirdBowlScoreNotRecordedFor(frame))
            {
                frame.SetThirdBowlBonusScore(kickedPins);
            }
        }

        internal void SetIsReadyToScoreForFrameToTrue(Frame frame)
        {
            ValidateForNull(frame);
            if (!IsThirdBowlScoreNotRecordedFor(frame))
            {
                frame.SetIsFrameReadyForScore(true);
            }
        }

        internal void SetIsFrameClosedFlagToTrue(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetIsFrameClosed(true);
        }

        internal void SetStatusForFrame(Frame frame, FrameStatus frameStatus)
        {
            ValidateForNull(frame);
            frame.SetFrameStatus(frameStatus);
        }

        internal void SetIsFinalFrameFlagToTrue(Frame frame)
        {
            ValidateForNull(frame);
            frame.SetIsFinalFrame(true);
        }



        private void ValidateForNull(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException("The Frame is Null. Pls check.");
        }

        private bool IsSecondBowlScoreNotRecordedFor(Frame frame)
        {
            return frame.SecondBowlScore == _initialValueForBowlThrow;
        }

        private bool IsThirdBowlScoreNotRecordedFor(Frame frame)
        {
            return (frame.ThirdBowlBonusScore == _initialValueForBowlThrow);
        }
    }
}
