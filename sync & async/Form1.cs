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

namespace sync_async
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;
        private uint _elapsedSec = 0;
        public Form1()
        {
            InitializeComponent();

            this._timer = new System.Windows.Forms.Timer();
            this._timer.Interval = 1000;
            this._timer.Tick += Timer_tick;
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            this._elapsedSec++;
            TimeSpan timeSpan = TimeSpan.FromSeconds(this._elapsedSec);

            txt1.Text = timeSpan.ToString(@"ss");
            txt1.Refresh();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            txt1.Text = "Waiting for 5 seconds...";
            txt1.Refresh();
            this._elapsedSec = 0;
            this._timer.Start();

            await Task.Delay(5000);

            this._timer.Stop();
            txt1.Text = "Wait completed!";
            txt1.Refresh();
        }
    }
}


//await Task.Delay(5000);
//System.Threading.Thread.Sleep(5000);
