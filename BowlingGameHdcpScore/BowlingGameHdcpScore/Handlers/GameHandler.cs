using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Modules;

namespace TenPinsBowlingGameHdcp.Handlers
{
    internal class GameHandler
    {
        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;
        private readonly FrameHandler _frameHandler = new FrameHandler();


        internal void SetFirstScoreForNewFrame(Frame currentFrame, int kickedPins)
        {
            _frameHandler.SetFirstBowlForFrame(currentFrame, kickedPins);
        }

        internal void SetFinalFrameFlagIfApplicableFor(Frame currentFrame)
        {
            _frameHandler.SetIsFinalFrameFlagToTrue(currentFrame);
        }
        
        internal void SetPropertiesForCurrentFrame(Frame currentFrame, int kickedPins)
        {
            ValidateFrameInputIsNotNull(currentFrame);
            ValidateSecondBowlValueForFrame(currentFrame, kickedPins);
            _frameHandler.SetSecondBowlForFrame(currentFrame, kickedPins);
            SetStatusForCurrentFrame(currentFrame);
            CompleteRegularFrame(currentFrame);
            _frameHandler.SetIsFrameClosedFlagToTrue(currentFrame);
        }

        internal void SetStatusForCurrentFrame(Frame currentFrame)
        {
            ValidateFrameInputIsNotNull(currentFrame);
            if (IsFirstBowlStrikeFor(currentFrame))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.Strike);
            else if (IsSecondBowlSpareFor(currentFrame))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.Spare);
            if (currentFrame.IsFinalFrame && (currentFrame.FrameStatus == FrameStatus.Strike ||
                                              currentFrame.FrameStatus == FrameStatus.Spare))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.TenthFrameWithBonus);
        }

        private const int _thirdBowlForFrameWithoutBonus = ConstTenPinsGameData.ThirdBowlForFrameWithoutBonus;
        private void CompleteRegularFrame(Frame currentFrame)
        {
            ValidateFrameInputIsNotNull(currentFrame);
            if (!IsSecondBowlSpareFor(currentFrame))
                FinishFrame(currentFrame, _thirdBowlForFrameWithoutBonus);
        }


        internal void SetFrameClosedFlagIfStrike(Frame currentFrame)
        {
            ValidateFrameInputIsNotNull(currentFrame);
            if (IsFirstBowlStrikeFor(currentFrame))
                _frameHandler.SetIsFrameClosedFlagToTrue(currentFrame);
        }

        private readonly int _initialValueForBowlThrow = ConstTenPinsGameData.InitialValueForTheBowlThrow;
        internal void SetDifferentPropertiesForFrame(Frame frame, int kickedPins)
        {
            ValidateFrameInputIsNotNull(frame);
            if (IsSecondBowlScoreNotRecordedFor(frame))
                _frameHandler.SetSecondBowlForFrame(frame, kickedPins);
            else if (IsThirdBowlScoreNotRecordedFor(frame))
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

        private void ValidateFrameInputIsNotNull(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException($"The Frame provided {frame} is Null. Pls check.");
        }

        private bool IsFirstBowlStrikeFor(Frame frame)
        {
            return frame.FirstBowlScore == _startingPinsNumber;
        }

        private bool IsSecondBowlSpareFor(Frame frame)
        {
            return frame.FirstBowlScore + frame.SecondBowlScore == _startingPinsNumber;
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
