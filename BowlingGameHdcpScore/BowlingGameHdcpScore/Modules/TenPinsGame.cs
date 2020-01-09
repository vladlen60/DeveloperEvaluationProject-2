using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Handlers;

namespace TenPinsBowlingGameHdcp.Modules
{
    public class TenPinsGame
    {
        Frame[] ArrayOfFrames = new Frame[_maxFrameNumber];
        private int _currentFrameIndex = 0;

        private const int _maxFrameNumber = ConstTenPinsGameData.MaxFramesNumber;
        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;
        private readonly int _finalFrameIndex = _maxFrameNumber - 1;
        private readonly GameHandler _gameHandler = new GameHandler();

        private bool _currentFrameIsNotSetYet => ArrayOfFrames[_currentFrameIndex] == null;
        private bool _isFinalFrame => _currentFrameIndex == _finalFrameIndex;
        private bool _frameBeforeLastIsAvailable => (_currentFrameIndex > 1) ? true : false;
        private bool _previousFrameIsAvailable => (_currentFrameIndex > 0) ? true : false;
        private bool _isCurrentFrameFinalWithBonus =>
            (ArrayOfFrames[_currentFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus) ? true : false;



        public int Bowl(int kickedPins)
        {
            int gameScore = 0;
            ValidateGameInputOfKickedPins(kickedPins);
            ValidateIfNewThrowAllowedForFinalFrame(ArrayOfFrames[_currentFrameIndex]);

            if (_currentFrameIsNotSetYet)
            {
                ArrayOfFrames[_currentFrameIndex] = new Frame();
                OrchestrateFramesBasedOnFirstThrowScore(kickedPins);
            }
            else
            {
                OrchestrateFramesBasedOnSecondThrowScore(kickedPins);
            }

            gameScore = ScoreCalculator.CalculateCurrentHdcpScoreFor(ArrayOfFrames, _currentFrameIndex);

            _currentFrameIndex = UpdateFrameIndexWhileNotFinalFrame(ArrayOfFrames[_currentFrameIndex], _currentFrameIndex);

            return gameScore;
        }





        private void OrchestrateFramesBasedOnFirstThrowScore(int kickedPins)
        {
            int previousFrameIndex = _currentFrameIndex - 1;
            int beforeLastFrameIndex = _currentFrameIndex - 2;

            if (_isFinalFrame)
                _gameHandler.SetFinalFrameFlagIfApplicable(ArrayOfFrames[_currentFrameIndex]);

            _gameHandler.SetFirstScoreForNewFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);

            if (_frameBeforeLastIsAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[beforeLastFrameIndex], kickedPins);
            if (_previousFrameIsAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);

            _gameHandler.SetStatusForCurrentFrame(ArrayOfFrames[_currentFrameIndex]);
            _gameHandler.SetFrameClosedFlagIfStrike(ArrayOfFrames[_currentFrameIndex]);
        }

        private void OrchestrateFramesBasedOnSecondThrowScore(int kickedPins)
        {
            int previousFrameIndex = _currentFrameIndex - 1;

            if (_previousFrameIsAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);
            
            if (_isCurrentFrameFinalWithBonus)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
            else
                _gameHandler.SetPropertiesForCurrentFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
        }

        private void ValidateGameInputOfKickedPins(int kickedPins)
        {
            if (kickedPins < 0 || kickedPins > _startingPinsNumber)
                throw new ArgumentException($"Sorry, your kickedPins '{kickedPins}' is out of allowed range 0-{_startingPinsNumber}. Pls check.");
        }

        private void ValidateIfNewThrowAllowedForFinalFrame(Frame currentFrame)
        {
            if (currentFrame != null && currentFrame.IsFinalFrame && currentFrame.IsFrameReadyForScore)
                throw new ArgumentException("Sorry, you have played All available bowl-throws for this game. Pls start a new game.");
        }

        private int UpdateFrameIndexWhileNotFinalFrame(Frame currentFrame, int currentFrameIndex)
        {
            if (!currentFrame.IsFinalFrame)
                currentFrameIndex = SetFrameIndexBasedOnKickedPins(currentFrame, currentFrameIndex);

            return currentFrameIndex;
        }

        private int SetFrameIndexBasedOnKickedPins(Frame currentFrame, int currentFrameIndex)
        {
            if (currentFrame.FrameStatus == FrameStatus.Strike)
                currentFrameIndex++;
            else if (currentFrame.IsFrameClose)
                currentFrameIndex++;

            return currentFrameIndex;
        }
    }
}
