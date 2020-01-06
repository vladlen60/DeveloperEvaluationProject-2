using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinsBowlingGameHdcp
{
    public class ScoreCalculator
    {
        public static int CalculateCurrentHdcpScore(Frame[] arrayOfFrames, int currentFrameIndex)
        {
            var gameScore = 0;
            for (int countIndex = 0; countIndex <= currentFrameIndex; countIndex++)
            {
                if (arrayOfFrames[countIndex].IsFrameRedyForScore)
                    gameScore += arrayOfFrames[countIndex].FirstBowlScore +
                                 arrayOfFrames[countIndex].SecondBowlScore +
                                 arrayOfFrames[countIndex].ThirdBowlBonusScore;

            }

            return gameScore;
        }
    }
}
