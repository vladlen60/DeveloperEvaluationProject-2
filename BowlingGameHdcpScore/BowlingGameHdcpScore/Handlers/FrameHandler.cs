using TenPinsBowlingGameHdcp.Controllers;
using TenPinsBowlingGameHdcp.Validators;

namespace TenPinsBowlingGameHdcp.Handlers
{
    internal class FrameHandler
    {
        private CommonValidator _validator = new CommonValidator();

        internal void SetStatusForFrame(Frame frame, FrameStatus frameStatus)
        {
            _validator.ValidateFrameIsNotNull(frame);
            frame.SetFrameStatus(frameStatus);
        }
    }
}
