using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PomodoroTimer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private byte WorkTimer = 0;
        private byte BreakTimer = 0;
        private bool IsWorkMode = true;

        

        private void BreakMode()
        {
            LblStatus.Text = "🍅 Break 😍";
            this.BackColor = Color.FromArgb(50, 222, 100);

            BreakTimer++;

            progressBar1.Value = BreakTimer;
            LblTimer.Text = BreakTimer.ToString();

            if (BreakTimer >= 10)
            {
                IsWorkMode = true;
                BreakTimer = 0;

                progressBar1.Value = 0;
                progressBar1.Maximum = 20;
            }
        }

        private void WorkMode()
        {
            LblStatus.Text = "🍅 Work 😖";
            this.BackColor = Color.FromArgb(97, 163, 186);

            WorkTimer++;

            progressBar1.Value = WorkTimer;
            LblTimer.Text = WorkTimer.ToString();

            if (WorkTimer >= 20)
            {
                notifyBreak.Icon = SystemIcons.Application;
                notifyBreak.BalloonTipIcon = ToolTipIcon.None;
                notifyBreak.BalloonTipTitle = "Break Time";
                notifyBreak.BalloonTipText = "Take Break 😍";
                notifyBreak.ShowBalloonTip(100);

                IsWorkMode = false;
                WorkTimer = 0;

                progressBar1.Value = 0;
                progressBar1.Maximum = 10;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsWorkMode)
            {
                WorkMode();
            }
            else
            {
                BreakMode();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
