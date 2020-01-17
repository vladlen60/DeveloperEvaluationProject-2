using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Common;
using TenPinsBowlingGameHdcp.Controllers;
using TenPinsBowlingGameHdcp.Utilities;

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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1, 1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1, 1,5");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1, 9");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1, 9, 5");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 1, 5");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 10");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 10, 10");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 10, 10, 0");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,1, 0,0, 0,0, 0,0, 0,0, 0,0 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 1,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,10, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,5 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,10, 1,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,1, 0,2, 0,3, 0,4, 0,5, 0,6, 0,7, 0,8, 0,9, 0,10, 0 ");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,10, 1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,10, 2");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 0, 0");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 1, 0");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 0, 1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 2, 0");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 10, 1, 1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10,10,10,10,10,10,10,10,10,10,10,10");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("9, 0, 9,0, 9,0,9, 0, 9, 0, 9, 0, 9,0 , 9,0, 9,0, 9,0");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1");
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1");
            List<int> expectedScoresList = new List<int>{0,0,20,39,48,48,48,74,74,74,84,90,90,90,120,148,167};
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
        public void TestsFailed_OnGame_With_Two_Throws_Sum_Higher_Than_StartingPins()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("9, 5");

            //-- Act
            try
            {
                foreach (var input in intInputList)
                {
                    game.Bowl(input);
                }
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The 2nd throw pins of 5 is higher than allowed for this frame. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        public void TestsFailed_OnGame_With_Strike_And_Next_Two_Throws_Higher_Than_StartingPins()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("10, 9, 5");

            //-- Act
            try
            {
                foreach (var input in intInputList)
                {
                    game.Bowl(input);
                }
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The 2nd throw pins of 5 is higher than allowed for this frame. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        public void TestsFailed_OnGame_With_Letter_Instead_Of_Integer()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();

            //-- Act
            try
            {
                var input = "O";
                game.Bowl(Convert.ToInt32(input));
            }
            catch (FormatException ex)
            {
                Assert.AreEqual("Input string was not in a correct format.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        public void TestFailed_OnGame_Complete_With_Last_Spare_And_Excessive_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 3,7, 1, 2");

            //-- Act
            try
            {
                foreach (var input in intInputList)
                {
                    game.Bowl(input);
                }
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1");

            //-- Act
            try
            {
                foreach (var input in intInputList)
                {
                    game.Bowl(input);
                }
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
        public void TestFailed_OnGame_Complete_With_No_Misses_And_Two_Bonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 2");

            //-- Act
            try
            {
                foreach (var input in intInputList)
                {
                    game.Bowl(input);
                }
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
            GameParser gameParser = new GameParser();
            List<int> intInputList = gameParser.ParseGameInputString("6,6, 6,6, 6,6, 6,6, 6,6, 6,6, 6,6, 6,6, 6,6, 6,6");

            //-- Act
            try
            {
                foreach (var input in intInputList)
                {
                    game.Bowl(input);
                }
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
            TenPinsGame game = new TenPinsGame("0,-1, 0");

            //-- Act
            try
            {
                foreach (var input in game.ListOfKickedPins)
                {
                    game.Bowl(input);
                }
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The kicked pins count is '-1', but has to be between 0 and 10. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        public void TestFailed_OnGame_With_Decimal_Value()
        {
            //-- Arrange

            //-- Act
            try
            {
                TenPinsGame game = new TenPinsGame("0,1.0,0");
                foreach (var input in game.ListOfKickedPins)
                {
                    game.Bowl(input);
                }
            }
            catch (FormatException)
            {
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }



        [TestMethod]
        public void TestFailed_OnGame_With_Empty_Value()
        {
            //-- Arrange

            //-- Act
            try
            {
                TenPinsGame game = new TenPinsGame("0,");
                foreach (var input in game.ListOfKickedPins)
                {
                    game.Bowl(input);
                }
            }
            catch (FormatException)
            {
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [DataTestMethod]
        [DataRow("10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1", 167, "cause the test under this says so")]
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
            var game = new TenPinsGame(gameInput);

            foreach (var input in game.ListOfKickedPins)
            {
                result = game.Bowl(input);
            }

            Assert.AreEqual(expectedScore, result, reason);
        }
    }
}
