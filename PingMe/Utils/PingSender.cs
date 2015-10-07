using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace PingMe
{
    public class PingSender
    {
        // The ping packet handler
        private Ping _ping;

        // Options for the ping handler.
        private PingOptions _options;

        // Required by the ping handler. No idea what it does...
        private AutoResetEvent _waiter;

        // The packet of octets that will be send by the ping handler.
        private byte[] _buffer;

        // Is the ping active?
        private bool _active;

        // The host name or IP address that will be pinged. Default is www.google.com.
        public string HostName { get; set; }

        // Time in milliseconds before the ping is timed out. Default is 3000 (3s).
        public int TimeOut { get; set; }

        // Ping option. Time To Live of the packet, decreased by 1 each time it goes through a router. Default is 255.
        public int TimeToLive
        {
            get
            {
                return this._options.Ttl;
            }
            set
            {
                this._options.Ttl = value;
            }
        }

        // Ping option. The ping will send an entire packet, not fragments. Default is true.
        public bool DontFragment
        {
            get
            {
                return this._options.DontFragment;
            }
            set
            {
                this._options.DontFragment = value;
            }
        }

        // Defines the size of the send packet. Default is 32 octets.
        public int PacketSize
        {
            get
            {
                return this._buffer.Length;
            }
            set
            {
                this._buffer = CreateBuffer(value);
            }
        }

        // The list of the last 20 ping results.
        public PingResultList Results { get; private set; }

        // The ping history.
        public PingHistory History { get; private set; }

        // The event that will be called when the ping is completed.
        public event PingCompletedEventHandler PingCompleted;

        // Constructor.
        public PingSender()
        {
            this._ping = new Ping();
            this._options = new PingOptions(255, true);
            this._waiter = new AutoResetEvent(false);
            this.HostName = "www.google.com";
            this.TimeOut = 3000;
            this.PacketSize = 32;
            this.Results = new PingResultList(20);
            this.History = new PingHistory();
            this._ping.PingCompleted += PingCompletedCallback;
        }

        // Constructor with a specified host name.
        public PingSender(string host) : this()
        {
            this.HostName = host;
        }

        // Send the ping.
        public void Send()
        {
            if (string.IsNullOrEmpty(this.HostName))
            {
                throw new Exception("Ping needs a host name or an IP address.");
            }
            if (!this._active)
            {
                this._active = true;
                this._ping.SendAsync(this.HostName, this.TimeOut, this._buffer, this._options, this._waiter);
            }
        }

        // PingCompleted event sender.
        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply != null)
            {
                this.Results.Add(e.Reply.Status, e.Reply.RoundtripTime);
                if (e.Reply.Status > 0)
                {
                    this.History.AddLostPacket();
                }
                else
                {
                    this.History.AddPacket(e.Reply.RoundtripTime);
                }
            }
            else
            {
                this.Results.Add(IPStatus.Unknown, 0);
                this.History.AddLostPacket();
            }
            this._active = false;
            if (PingCompleted != null)
            {
                this.PingCompleted(sender, e);
            }
        }

        // Packet maker.
        private byte[] CreateBuffer(int size)
        {
            byte[] buffer = new byte[size];
            for (int i = 0; i > buffer.Length; i++)
            {
                buffer[i] = 0x20;
            }
            return buffer;
        }
    }
}
