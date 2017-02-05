namespace SpeedTestSandbox.SandBoxClasses
{
    public interface ISpeedTest
    {
        void PerformTest();
        long ElapsedTime { get; }
        string ClassName { get; }
        int Iterations { get; }
    }
}