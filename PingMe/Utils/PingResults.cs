using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace PingMe
{
    public class PingResult
    {
        public IPStatus Status { get; private set; }

        public long Time { get; private set; }

        public PingResult(IPStatus status, long time)
        {
            this.Status = status;
            this.Time = time;
        }
    }

    public class PingResultList
    {
        private List<PingResult> _results;
        private int _limit;

        public long TimeTotal
        {
            get
            {
                long total = 0;
                for (int i = 0; i < this._results.Count; i++)
                {
                    PingResult result = this._results[i];
                    if (result.Status == 0)
                    {
                        total += result.Time;
                    }
                }
                return total;
            }
        }

        public long TimeMax
        {
            get
            {
                long max = 0;
                for (int i = 0; i < this._results.Count; i++)
                {
                    PingResult result = this._results[i];
                    if (result.Status == 0)
                    {
                        if (result.Time > max)
                        {
                            max = result.Time;
                        }
                    }
                }
                return max;
            }
        }

        public long TimeMin
        {
            get
            {
                long min = 0;
                for (int i = 0; i < this._results.Count; i++)
                {
                    PingResult result = this._results[i];
                    if (result.Status == 0)
                    {
                        if (result.Time < min)
                        {
                            min = result.Time;
                        }
                    }
                }
                return min;
            }
        }

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

        public int SendPackets
        {
            get
            {
                return this._results.Count;
            }
        }

        public int ReceivedPackets
        {
            get
            {
                int count = 0;
                for (int i = 0; i < this._results.Count; i++)
                {
                    PingResult result = this._results[i];
                    if (result.Status == 0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int LostPackets
        {
            get
            {
                int count = 0;
                for (int i = 0; i < this._results.Count; i++)
                {
                    PingResult result = this._results[i];
                    if (result.Status != 0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

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

        public PingResultList()
        {
            this._results = new List<PingResult>();
        }

        public PingResultList(int limit) : this()
        {
            this._limit = limit;
        }

        public void Add(PingResult ping)
        {
            this._results.Add(ping);
            if (this._limit > 0 && this._results.Count > this._limit)
            {
                this._results.RemoveAt(0);
            }
        }

        public void Add(IPStatus status, long time)
        {
            this.Add(new PingResult(status, time));
        }

        public void Clear()
        {
            this._results.Clear();
        }
    }
}
