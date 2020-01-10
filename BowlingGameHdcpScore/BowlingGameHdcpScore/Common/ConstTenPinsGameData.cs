using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TenPinsBowlingGameHdcp.Tests")]

namespace TenPinsBowlingGameHdcp.Common
{
    internal static class ConstTenPinsGameData
    {
        internal const int MaxFramesNumber = 10;
        internal const int StartingPinsNumber = 10;
        internal const int InitialValueForTheBowlThrow = -1;
        internal const int ThirdBowlForFrameWithoutBonus = 0;
        internal const int FinalFrameIndex = MaxFramesNumber - 1;
    }
}
