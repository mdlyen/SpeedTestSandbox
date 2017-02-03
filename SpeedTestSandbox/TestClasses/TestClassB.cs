using System;
using System.Threading;

namespace SpeedTestSandbox.TestClasses
{
    internal class TestClassB : ISpeedTest
    {
        private DateTime _start;
        private DateTime _end;

        void ISpeedTest.PerformTest()
        {
            _start = DateTime.Now;

            // Perform the testing code.
            Thread.Sleep(2350);

            _end = DateTime.Now;

            ElapsedTime = _end - _start;
        }

        public TimeSpan ElapsedTime { get; private set; }
    }
}
