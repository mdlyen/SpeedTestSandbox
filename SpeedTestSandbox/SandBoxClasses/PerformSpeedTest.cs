using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace SpeedTestSandbox.SandBoxClasses
{
    internal class PerformSpeedTest
    {
        internal readonly ISpeedTest AClass;
        internal readonly ISpeedTest BClass;
        internal string TextOutput;
        private StringBuilder _stringBuilder;

        public PerformSpeedTest(ISpeedTest aClass, ISpeedTest bClass)
        {
            AClass = aClass;
            BClass = bClass;
        }

        public bool RequestCancel { get; internal set; }

        public void RunTests(BackgroundWorker backgroundWorker)
        {
            AClass.PerformTest();
            if (backgroundWorker.CancellationPending)
            {
                CancelOperationExit();
                return;
            }
            BClass.PerformTest();
            if (backgroundWorker.CancellationPending)
            {
                CancelOperationExit();
                return;
            }

            _stringBuilder = new StringBuilder();
            _stringBuilder.AppendLine($"Class A: {AClass.ElapsedTime}");
            _stringBuilder.AppendLine($"Class B: {BClass.ElapsedTime}");

            TextOutput = _stringBuilder.ToString();
        }

        private void CancelOperationExit()
        {
            TextOutput = "Operation cancelled...";
        }
    }
}