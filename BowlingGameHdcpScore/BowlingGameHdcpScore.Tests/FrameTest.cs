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
        public void TestFailed_Frame_SetFirstBowlThrow_OutOfRange()
        {
            //-- Arrange
            Frame frame = new Frame();
            var kickedPinsCount = 11;
            var startingPinsNumber = 10;

            //-- Act
            try
            {
                frame.FirstBowlScore = kickedPinsCount;
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
                frame.SecondBowlScore = kickedPinsCount;
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
                frame.ThirdBowlBonusScore = kickedPinsCount;
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
                frame.FirstBowlScore = kickedPinsCount;
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
                frame.SecondBowlScore = kickedPinsCount;
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
                frame.ThirdBowlBonusScore = kickedPinsCount;
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
