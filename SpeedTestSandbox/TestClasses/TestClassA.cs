using System.Diagnostics;
using System.Threading;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox.TestClasses
{
    [SpeedTestClass]
    public class TestClassA : ISpeedTest
    {
        private const int Iterations = 1453;

        public long ElapsedTime { get; private set; }

        //TODO: Figure out a better way to get a short name of the class for display purposes.
        public string ClassName { get; } = "Temp Class A";

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