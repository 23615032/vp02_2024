using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _022_Dockclock
{
    public partial class Form1 : Form
    {
        // 필드(멤버함수)
        private Graphics g;
        private bool aClockFlag = true; // 아날로그 시계
        private Point center;
        private int radius;
        private int hourHand; //시침의 길이
        private int minHand; //분침의 길이
        private int secHand; //초침의 길이

        const int clientSize = 300; // client 크기
        const int clockSize = 200; // 시계의 크기

        private Font fDate;
        private Font fTime;
        private Brush bDate;
        private Brush bTime;

        Point panelCenter;

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(clientSize,
                clientSize + menuStrip1.Height);
            this.Text = "My Form Clock";

            // panel 지정
            panel1.BackColor = Color.Beige;
            panel1.Width = clockSize + 1;
            panel1.Height = clockSize + 1;
            panel1.Location = new Point(
                clientSize/2 - clockSize/2 ,
                clientSize / 2 - clockSize / 2 + menuStrip1.Height);

            g = panel1.CreateGraphics();

            aClockSetting();
            dClockSetting();
            timerSetting();
        }

        private void dClockSetting()
        {
            fDate = new Font("맑은 고딕", 12, FontStyle.Bold);
            fTime = new Font("맑은 고딕", 32, FontStyle.Bold | FontStyle.Italic);
            bDate = Brushes.Pink;
            bTime = Brushes.DarkBlue;
        }

        private void timerSetting()
        {
            Timer t = new Timer(); // 타이머를 코드에서 만든다

            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += T_Tick;

        }

        private void T_Tick(object sender, EventArgs e)
        {
            DateTime c = DateTime.Now; //현재 시간
            panel1.Refresh();
            if (aClockFlag == true) // 아날로그
            {
                DrawClockFace();

                // 시계 바늘 각도
                double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;
                double radMinute = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
                double radSec = c.Second * 6 * Math.PI / 180;

                DrawHands(radHr, radMinute, radSec);
            }
            else //디지털
            {
                string date = DateTime.Today.ToString("D");
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    c.Hour, c.Minute, c.Second);
                g.DrawString(date, fDate, bDate, new Point(5, 70));
                g.DrawString(time, fTime, bTime, new Point(5, 100));
            }
        }

        private void DrawHands(double radHr, double radMinute, double radSec)
        {
            
        }

        private void DrawClockFace()
        {
            const int penWidth = 30;

            Pen p = new Pen(Brushes.HotPink, penWidth);
            g.DrawEllipse(p, penWidth/2, penWidth/2, clockSize- penWidth , clockSize- penWidth);
        }

        private void aClockSetting()
        {
            center = new Point(clientSize/2, clientSize/2);
            radius = clientSize/2;
            hourHand = (int)(radius * 0.45);
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }
    }
}
