using System;
using TenPinsBowlingGameHdcp.Common;

namespace TenPinsBowlingGameHdcp.Handlers
{
    public class GameHandler
    {
        private readonly int _defaultValueForBowlThrow = CommonGameData.DefaultValueForTheBowlThrow;
        private readonly int _startingPinsNumber = CommonGameData.StartingPinsNumber;
        private readonly FrameHamdler _frameHandler = new FrameHamdler();

        private const int _thirdBowlWithoutBonus = 0;



        public void SetInitialValueForNewFrame(Frame currentFrame, int kickedPins)
        {
            _frameHandler.SetFirstBowlForFrame(currentFrame, kickedPins);
        }

        public void SetFinalFrameFlagIfApplicable(Frame currentFrame)
        {
            _frameHandler.SetIsFinalFrameFlagToTrue(currentFrame);
        }
        
        public void SetPropertiesForCurrentFrame(Frame currentFrame, int kickedPins)
        {
            _frameHandler.SetSecondBowlForFrame(currentFrame, kickedPins);
            this.SetStatusForCurrentFrame(currentFrame);
            this.CompleteCurrentRegularFrame(currentFrame);
            _frameHandler.SetIsFrameClosedFlagToTrue(currentFrame);
        }

        public void SetStatusForCurrentFrame(Frame currentFrame)
        {
            if (currentFrame.FirstBowlScore == _startingPinsNumber)
                _frameHandler.SetStatusForCurrentFrame(currentFrame, FrameStatus.Strike);
            else if (currentFrame.FirstBowlScore + currentFrame.SecondBowlScore == _startingPinsNumber)
                _frameHandler.SetStatusForCurrentFrame(currentFrame, FrameStatus.Spare);
            if (currentFrame.IsFinalFrame && (currentFrame.FrameStatus == FrameStatus.Strike ||
                                              currentFrame.FrameStatus == FrameStatus.Spare))
                _frameHandler.SetStatusForCurrentFrame(currentFrame, FrameStatus.TenthFrameWithBonus);
        }

        private void CompleteCurrentRegularFrame(Frame currentFrame)
        {
            if (currentFrame.FirstBowlScore + currentFrame.SecondBowlScore != _startingPinsNumber)
            {
                _frameHandler.SetThirdBowlForFrame(currentFrame, _thirdBowlWithoutBonus);
                _frameHandler.SetIsReadyToScoreForFrameToTrue(currentFrame);
            }
        }

        public void SetDifferentPropertiesForFrame(Frame frame, int kickedPins)
        {
            if (frame.SecondBowlScore == _defaultValueForBowlThrow)
            {
                _frameHandler.SetSecondBowlForFrame(frame, kickedPins);
            }
            else if (frame.SecondBowlScore != _defaultValueForBowlThrow &&
                     frame.ThirdBowlBonusScore == _defaultValueForBowlThrow)
            {
                this.CompleteSettingPropertiesForFrame(frame, kickedPins);
            }
            
        }

        private void CompleteSettingPropertiesForFrame(Frame frame, int kickedPins)
        {
            _frameHandler.SetThirdBowlForFrame(frame, kickedPins);
            _frameHandler.SetIsReadyToScoreForFrameToTrue(frame);
        }
    }
}
