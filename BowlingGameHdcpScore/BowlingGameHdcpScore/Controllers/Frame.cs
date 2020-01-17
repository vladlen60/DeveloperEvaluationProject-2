using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Controllers
{
    internal class Frame
    {
        private CommonValidator _validator = new CommonValidator();

        public FrameStatus FrameStatus { get; private set; }
        public int FirstBowlScore { get; private set; } = ConstTenPinsGameData.InitialValueForTheBowlThrow;
        public int SecondBowlScore { get; private set; } = ConstTenPinsGameData.InitialValueForTheBowlThrow;
        public int ThirdBowlBonusScore { get; private set; } = ConstTenPinsGameData.InitialValueForTheBowlThrow;

        public bool IsFrameClose { get; private set; } = false;
        public bool IsFrameReadyForScore { get; private set; } = false;
        public bool IsFinalFrame { get; private set; } = false;


        public void SetFirstBowlScore(int kickedPinsCount)
        {
            _validator.ValidateKickedPinsCount(kickedPinsCount);
            FirstBowlScore = kickedPinsCount;
        }

        public void SetSecondBowlScore(int kickedPinsCount)
        {
            _validator.ValidateKickedPinsCount(kickedPinsCount);
            SecondBowlScore = kickedPinsCount;
        }

        public void SetThirdBowlBonusScore(int kickedPinsCount)
        {
            _validator.ValidateKickedPinsCount(kickedPinsCount);
            ThirdBowlBonusScore = kickedPinsCount;
        }

        public void SetIsFrameClosed(bool isSet)
        {
            IsFrameClose = isSet;
        }

        public void SetIsFrameReadyForScore(bool isSet)
        {
            IsFrameReadyForScore = isSet;
        }

        public void SetIsFinalFrame(bool isSet)
        {
            IsFinalFrame = isSet;
        }

        public void SetFrameStatus(FrameStatus frameStatus)
        {
            FrameStatus = frameStatus;
        }
    }
}
