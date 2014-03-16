using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace CSTrackaccess
{
    public partial class Form1 : Form
    {
        Capture capWebCam = null;
        private HaarCascade haarCasc;
        bool blnCapturingProcess = false;
        Image<Bgr, Byte> imgOriginal;
        float scaleH, scaleW;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                capWebCam = new Capture();
            }
            catch (NullReferenceException except)
            {         
                return;
            }
            haarCasc = new HaarCascade("haarcascade_frontalface_alt2.xml");
            Application.Idle += processFrameAndUpdateGUI;
            blnCapturingProcess = true;
            Cursor.Position = new Point(SystemInformation.PrimaryMonitorSize.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2);
            scaleW = SystemInformation.PrimaryMonitorSize.Width / ibOriginal.Size.Width;
            scaleH = SystemInformation.PrimaryMonitorSize.Height / ibOriginal.Size.Height;

        }

        private void Form1_FormClosed( object sender, FormClosedEventArgs e)
        {
            if (capWebCam != null)
            {
                capWebCam.Dispose();
            }
        }

        void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
           /* imgOriginal = capWebCam.QueryFrame();
            if (imgOriginal == null) return;

            imgProcess = imgOriginal.InRange(new Bgr(0,0,175), new Bgr(100,100,256));
            imgProcess = imgProcess.SmoothGaussian(9);
            CircleF[] circles = imgProcess.HoughCircles(new Gray(100), new Gray(50), 2,
                                                            imgProcess.Height/4,10,400)[0];
            foreach (CircleF circle in circles)
            {
                if (txtXYRadius.Text != "") txtXYRadius.AppendText( Environment.NewLine);
                txtXYRadius.AppendText("ball position = x " +circle.Center.X.ToString().PadLeft(4) 
                                            + ", y =  " + circle.Center.X.ToString().PadLeft(4) +
                                            ", radius = " +circle.Radius.ToString("###.000").PadLeft(7));
                txtXYRadius.ScrollToCaret();

                CvInvoke.cvCircle(imgOriginal, new Point ((int) circle.Center.X, (int) circle.Center.Y), 3, new MCvScalar(0,255,0), -1, LINE_TYPE.CV_AA, 0);
                imgOriginal.Draw(circle, new Bgr(Color.Red), 3);                
            }
            */
          

            using (Image<Bgr, Byte> nextFrame = capWebCam.QueryFrame())
            {
                if (nextFrame != null)
                {
                    Image<Gray, byte> grayFrame = nextFrame.Convert<Gray, byte>();
                    var faces = grayFrame.DetectHaarCascade(haarCasc,1.4,4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                                                    new Size(nextFrame.Width/8, nextFrame.Height/8))[0];
                    foreach (var face in faces)
                    {
                        nextFrame.Draw(face.rect, new Bgr(7, double.MaxValue, 0), 3);
                        Cursor.Position = new Point((int)(face.rect.X * scaleW + face.rect.Width/2), 
                            (int) (face.rect.Y *scaleH + face.rect.Height/2));                       
                    }

                    ibOriginal.Image = nextFrame;
                }
            }
        }

        private void btnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingProcess == true)
            {
                Application.Idle -= processFrameAndUpdateGUI;
                blnCapturingProcess = false;
                btnPauseOrResume.Text = "resume";
            }
            else
            {
                Application.Idle += processFrameAndUpdateGUI;
                blnCapturingProcess = true;
                btnPauseOrResume.Text = "pause";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
