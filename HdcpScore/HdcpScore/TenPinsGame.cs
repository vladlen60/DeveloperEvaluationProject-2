using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinsBowlingGameHdcp
{
    public class TenPinsGame
    {
        Frame[] ArrayOfFrames = new Frame[CommonGameData.MaxFramesNumber];
        private int _currentFrameIndex = 0;

        private readonly int _defaultValueForBowlThrow = CommonGameData.DefaultValueForTheBowlThrow;
        private readonly int _startingPinsNumber = CommonGameData.StartingPinsNumber;
        private readonly int _maxFramesNumberIndex = CommonGameData.MaxFramesNumber - 1;
        private const int _thirdBowlWithoutBonus = 0;

        private readonly GameHandler _gameHandler = new GameHandler();

        private bool _newFrameIsNotSet => ArrayOfFrames[_currentFrameIndex] == null;



        public int Bowl(int kickedPins)
        {
            int gameScore = 0;
            int previousFrameIndex = _currentFrameIndex - 1;
            int beforeLastFrameIndex = _currentFrameIndex - 2;


            if (_currentFrameIndex >= _maxFramesNumberIndex &&
                ArrayOfFrames[previousFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus)
            {
                _currentFrameIndex = _maxFramesNumberIndex;
                previousFrameIndex = _currentFrameIndex - 1;
                beforeLastFrameIndex = _currentFrameIndex - 2;
            }

            //if (ArrayOfFrames[_currentFrameIndex] == null)
            if (_newFrameIsNotSet)
            {
                ArrayOfFrames[_currentFrameIndex] = new Frame();

                SetInitialValueForNewFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
                if (_currentFrameIndex > 0)
                {
                    HandlePreviousFrame(ArrayOfFrames[previousFrameIndex], kickedPins);

                    if (_currentFrameIndex > 1)
                        HandleFrameBeforeLast(ArrayOfFrames[beforeLastFrameIndex], kickedPins);
                }

                if (kickedPins == _startingPinsNumber)
                {
                    HandleCurrentStrikeFrame(ArrayOfFrames[_currentFrameIndex]);
                }

                ReduceIndexIfFirstThrowIsNotStrike(kickedPins);
            }
            else
            {
                if (_currentFrameIndex > 0)
                {
                    HandlePreviousFrame(ArrayOfFrames[previousFrameIndex], kickedPins);
                }

                if (ArrayOfFrames[_currentFrameIndex].FrameStatus != FrameStatus.TenthFrameWithBonus)
                {
                    if (ArrayOfFrames[_currentFrameIndex].FirstBowlScore != _defaultValueForBowlThrow)
                    {
                        HandleCurrentFrame(ArrayOfFrames[_currentFrameIndex], kickedPins);
                    }
                }
                else if (ArrayOfFrames[_currentFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus)
                {
                    HandleFinalFrameWithBonus(ArrayOfFrames[_currentFrameIndex], kickedPins);
                }
            }

            gameScore = ScoreCalculator.CalculateCurrentHdcpScore(ArrayOfFrames, _currentFrameIndex);

            _currentFrameIndex++;

            return gameScore;
        }






        private void SetInitialValueForNewFrame(Frame currentFrame, int kickedPins)
        {
            _gameHandler.SetFirstBowlForFrame(currentFrame, kickedPins);
        }

        private void HandleCurrentFrame(Frame currentFrame, int kickedPins)
        {
            _gameHandler.SetSecondBowlForFrame(currentFrame, kickedPins);
            HandleCurrentSpareFrame(currentFrame);
            HandleCurrentRegularFrame(currentFrame);
            currentFrame.SetIsFrameClosed(true);
        }

        private void HandleCurrentStrikeFrame(Frame currentFrame)
        {
            if (_currentFrameIndex == _maxFramesNumberIndex)
                _gameHandler.SetBonusFlagForFinalFrame(currentFrame);
            _gameHandler.SetIsFrameClosedFlag(currentFrame);
        }

        private void HandleCurrentSpareFrame(Frame currentFrame)
        {
            if (currentFrame.FirstBowlScore + currentFrame.SecondBowlScore == _startingPinsNumber)
            {
                if (_currentFrameIndex == _maxFramesNumberIndex)
                    _gameHandler.SetBonusFlagForFinalFrame(currentFrame);
            }
        }

        private void HandleCurrentRegularFrame(Frame currentFrame)
        {
            if (currentFrame.FirstBowlScore + currentFrame.SecondBowlScore != _startingPinsNumber)
            {
                _gameHandler.SetThirdBowlForFrame(currentFrame, _thirdBowlWithoutBonus); 
                _gameHandler.SetIsReadyToScoreForFrame(currentFrame);
            }
        }

        private void HandlePreviousFrame(Frame previousFrame, int kickedPins)
        {
            if (previousFrame.SecondBowlScore == _defaultValueForBowlThrow)
            {
                _gameHandler.SetSecondBowlForFrame(previousFrame, kickedPins);
            }
            else if (previousFrame.SecondBowlScore != _defaultValueForBowlThrow &&
                     previousFrame.ThirdBowlBonusScore == _defaultValueForBowlThrow)
            {
                _gameHandler.SetThirdBowlForFrame(previousFrame, kickedPins);
                _gameHandler.SetIsReadyToScoreForFrame(previousFrame);
            }
        }

        private void HandleFrameBeforeLast(Frame beforeLastFrame, int kickedPins)
        {
            _gameHandler.SetThirdBowlForFrame(beforeLastFrame, kickedPins);
            _gameHandler.SetIsReadyToScoreForFrame(beforeLastFrame);
        }

        private void HandleFinalFrameWithBonus(Frame currentFrame, int kickedPins)
        {
            if (currentFrame.SecondBowlScore == _defaultValueForBowlThrow)
                _gameHandler.SetSecondBowlForFrame(currentFrame, kickedPins);
            else if (currentFrame.ThirdBowlBonusScore == _defaultValueForBowlThrow)
            {
                _gameHandler.SetThirdBowlForFrame(currentFrame, kickedPins);
                _gameHandler.SetIsReadyToScoreForFrame(currentFrame);
            }
        }

        private void ReduceIndexIfFirstThrowIsNotStrike(int kickedPins)
        {
            if (kickedPins < _startingPinsNumber)
                _currentFrameIndex--;
        }
    }
}
