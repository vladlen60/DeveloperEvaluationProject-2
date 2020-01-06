using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BowlingGameHdcp
{
    public class Class1
    {
    }

    public enum Status
    {
        Points,
        Spare,
        Strike,
        TenthFrameStrike,
        TenthFrameSpare
    }

    public enum CurrentBowlTry
    {
        FirstBowl,
        SecondBowl,
        ThirdBowl
    }

    public class BowlingFrame
    {
        public Status FrameStatus;

        public int FirstBowlScore = -1;
        public int SecondBowlScore = -1;
        public int ThirdBowlScore = -1;

        public CurrentBowlTry CurrentBowlTryForTheFrame;

        public bool IsFrameClose = false;

        public bool IsFrameRedyForScore = false;

    }

    public class BowlingGame
    {
        BowlingFrame[] ArrayOfFrames = new BowlingFrame[10];
        public int CurrentFrame = 0;
        

        public int Bowl(int kickedPins)
        {
            int gameScore = 0;

            if (CurrentFrame == 7)
            {
                Thread.Sleep(4000);
                Console.WriteLine("--- SLEEPING ---");
            }
                

            if (CurrentFrame > 8 && (ArrayOfFrames[CurrentFrame - 1].FrameStatus == Status.TenthFrameStrike ||
                                     ArrayOfFrames[CurrentFrame - 1].FrameStatus == Status.TenthFrameSpare))
                CurrentFrame = 9;
            
            if (ArrayOfFrames[CurrentFrame] == null)
            {
                ArrayOfFrames[CurrentFrame] = new BowlingFrame();
                if (kickedPins == 10)
                {
                    ArrayOfFrames[CurrentFrame].FirstBowlScore = kickedPins;
                    if (CurrentFrame > 0)
                    {
                        if (ArrayOfFrames[CurrentFrame - 1].SecondBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame - 1].SecondBowlScore = kickedPins;
                        }
                        else if (ArrayOfFrames[CurrentFrame - 1].SecondBowlScore != -1 && ArrayOfFrames[CurrentFrame - 1].ThirdBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame - 1].ThirdBowlScore = kickedPins;
                            ArrayOfFrames[CurrentFrame - 1].IsFrameRedyForScore = true;
                        }

                        if (CurrentFrame > 1 && ArrayOfFrames[CurrentFrame - 2].ThirdBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame - 2].ThirdBowlScore = kickedPins;
                            ArrayOfFrames[CurrentFrame - 2].IsFrameRedyForScore = true;
                        }
                    }

                    if (CurrentFrame == 9)
                        ArrayOfFrames[CurrentFrame].FrameStatus = Status.TenthFrameStrike;
                    else
                        ArrayOfFrames[CurrentFrame].FrameStatus = Status.Strike;
                    ArrayOfFrames[CurrentFrame].IsFrameClose = true;
                    ArrayOfFrames[CurrentFrame].CurrentBowlTryForTheFrame = CurrentBowlTry.FirstBowl;
                    
                }

                if (kickedPins < 10)
                {
                    ArrayOfFrames[CurrentFrame].FirstBowlScore = kickedPins;
                    ArrayOfFrames[CurrentFrame].FrameStatus = Status.Points;
                    ArrayOfFrames[CurrentFrame].CurrentBowlTryForTheFrame = CurrentBowlTry.FirstBowl;
                    if (CurrentFrame > 0)
                    {
                        if (ArrayOfFrames[CurrentFrame - 1].SecondBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame - 1].SecondBowlScore = kickedPins;
                        }
                        else if (ArrayOfFrames[CurrentFrame - 1].SecondBowlScore != -1 && ArrayOfFrames[CurrentFrame - 1].ThirdBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame - 1].ThirdBowlScore = kickedPins;
                            ArrayOfFrames[CurrentFrame - 1].IsFrameRedyForScore = true;
                        }

                        if (CurrentFrame > 1 && ArrayOfFrames[CurrentFrame - 2].ThirdBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame - 2].ThirdBowlScore = kickedPins;
                            ArrayOfFrames[CurrentFrame - 2].IsFrameRedyForScore = true;
                        }
                    }
                    CurrentFrame--;
                }
            }
            else
            {
                if (ArrayOfFrames[CurrentFrame - 1].SecondBowlScore == -1)
                    ArrayOfFrames[CurrentFrame - 1].SecondBowlScore = kickedPins;
                else if (ArrayOfFrames[CurrentFrame - 1].SecondBowlScore != -1 &&
                         ArrayOfFrames[CurrentFrame - 1].ThirdBowlScore == -1)
                {
                    ArrayOfFrames[CurrentFrame - 1].ThirdBowlScore = kickedPins;
                    ArrayOfFrames[CurrentFrame - 1].IsFrameRedyForScore = true;
                }


                if (ArrayOfFrames[CurrentFrame].FrameStatus != Status.TenthFrameStrike &&
                    ArrayOfFrames[CurrentFrame].FrameStatus != Status.TenthFrameSpare)
                {
                    if (ArrayOfFrames[CurrentFrame].FirstBowlScore != -1)
                    {
                        if (ArrayOfFrames[CurrentFrame].SecondBowlScore == -1)
                        {
                            ArrayOfFrames[CurrentFrame].SecondBowlScore = kickedPins;
                            ArrayOfFrames[CurrentFrame].CurrentBowlTryForTheFrame = CurrentBowlTry.SecondBowl;
                            if (ArrayOfFrames[CurrentFrame].FirstBowlScore + ArrayOfFrames[CurrentFrame].SecondBowlScore == 10)
                            {
                                if (CurrentFrame == 9)
                                    ArrayOfFrames[CurrentFrame].FrameStatus = Status.TenthFrameSpare;
                                else
                                    ArrayOfFrames[CurrentFrame].FrameStatus = Status.Spare;
                                ArrayOfFrames[CurrentFrame].IsFrameClose = true;
                            }
                            else
                            {
                                ArrayOfFrames[CurrentFrame].ThirdBowlScore = 0;
                                ArrayOfFrames[CurrentFrame].IsFrameClose = true;
                                ArrayOfFrames[CurrentFrame].IsFrameRedyForScore = true;
                            }
                        }
                    }
                }
                else if (ArrayOfFrames[CurrentFrame].FrameStatus == Status.TenthFrameStrike)
                {
                    if (ArrayOfFrames[CurrentFrame].SecondBowlScore == -1)
                        ArrayOfFrames[CurrentFrame].SecondBowlScore = kickedPins;
                    else if (ArrayOfFrames[CurrentFrame].ThirdBowlScore == -1)
                    {
                        ArrayOfFrames[CurrentFrame].ThirdBowlScore = kickedPins;
                        ArrayOfFrames[CurrentFrame].IsFrameRedyForScore = true;
                    }
                }
                else if (ArrayOfFrames[CurrentFrame].FrameStatus == Status.TenthFrameSpare)
                {
                    if (ArrayOfFrames[CurrentFrame].SecondBowlScore == -1)
                        ArrayOfFrames[CurrentFrame].SecondBowlScore = kickedPins;
                    else if (ArrayOfFrames[CurrentFrame].SecondBowlScore != -1 &&
                             ArrayOfFrames[CurrentFrame].ThirdBowlScore == -1)
                    {
                        ArrayOfFrames[CurrentFrame].ThirdBowlScore = kickedPins;
                        ArrayOfFrames[CurrentFrame].IsFrameRedyForScore = true;
                    }
                }
            }

            if (CurrentFrame > 0 && ArrayOfFrames[CurrentFrame - 1] != null)
            {
                for (int countIndex = 0; countIndex <= CurrentFrame; countIndex++)
                {
                    if (ArrayOfFrames[countIndex].IsFrameRedyForScore)
                        gameScore += ArrayOfFrames[countIndex].FirstBowlScore +
                                     ArrayOfFrames[countIndex].SecondBowlScore +
                                     ArrayOfFrames[countIndex].ThirdBowlScore;

                }
            }

            CurrentFrame++;

            return gameScore;
        }
    }
}
