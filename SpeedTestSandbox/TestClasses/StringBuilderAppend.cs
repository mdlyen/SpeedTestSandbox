using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Xml;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox.TestClasses
{
    public class StringBuilderAppend : ISpeedTest
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
            var sb = new StringBuilder();

            for (var i = 0; i < Iterations; i++)
            {
                sb.Append(i.ToString());
            }
            var resultString = sb.ToString();

            // Stop the stopwatch.
            sw.Stop();

            ElapsedTime = sw.ElapsedMilliseconds;
        }
    }
}