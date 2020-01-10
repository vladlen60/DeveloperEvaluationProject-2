using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Modules;

namespace TenPinsBowlingGameHdcp.Handlers
{
    public class GameHandler
    {
        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;
        private readonly FrameHandler _frameHandler = new FrameHandler();


        internal void SetFirstScoreForNewFrame(Frame currentFrame, int kickedPins)
        {
            _frameHandler.SetFirstBowlForFrame(currentFrame, kickedPins);
        }

        internal void SetFinalFrameFlagIfApplicable(Frame currentFrame)
        {
            _frameHandler.SetIsFinalFrameFlagToTrue(currentFrame);
        }
        
        public virtual void SetPropertiesForCurrentFrame(Frame currentFrame, int kickedPins)
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
            if (currentFrame.FirstBowlScore == _startingPinsNumber)
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.Strike);
            else if (currentFrame.FirstBowlScore + currentFrame.SecondBowlScore == _startingPinsNumber)
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.Spare);
            if (currentFrame.IsFinalFrame && (currentFrame.FrameStatus == FrameStatus.Strike ||
                                              currentFrame.FrameStatus == FrameStatus.Spare))
                _frameHandler.SetStatusForFrame(currentFrame, FrameStatus.TenthFrameWithBonus);
        }

        private const int _thirdBowlForFrameWithoutBonus = ConstTenPinsGameData.ThirdBowlForFrameWithoutBonus;
        private void CompleteRegularFrame(Frame currentFrame)
        {
            ValidateFrameInputIsNotNull(currentFrame);
            if (currentFrame.FirstBowlScore + currentFrame.SecondBowlScore != _startingPinsNumber)
                CompleteSettingPropertiesForFrame(currentFrame, _thirdBowlForFrameWithoutBonus);
        }


        internal void SetFrameClosedFlagIfStrike(Frame currentFrame)
        {
            ValidateFrameInputIsNotNull(currentFrame);
            if (currentFrame.FirstBowlScore == _startingPinsNumber)
                _frameHandler.SetIsFrameClosedFlagToTrue(currentFrame);
        }

        private readonly int _initialValueForBowlThrow = ConstTenPinsGameData.InitialValueForTheBowlThrow;
        internal void SetDifferentPropertiesForFrame(Frame frame, int kickedPins)
        {
            ValidateFrameInputIsNotNull(frame);
            if (frame.SecondBowlScore == _initialValueForBowlThrow)
                _frameHandler.SetSecondBowlForFrame(frame, kickedPins);
            else if (frame.ThirdBowlBonusScore == _initialValueForBowlThrow)
                CompleteSettingPropertiesForFrame(frame, kickedPins);
        }

        private void CompleteSettingPropertiesForFrame(Frame frame, int kickedPins)
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
    }
}
