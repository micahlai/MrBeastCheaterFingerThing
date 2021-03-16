using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MrBeastCheaterFingerThing
{

    public partial class Form1 : Form
    {
        private Thread thr;
        private Thread targetThr;
        Point targetPoint;
        public Form1()
        {
            InitializeComponent();
            Thread thr = new Thread(Capture);
            Thread targetThr = new Thread(SetTarget);
            thr.Start();
            targetThr.Start();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            
            
        }

        void Capture()
        {
            while (true)
            {
                if ((Control.ModifierKeys & Keys.Shift) == 0)
                {
                    Point cp = Cursor.Position;
                    if (cp.X > targetPoint.X)
                    {
                        cp.X -= 1;
                    }
                    else if (cp.X < targetPoint.X)
                    {
                        cp.X += 1;
                    }
                    if (cp.Y > targetPoint.Y)
                    {
                        cp.Y -= 1;
                    }
                    else if (cp.Y < targetPoint.Y)
                    {
                        cp.Y += 1;
                    }
                    Cursor.Position = cp;
                    Thread.Sleep(1);
                }
            }
        }
        void SetTarget()
        {
            while (true)
            {
                targetPoint = new Point(139, 322);
                Thread.Sleep(500);
                targetPoint = new Point(139, 523);
                Thread.Sleep(500);
                targetPoint = new Point(219, 523);
                Thread.Sleep(500);
                targetPoint = new Point(219, 322);
                Thread.Sleep(500);
                //CursorPos: TopLeft (139,322), BottomRight (219, 523)
            }
        }
        public void UpdateVisual()
        {
            try
            {
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                pictureBox1.Image = bitmap;
            }
            catch
            {

            }
        }

    }
}
