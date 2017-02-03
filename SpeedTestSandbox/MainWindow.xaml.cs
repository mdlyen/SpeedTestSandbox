using System.Windows;

namespace SpeedTestSandbox
{
    public partial class MainWindow : Window
    {
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
            SetFormButtons(false);

            var a = new TestClasses.TestClassA();
            var b = new TestClasses.TestClassB();

            try
            {
                using (new HourglassCursor())
                {
                    var pst = new PerformSpeedTest(a, b);

                    // Todo: Change this to a background thread so UI can update, etc.
                    TextBoxOutput.Text = pst.RunTests();
                }
            }
            finally
            {
                SetFormButtons(true);
            }
        }

        private void SetFormButtons(bool newValue)
        {
            BtnGoCancel.Content = newValue ? "Go" : "Cancel";

            BtnExit.IsEnabled = newValue;
        }
    }
}
