﻿using System;
using System.Runtime.Serialization;

namespace TenPinsBowlingGameHdcp.Controllers
{
    [Serializable]
    public class TooManyPinsException : Exception
    {
    }
}