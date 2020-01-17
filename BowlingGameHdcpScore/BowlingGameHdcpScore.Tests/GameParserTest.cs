using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Utilities;

namespace TenPinsBowlingGameHdcp.Tests
{
    [TestClass]
    public class GameParserTest
    {
        [TestMethod]
        public void TestFailed_Game_Input_IntoParser_Null()
        {
            //-- Arrange
            GameParser gameParser = new GameParser();

            //-- Act
            try
            {
                gameParser.ParseGameInputString(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You have an invalid input ``. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        public void TestFailed_Game_Input_IntoParser_Empty()
        {
            //-- Arrange
            GameParser gameParser = new GameParser();

            //-- Act
            try
            {
                gameParser.ParseGameInputString("");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You have an invalid input ``. Pls check.", ex.Message);
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }
    }
}
