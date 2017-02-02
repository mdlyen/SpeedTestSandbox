using System;

namespace SpeedTestSandbox.TestClasses
{
    interface ISpeedTest
    {
        TimeSpan PerformTest();
    }
}