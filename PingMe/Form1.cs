using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingMe
{
    public partial class Form1 : Form
    {
        PingSender pingSender;
        int pingTimerTick;
        int expHeight = 110;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pingSender.HostName = tbHostName.Text;
            if (pingTimer.Enabled)
            {
                pingTimer.Stop();
                btnStart.Text = "Start";
                tbHostName.ReadOnly = false;
                Icon = Properties.Resources.status_s;
            }
            else
            {
                btnStart.Text = "Stop";
                tbHostName.ReadOnly = true;
                tbStartTime.Text = DateTime.Now.ToString();
                ResetTexts();
                pingSender.Results.Clear();
                pingSender.History.Clear();
                pingTimerTick = 0;
                pingTimer.Start();
                Timer_Tick(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pingTimer.Tick += Timer_Tick;
            pingSender = new PingSender();
            pingSender.PingCompleted += PingSender_PingCompleted;
            tbHostName.Text = "173.194.40.147";
            ResetTexts();
            chart.Series["Time"].Points.AddXY(20, 200);
            chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
            panel1.Height = 0;
            panel2.Height = 0;
            panel3.Height = 0;
            btnPanel1.Tag = panel1;
            btnPanel2.Tag = panel2;
            btnPanel3.Tag = panel3;
            Height -= expHeight * 3;
            Icon = Properties.Resources.status_s;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pingTimerTick++;
            tbElapsedTime.Text = TimeSpan.FromSeconds(pingTimerTick).ToString();
            try
            {
                pingSender.Send();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                btnStart_Click(sender, e);
            }
        }

        private void PingSender_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            DateTime date = DateTime.Now;
            PingHistory history = pingSender.History;
            PingResultList results = pingSender.Results;
            PingReply reply = e.Reply;

            if (reply.Status > 0)
            {
                chart.Series["Time"].Points.AddXY(history.SendPackets, 0);
                tableResults.Rows.Add(date, StatusError(reply.Status));
            }
            else
            {
                tableResults.Rows.Add(date, reply.Address, reply.RoundtripTime, reply.Buffer.Length, reply.Options.Ttl);
                tbTimeMin.Text = history.TimeMin.ToString() + "ms";
                tbLastTimeMin.Text = results.TimeMin.ToString() + "ms";
                tbTimeMax.Text = history.TimeMax.ToString() + "ms";
                tbLastTimeMax.Text = results.TimeMax.ToString() + "ms";
                tbTimeAverage.Text = history.TimeAverage.ToString("F0") + "ms";
                tbLastTimeAverage.Text = results.TimeAverage.ToString("F0") + "ms";
                chart.Series["Time"].Points.AddXY(history.SendPackets, reply.RoundtripTime);
            }
            if (chart.Series["Time"].Points.Count > 20)
            {
                chart.Series["Time"].Points.RemoveAt(0);
                chart.ChartAreas["ChartArea1"].AxisX.Maximum++;
                chart.ChartAreas["ChartArea1"].AxisX.Minimum++;
                chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
            }
            if (tableResults.Rows.Count > 20)
            {
                tableResults.Rows.RemoveAt(0);
            }
            tbSendPackets.Text = history.SendPackets.ToString();
            tbLastSendPackets.Text = results.SendPackets.ToString();
            tbReceivedPackets.Text = history.ReceivedPackets.ToString();
            tbLastReceivedPackets.Text = results.ReceivedPackets.ToString();
            tbLostPackets.Text = history.LostPackets.ToString() + " (" + history.LostPacketsRatio.ToString("F0") + "%)";
            tbLastLostPackets.Text = results.LostPackets.ToString() + " (" + results.LostPacketsRatio.ToString("F0") + "%)";
            DisplayStatus(results.LostPacketsRatio);
        }

        private void ResetTexts()
        {
            lblStatus.Text = "";
            tableResults.Rows.Clear();
            tbElapsedTime.Text = TimeSpan.FromSeconds(0).ToString();
            tbTimeMin.Text = "0ms";
            tbTimeMax.Text = "0ms";
            tbTimeAverage.Text = "0ms";
            tbSendPackets.Text = "0";
            tbReceivedPackets.Text = "0";
            tbLostPackets.Text = "0 (0%)";
            tbLastTimeMin.Text = "0ms";
            tbLastTimeMax.Text = "0ms";
            tbLastTimeAverage.Text = "0ms";
            tbLastSendPackets.Text = "0";
            tbLastReceivedPackets.Text = "0";
            tbLastLostPackets.Text = "0 (0%)";
            chart.Series["Time"].Points.Clear();
            chart.ChartAreas["ChartArea1"].AxisX.Maximum = 20;
            chart.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
        }

        private void DisplayStatus(double lostPacketsRatio)
        {
            if (lostPacketsRatio == 100)
            {
                lblStatus.Text = "No connection";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                Icon = Properties.Resources.status_b;
            }
            else if (lostPacketsRatio > 75)
            {
                lblStatus.Text = "Very bad";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                Icon = Properties.Resources.status_b;
            }
            else if (lostPacketsRatio > 50)
            {
                lblStatus.Text = "Bad";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                Icon = Properties.Resources.status_m;
            }
            else if (lostPacketsRatio > 25)
            {
                lblStatus.Text = "Average";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                Icon = Properties.Resources.status_m;
            }
            else if (lostPacketsRatio > 0)
            {
                lblStatus.Text = "Good";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                Icon = Properties.Resources.status_g;
            }
            else
            {
                lblStatus.Text = "Excellent";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                Icon = Properties.Resources.status_g;
            }
        }

        private string StatusError(IPStatus status)
        {
            string text = "";
            switch (status)
            {
                case IPStatus.Unknown:
                    text = "Unknown error";
                    break;
                case IPStatus.Success:
                    text = "Success";
                    break;
                case IPStatus.DestinationNetworkUnreachable:
                    text = "Destination Network unreachable";
                    break;
                case IPStatus.DestinationHostUnreachable:
                    text = "Destination Host Unreachable";
                    break;
                case IPStatus.DestinationProtocolUnreachable:
                    text = "Destination Protocol Unreachable";
                    break;
                case IPStatus.TimedOut:
                    text = "Timed Out";
                    break;
                default:
                    text = status.ToString();
                    break;
            }
            return text;
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel pnl = (Panel)btn.Tag;
            if (pnl.Height == 0)
            {
                pnl.Height = expHeight;
                Height += expHeight;
                btn.Image = Properties.Resources.arrow_down;
            }
            else
            {
                pnl.Height = 0;
                Height -= expHeight;
                btn.Image = Properties.Resources.arrow_right;
            }
        }
    }
}
