using System;
using System.Threading;

namespace SpeedTestSandbox.TestClasses
{
    class TestClassB : ISpeedTest
    {
        DateTime start;
        DateTime end;

        public TimeSpan PerformTest()
        {
            start = DateTime.Now;

            // Perform the testing code.
            Thread.Sleep(2300);

            end = DateTime.Now;

            return end - start;
        }
    }
}
