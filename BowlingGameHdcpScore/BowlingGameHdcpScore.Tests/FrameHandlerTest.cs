using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinsBowlingGameHdcp.Handlers;

namespace TenPinsBowlingGameHdcp.Tests
{
    public partial class TenPinsGameTest
    {
        [TestClass]
        public class FrameHandlerTest
        {

            [TestMethod]
            public void TestFailed_FrameHandler_SetFirstBowlForFrame_FrameIsNull()
            {
                //-- Arrange
                FrameHandler frameHandler = new FrameHandler();
                var kickedPinsCount = 1;

                //-- Act
                try
                {
                    frameHandler.SetFirstBowlForFrame(null, kickedPinsCount);
                }
                catch (ArgumentNullException)
                {
                    return;
                }

                //-- Assert
                Assert.Fail("Call did NOT throw the Argument Exception");
            }

            [TestMethod]
            public void TestFailed_FrameHandler_SetSecondBowlForFrame_FrameIsNull()
            {
                //-- Arrange
                FrameHandler frameHandler = new FrameHandler();
                var kickedPinsCount = 1;

                //-- Act
                try
                {
                    frameHandler.SetSecondBowlForFrame(null, kickedPinsCount);
                }
                catch (ArgumentNullException)
                {
                    return;
                }

                //-- Assert
                Assert.Fail("Call did NOT throw the Argument Exception");
            }

            [TestMethod]
            public void TestFailed_FrameHandler_SetThirdBowlForFrame_FrameIsNull()
            {
                //-- Arrange
                FrameHandler frameHandler = new FrameHandler();
                var kickedPinsCount = 1;

                //-- Act
                try
                {
                    frameHandler.SetThirdBowlForFrame(null, kickedPinsCount);
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
}
