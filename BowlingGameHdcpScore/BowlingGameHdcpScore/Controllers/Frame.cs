using System;
using System.Collections.Generic;
using System.Linq;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Controllers
{
    internal class Frame
    {
        //todo remove this const
        const int NoBallBowled = -1;

        private CommonValidator _validator = new CommonValidator();
        private int _firstBowlScore;
        private int _secondBowlScore;
        private int _thirdBowlBonusScore;
        private List<int> _bowlScores = new List<int>();

        public bool IsFinalFrame { get; } = false;

        public Frame(bool isfinalFrame = false)
        {
            _firstBowlScore = _secondBowlScore = _thirdBowlBonusScore = NoBallBowled;
            IsFinalFrame = isfinalFrame;
        }

        public bool IsFrameReadyForScore
        {
            get
            {
                //if two balls not strike or spare
                if (FirstBowlScore != NoBallBowled
                    && SecondBowlScore != NoBallBowled
                    && FirstBowlScore + SecondBowlScore < ConstTenPinsGameData.StartingPinsNumber)
                {
                    return true;
                }

                //if all balls including bonus
                if (FirstBowlScore != NoBallBowled
                    && SecondBowlScore != NoBallBowled
                    && ThirdBowlBonusScore != NoBallBowled)
                {
                    return true;
                }

                return false;
            }
        }

        public void Bowl(int kickedPins)
        {
            if (IsFrameClosed)
            {
                throw new FrameClosedException();
            }

            _bowlScores.Add(kickedPins);
        }

        public int Score
        {
            get
            {
                if (IsFrameClosed)
                {
                    return _bowlScores.Sum();
                }

                return 0;
            }
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

        public bool IsFrameClosed
        {
            get
            {
                if (_bowlScores.FirstOrDefault() == ConstTenPinsGameData.StartingPinsNumber)
                {
                    return true;
                }

                return _bowlScores.Count == 2;
            }
        }
    }
}
