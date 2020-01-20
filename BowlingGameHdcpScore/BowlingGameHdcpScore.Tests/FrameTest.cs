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

            frame.IsFrameClosed.Should().BeFalse();
        }

        [TestMethod]
        public void Frame_With_One_Bowl_Should_Be_Open()
        {
            var frame = new Frame();

            frame.Bowl(0);

            frame.IsFrameClosed.Should().BeFalse();
        }

        [TestMethod]
        public void Frame_With_Two_Bowls_Should_Be_Closed()
        {
            var frame = new Frame();

            frame.Bowl(0);
            frame.Bowl(0);

            frame.IsFrameClosed.Should().BeTrue();
        }

        [TestMethod]
        public void Frame_With_Strike_Should_Be_Closed()
        {
            var frame = new Frame();

            frame.Bowl(10);

            frame.IsFrameClosed.Should().BeTrue();
        }

        [TestMethod]
        public void Can_Bowl_Two_Balls_Without_Exception()
        {
            var frame = new Frame();

            frame.Bowl(3);
            frame.Bowl(3);
        }

        [TestMethod]
        public void Bowling_Three_Balls_Throws_Exception()
        {
            var frame = new Frame();

            frame.Bowl(3);
            frame.Bowl(3);

            Action action = () => frame.Bowl(1);

            action.Should().Throw<FrameClosedException>();
        }

        [TestMethod]
        public void Bowling_Another_Ball_After_A_Strike_Should_Throw()
        {
            var frame = new Frame();

            frame.Bowl(10);

            Action action = () => frame.Bowl(1);

            action.Should().Throw<FrameClosedException>();
        }

        [TestMethod]
        public void Should_Score_0_By_Default()
        {
            var frame = new Frame();

            frame.Score.Should().Be(0);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void Should_Score_0_When_1_Ball(int score)
        {
            var frame = new Frame();

            frame.Bowl(score);

            frame.Score.Should().Be(0);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 8)]
        [DataRow(3, 6)]
        [DataRow(4, 2)]
        [DataRow(5, 0)]
        public void Should_Score_Something_When_2_Balls(int first, int second)
        {
            var frame = new Frame();

            frame.Bowl(first);
            frame.Bowl(second);

            frame.Score.Should().Be(first + second);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        public void Should_Score_0_When_Spare(int first)
        {
            var frame = new Frame();

            frame.Bowl(first);
            frame.Bowl(10 - first);

            frame.Score.Should().Be(0);
        }

        [TestMethod]
        public void Should_Score_0_When_Strike()
        {
            var frame = new Frame();

            frame.Bowl(10);

            frame.Score.Should().Be(0);
        }

        [TestMethod]
        public void Should_Not_Be_Ready_For_Score()
        {
            var frame = new Frame();

            frame.IsFrameReadyForScore.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void Should_Not_Be_Ready_For_Score_When_1_Ball(int score)
        {
            var frame = new Frame();

            frame.Bowl(score);

            frame.IsFrameReadyForScore.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 8)]
        [DataRow(3, 6)]
        [DataRow(4, 2)]
        [DataRow(5, 0)]
        public void Should_Be_Ready_For_Score_When_2_Balls(int first, int second)
        {
            var frame = new Frame();

            frame.Bowl(first);
            frame.Bowl(second);

            frame.IsFrameReadyForScore.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        public void Should_Not_Be_Ready_For_Score_When_Spare(int score)
        {
            var frame = new Frame();

            frame.Bowl(score);
            frame.Bowl(10 - score);

            frame.IsFrameReadyForScore.Should().BeFalse();
        }

        [TestMethod]
        public void Should_Not_Be_Ready_For_Score_When_Strike()
        {
            var frame = new Frame();

            frame.Bowl(10);

            frame.IsFrameReadyForScore.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        public void Should_Be_Ready_For_Score_When_Spare_And_Bonus(int score)
        {
            var frame = new Frame();

            frame.Bowl(score);
            frame.Bowl(10 - score);
            frame.ApplyBonus(0);

            frame.IsFrameReadyForScore.Should().BeTrue();
        }

        [TestMethod]
        public void Should_Not_Be_Ready_For_Score_When_Strike_And_Single_Bonus()
        {
            var frame = new Frame();

            frame.Bowl(10);
            frame.ApplyBonus(0);

            frame.IsFrameReadyForScore.Should().BeFalse();
        }

        [TestMethod]
        public void Should_Be_Ready_For_Score_When_Strike_And_Double_Bonus()
        {
            var frame = new Frame();

            frame.Bowl(10);
            frame.ApplyBonus(0);
            frame.ApplyBonus(0);

            frame.IsFrameReadyForScore.Should().BeTrue();
        }

        [TestMethod]
        public void Should_Not_Need_Bonus_For_New_Frame()
        {
            var frame = new Frame();

            frame.NeedsBonus.Should().BeFalse();
        }

        [TestMethod]
        public void Should_Need_Bonus_For_Strike()
        {
            var frame = new Frame();

            frame.Bowl(10);

            frame.NeedsBonus.Should().BeTrue();
        }

        [TestMethod]
        public void Should_Need_Bonus_For_Strike_With_1_Bonus()
        {
            var frame = new Frame();

            frame.Bowl(10);
            frame.ApplyBonus(0);

            frame.NeedsBonus.Should().BeTrue();
        }

        [TestMethod]
        public void Should_Not_Need_Bonus_For_Strike_With_2_Bonuses()
        {
            var frame = new Frame();

            frame.Bowl(10);
            frame.ApplyBonus(0);
            frame.ApplyBonus(0);

            frame.NeedsBonus.Should().BeFalse();
        }

        [TestMethod]
        public void Should_Need_Bonus_For_Spare()
        {
            var frame = new Frame();

            frame.Bowl(1);
            frame.Bowl(9);

            frame.NeedsBonus.Should().BeTrue();
        }

        [TestMethod]
        public void Should_Not_Need_Bonus_For_Spare_With_Bonus()
        {
            var frame = new Frame();

            frame.Bowl(1);
            frame.Bowl(9);
            frame.ApplyBonus(0);

            frame.NeedsBonus.Should().BeFalse();
        }

        [TestMethod]
        public void Should_Throw_When_Adding_Third_Bonus_To_Strike()
        {
            var frame = new Frame();

            frame.Bowl(10);
            frame.ApplyBonus(0);
            frame.ApplyBonus(0);
            
            Action action = () => frame.ApplyBonus(0);

            action.Should().Throw<NoBonusNeededException>();
        }

        [TestMethod]
        public void Should_Throw_When_Adding_Second_Bonus_To_Spare()
        {
            var frame = new Frame();

            frame.Bowl(1);
            frame.Bowl(9);
            frame.ApplyBonus(0);

            Action action = () => frame.ApplyBonus(0);

            action.Should().Throw<NoBonusNeededException>();
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 8)]
        [DataRow(3, 6)]
        [DataRow(4, 2)]
        [DataRow(5, 0)]
        public void Should_Calculate_Score_For_Regular_Frame(int first, int second)
        {
            var frame = new Frame();

            frame.Bowl(first);
            frame.Bowl(second);

            frame.Score.Should().Be(first + second);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void Should_Calculate_Score_For_Spare_Frame(int bonus)
        {
            var frame = new Frame();

            frame.Bowl(5);
            frame.Bowl(5);
            frame.ApplyBonus(bonus);

            frame.Score.Should().Be(10 + bonus);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(1, 1)]        
        [DataRow(10, 10)]
        [DataRow(5, 5)]
        [DataRow(5, 0)]
        [DataRow(1, 8)]
        public void Should_Calculate_Score_For_Strike_Frame(int firstBonus, int secondBonus)
        {
            var frame = new Frame();

            frame.Bowl(10);
            frame.ApplyBonus(firstBonus);
            frame.ApplyBonus(secondBonus);

            frame.Score.Should().Be(10 + firstBonus + secondBonus);
        }
    }
}
