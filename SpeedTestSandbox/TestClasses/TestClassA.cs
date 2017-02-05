using System.Diagnostics;
using System.Threading;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox.TestClasses
{
    public class TestClassA : ISpeedTest
    {
        private const int Iterations = 1453;

        public long ElapsedTime { get; private set; }

        public string ClassName { get; private set; }

        void ISpeedTest.PerformTest()
        {
            ClassName = GetType().Name;
            
            var sw = new Stopwatch();

            // Perform the testing code.
            sw.Start();
            Thread.Sleep(Iterations);
            sw.Stop();

            ElapsedTime = sw.ElapsedMilliseconds;
        }
    }
}