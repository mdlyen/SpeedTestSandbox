using System.Threading;
using System.Windows;
using System.Windows.Input;

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
                using (new WaitCursor())
                {
                    var PST = new PerformSpeedTest(a, b);

                    // Todo: Change this to a background thread so UI can update, etc.
                    textBoxOutput.Text = PST.RunTests();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                SetFormButtons(true);
            }
        }

        private void SetFormButtons(bool newValue)
        {
            if (newValue)
            {
                btnGoCancel.Content = "Go";
            }
            else
            {
                btnGoCancel.Content = "Cancel";
            }

            btnExit.IsEnabled = newValue;
        }
    }
}
