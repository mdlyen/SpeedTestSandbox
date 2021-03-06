﻿using System;
using System.Diagnostics;
using System.Threading;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox.TestClasses
{
    public class StringAppend : ISpeedTest
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
            var resultString = "";

            for (var i = 0; i < Iterations; i++)
            {
                resultString += i.ToString();
            }

            // Stop the stopwatch.
            sw.Stop();

            ElapsedTime = sw.ElapsedMilliseconds;
        }
    }
}