
namespace TenPinsBowlingGameHdcp.Controllers
{
    internal class ScoreCalculator
    {
        public virtual int CalculateCurrentHdcpScoreFor(Frame[] arrayOfCurrentFrames, int currentFrameIndex)
        {
            var currentScoreForGame = 0;
            for (int i = 0; i <= currentFrameIndex; i++)
            {
                var frame = arrayOfCurrentFrames[i];
                currentScoreForGame += frame.Score;
            }

            return currentScoreForGame;
        }
    }
}
