﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox
{
    public partial class MainWindow : Window
    {
        private PerformSpeedTest _performSpeedTest;
        private Cursor _oldCursor;
        private BackgroundWorker _backgroundWorker;
        private bool _isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGoCancel_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                if (_backgroundWorker.IsBusy) _backgroundWorker.CancelAsync();
                TextBoxOutput.Text = _performSpeedTest.TextOutput;
                SetFormButtons(true);
            }
            else
            {
                SetFormButtons(false);

                // Spin up the test classes and the SpeedTest harness.
                var a = new TestClasses.TestClassA();
                var b = new TestClasses.TestClassB();
                _performSpeedTest = new PerformSpeedTest(a, b);

                // Set up the background process.
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.RunWorkerCompleted += WorkerCompleted;
                _backgroundWorker.DoWork += PerformTests;
                _backgroundWorker.WorkerSupportsCancellation = true;

                // Start the background process.
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TextBoxOutput.Text = _performSpeedTest.TextOutput;
            SetFormButtons(true);
        }

        private void PerformTests(object s, DoWorkEventArgs args)
        {
            _performSpeedTest.RunTests(_backgroundWorker);
        }

        private void SetFormButtons(bool isIdle)
        {
            BtnGoCancel.Content = isIdle ? "Go" : "Cancel";
            BtnExit.IsEnabled = isIdle;

            if (isIdle)
            {
                _isRunning = false;
                Mouse.OverrideCursor = _oldCursor;
            }
            else
            {
                _isRunning = true;
                _oldCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
            }
        }
    }
}