
namespace TenPinsBowlingGameHdcp
{
    public class ScoreCalculator
    {
        public static int CalculateCurrentHdcpScoreFor(Frame[] arrayOfCurrentFrames, int currentFrameIndex)
        {
            var gameScore = 0;
            for (int countIndex = 0; countIndex <= currentFrameIndex; countIndex++)
            {
                if (arrayOfCurrentFrames[countIndex].IsFrameRedyForScore)
                    gameScore += arrayOfCurrentFrames[countIndex].FirstBowlScore +
                                 arrayOfCurrentFrames[countIndex].SecondBowlScore +
                                 arrayOfCurrentFrames[countIndex].ThirdBowlBonusScore;

            }

            return gameScore;
        }
    }
}
