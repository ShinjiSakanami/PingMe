using System.Net.NetworkInformation;
using System.Threading;

namespace PingMe.Console
{
    class Program
    {
        static PingSender pingSender;
        static int pingCount;

        static void Main(string[] args)
        {
            pingSender = new PingSender();
            
            pingSender.HostName = "www.google.com";
            pingSender.PingCompleted += PingSender_PingCompleted;
            Log("Start ping test");
            Log();
            SendPings(4);
            WaitForInput();
        }

        private static void SendPings(int count)
        {
            do
            {
                pingSender.Send();
                Thread.Sleep(1000);
            } while (pingCount <= count);
            PingDone();
        }

        private static void PingDone()
        {
            PingResultList results = pingSender.Results;
            Log();
            Log("Statistiques Ping pour " + pingSender.HostName + ":");
            Log("    Paquets : envoyés = " + results.SendPackets + ", reçus = " + results.ReceivedPackets + ", perdus = " + results.LostPackets + " (perte " + results.LostPacketsRatio + "%)");
            Log("Durée approximative des boucles en millisecondes :");
            Log("    Minimum = " + results.TimeMin + "ms, Maximum = " + results.TimeMax + "ms, Moyenne = " + results.TimeAverage + "ms");
        }

        private static void PingSender_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status > 0)
            {
                Log(e.Reply.Status.ToString());
            }
            else
            {
                string host = e.Reply.Address.ToString();
                int size = e.Reply.Buffer.Length;
                long time = e.Reply.RoundtripTime;
                int ttl = e.Reply.Options.Ttl;
                Log("Réponse de " + host + " : octets=" + size + " temps=" + time + "ms TTL=" + ttl);
            }
            pingCount++;
        }

        static void Log(string text = null)
        {
            System.Console.WriteLine(text);
        }

        static void WaitForInput()
        {
            System.Console.ReadLine();
        }
    }
}
