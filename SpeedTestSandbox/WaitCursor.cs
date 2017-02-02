using System;
using System.Windows.Input;

namespace SpeedTestSandbox
{
    public class WaitCursor : IDisposable
    {
        private Cursor _oldCursor;

        public WaitCursor()
        {
            _oldCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
        }

        public void Dispose()
        {
            //Set it back now that we are done.
            Mouse.OverrideCursor = _oldCursor;
        }
    }
}