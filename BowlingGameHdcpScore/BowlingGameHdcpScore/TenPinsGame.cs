using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Handlers;

namespace TenPinsBowlingGameHdcp
{
    public class TenPinsGame
    {

        Frame[] ArrayOfFrames = new Frame[_maxFrameNumber];
        private int _currentFrameIndex = 0;

        private const int _maxFrameNumber = CommonGameData.MaxFramesNumber;

        private readonly int _startingPinsNumber = CommonGameData.StartingPinsNumber;
        private readonly int _finalFrameIndex = _maxFrameNumber - 1;

        private readonly GameHandler _gameHandler = new GameHandler();

        private bool _currentFrameIsNotSetYet => ArrayOfFrames[_currentFrameIndex] == null;


        /// <summary>
        /// The name for this method 'Bowl(int)' was in the requirements.
        /// But if requirements are not firm on the name, then it can be changed to something like: "CalculateCurrentScoreForBowl(int)"
        /// </summary>
        /// <param name="kickedPins"></param>
        /// <returns></returns>
        public int Bowl(int kickedPins)
        {
            int gameScore = 0;

            if (_currentFrameIsNotSetYet)
            {
                ArrayOfFrames[_currentFrameIndex] = new Frame();
                OrchestrateOlderFramesBasedOnNewFrameInput(_currentFrameIndex, kickedPins);
            }
            else
            {
                OrchestrateOlderFramesBasedOnExistingFrameInput(_currentFrameIndex, kickedPins);
            }

            gameScore = ScoreCalculator.CalculateCurrentHdcpScoreFor(ArrayOfFrames, _currentFrameIndex);

            SetFrameIndexBasedOnKickedPins(ArrayOfFrames[_currentFrameIndex], kickedPins);

            return gameScore;
        }


        private void OrchestrateOlderFramesBasedOnNewFrameInput(int currentFrameIndex, int kickedPins)
        {
            int previousFrameIndex = currentFrameIndex - 1;
            int beforeLastFrameIndex = currentFrameIndex - 2;

            if (currentFrameIndex == _finalFrameIndex)
                _gameHandler.SetFinalFrameFlagIfApplicable(ArrayOfFrames[currentFrameIndex]);

            _gameHandler.SetInitialValueForNewFrame(ArrayOfFrames[currentFrameIndex], kickedPins);

            if (CheckIfFrameBeforeLastIsAvailable(currentFrameIndex))
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[beforeLastFrameIndex], kickedPins);
            if (CheckIfPreviousFrameIsAvailable(currentFrameIndex))
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);

            _gameHandler.SetStatusForCurrentFrame(ArrayOfFrames[currentFrameIndex]);
        }

        private void OrchestrateOlderFramesBasedOnExistingFrameInput(int currentFrameIndex, int kickedPins)
        {
            int previousFrameIndex = currentFrameIndex - 1;

            if (CheckIfPreviousFrameIsAvailable(currentFrameIndex))
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);

            if (ArrayOfFrames[currentFrameIndex].FrameStatus != FrameStatus.TenthFrameWithBonus)
            {
                //if (ArrayOfFrames[currentFrameIndex].FirstBowlScore != _defaultValueForBowlThrow)
                //{
                //    _gameHandler.SetPropertiesForCurrentFrame(ArrayOfFrames[currentFrameIndex], kickedPins);
                //}
                _gameHandler.SetPropertiesForCurrentFrame(ArrayOfFrames[currentFrameIndex], kickedPins);
            }
            else if (ArrayOfFrames[currentFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus)
            {
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[currentFrameIndex], kickedPins);
            }
        }


        private void SetFrameIndexBasedOnKickedPins(Frame currentFrame, int kickedPins)
        {
            if (!currentFrame.IsFinalFrame)
            {
                if (kickedPins == _startingPinsNumber)
                    _currentFrameIndex++;
                else if (kickedPins < _startingPinsNumber && currentFrame.IsFrameClose)
                    _currentFrameIndex++;
            }
        }


        private bool CheckIfPreviousFrameIsAvailable(int currentFrameIndex)
        {
            return (currentFrameIndex > 0);
        }
        private bool CheckIfFrameBeforeLastIsAvailable(int currentFrameIndex)
        {
            return (currentFrameIndex > 1);
        }
    }
}
