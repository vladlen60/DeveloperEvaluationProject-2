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



        public int Bowl(int kickedPins)
        {
            int gameScore = 0;
            int previousFrameIndex = _currentFrameIndex - 1;
            int twoFramesAgoIndex = _currentFrameIndex - 2;

            if (_currentFrameIndex > 8 &&
                ArrayOfFrames[previousFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus)
            {
                _currentFrameIndex = _maxFramesNumberIndex;
                previousFrameIndex = _currentFrameIndex - 1;
                twoFramesAgoIndex = _currentFrameIndex - 2;
            }

            if (ArrayOfFrames[_currentFrameIndex] == null)
            {
                ArrayOfFrames[_currentFrameIndex] = new Frame();
                if (kickedPins == _startingPinsNumber)
                {
                    ArrayOfFrames[_currentFrameIndex].SetFirstBowlScore(kickedPins);
                    if (_currentFrameIndex > 0)
                    {
                        if (ArrayOfFrames[previousFrameIndex].SecondBowlScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[previousFrameIndex].SetSecondBowlScore(kickedPins);
                        }
                        else if (ArrayOfFrames[previousFrameIndex].SecondBowlScore != _defaultValueForBowlThrow && ArrayOfFrames[previousFrameIndex].ThirdBowlBonusScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[previousFrameIndex].SetThirdBowlBonusScore(kickedPins);
                            ArrayOfFrames[previousFrameIndex].SetIsFrameReadyForScore(true);
                        }

                        if (_currentFrameIndex > 1 && ArrayOfFrames[twoFramesAgoIndex].ThirdBowlBonusScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[twoFramesAgoIndex].SetThirdBowlBonusScore(kickedPins);
                            ArrayOfFrames[twoFramesAgoIndex].SetIsFrameReadyForScore(true);
                        }
                    }

                    if (_currentFrameIndex == _maxFramesNumberIndex)
                        ArrayOfFrames[_currentFrameIndex].FrameStatus = FrameStatus.TenthFrameWithBonus;
                    ArrayOfFrames[_currentFrameIndex].SetIsFrameClosed(true);
                }

                if (kickedPins < _startingPinsNumber)
                {
                    ArrayOfFrames[_currentFrameIndex].SetFirstBowlScore(kickedPins);
                    ArrayOfFrames[_currentFrameIndex].FrameStatus = FrameStatus.Points;
                    if (_currentFrameIndex > 0)
                    {
                        if (ArrayOfFrames[previousFrameIndex].SecondBowlScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[previousFrameIndex].SetSecondBowlScore(kickedPins);
                        }
                        else if (ArrayOfFrames[previousFrameIndex].SecondBowlScore != _defaultValueForBowlThrow && ArrayOfFrames[previousFrameIndex].ThirdBowlBonusScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[previousFrameIndex].SetThirdBowlBonusScore(kickedPins);
                            ArrayOfFrames[previousFrameIndex].SetIsFrameReadyForScore(true);
                        }

                        if (_currentFrameIndex > 1 && ArrayOfFrames[twoFramesAgoIndex].ThirdBowlBonusScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[twoFramesAgoIndex].SetThirdBowlBonusScore(kickedPins);
                            ArrayOfFrames[twoFramesAgoIndex].SetIsFrameReadyForScore(true);
                        }
                    }
                    _currentFrameIndex--;
                }
            }
            else
            {
                if (_currentFrameIndex > 0)
                {
                    if (ArrayOfFrames[previousFrameIndex].SecondBowlScore == _defaultValueForBowlThrow)
                        ArrayOfFrames[previousFrameIndex].SetSecondBowlScore(kickedPins);
                    else if (ArrayOfFrames[previousFrameIndex].SecondBowlScore != _defaultValueForBowlThrow &&
                             ArrayOfFrames[previousFrameIndex].ThirdBowlBonusScore == _defaultValueForBowlThrow)
                    {
                        ArrayOfFrames[previousFrameIndex].SetThirdBowlBonusScore(kickedPins);
                        ArrayOfFrames[previousFrameIndex].SetIsFrameReadyForScore(true);
                    }
                }


                if (ArrayOfFrames[_currentFrameIndex].FrameStatus != FrameStatus.TenthFrameWithBonus)
                {
                    if (ArrayOfFrames[_currentFrameIndex].FirstBowlScore != _defaultValueForBowlThrow)
                    {
                        if (ArrayOfFrames[_currentFrameIndex].SecondBowlScore == _defaultValueForBowlThrow)
                        {
                            ArrayOfFrames[_currentFrameIndex].SetSecondBowlScore(kickedPins);
                            if (ArrayOfFrames[_currentFrameIndex].FirstBowlScore + ArrayOfFrames[_currentFrameIndex].SecondBowlScore == _startingPinsNumber)
                            {
                                if (_currentFrameIndex == _maxFramesNumberIndex)
                                    ArrayOfFrames[_currentFrameIndex].FrameStatus = FrameStatus.TenthFrameWithBonus;
                                ArrayOfFrames[_currentFrameIndex].SetIsFrameClosed(true);
                            }
                            else
                            {
                                ArrayOfFrames[_currentFrameIndex].SetThirdBowlBonusScore(0);
                                ArrayOfFrames[_currentFrameIndex].SetIsFrameClosed(true);
                                ArrayOfFrames[_currentFrameIndex].SetIsFrameReadyForScore(true);
                            }
                        }
                    }
                }
                else if (ArrayOfFrames[_currentFrameIndex].FrameStatus == FrameStatus.TenthFrameWithBonus)
                {
                    if (ArrayOfFrames[_currentFrameIndex].SecondBowlScore == _defaultValueForBowlThrow)
                        ArrayOfFrames[_currentFrameIndex].SetSecondBowlScore(kickedPins);
                    else if (ArrayOfFrames[_currentFrameIndex].ThirdBowlBonusScore == _defaultValueForBowlThrow)
                    {
                        ArrayOfFrames[_currentFrameIndex].SetThirdBowlBonusScore(kickedPins);
                        ArrayOfFrames[_currentFrameIndex].SetIsFrameReadyForScore(true);
                    }
                }
            }

            gameScore = ScoreCalculator.CalculateCurrentHdcpScore(ArrayOfFrames, _currentFrameIndex);

            _currentFrameIndex++;

            return gameScore;
        }
    }
}
