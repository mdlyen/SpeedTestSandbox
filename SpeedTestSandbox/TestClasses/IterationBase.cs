using System;
using System.Diagnostics;
using System.Threading;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox.TestClasses
{
    public class IterationBase : ISpeedTest
    {
        public long ElapsedTime { get; private set; }
        public string ClassName { get; private set; }
        public int Iterations => 150000;

        void ISpeedTest.PerformTest()
        {
            ClassName = GetType().Name;

            // Create stopwatch.
            var sw = new Stopwatch();

            // Start the stopwatch.
            sw.Start();

            // Perform the testing code.
            var nullTesting = 0;

            for (var i = 0; i < Iterations; i++)
            {
                nullTesting = i;
            }

            // Stop the stopwatch.
            sw.Stop();

            ElapsedTime = sw.ElapsedMilliseconds;
        }
    }
}