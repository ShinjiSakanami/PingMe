using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingMe
{
    public partial class Form1 : Form
    {
        PingSender pingSender;
        int pingTimerTick;
        int expHeight = 110;
        bool warningNotify = true;

        public Form1()
        {
            this.InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.pingSender.HostName = this.tbHostName.Text;
            if (this.pingTimer.Enabled)
            {
                this.pingTimer.Stop();
                this.btnStart.Text = "Start";
                this.startToolStripMenuItem.Text = "Start";
                this.tbHostName.ReadOnly = false;
                this.SetIcon(Properties.Resources.status_s);
                this.notifyIcon.Text = "PingMe: Inactive";
                this.Notification(ToolTipIcon.Info, "PingMe", "Ping stopped!", 3000);
            }
            else
            {
                this.btnStart.Text = "Stop";
                this.startToolStripMenuItem.Text = "Stop";
                this.tbHostName.ReadOnly = true;
                this.tbStartTime.Text = DateTime.Now.ToString();
                this.ResetTexts();
                this.pingSender.Results.Clear();
                this.pingSender.History.Clear();
                this.pingTimerTick = 0;
                this.pingTimer.Start();
                this.Timer_Tick(sender, e);
                this.Notification(ToolTipIcon.Info, "PingMe", "Ping started to " + this.tbHostName.Text, 3000);
            }
        }

        private void SetIcon(Icon icon)
        {
            this.Icon = icon;
            this.notifyIcon.Icon = icon;
        }

        private void Notification(ToolTipIcon icon, string title, string text, int timeout = 0)
        {
            this.notifyIcon.BalloonTipIcon = icon;
            this.notifyIcon.BalloonTipTitle = title;
            this.notifyIcon.BalloonTipText = text;
            this.notifyIcon.ShowBalloonTip(timeout);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pingTimer.Tick += this.Timer_Tick;
            this.pingSender = new PingSender();
            this.pingSender.PingCompleted += this.PingSender_PingCompleted;
            this.tbHostName.Text = "www.google.fr";
            this.ResetTexts();
            this.chart.Series["Time"].Points.AddXY(20, 200);
            this.chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
            this.panel1.Height = 0;
            this.panel2.Height = 0;
            this.panel3.Height = 0;
            this.btnPanel1.Tag = this.panel1;
            this.btnPanel2.Tag = this.panel2;
            this.btnPanel3.Tag = this.panel3;
            this.Height -= expHeight * 3;
            this.SetIcon(Properties.Resources.status_s);
            this.Notification(ToolTipIcon.Info, "PingMe", "Ready to ping!", 3000);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.pingTimerTick++;
            this.tbElapsedTime.Text = TimeSpan.FromSeconds(this.pingTimerTick).ToString();
            try
            {
                this.pingSender.Send();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.btnStart_Click(sender, e);
            }
        }

        private void PingSender_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            DateTime date = DateTime.Now;
            PingHistory history = this.pingSender.History;
            PingResultList results = this.pingSender.Results;
            PingReply reply = e.Reply;

            if (reply != null)
            {
                if (reply.Status > 0)
                {
                    this.chart.Series["Time"].Points.AddXY(history.SendPackets, 0);
                    this.tableResults.Rows.Add(date, this.StatusError(reply.Status));
                }
                else
                {
                    this.tableResults.Rows.Add(date, reply.Address, reply.RoundtripTime, reply.Buffer.Length, reply.Options.Ttl);
                    this.tbTimeMin.Text = history.TimeMin.ToString() + "ms";
                    this.tbLastTimeMin.Text = results.TimeMin.ToString() + "ms";
                    this.tbTimeMax.Text = history.TimeMax.ToString() + "ms";
                    this.tbLastTimeMax.Text = results.TimeMax.ToString() + "ms";
                    this.tbTimeAverage.Text = history.TimeAverage.ToString("F0") + "ms";
                    this.tbLastTimeAverage.Text = results.TimeAverage.ToString("F0") + "ms";
                    this.chart.Series["Time"].Points.AddXY(history.SendPackets, reply.RoundtripTime);
                }
            }
            else
            {
                this.chart.Series["Time"].Points.AddXY(history.SendPackets, 0);
                this.tableResults.Rows.Add(date, this.StatusError(IPStatus.Unknown));
            }
            if (this.chart.Series["Time"].Points.Count > 20)
            {
                this.chart.Series["Time"].Points.RemoveAt(0);
                this.chart.ChartAreas["ChartArea1"].AxisX.Maximum++;
                this.chart.ChartAreas["ChartArea1"].AxisX.Minimum++;
                this.chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
            }
            if (this.tableResults.Rows.Count > 20)
            {
                this.tableResults.Rows.RemoveAt(0);
            }
            this.tbSendPackets.Text = history.SendPackets.ToString();
            this.tbLastSendPackets.Text = results.SendPackets.ToString();
            this.tbReceivedPackets.Text = history.ReceivedPackets.ToString();
            this.tbLastReceivedPackets.Text = results.ReceivedPackets.ToString();
            this.tbLostPackets.Text = history.LostPackets.ToString() + " (" + (history.LostPacketsRatio * 100).ToString("F0") + "%)";
            this.tbLastLostPackets.Text = results.LostPackets.ToString() + " (" + (results.LostPacketsRatio * 100).ToString("F0") + "%)";
            this.DisplayStabilityStatus(results.LostPacketsRatio);
            this.DisplayPingStatus(results.TimeAverage);
        }

        private void ResetTexts()
        {
            this.lblStabilityStatus.Text = "";
            this.lblPingStatus.Text = "";
            this.tableResults.Rows.Clear();
            this.tbElapsedTime.Text = TimeSpan.FromSeconds(0).ToString();
            this.tbTimeMin.Text = "0ms";
            this.tbTimeMax.Text = "0ms";
            this.tbTimeAverage.Text = "0ms";
            this.tbSendPackets.Text = "0";
            this.tbReceivedPackets.Text = "0";
            this.tbLostPackets.Text = "0 (0%)";
            this.tbLastTimeMin.Text = "0ms";
            this.tbLastTimeMax.Text = "0ms";
            this.tbLastTimeAverage.Text = "0ms";
            this.tbLastSendPackets.Text = "0";
            this.tbLastReceivedPackets.Text = "0";
            this.tbLastLostPackets.Text = "0 (0%)";
            this.chart.Series["Time"].Points.Clear();
            this.chart.ChartAreas["ChartArea1"].AxisX.Maximum = 20;
            this.chart.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            this.chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
        }
        
        private void DisplayPingStatus(double ping)
        {
            if (ping > 500)
            {
                this.lblPingStatus.Text = "Very bad";
                this.lblPingStatus.ForeColor = Color.Red;
            }
            else if (ping > 250)
            {
                this.lblPingStatus.Text = "Bad";
                this.lblPingStatus.ForeColor = Color.Red;
            }
            else if (ping > 100)
            {
                this.lblPingStatus.Text = "Average";
                this.lblPingStatus.ForeColor = Color.Orange;
            }
            else if (ping > 50)
            {
                this.lblPingStatus.Text = "Good";
                this.lblPingStatus.ForeColor = Color.Green;
            }
            else
            {
                this.lblPingStatus.Text = "Excellent";
                this.lblPingStatus.ForeColor = Color.Green;
            }
        }

        private void DisplayStabilityStatus(double lostPacketsRatio)
        {
            if (lostPacketsRatio >= 1)
            {
                this.lblStabilityStatus.Text = "No connection";
                this.lblStabilityStatus.ForeColor = Color.Red;
                this.SetIcon(Properties.Resources.status_b);
                this.notifyIcon.Text = "PingMe: No connection!";
                if (this.warningNotify)
                {
                    this.Notification(ToolTipIcon.Error, "PingMe", "Connection lost!!", 3000);
                    this.warningNotify = false;
                }
            }
            else if (lostPacketsRatio > 0.75)
            {
                this.lblStabilityStatus.Text = "Very bad";
                this.lblStabilityStatus.ForeColor = Color.Red;
                this.SetIcon(Properties.Resources.status_b);
                this.notifyIcon.Text = "PingMe: Very bad connection!";
                if (!this.warningNotify)
                {
                    this.warningNotify = true;
                }
            }
            else if (lostPacketsRatio > 0.5)
            {
                this.lblStabilityStatus.Text = "Bad";
                this.lblStabilityStatus.ForeColor = Color.Orange;
                this.SetIcon(Properties.Resources.status_m);
                this.notifyIcon.Text = "PingMe: Bad connection";
            }
            else if (lostPacketsRatio > 0.25)
            {
                this.lblStabilityStatus.Text = "Average";
                this.lblStabilityStatus.ForeColor = Color.Orange;
                this.SetIcon(Properties.Resources.status_m);
                this.notifyIcon.Text = "PingMe: Average connection";
            }
            else if (lostPacketsRatio > 0)
            {
                this.lblStabilityStatus.Text = "Good";
                this.lblStabilityStatus.ForeColor = Color.Green;
                this.SetIcon(Properties.Resources.status_g);
                this.notifyIcon.Text = "PingMe: Good connection";
            }
            else
            {
                this.lblStabilityStatus.Text = "Excellent";
                this.lblStabilityStatus.ForeColor = Color.Green;
                this.SetIcon(Properties.Resources.status_g);
                this.notifyIcon.Text = "PingMe: Excellent connection";
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
                    text = "Destination network unreachable";
                    break;
                case IPStatus.DestinationHostUnreachable:
                    text = "Destination host unreachable";
                    break;
                case IPStatus.DestinationProtocolUnreachable:
                    text = "Destination protocol unreachable or prohibited";
                    break;
                case IPStatus.DestinationPortUnreachable:
                    text = "Destination port unreachable";
                    break;
                case IPStatus.NoResources:
                    text = "No resources";
                    break;
                case IPStatus.BadOption:
                    text = "Bad option";
                    break;
                case IPStatus.HardwareError:
                    text = "Hardware error";
                    break;
                case IPStatus.PacketTooBig:
                    text = "Packet too big";
                    break;
                case IPStatus.TimedOut:
                    text = "Timed out";
                    break;
                case IPStatus.BadRoute:
                    text = "Bad route";
                    break;
                case IPStatus.TtlExpired:
                    text = "TTL expired";
                    break;
                case IPStatus.TtlReassemblyTimeExceeded:
                    text = "TTL reassembly time exceeded";
                    break;
                case IPStatus.ParameterProblem:
                    text = "Parameter problem";
                    break;
                case IPStatus.SourceQuench:
                    text = "Source quench";
                    break;
                case IPStatus.BadDestination:
                    text = "Bad destination";
                    break;
                case IPStatus.DestinationUnreachable:
                    text = "Destination unreachable";
                    break;
                case IPStatus.TimeExceeded:
                    text = "Time exceeded";
                    break;
                case IPStatus.BadHeader:
                    text = "Bad header";
                    break;
                case IPStatus.UnrecognizedNextHeader:
                    text = "Unrecognized next header";
                    break;
                case IPStatus.IcmpError:
                    text = "ICMP error";
                    break;
                case IPStatus.DestinationScopeMismatch:
                    text = "Destination scope mismatch";
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
                this.Height += expHeight;
                btn.Image = Properties.Resources.arrow_down;
            }
            else
            {
                pnl.Height = 0;
                this.Height -= expHeight;
                btn.Image = Properties.Resources.arrow_right;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Visible = false;
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                this.Notification(ToolTipIcon.Info, "PingMe", "PingMe is minimzed to tray", 3000);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnStart_Click(sender, e);
        }
    }
}
