using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Handlers
{
    internal class GameHandler
    {
        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;
        private CommonValidator _validator = new CommonValidator();


        internal void SetFirstScoreForNewFrame(Frame currentFrame, int kickedPins)
        {
            currentFrame.FirstBowlScore = kickedPins;
        }
        
        internal void SetSecondBowlOfRegularFrame(Frame currentFrame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(currentFrame);
            ValidateSecondBowlValueForFrame(currentFrame, kickedPins);
            currentFrame.SecondBowlScore = kickedPins;
            CompleteRegularFrame(currentFrame);
        }

        private void CompleteRegularFrame(Frame currentFrame)
        {
            _validator.ValidateFrameIsNotNull(currentFrame);
            if (!IsSecondBowlSpareFor(currentFrame))
                FinishFrame(currentFrame, ConstTenPinsGameData.ThirdBowlForFrameWithoutBonus);
        }

        internal void SetSecondOrThirdBowlAsAppropriate(Frame frame, int kickedPins)
        {
            _validator.ValidateFrameIsNotNull(frame);
            if (_validator.IsSecondBowlScoreNotRecordedFor(frame))
                frame.SecondBowlScore = kickedPins;
            else if (_validator.IsThirdBowlScoreNotRecordedFor(frame))
                FinishFrame(frame, kickedPins);
        }


        private void FinishFrame(Frame frame, int kickedPins)
        {
            frame.ThirdBowlBonusScore = kickedPins;
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
