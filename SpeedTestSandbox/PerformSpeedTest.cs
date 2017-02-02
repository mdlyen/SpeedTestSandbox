using SpeedTestSandbox.TestClasses;
using System.Text;
using System.Windows.Controls;

namespace SpeedTestSandbox
{
    internal class PerformSpeedTest
    {
        ISpeedTest _AClass;
        ISpeedTest _BClass;

        public PerformSpeedTest(TestClasses.ISpeedTest AClass, TestClasses.ISpeedTest BClass)
        {
            _AClass = AClass;
            _BClass = BClass;
        }

        public string RunTests()
        {
            var a = _AClass.PerformTest();
            var b = _BClass.PerformTest();

            var SB = new StringBuilder();
            SB.AppendLine($"Class A: {a}");
            SB.AppendLine($"Class B: {b}");

            return SB.ToString();
        }
    }
}