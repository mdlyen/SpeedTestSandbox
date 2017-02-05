using System;
using System.ComponentModel;
using System.Text;

namespace SpeedTestSandbox.SandBoxClasses
{
    public class PerformSpeedTest
    {
        public string TextOutput;
        public bool RequestCancel { get; set; }

        public void RunTests(BackgroundWorker backgroundWorker)
        {
            var sb = new StringBuilder();
            var types = SpeedTestInterfaceUtility.GetTestClasses();

            foreach (var testClass in types)
            {
                var testInstance = Activator.CreateInstance(testClass) as ISpeedTest;
                if (testInstance == null) continue;

                testInstance.PerformTest();

                if (backgroundWorker.CancellationPending)
                {
                    break;
                }

                var et = testInstance.ElapsedTime;
                var it = testInstance.Iterations;
                var msPerIt = (double)et / (double)it;

                sb.AppendFormat("{0}: {1}ms, {2:0.00000}ms per Iteration\n", testInstance.ClassName, testInstance.ElapsedTime, msPerIt);
            }

            TextOutput = sb.ToString();
        }
    }
}