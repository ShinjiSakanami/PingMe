using System;

namespace PingMe
{
    public class PingHistory
    {
        public long TimeTotal { get; private set; }

        public long TimeMax { get; private set; }

        public long TimeMin { get; private set; }

        public double TimeAverage
        {
            get
            {
                if (this.ReceivedPackets > 0)
                {
                    return Convert.ToDouble(this.TimeTotal) / Convert.ToDouble(this.ReceivedPackets);
                }
                else
                {
                    return 0.0;
                }
            }
        }

        public int SendPackets { get; private set; }

        public int ReceivedPackets { get; private set; }

        public int LostPackets { get; private set; }

        public double LostPacketsRatio
        {
            get
            {
                if (this.SendPackets > 0)
                {
                    return Convert.ToDouble(this.LostPackets) / Convert.ToDouble(this.SendPackets);
                }
                else
                {
                    return 0.0;
                }
            }
        }

        public PingHistory() { }

        public void AddPacket(long time)
        {
            this.SendPackets++;
            this.ReceivedPackets++;
            this.TimeTotal += time;
            if (time > this.TimeMax)
            {
                this.TimeMax = time;
            }
            if (this.TimeMin == 0 || time < this.TimeMin)
            {
                this.TimeMin = time;
            }
        }

        public void AddLostPacket()
        {
            this.SendPackets++;
            this.LostPackets++;
        }

        public void Clear()
        {
            this.TimeTotal = 0;
            this.TimeMin = 0;
            this.TimeMax = 0;
            this.SendPackets = 0;
            this.ReceivedPackets = 0;
            this.LostPackets = 0;
        }
    }
}
