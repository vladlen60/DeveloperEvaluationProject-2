using System;
using TenPinsBowlingGameHdcp.Controllers;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Handlers
{
    internal class FrameHandler
    {
        private CommonValidator _validator = new CommonValidator();

        internal void SetFirstBowlForFrame(Frame frame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(frame);
            frame.SetFirstBowlScore(kickedPins);
        }

        internal void SetSecondBowlForFrame(Frame frame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(frame);
            if (_validator.IsSecondBowlScoreNotRecordedFor(frame))
            {
                frame.SetSecondBowlScore(kickedPins);
            }
        }

        internal void SetThirdBowlForFrame(Frame frame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(frame);
            if (_validator.IsThirdBowlScoreNotRecordedFor(frame))
            {
                frame.SetThirdBowlBonusScore(kickedPins);
            }
        }

        internal void SetIsReadyToScoreForFrameToTrue(Frame frame)
        {
            _validator.ValidateFrameIsNotNull(frame);
            if (!_validator.IsThirdBowlScoreNotRecordedFor(frame))
            {
                frame.SetIsFrameReadyForScore(true);
            }
        }

        internal void SetIsFrameClosedFlagToTrue(Frame frame)
        {
            _validator.ValidateFrameIsNotNull(frame);
            frame.SetIsFrameClosed(true);
        }

        internal void SetStatusForFrame(Frame frame, FrameStatus frameStatus)
        {
            _validator.ValidateFrameIsNotNull(frame);
            frame.SetFrameStatus(frameStatus);
        }

        internal void SetIsFinalFrameFlagToTrue(Frame frame)
        {
            _validator.ValidateFrameIsNotNull(frame);
            frame.SetIsFinalFrame(true);
        }
    }
}
