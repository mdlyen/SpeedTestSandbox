using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SpeedTestSandbox.SandBoxClasses;

namespace SpeedTestSandbox
{
    public partial class MainWindow
    {
        private PerformSpeedTest _performSpeedTest;
        private Cursor _oldCursor;
        private BackgroundWorker _backgroundWorker;
        private bool _isCancelled;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            SetFormButtons(false);

            // Spin up the SpeedTest harness.
            _performSpeedTest = new PerformSpeedTest();

            // Set up the background process.
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.RunWorkerCompleted += WorkerCompleted;
            _backgroundWorker.DoWork += PerformTests;
            _backgroundWorker.WorkerSupportsCancellation = true;

            // Start the background process.
            _backgroundWorker.RunWorkerAsync();
            _isCancelled = false;
            TextBoxOutput.Text = "Performing tests...";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (_backgroundWorker.IsBusy) _backgroundWorker.CancelAsync();

            TextBoxOutput.Text = "Operation pending...";
            _isCancelled = true;
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TextBoxOutput.Text = _isCancelled ? "Operation cancelled..." : _performSpeedTest.TextOutput;
            SetFormButtons(true);
        }

        private void PerformTests(object s, DoWorkEventArgs args)
        {
            _performSpeedTest.RunTests(_backgroundWorker);
        }

        private void SetFormButtons(bool isIdle)
        {
            BtnGo.IsEnabled = isIdle;
            BtnCancel.IsEnabled = !isIdle;
            BtnExit.IsEnabled = isIdle;

            if (isIdle)
            {
                Mouse.OverrideCursor = _oldCursor;
            }
            else
            {
                _oldCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
            }
        }
    }
}