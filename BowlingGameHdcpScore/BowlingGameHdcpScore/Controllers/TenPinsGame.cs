using System;
using System.Collections.Generic;
using System.Linq;
using TenPinsBowlingGameHdcp.Exceptions;

namespace TenPinsBowlingGameHdcp.Controllers
{
    public class TenPinsGame
    {
        private List<Frame> _frames = new List<Frame>();
       
        /// <summary>
        /// Takes kicked-pins count for the current throw,
        /// and returns the current score for all applicable frames for the game up until current throw
        /// </summary>
        /// <param name="kickedPins"></param>
        /// <returns></returns>
        public int Bowl(int kickedPins)
        {
            if (!IsValidKickedPinsCount(kickedPins))
                throw new ArgumentException(nameof(kickedPins));

            var currentFrame = GetCurrentFrame();
            ApplyBonuses(kickedPins);
            BowlKickedPins(kickedPins, currentFrame);

            return CalculateScore();
        }

        private int CalculateScore()
        {
            return _frames.Select(x => x.Score).Sum();
        }

        private static void BowlKickedPins(int kickedPins, Frame currentFrame)
        {
            if (!currentFrame.IsFrameClosed) 
                currentFrame.Bowl(kickedPins);
        }

        private void ApplyBonuses(int kickedPins)
        {
            var bonusableFrames = _frames.Where(x => x.NeedsBonus);
            foreach (var frame in bonusableFrames)
            {
                frame.ApplyBonus(kickedPins);
            }
        }

        private Frame GetCurrentFrame()
        {
            var currentFrame = _frames.LastOrDefault();

            if (currentFrame != null && currentFrame.IsFinalFrame && currentFrame.IsFrameClosed && !currentFrame.NeedsBonus)
                throw new GameOverException();

            if (currentFrame == null || (currentFrame.IsFrameClosed && !currentFrame.IsFinalFrame))
            {
                var isFinalFrame = _frames.Count == 9;
                currentFrame = new Frame(isFinalFrame);
                _frames.Add(currentFrame);
            }

            return currentFrame;
        }

        private bool IsValidKickedPinsCount(int kickedPinsCount)
        {
            return kickedPinsCount >= 0 && kickedPinsCount <= 10;
        }
    }
}
