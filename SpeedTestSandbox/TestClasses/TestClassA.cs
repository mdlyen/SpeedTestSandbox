using System;
using System.Threading;

namespace SpeedTestSandbox.TestClasses
{
    class TestClassA : ISpeedTest
    {
        DateTime start;
        DateTime end;

        public TimeSpan PerformTest()
        {
            start = DateTime.Now;

            // Perform the testing code.
            Thread.Sleep(1500);

            end = DateTime.Now;

            return end - start;
        }
    }
}
