using System;
using System.Windows.Input;

namespace SpeedTestSandbox
{
    public class HourglassCursor : IDisposable
    {
        private readonly Cursor _oldCursor;

        public HourglassCursor()
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