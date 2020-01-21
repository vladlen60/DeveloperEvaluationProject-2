using System;
using System.Collections.Generic;
using System.Linq;
using TenPinsBowlingGameHdcp.Common;

namespace TenPinsBowlingGameHdcp.Controllers
{
    internal class Frame
    {
        private List<int> _bowlScores = new List<int>();
        private List<int> _bonusScores = new List<int>();

        public bool IsFinalFrame { get; } = false;

        public Frame(bool isfinalFrame = false)
        {
            IsFinalFrame = isfinalFrame;
        }

        public void Bowl(int kickedPins)
        {
            if (IsFrameClosed)
            {
                throw new FrameClosedException();
            }

            if(_bowlScores.Sum() + kickedPins > 10)
            {
                throw new TooManyPinsException();
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
