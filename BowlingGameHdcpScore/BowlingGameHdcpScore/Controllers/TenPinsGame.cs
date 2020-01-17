using System;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Handlers;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Controllers
{
    public class TenPinsGame
    {
        private Frame[] ArrayOfFrames;
        private int _currentFrameIndex;
        private readonly int _maxFrameNumber;
        private ScoreCalculator _scoreCalculator;
        private CommonValidator _validator = new CommonValidator();


        public TenPinsGame()
        {
            _currentFrameIndex = 0;
            _maxFrameNumber = ConstTenPinsGameData.MaxFramesNumber;
            ArrayOfFrames = new Frame[_maxFrameNumber];
            _scoreCalculator = new ScoreCalculator();
        }

        private bool _currentFrameIsNotSetYet => ArrayOfFrames[_currentFrameIndex] == null;
        /// <summary>
        /// Takes kicked-pins count for the current throw,
        /// and returns the current score for all applicable frames for the game up until current throw
        /// </summary>
        /// <param name="kickedPins"></param>
        /// <returns></returns>
        public int Bowl(int kickedPins)
        {
            int currentScoreForGame = 0;
            _validator.ValidateKickedPinsCount(kickedPins);
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

            currentScoreForGame = _scoreCalculator.CalculateCurrentHdcpScoreFor(ArrayOfFrames, _currentFrameIndex);

            _currentFrameIndex = IncreaseFrameIndexWhileNotFinalFrame(ArrayOfFrames[_currentFrameIndex], _currentFrameIndex);

            return currentScoreForGame;
        }



        private bool _isFinalFrame => _currentFrameIndex == ConstTenPinsGameData.FinalFrameIndex;
        private bool _isFrameBeforeLastAvailable => (_currentFrameIndex > 1) ? true : false;
        private bool _isPreviousFrameAvailable => (_currentFrameIndex > 0) ? true : false;
        private readonly GameHandler _gameHandler = new GameHandler();

        private void OrchestrateFramesBasedOnFirstThrowScore(int kickedPins)
        {
            int previousFrameIndex = _currentFrameIndex - 1;
            int beforeLastFrameIndex = _currentFrameIndex - 2;

            if (_isFinalFrame)
                _gameHandler.SetFinalFrameFlagIfApplicableFor(ArrayOfFrames[_currentFrameIndex]);

            _gameHandler.SetFirstScoreForNewFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);

            if (_isFrameBeforeLastAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[beforeLastFrameIndex], kickedPins);
            if (_isPreviousFrameAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);

            _gameHandler.SetStatusForCurrentFrame(ArrayOfFrames[_currentFrameIndex]);
            _gameHandler.SetFrameClosedFlagIfStrike(ArrayOfFrames[_currentFrameIndex]);
        }

        private bool _isCurrentFrameFinalWithBonus =>
            (ArrayOfFrames[_currentFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus) ? true : false;
        private void OrchestrateFramesBasedOnSecondThrowScore(int kickedPins)
        {
            int previousFrameIndex = _currentFrameIndex - 1;

            if (_isPreviousFrameAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);
            
            if (_isCurrentFrameFinalWithBonus)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
            else
                _gameHandler.SetPropertiesForCurrentFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
        }

        private int IncreaseFrameIndexWhileNotFinalFrame(Frame currentFrame, int currentFrameIndex)
        {
            if (!currentFrame.IsFinalFrame && currentFrame.IsFrameClose)
                currentFrameIndex++;

            return currentFrameIndex;
        }


        private void ValidateIfNewBowlAllowedForFinalFrame(Frame currentFrame)
        {
            if (currentFrame != null && currentFrame.IsFinalFrame && currentFrame.IsFrameReadyForScore)
                throw new ArgumentException("Sorry, you have played All available bowl-throws for this game. Pls start a new game.");
        }

    }
}
