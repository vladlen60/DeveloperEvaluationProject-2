using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Handlers
{
    internal class GameHandler
    {
        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;
        private readonly FrameHandler _frameHandler = new FrameHandler();
        private CommonValidator _validator = new CommonValidator();


        internal void SetFirstScoreForNewFrame(Frame currentFrame, int kickedPins)
        {
            _frameHandler.SetFirstBowlForFrame(currentFrame, kickedPins);
        }
        
        internal void SetPropertiesForCurrentFrame(Frame currentFrame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(currentFrame);
            ValidateSecondBowlValueForFrame(currentFrame, kickedPins);
            _frameHandler.SetSecondBowlForFrame(currentFrame, kickedPins);
            SetStatusForCurrentFrame(currentFrame);
            CompleteRegularFrame(currentFrame);
            _frameHandler.SetIsFrameClosedFlagToTrue(currentFrame);
        }

        internal void SetStatusForCurrentFrame(Frame currentFrame)
        {
            _validator.ValidateFrameIsNotNull(currentFrame);
            if (IsFirstBowlStrikeFor(currentFrame))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.Strike);
            else if (IsSecondBowlSpareFor(currentFrame))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.Spare);
            if (currentFrame.IsFinalFrame && (currentFrame.FrameStatus == FrameStatus.Strike ||
                                              currentFrame.FrameStatus == FrameStatus.Spare))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.TenthFrameWithBonus);
        }

        private void CompleteRegularFrame(Frame currentFrame)
        {
            _validator.ValidateFrameIsNotNull(currentFrame);
            if (!IsSecondBowlSpareFor(currentFrame))
                FinishFrame(currentFrame, ConstTenPinsGameData.ThirdBowlForFrameWithoutBonus);
        }


        internal void SetFrameClosedFlagIfStrike(Frame currentFrame)
        {
            _validator.ValidateFrameIsNotNull(currentFrame);
            if (IsFirstBowlStrikeFor(currentFrame))
                _frameHandler.SetIsFrameClosedFlagToTrue(currentFrame);
        }

        internal void SetDifferentPropertiesForFrame(Frame frame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(frame);
            if (_validator.IsSecondBowlScoreNotRecordedFor(frame))
                _frameHandler.SetSecondBowlForFrame(frame, kickedPins);
            else if (_validator.IsThirdBowlScoreNotRecordedFor(frame))
                FinishFrame(frame, kickedPins);
        }


        private void FinishFrame(Frame frame, int kickedPins)
        {
            _frameHandler.SetThirdBowlForFrame(frame, kickedPins);
            _frameHandler.SetIsReadyToScoreForFrameToTrue(frame);
        }


        private void ValidateSecondBowlValueForFrame(Frame frame, int kickedPins)
        {
            if (frame.FirstBowlScore + kickedPins > _startingPinsNumber)
                throw new ArgumentException($"The 2nd throw pins of {kickedPins} is higher than allowed for this frame. Pls check.");
        }

        private bool IsFirstBowlStrikeFor(Frame frame)
        {
            return frame.FirstBowlScore == _startingPinsNumber;
        }

        private bool IsSecondBowlSpareFor(Frame frame)
        {
            return frame.FirstBowlScore + frame.SecondBowlScore == _startingPinsNumber;
        }
    }
}
