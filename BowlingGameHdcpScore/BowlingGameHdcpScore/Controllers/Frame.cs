using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Controllers
{
    internal class Frame
    {
        private CommonValidator _validator = new CommonValidator();
        private int _firstBowlScore;
        private int _secondBowlScore;
        private int _thirdBowlBonusScore;

        public FrameStatus FrameStatus { get; private set; }

        public bool IsFrameClose { get; private set; } = false;
        public bool IsFrameReadyForScore { get; private set; } = false;
        public bool IsFinalFrame { get; } = false;

        public Frame(bool isfinalFrame = false)
        {
            _firstBowlScore = _secondBowlScore = _thirdBowlBonusScore = ConstTenPinsGameData.InitialValueForTheBowlThrow;
            IsFinalFrame = isfinalFrame;
        }

        public int FirstBowlScore
        {
            get
            {
                return _firstBowlScore;
            }
            set
            {
                if (!_validator.IsValidKickedPinsCount(value)) 
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _firstBowlScore = value;
            }
        }

        public int SecondBowlScore
        {
            get
            {
                return _secondBowlScore;
            }
            set
            {
                if (!_validator.IsValidKickedPinsCount(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _secondBowlScore = value;
            }
        }

        public int ThirdBowlBonusScore
        {
            get
            {
                return _thirdBowlBonusScore;
            }
            set
            {
                if (!_validator.IsValidKickedPinsCount(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _thirdBowlBonusScore = value;
            }
        }

        public void SetIsFrameClosed(bool isSet)
        {
            IsFrameClose = isSet;
        }

        public void SetIsFrameReadyForScore(bool isSet)
        {
            IsFrameReadyForScore = isSet;
        }

        public void SetFrameStatus(FrameStatus frameStatus)
        {
            FrameStatus = frameStatus;
        }
    }
}
