using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;

namespace TenPinsBowlingGameHdcp.Tests
{
    [TestClass]
    public class FrameTest
    {
        [TestMethod]
        public void Test_Frame_SetFirstBowlThrow_Min()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetFirstBowlScore(0);
            var expected = 0;

            //-- Act
            var actual = frame.FirstBowlScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Frame_SetSecondBowlThrow()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetSecondBowlScore(0);
            var expected = 0;

            //-- Act
            var actual = frame.SecondBowlScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Frame_SetThirdBowlThrow()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetThirdBowlBonusScore(0);
            var expected = 0;

            //-- Act
            var actual = frame.ThirdBowlBonusScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Test_Frame_SetFirstBowlThrow_Max()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetFirstBowlScore(10);
            var expected = 10;

            //-- Act
            var actual = frame.FirstBowlScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Frame_SetSecondBowlThrow_Max()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetSecondBowlScore(10);
            var expected = 10;

            //-- Act
            var actual = frame.SecondBowlScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Frame_SetThirdBowlThrow_Max()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetThirdBowlBonusScore(10);
            var expected = 10;

            //-- Act
            var actual = frame.ThirdBowlBonusScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Test_Frame_SetFirstBowlThrow_Middle()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetFirstBowlScore(5);
            var expected = 5;

            //-- Act
            var actual = frame.FirstBowlScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Frame_SetSecondBowlThrow_Middle()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetSecondBowlScore(5);
            var expected = 5;

            //-- Act
            var actual = frame.SecondBowlScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Frame_SetThirdBowlThrow_Middle()
        {
            //-- Arrange
            Frame frame = new Frame();
            frame.SetThirdBowlBonusScore(5);
            var expected = 5;

            //-- Act
            var actual = frame.ThirdBowlBonusScore;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFailed_Frame_SetFirstBowlThrow_OutOfRange()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = 11;
            var startingPinsNumber = 10;

            //-- Act
            try
            {
                frame.SetFirstBowlScore(kickedPinsCount);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {startingPinsNumber}. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_Frame_SetSecondBowlThrow_OutOfRange()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = 11;
            var startingPinsNumber = 10;

            //-- Act
            try
            {
                frame.SetSecondBowlScore(kickedPinsCount);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {startingPinsNumber}. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_Frame_SetThirdBowlThrow_OutOfRange()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = 11;
            var startingPinsNumber = 10;

            //-- Act
            try
            {
                frame.SetThirdBowlBonusScore(kickedPinsCount);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {startingPinsNumber}. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }



        [TestMethod]
        public void TestFailed_Frame_SetFirstBowlThrow_OutOfRange_SubZero()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = -1;
            var startingPinsNumber = 10;

            //-- Act
            try
            {
                frame.SetFirstBowlScore(kickedPinsCount);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {startingPinsNumber}. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_Frame_SetSecondBowlThrow_OutOfRange_SubZero()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = -1;
            var startingPinsNumber = 10;

            //-- Act
            try
            {
                frame.SetSecondBowlScore(kickedPinsCount);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {startingPinsNumber}. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_Frame_SetThirdBowlThrow_OutOfRange_SubZero()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = -1;
            var startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;

            //-- Act
            try
            {
                frame.SetThirdBowlBonusScore(kickedPinsCount);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"The kicked pins count is '{kickedPinsCount}', but has to be between 0 and {startingPinsNumber}. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }
    }
}
