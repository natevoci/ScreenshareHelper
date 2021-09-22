using ScreenshareHelper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshareHelper
{
    public partial class Form1 : Form
    {
        private const byte VISIBLE_TRANSPARENCY = 160;
        private const byte HIDDEN_TRANSPARENCY = 30;
        private const int OUTLINE_THICKNESS = 4;
        private Brush OUTLINE_COLOR = Brushes.Red;

        private bool _isHidden = false;
        private Rectangle _frameOffset = new Rectangle(0, 0, 0, 0);

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;//update CreateParams

            this.MouseDown += Form1_MouseDown;
            this.panelButtons.MouseDown += Form1_MouseDown;

            SetTransparency(this.Handle, VISIBLE_TRANSPARENCY);

            RestoreWindowPosition();
        }

        #region Window Events
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    if (_isHidden)
                        Invalidate();
                    Thread.Sleep(40);
                }
            });
            t.IsBackground = true;
            t.Start();

            this.FormBorderStyle = FormBorderStyle.None;//update CreateParams
            CalculateFrameBounds();

            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.Cross;
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (_isHidden)
            {
                _isHidden = false;
                panelButtons.Visible = true;

                var inactiveBounds = this.Bounds;
                System.Diagnostics.Debug.WriteLine($"a1 {this.Bounds}");

                var style = Win32.GetWindowLong(this.Handle, Win32.GWL_STYLE);
                Win32.SetWindowLong(this.Handle, Win32.GWL_STYLE, (uint)(style | Win32.WS_SIZEBOX));

                var exStyle = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
                Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, (uint)(exStyle & ~Win32.WS_EX_TRANSPARENT));

                System.Diagnostics.Debug.WriteLine($"a2 {this.Bounds}");

                var activeBounds = GetBoundsWithBorders(inactiveBounds);
                System.Diagnostics.Debug.WriteLine($"a3 {activeBounds}");

                this.Bounds = activeBounds;
                System.Diagnostics.Debug.WriteLine($"a4 {this.Bounds}");

                this.TopMost = false;
            }

            SetTransparency(this.Handle, VISIBLE_TRANSPARENCY);

            Invalidate();
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (_isHidden)
            {
                SetTransparency(this.Handle, HIDDEN_TRANSPARENCY);
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (!_isHidden)
            {
                SaveWindowPosition();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!_isHidden)
            {
                SaveWindowPosition();
            }
        }
        #endregion

        #region Overrides
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= Win32.WS_SIZEBOX;
                cp.ExStyle |= Win32.WS_EX_LAYERED;
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!_isHidden)
            {
                base.OnPaintBackground(e);
            }
            else
            {
                // Copy the capture area
                e.Graphics.CopyFromScreen(Settings.Default.CaptureLocation.X, Settings.Default.CaptureLocation.Y, 0, 0, Settings.Default.CaptureSize);

                // Draw the outline. It get's covered by teams once sharing begins
                e.Graphics.FillRectangle(OUTLINE_COLOR, 0, 0, this.Width, OUTLINE_THICKNESS);
                e.Graphics.FillRectangle(OUTLINE_COLOR, 0, 0, OUTLINE_THICKNESS, this.Height);
                e.Graphics.FillRectangle(OUTLINE_COLOR, 0, this.Height - OUTLINE_THICKNESS, this.Width, OUTLINE_THICKNESS);
                e.Graphics.FillRectangle(OUTLINE_COLOR, this.Width - OUTLINE_THICKNESS, 0, OUTLINE_THICKNESS, this.Height);
            }
        }
        #endregion

        #region Bounds
        private Rectangle GetBoundsWithBorders(Rectangle srcRect)
        {
            return new Rectangle(
                srcRect.X - _frameOffset.X,
                srcRect.Y - _frameOffset.Y,
                srcRect.Width - _frameOffset.Width,
                srcRect.Height - _frameOffset.Height);
        }

        private Rectangle GetBoundsWithoutBorders()
        {
            Win32.RECT frame;
            Win32.DwmGetWindowAttribute(this.Handle, Win32.DWMWINDOWATTRIBUTE.ExtendedFrameBounds, out frame, Marshal.SizeOf(typeof(Win32.RECT)));
            return new Rectangle(frame.Location, frame.Size);
        }

        private void CalculateFrameBounds()
        {
            var rect = GetBoundsWithoutBorders();
            System.Diagnostics.Debug.WriteLine($"Bounds       {this.Bounds}");
            System.Diagnostics.Debug.WriteLine($"Frame        {rect}");
            _frameOffset = new Rectangle(
                rect.X - Bounds.X,
                rect.Y - Bounds.Y,
                rect.Width - Bounds.Width,
                rect.Height - Bounds.Height);
            System.Diagnostics.Debug.WriteLine($"Frame offset {_frameOffset}");
        }
        #endregion

        private void RestoreWindowPosition()
        {
            if (Settings.Default.HasSetDefaults)
            {
                var savedRect = new Rectangle(Settings.Default.Location, Settings.Default.Size);
                System.Diagnostics.Debug.WriteLine($"restoring    {savedRect}");
                this.Bounds = savedRect;
                System.Diagnostics.Debug.WriteLine($"restored to  {this.Bounds}");
                var withoutRect = GetBoundsWithoutBorders();
                System.Diagnostics.Debug.WriteLine($"without bord {withoutRect}");
            }
        }

        private void SaveWindowPosition()
        {
            var rect = GetBoundsWithoutBorders();

            System.Diagnostics.Debug.WriteLine($"saving bounds  {this.Bounds}");
            System.Diagnostics.Debug.WriteLine($"saving capture {rect}");

            Settings.Default.Location = this.Location;
            Settings.Default.Size = this.Size;
            Settings.Default.CaptureLocation = rect.Location;
            Settings.Default.CaptureSize = rect.Size;
            Settings.Default.HasSetDefaults = true;
            Settings.Default.Save();
        }
       
        private void buttonCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            panelButtons.Visible = false;

            SetTransparency(this.Handle, HIDDEN_TRANSPARENCY);

            var inactiveBounds = GetBoundsWithoutBorders();
            System.Diagnostics.Debug.WriteLine($"d1 {this.Bounds}");

            var style = Win32.GetWindowLong(this.Handle, Win32.GWL_STYLE);
            Win32.SetWindowLong(this.Handle, Win32.GWL_STYLE, (uint)(style & ~Win32.WS_SIZEBOX));

            var exStyle = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
            Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, exStyle | Win32.WS_EX_TRANSPARENT);

            System.Diagnostics.Debug.WriteLine($"d2 {this.Bounds}");

            this.Bounds = inactiveBounds;
            System.Diagnostics.Debug.WriteLine($"d3 {this.Bounds}");

            this.TopMost = true;

            _isHidden = true;

            // Unfocus this window by focussing the shell window.
            Win32.SetForegroundWindow(Win32.GetShellWindow());
        }

        private static void SetTransparency(IntPtr handle, byte alpha)
        {
            Win32.SetLayeredWindowAttributes(handle, 0, alpha, Win32.LWA_ALPHA);

            System.Diagnostics.Debug.WriteLine($"Transparency set to {alpha}");
        }

    }
}
