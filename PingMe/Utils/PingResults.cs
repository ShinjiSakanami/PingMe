using System;
using System.Collections.Generic;
using System.Linq;
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
                return this._results.Where(p => p.Status == 0).Sum(p => p.Time);
            }
        }

        public long TimeMax
        {
            get
            {
                return this._results.Where(p => p.Status == 0).Max(p => p.Time);
            }
        }

        public long TimeMin
        {
            get
            {
                return this._results.Where(p => p.Status == 0).Min(p => p.Time);
            }
        }

        public double TimeAverage
        {
            get
            {
                return this._results.Where(p => p.Status == 0).Average(p => p.Time);
            }
        }

        public int SendPackets
        {
            get
            {
                return this._results.Count();
            }
        }

        public int ReceivedPackets
        {
            get
            {
                return this._results.Count(p => p.Status == 0);
            }
        }

        public int LostPackets
        {
            get
            {
                return this._results.Count(p => (p.Status != 0));
            }
        }

        public double LostPacketsRatio
        {
            get
            {
                return Convert.ToDouble(this.LostPackets) / Convert.ToDouble(this.SendPackets); 
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
            Add(new PingResult(status, time));
        }

        public void Clear()
        {
            this._results.Clear();
        }
    }
}
