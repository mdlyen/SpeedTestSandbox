using System;

namespace SpeedTestSandbox.SandBoxClasses
{
    internal interface ISpeedTest
    {
        void PerformTest();

        TimeSpan ElapsedTime { get; }
    }
}