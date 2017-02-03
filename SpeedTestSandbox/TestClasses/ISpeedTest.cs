using System;

namespace SpeedTestSandbox.TestClasses
{
    internal interface ISpeedTest
    {
        void PerformTest();

        TimeSpan ElapsedTime { get; }
    }
}