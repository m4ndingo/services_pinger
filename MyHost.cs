using System.Collections.Generic;

namespace Pinger
{
    public class MyHost
    {
        public string hostname { get; internal set; }
        public List<MyHostService> services { get; internal set; }
        public MyHost()
        {
            this.services = new List<MyHostService>();
        }

        internal void Ping()
        {
            foreach(MyHostService hs in services)
            {
                hs.Ping();
            }
        }

        internal void AddService(int port, string description, ServiceConfig sc)
        {
            this.services.Add(new MyHostService(hostname, port, description, sc));
        }
    }
}
