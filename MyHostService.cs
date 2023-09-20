using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Pinger
{
    public class MyHostService
    {
        public MyHostService(string address_value, int port_value, string description_value, ServiceConfig sc_value)
        {
            address = address_value;
            port = port_value;
            description = description_value;
            sc = sc_value;
            state = "unknown";
        }
        public string address { get; }
        public int port { get; }
        public string description { get; }
        public string state { set; get; }
        public ServiceConfig sc { set; get; }
        public HostStatusControl control { get; internal set; }
        public ImageList image_list { get; internal set; }
        public DateTime lastcheck_date { get; private set; }
        public Byte[] bytes { get; private set; }

        internal void Ping()
        {
            var client = new TcpClient();
            var result = client.BeginConnect(this.address, this.port, null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

            lastcheck_date = DateTime.Now;

            if (!success)
            {
                state = "closed";
                return;
            }
            // puede dar error el EndConnect
            client.EndConnect(result);
            state = "open";
            /*
            bytes = new byte[client.ReceiveBufferSize];
            NetworkStream ns = client.GetStream();
            int i = 0;
            while(ns.DataAvailable && i<bytes.Length)
            {
                bytes[i++] = (byte)ns.ReadByte();
            }
            bytes = bytes.Take(i).ToArray();
            if(bytes.Length>0)
            {

            }*/
        }
    }
}
