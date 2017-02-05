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

                //TODO: Add additional statistical elements for analysis.
                sb.AppendFormat("{0}: {1}\n", testInstance.ClassName, testInstance.ElapsedTime);
            }

            TextOutput = sb.ToString();
        }
    }
}