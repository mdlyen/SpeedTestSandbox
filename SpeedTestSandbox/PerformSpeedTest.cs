using SpeedTestSandbox.TestClasses;
using System.Text;

namespace SpeedTestSandbox
{
    internal class PerformSpeedTest
    {
        internal readonly ISpeedTest AClass;
        internal readonly ISpeedTest BClass;

        public PerformSpeedTest(TestClasses.ISpeedTest aClass, TestClasses.ISpeedTest bClass)
        {
            AClass = aClass;
            BClass = bClass;
        }

        public string RunTests()
        {
            AClass.PerformTest();
            BClass.PerformTest();

            var sb = new StringBuilder();
            sb.AppendLine($"Class A: {AClass.ElapsedTime}");
            sb.AppendLine($"Class B: {BClass.ElapsedTime}");

            return sb.ToString();
        }
    }
}