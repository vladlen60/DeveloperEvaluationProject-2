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
        private List<int> _bonusScores = new List<int>();

        public bool IsFinalFrame { get; } = false;

        public Frame(bool isfinalFrame = false)
        {
            _firstBowlScore = _secondBowlScore = _thirdBowlBonusScore = NoBallBowled;
            IsFinalFrame = isfinalFrame;
        }

        public void Bowl(int kickedPins)
        {
            if (IsFrameClosed)
            {
                throw new FrameClosedException();
            }

            _bowlScores.Add(kickedPins);
        }

        public void ApplyBonus(int kickedPins)
        {
            if(!NeedsBonus)
            {
                throw new NoBonusNeededException();
            }

            _bonusScores.Add(kickedPins);
        }

        public bool NeedsBonus
        {
            get 
            {
                //if a spare
                if(IsSpare&& _bonusScores.Count() == 0)
                {
                    return true;
                }

                if(IsStrike&& _bonusScores.Count() < 2)
                {
                    return true;
                }

                return false;
            }
        }

        private bool IsSpare => _bowlScores.Count == 2 && _bowlScores.Sum() == ConstTenPinsGameData.StartingPinsNumber;

        private bool IsStrike => _bowlScores.FirstOrDefault() == ConstTenPinsGameData.StartingPinsNumber;

        public bool IsFrameReadyForScore
        {
            get
            {
                //if two balls not strike or spare
                if (_bowlScores.Count == 2 && _bowlScores.Sum() < 10)
                {
                    return true;
                }

                if((IsSpare|| IsStrike) && NeedsBonus == false)
                {
                    return true;
                }

                return false;
            }
        }

        public int Score
        {
            get
            {
                if (IsFrameReadyForScore)
                {
                    return _bowlScores.Sum() + _bonusScores.Sum();
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
