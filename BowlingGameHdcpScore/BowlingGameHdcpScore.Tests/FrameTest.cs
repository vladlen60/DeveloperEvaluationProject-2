using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Controllers;

namespace TenPinsBowlingGameHdcp.Tests
{
    [TestClass]
    public class FrameTest
    {
        [DataTestMethod]
        [DataRow(-1, "negative is out of range")]
        [DataRow(11, "11 is too high")]
        public void TestFailed_FirstBowl_OutOfRange(int value, string reason)
        {
            var frame = new Frame();

            Action action = () => frame.FirstBowlScore = value;

            Assert.ThrowsException<ArgumentOutOfRangeException>(action, reason);
        }

        [DataTestMethod]
        [DataRow(-1, "negative is out of range")]
        [DataRow(11, "11 is too high")]
        public void TestFailed_SecondBowl_OutOfRange(int value, string reason)
        {
            var frame = new Frame();

            Action action = () => frame.SecondBowlScore = value;

            Assert.ThrowsException<ArgumentOutOfRangeException>(action, reason);
        }

        [DataTestMethod]
        [DataRow(-1, "negative is out of range")]
        [DataRow(11, "11 is too high")]
        public void TestFailed_ThirdBowlBonus_OutOfRange(int value, string reason)
        {
            var frame = new Frame();

            Action action = () => frame.ThirdBowlBonusScore = value;

            Assert.ThrowsException<ArgumentOutOfRangeException>(action, reason);
        }
    }
}
