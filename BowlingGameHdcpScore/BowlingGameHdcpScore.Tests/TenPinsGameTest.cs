using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;

namespace TenPinsBowlingGameHdcp.Tests
{
    [TestClass]
    public partial class TenPinsGameTest
    {
        [TestMethod]
        public void Test_Game_With_Single_Throw_NoBonuses_FrameIncomplete()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var intInputList = new [] { 1 };
            int expectedScore = 0;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_With_Two_Throws_NoBonuses_FrameComplete()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var intInputList = new [] { 1, 1 };
            int expectedScore = 2;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_With_Three_Throws_NoBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var intInputList = new [] { 1, 1,5 };
            int expectedScore = 2;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_With_Single_Throw_Strike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10 };
            int expectedScore = 0;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_With_Two_Throws_Spare()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 1, 9 };
            int expectedScore = 0;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_With_Two_Throws_First_Strike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10, 1 };
            int expectedScore = 0;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_With_Three_Throws_Spare()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 1, 9, 5 };
            int expectedScore = 15;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_With_Three_Throws_First_Strike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10, 1, 5 };
            int expectedScore = 22;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_With_Two_Throws_Both_Strike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10, 10 };
            int expectedScore = 0;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_With_Three_Throws_All_Strike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10, 10, 10 };
            int expectedScore = 30;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_With_Four_Throws_Three_Strike_And_Miss()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10, 10, 10, 0 };
            int expectedScore = 50;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_All_Misses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0  };
            int expectedScore = 0;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_Complete_With_All_Misses_But_One()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,1, 0,0, 0,0, 0,0, 0,0, 0,0  };
            int expectedScore = 1;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_All_Misses_But_One_Different()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 1,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0  };
            int expectedScore = 1;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_All_Misses_But_One_Spare()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,10, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0  };
            int expectedScore = 10;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_All_Misses_But_With_Last_FivePins()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,5  };
            int expectedScore = 5;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_Just_One_Spare_And_Single_One()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,10, 1,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0  };
            int expectedScore = 12;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_Complete_With_Factorial_Increments_On_Every_Frame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,1, 0,2, 0,3, 0,4, 0,5, 0,6, 0,7, 0,8, 0,9, 0,10, 0  };
            int expectedScore = 55;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_Only_Spare_And_Single_On_Last_Frame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,10, 1 };
            int expectedScore = 11;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_Only_Spare_And_Pair_On_Last_Frame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,10, 2 };
            int expectedScore = 12;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_Only_Strike_On_Last_Frame_And_Missed_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 0, 0 };
            int expectedScore = 10;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_Only_Strike_On_Last_Frame_And_Single_Bonus()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 1, 0 };
            int expectedScore = 11;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Game_Complete_With_Only_Strike_On_Last_Frame_And_Single_Bonus_Different()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 0, 1 };
            int expectedScore = 11;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_Complete_With_Only_Strike_On_Last_Frame_And_Pair_Bonus()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 2, 0 };
            int expectedScore = 12;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_Complete_With_Only_Strike_On_Last_Frame_And_Two_Single_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 1, 1 };
            int expectedScore = 12;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Perfect_Game_Complete()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 10,10,10,10,10,10,10,10,10,10,10,10 };
            int expectedScore = 300;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Game_Complete_With_Single_Miss_On_Every_Frame_NoBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            var intInputList = new [] { 9, 0, 9,0, 9,0,9, 0, 9, 0, 9, 0, 9,0 , 9,0, 9,0, 9,0 };
            int expectedScore = 90;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Almost_Perfect_Game_Complete_With_Spare_On_Every_Frame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var intInputList = new [] { 5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5 };
            int expectedScore = 150;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        public void Test_Regular_Game_Complete_With_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var intInputList = new[] { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 };
            int expectedScore = 167;
            int actualScore = 0;

            //-- Act
            foreach (var input in intInputList)
            {
                actualScore = game.Bowl(input);
            }

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void Test_Intermittent_Score_Till_RegularGameComplete_With_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var intInputList = new[] { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 };
            var expectedScoresList = new [] { 0, 0, 20, 39, 48, 48, 48, 74, 74, 74, 84, 90, 90, 90, 120, 148, 167 };
            var inputValuesAndExpectedScores = intInputList.Zip(expectedScoresList, (kickedPins, correspondingExpectedScore) => (kickedPins, correspondingExpectedScore));
            int actualScore = 0;

            //-- Act
            foreach (var input in inputValuesAndExpectedScores)
            {
                actualScore = game.Bowl(input.kickedPins);
                //-- Assert
                Assert.AreEqual(input.correspondingExpectedScore, actualScore);
            }
        }

        [TestMethod]
        public void TestFailed_OnGame_Complete_With_Last_Spare_And_Excessive_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();

            //-- Act
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    //bowl 1 for each ball in a frame
                    game.Bowl(1);
                    game.Bowl(1);
                }

                //10th frame spare and bonus
                game.Bowl(1);
                game.Bowl(9);
                game.Bowl(2);

                //extra bonus
                game.Bowl(1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Sorry, you have played All available bowl-throws for this game. Pls start a new game.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_OnGame_Complete_With_No_Misses_And_Bonus()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();

            //-- Act
            try
            {
                for(int i = 0; i < 10; i++)
                {
                    //bowl 1 for each ball in a frame
                    game.Bowl(1);
                    game.Bowl(1);
                }

                game.Bowl(2);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Sorry, you have played All available bowl-throws for this game. Pls start a new game.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_OnGame_Complete_With_No_Misses_But_OutOfRange_Throws_Sum()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            
            //-- Act
            try
            {
                game.Bowl(6);
                game.Bowl(6);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The 2nd throw pins of 6 is higher than allowed for this frame. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestFailed_OnGame_KickedPinsInput_OutOfRange_SubZero()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var kickedPinsCount = -1;
            var startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;

            //-- Act
            try
            {
                game.Bowl(kickedPinsCount);
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
        public void TestFailed_OnGame_KickedPinsInput_OutOfRange_AboveMax()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            var kickedPinsCount = 11;
            var startingPinsNumber = ConstTenPinsGameData.StartingPinsNumber;

            //-- Act
            try
            {
                game.Bowl(kickedPinsCount);
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
        public void TestFailed_OnGame_With_Negative_Value()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();

            //-- Act
            try
            {
                game.Bowl(-1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The kicked pins count is '-1', but has to be between 0 and 10. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [DataTestMethod]
        [DataRow("10, 7,3, 9,0, 10, 0,8, 8,2, 0,6, 10, 10, 10, 8, 1", 167, "cause the test under this says so")]
        [DataRow("10, 10,10,10,10,10,10,10,10,10,10,10", 300, "perfect game")]
        [DataRow("0,0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0, 0,0 ", 0, "gutter city")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,1, 0,0, 0,0,0, 0,0, 0, 0,0 ", 1, "a measly one")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 1,0, 0,0,0, 0,0, 0,0, 0, 0,0 ", 1, "a measly one a different way")]
        [DataRow("0,0, 0,0, 0,0, 0,10, 0,0, 0,0,0, 0,0, 0,0, 0, 0,0 ", 10, "a spare")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0,0, 0,0, 0,0, 0, 0,5 ", 5, "a single 5 frame")]
        [DataRow("0,0, 0,0, 0,10, 1,0, 0,0, 0,0,0, 0,0, 0,0, 0, 0,0 ", 12, "a spare and a single")]
        [DataRow("0,0, 0,0, 0,10, 2,0, 0,0, 0,0,0, 0,0, 0,0, 0, 0,0 ", 14, "a spare and a pair")]
        [DataRow("0,1, 0,2, 0,3, 0,4, 0,5, 0,6, 0,7, 0,8, 0,9, 0,10, 0 ", 55, "the factorial game")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,10,1 ", 11, "a spare and a single on the last frame")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,10, 2 ", 12, "a spare and a pair on the last frame")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10,0,0 ", 10, "strike on the last frame")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10,1,0", 11, "strike and single on the last frame")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10,2,0", 12, "strike and pair on the last frame")]
        [DataRow("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10,1,1", 12, "strike and two singles on the last frame")]
        public void should_calculate_score(string gameInput, int expectedScore, string reason)
        {
            int result = 0;
            var game = new TenPinsGame();

            var bowls = gameInput.Split(',').Select(s => Convert.ToInt32(s));

            foreach (var input in bowls)
            {
                result = game.Bowl(input);
            }

            Assert.AreEqual(expectedScore, result, reason);
        }
    }
}
