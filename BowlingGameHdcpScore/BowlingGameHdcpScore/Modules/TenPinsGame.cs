﻿using System;
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


        /// <summary>
        /// The name for this method 'Bowl(int)' was in the requirements.
        /// But if the requirements are not firm on the name, then it can be changed to something like: "CalculateCurrentScoreForBowl(int)"
        /// </summary>
        /// <param name="kickedPins"></param>
        /// <returns></returns>
        public int Bowl(int kickedPins)
        {
            int gameScore = 0;
            ValidateKickedPinsInput(kickedPins);
            ValidateIfNewThrowAllowedForFinalFrame(ArrayOfFrames[_currentFrameIndex]);

            if (_currentFrameIsNotSetYet)
            {
                ArrayOfFrames[_currentFrameIndex] = new Frame();
                OrchestrateFramesWithFirstThrowScore(kickedPins);
            }
            else
            {
                OrchestrateFramesWithSecondThrowScore(kickedPins);
            }

            gameScore = ScoreCalculator.CalculateCurrentHdcpScoreFor(ArrayOfFrames, _currentFrameIndex);

            SetFrameIndexForNoneFinalFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);

            return gameScore;
        }





        private void OrchestrateFramesWithFirstThrowScore(int kickedPins)
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

        private void OrchestrateFramesWithSecondThrowScore(int kickedPins)
        {
            int previousFrameIndex = _currentFrameIndex - 1;

            if (_previousFrameIsAvailable)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[previousFrameIndex], kickedPins);
            
            if (_isCurrentFrameFinalWithBonus)
                _gameHandler.SetDifferentPropertiesForFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
            else
                _gameHandler.SetPropertiesForCurrentFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
        }

        private void ValidateKickedPinsInput(int kickedPins)
        {
            if (kickedPins < 0 || kickedPins > _startingPinsNumber)
                throw new ArgumentException($"Sorry, your kickedPins '{kickedPins}' is out of allowed range 0-{_startingPinsNumber}. Pls check.");
        }

        private void ValidateIfNewThrowAllowedForFinalFrame(Frame currentFrame)
        {
            if (currentFrame != null && currentFrame.IsFinalFrame && currentFrame.IsFrameReadyForScore)
                throw new ArgumentException("Sorry, you have played All available bowl-throws for this game. Pls start a new game.");
        }

        private void SetFrameIndexForNoneFinalFrame(Frame currentFrame, int kickedPins)
        {
            if (!currentFrame.IsFinalFrame)
                SetFrameIndexBasedOnKickedPins(currentFrame, kickedPins);
        }

        private void SetFrameIndexBasedOnKickedPins(Frame currentFrame, int kickedPins)
        {
            if (kickedPins == _startingPinsNumber)
                _currentFrameIndex++;
            else if (currentFrame.IsFrameClose)
                _currentFrameIndex++;
        }
    }
}