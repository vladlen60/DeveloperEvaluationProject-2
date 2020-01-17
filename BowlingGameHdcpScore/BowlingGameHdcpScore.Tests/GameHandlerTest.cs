using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Handlers;

namespace TenPinsBowlingGameHdcp.Tests
{
    [TestClass]
    public class GameHandlerTest
    {
        [TestMethod]
        public void TestFailed_GameHandler_SetPropertiesForCurrentFrame_FrameIsNull()
        {
            //-- Arrange
            GameHandler gameHandler = new GameHandler();
            var kickedPinsCount = 1;

            //-- Act
            try
            {
                gameHandler.SetPropertiesForCurrentFrame(null, kickedPinsCount);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            //-- Assert
            Assert.Fail("Call did NOT throw the Argument Exception");
        }
    }
}
