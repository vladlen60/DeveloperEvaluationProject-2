
namespace TenPinsBowlingGameHdcp.Controllers
{
    internal class ScoreCalculator
    {
        public virtual int CalculateCurrentHdcpScoreFor(Frame[] arrayOfCurrentFrames, int currentFrameIndex)
        {
            var currentScoreForGame = 0;
            for (int countIndex = 0; countIndex <= currentFrameIndex; countIndex++)
            {
                if (arrayOfCurrentFrames[countIndex].IsFrameReadyForScore)
                    currentScoreForGame += arrayOfCurrentFrames[countIndex].FirstBowlScore +
                                 arrayOfCurrentFrames[countIndex].SecondBowlScore +
                                 arrayOfCurrentFrames[countIndex].ThirdBowlBonusScore;

            }

            return currentScoreForGame;
        }
    }
}
