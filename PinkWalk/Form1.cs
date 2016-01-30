using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Reflection;

namespace PinkWalk
{
    


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public NotifyIcon notify;

        public Bitmap pinky1;

        public Timer frametick;

        public PinkyStatus _status = PinkyStatus.Right;
        
        public int frame_n = 0;
        public int frame_last = 9;
        public int frame_move = 4;

        public bool animation_repeat = true;
        public bool animation_run = true;

        public string animation_base = @"Walk.bigpinky_allgemein_simpleright_";
        public string animation_extension = @".png";

        private void SetPinkyStatus(PinkyStatus newStatus)
        {
            if (_status != newStatus)
            {
                menuItemRight.Checked = false;
                menuItemLeft.Checked = false;
                menuItemWait.Checked = false;

                if (newStatus == PinkyStatus.Right)
                {

                    animation_base = @"Walk.bigpinky_allgemein_simpleright_";
                    frame_last = 9;
                    frame_n = 0;
                    frame_move = 4;
                    animation_repeat = true;
                    animation_run = true;
                    menuItemRight.Checked = true;
                }
                else if (newStatus == PinkyStatus.Left)
                {
                    animation_base = @"Walk.bigpinky_allgemein_simpleleft_";
                    frame_last = 9;
                    frame_n = 0;
                    frame_move = -4;
                    animation_repeat = true;
                    animation_run = true;
                    menuItemLeft.Checked = true;
                }
                else if (newStatus== PinkyStatus.Wait)
                {
                    animation_base = @"Kitzel.bigpinky_kitzel_0_";
                    frame_last = 20;
                    frame_n = 0;
                    frame_move = 0;
                    animation_repeat = false;
                    animation_run = false;
                    menuItemWait.Checked = true;
                    LoadCurrentAnimationImageFile();

                }
                else if (newStatus == PinkyStatus.Tickle1)
                {
                    animation_base = @"Kitzel.bigpinky_kitzel_0_";
                    frame_last = 20;
                    frame_n = 0;
                    frame_move = 0;
                    animation_repeat = false;
                    animation_run = true;
                }
                else if (newStatus == PinkyStatus.Tickle2)
                {
                    animation_base = @"Kitzel.bigpinky_kitzel_1_";
                    frame_last = 11;
                    frame_n = 0;
                    frame_move = 0;
                    animation_repeat = false;
                    animation_run = true;
                }
                else if (newStatus == PinkyStatus.Tickle3)
                {
                    animation_base = @"Kitzel.bigpinky_kitzel_2_";
                    frame_last = 19;
                    frame_n = 0;
                    frame_move = 0;
                    animation_repeat = false;
                    animation_run = true;
                }
                else if (newStatus == PinkyStatus.Tickle4)
                {
                    animation_base = @"Kitzel.bigpinky_kitzel_3_";
                    frame_last = 42;
                    frame_n = 0;
                    frame_move = 0;
                    animation_repeat = false;
                    animation_run = true;
                }

                _status = newStatus;
                
            }
        }

        private string CurrentAnimationImageFile()
        {
            //animation_base = @"C:\LokaleDaten\Grafikexport\BigPinky\Kitzel\bigpinky_kitzel_3_";
            return (animation_base + frame_n.ToString() + animation_extension);
        }

        private void LoadCurrentAnimationImageFile()
        {
            string adr = "PinkWalk.Images." + CurrentAnimationImageFile();
            Bitmap btm = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(adr));
            this.SetBitmap(btm, 255);
            btm.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form1.ActiveForm.Opacity = 0.5f;
            //this.Opacity = 0.5f;
           // this.TransparencyKey = this.BackColor;
            //pinky1 = new Bitmap(CurrentAnimationImageFile());

            Text = "Pinky";
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;

            SetPinkyStatus(PinkyStatus.Wait);
            
            frametick = new Timer();
            frametick.Interval = 60;
            frametick.Tick += new EventHandler(frametick_Tick);

            this.Width = 96;
            this.Height = 120;
            this.Show();

            LoadCurrentAnimationImageFile();

            frametick.Start();
            
        }

        void frametick_Tick(object sender, EventArgs e)
        {
            if (animation_run)
            {
                if (frame_n == frame_last)
                {
                    frame_n = 0;
                    if (!animation_repeat) SetPinkyStatus(PinkyStatus.Wait);
                }
                else frame_n++;

                LoadCurrentAnimationImageFile();

                if (_status == PinkyStatus.Left)
                {
                    if ((this.Left == (Screen.PrimaryScreen.WorkingArea.Width + 100)) && (frametick.Interval == 10000))
                    {
                        frametick.Interval = 60;
                    }
                    else if (this.Left < -100)
                    {
                        this.Left = (Screen.PrimaryScreen.WorkingArea.Width + 100);
                        frametick.Interval = 10000;
                    }
                    else this.Left += frame_move;
                }
                else if (_status == PinkyStatus.Right)
                {
                    if ((this.Left == -100) && (frametick.Interval == 10000))
                    {
                        frametick.Interval = 60;
                    }
                    else if (this.Left > Screen.PrimaryScreen.WorkingArea.Width)
                    {
                        this.Left = -100;
                        frametick.Interval = 10000;
                    }
                    else this.Left += frame_move;
                }
                else
                {
                }

            }

        }

        // Let Windows drag this window for us
        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == 0x0084 ) // WM_NCHITTEST
            {
                m.Result = (IntPtr)2;	// HTCLIENT
                /*
                if ((Cursor.Position.X - this.Left) > 25 &
                    (Cursor.Position.X - this.Left) < 125 &
                    (Cursor.Position.Y - this.Top) > 260 &
                    (Cursor.Position.Y - this.Top) < 285)
                {
                    Bitmap btm = (Bitmap)Bitmap.FromFile(CurrentAnimationImageFile());
                    this.SetBitmap(btm, 255);
                    Invalidate();
                    btm.Dispose();
                }
                else
                {
                    Bitmap btm = (Bitmap)Bitmap.FromFile(CurrentAnimationImageFile());
                    this.SetBitmap(btm, 255);
                    Invalidate();
                    btm.Dispose();

                }
                 */
                return;
            }
            

            if (m.Msg == 0x00A1)//WM_NCLBUTTONDOWN 
            {
                m.Result = (IntPtr)2;	// HTCLIENT

                if (_status == PinkyStatus.Wait)
                {

                    if (!animation_run)
                    {
                        Point coord = this.PointToClient(Cursor.Position);
                        if (coord.Y < 30) SetPinkyStatus(PinkyStatus.Tickle2);
                        else if (coord.Y > 70) SetPinkyStatus(PinkyStatus.Tickle3);
                        else
                        {
                            if (coord.X < 30) SetPinkyStatus(PinkyStatus.Tickle4);
                            else SetPinkyStatus(PinkyStatus.Tickle1);
                        }
                        
                    }
                    
                }

            }

            if (m.Msg == 0x00A4)//WM_NCRBUTTONDOWN 
            {
                m.Result = (IntPtr)2;	// HTCLIENT

                SetPinkyStatus(PinkyStatus.Wait);
                contextMenuStrip1.Show(Cursor.Position);
                /*
                DialogResult Result = MessageBox.Show("Press Yes to quit.", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                 * */

            }

            base.WndProc(ref m);
        }


      /// <para>Changes the current bitmap.</para>
        public void SetBitmap(Bitmap bitmap)
        {
            SetBitmap(bitmap, 255);
        }

        /// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // The ideia of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
                return cp;
            }
        }

        private void menuItemRight_Click(object sender, EventArgs e)
        {
            SetPinkyStatus(PinkyStatus.Right);
        }

        private void menuItemLeft_Click(object sender, EventArgs e)
        {
            SetPinkyStatus(PinkyStatus.Left);
        }

        private void menuItemWait_Click(object sender, EventArgs e)
        {
            SetPinkyStatus(PinkyStatus.Wait);
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }

    public enum PinkyStatus
    {
        Left,
        Right,
        Wait,
        Tickle1,
        Tickle2,
        Tickle3,
        Tickle4
    }

    #region Win32 GDI functions
    /// <summary>
    // a static class to expose needed win32 gdi functions.
    /// </summary>
    class Win32
    {
        public enum Bool
        {
            False = 0,
            True
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public Int32 x;
            public Int32 y;

            public Point(Int32 x, Int32 y) { this.x = x; this.y = y; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public Int32 cx;
            public Int32 cy;

            public Size(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct ARGB
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }


        public const Int32 ULW_COLORKEY = 0x00000001;
        public const Int32 ULW_ALPHA = 0x00000002;
        public const Int32 ULW_OPAQUE = 0x00000004;

        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;


        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteObject(IntPtr hObject);
    }
    #endregion
}