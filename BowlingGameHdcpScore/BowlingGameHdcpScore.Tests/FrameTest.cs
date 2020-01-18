using System;
using FluentAssertions;
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

            action.Should().Throw<ArgumentOutOfRangeException>(reason);
        }

        [DataTestMethod]
        [DataRow(-1, "negative is out of range")]
        [DataRow(11, "11 is too high")]
        public void TestFailed_SecondBowl_OutOfRange(int value, string reason)
        {
            var frame = new Frame();

            Action action = () => frame.SecondBowlScore = value;

            action.Should().Throw<ArgumentOutOfRangeException>(reason);
        }

        [DataTestMethod]
        [DataRow(-1, "negative is out of range")]
        [DataRow(11, "11 is too high")]
        public void TestFailed_ThirdBowlBonus_OutOfRange(int value, string reason)
        {
            var frame = new Frame();

            Action action = () => frame.ThirdBowlBonusScore = value;

            action.Should().Throw<ArgumentOutOfRangeException>(reason);
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void Constructor_Sets_IsFinalFrame(bool isFinal)
        {
            var frame = new Frame(isFinal);

            frame.IsFinalFrame.Should().Be(isFinal);
        }

        [TestMethod]
        public void DefaultConstructor_Sets_IsFinalFrame_False()
        {
            var frame = new Frame();

            frame.IsFinalFrame.Should().BeFalse();
        }

        [TestMethod]
        public void Frame_With_No_Bowls_Is_Not_Closed()
        {
            var frame = new Frame();

            frame.IsFrameClose.Should().BeFalse();
        }

        [TestMethod]
        public void Frame_With_One_Bowl_Should_Be_Open()
        {
            var frame = new Frame();

            frame.FirstBowlScore = 0;

            frame.IsFrameClose.Should().BeFalse();
        }

        [TestMethod]
        public void Frame_With_Two_Bowls_Should_Be_Closed()
        {
            var frame = new Frame();

            frame.FirstBowlScore = 0;
            frame.SecondBowlScore = 0;

            frame.IsFrameClose.Should().BeTrue();
        }

        [TestMethod]
        public void Frame_With_Strike_Should_Be_Closed()
        {
            var frame = new Frame();

            frame.FirstBowlScore = 10;

            frame.IsFrameClose.Should().BeTrue();
        }
    }
}
