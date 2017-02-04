using System.Diagnostics;
using System.Threading;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox.TestClasses
{
    [SpeedTestClass]
    public class TestClassB : ISpeedTest
    {
        private const int Iterations = 12478;

        public long ElapsedTime { get; private set; }

        public string ClassName { get; } = "Temp Class B";

        void ISpeedTest.PerformTest()
        {
            var sw = new Stopwatch();

            // Perform the testing code.
            sw.Start();
            Thread.Sleep(Iterations);
            sw.Stop();

            ElapsedTime = sw.ElapsedMilliseconds;
        }
    }
}