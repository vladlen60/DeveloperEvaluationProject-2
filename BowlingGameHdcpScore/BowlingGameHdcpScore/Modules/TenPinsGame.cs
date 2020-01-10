using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Handlers;

namespace TenPinsBowlingGameHdcp.Modules
{
    public class TenPinsGame : GameBase
    {
        Frame[] ArrayOfFrames;
        private int _currentFrameIndex;
        private readonly int _maxFrameNumber;

        
        public TenPinsGame() : base()
        {
            _currentFrameIndex = 0;
            _maxFrameNumber = ConstTenPinsGameData.MaxFramesNumber;
            ArrayOfFrames = new Frame[_maxFrameNumber];
        }

        public TenPinsGame(string gameInput) : base(gameInput)
        {
            _currentFrameIndex = 0;
            _maxFrameNumber = ConstTenPinsGameData.MaxFramesNumber;
            ArrayOfFrames = new Frame[_maxFrameNumber];
        }

        private bool _currentFrameIsNotSetYet => ArrayOfFrames[_currentFrameIndex] == null;
        public int Bowl(int kickedPins)
        {
            int gameScore = 0;
            ValidateGameInputOfKickedPins(kickedPins);
            ValidateIfNewBowlAllowedForFinalFrame(ArrayOfFrames[_currentFrameIndex]);

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

            _currentFrameIndex = IncreaseFrameIndexWhileNotFinalFrame(ArrayOfFrames[_currentFrameIndex], _currentFrameIndex);

            return gameScore;
        }



        private readonly int _finalFrameIndex = ConstTenPinsGameData.FinalFrameIndex;
        private bool _isFinalFrame => _currentFrameIndex == _finalFrameIndex;
        private bool _frameBeforeLastIsAvailable => (_currentFrameIndex > 1) ? true : false;
        private bool _previousFrameIsAvailable => (_currentFrameIndex > 0) ? true : false;
        private readonly GameHandler _gameHandler = new GameHandler();


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

        private bool _isCurrentFrameFinalWithBonus =>
            (ArrayOfFrames[_currentFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus) ? true : false;

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

        private readonly int _startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;

        private void ValidateGameInputOfKickedPins(int kickedPins)
        {
            if (kickedPins < 0 || kickedPins > _startingPinsNumber)
                throw new ArgumentException($"Sorry, your kickedPins '{kickedPins}' is out of allowed range 0-{_startingPinsNumber}. Pls check.");
        }

        private void ValidateIfNewBowlAllowedForFinalFrame(Frame currentFrame)
        {
            if (currentFrame != null && currentFrame.IsFinalFrame && currentFrame.IsFrameReadyForScore)
                throw new ArgumentException("Sorry, you have played All available bowl-throws for this game. Pls start a new game.");
        }

        private int IncreaseFrameIndexWhileNotFinalFrame(Frame currentFrame, int currentFrameIndex)
        {
            if (!currentFrame.IsFinalFrame && currentFrame.IsFrameClose)
                currentFrameIndex++;

            return currentFrameIndex;
        }
    }
}
