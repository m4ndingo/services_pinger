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

namespace Pinger
{
    public partial class Form1 : Form
    {
        private List<MyHost> all_hosts = new List<MyHost>();
        private Thread refreshThread = null;
        public Form1()
        {
            InitializeComponent();
            LoadHostsAndServices();
        }

        private void LoadHostsAndServices()
        {
            string run_ssh_cmd = "ssh mandi@10.144.43.253 -L 9200:localhost:9200 -L 5601:localhost:5601 -L 9000:localhost:9000  -L 23080:localhost:23080";
            
            NewHostService("cyber3", 5601, "Kibana");
            NewHostService("cyber3", 9000, "Portainer");
            NewHostService("cyber3", 20, "SSH", new ServiceConfig() { hide_button = true });

            NewHostService("188.40.66.121", 22, "SSH", new ServiceConfig()
            {
                closed_tip = "Restart Server on Hetzner",
                closed_cmd = "https://accounts.hetzner.com/login",
                closed_instructions = new string[] { "Open Hetznet URL", "Go to: robot > server > open cyber-lab > reset", "Execute an authomatic hardware reset" }
            });
            NewHostService("188.40.66.121", 8080, "Kolide Fleet (PortFortward->23080)", new ServiceConfig()
            {
                closed_tip = "Start containers && Run portforward.sh at host",
                closed_cmd = run_ssh_cmd,
                closed_url = "http://localhost:9000/#/containers",
                closed_instructions = new string[] { "Run ssh command", "Go to http://localhost:9000/#/containers", "Init ELK", "Run portforward at host when ELK is ready" },
                ssl = true
            }) ;

            NewHostService("localhost", 5602, "Kibana", new ServiceConfig() { closed_tip = "Run SSH PortMapping", closed_cmd = run_ssh_cmd });
            NewHostService("localhost", 9201, "Elastic Search", new ServiceConfig() { closed_tip = "Run SSH PortMapping", closed_cmd = run_ssh_cmd, ssl = true });
            NewHostService("localhost", 9443, "Portainer", new ServiceConfig() { closed_tip = "Run SSH PortMapping", closed_cmd = run_ssh_cmd });

            CreateHostsControls();
            UpdateHosts();

            LaunchRefreshThread();
        }

        private void LaunchRefreshThread()
        {
            int elapsed_time = 0;
            int refresh_time = 60 * 15;
            tslabel_waitRefresh.Text = "";
            refreshThread = new Thread(() =>
            {
                while (true)
                {
                    if (Visible)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            tslabel_waitRefresh.Text = string.Format("Refresh in {0}s ...", refresh_time - elapsed_time);
                            elapsed_time++;
                            if (elapsed_time > refresh_time)
                            {
                                tslabel_waitRefresh.Text = "Refreshing services ...";
                                UpdateHosts();
                                elapsed_time = 0;
                            }
                        }));
                    }
                    Thread.Sleep(1000);
                }
            });
            refreshThread.Start();
        }
        private void CreateHostsControls()
        {
            foreach (MyHost host in all_hosts)
            {
                CreateHostControls(host);
            }
        }

        private void NewHostService(string hostname, int port, string description, ServiceConfig sc = null)
        {
            List<MyHost> found = all_hosts.Where(h => h.hostname.Equals(hostname)).ToList();
            MyHost use_host = null;
            if (found.Count == 0)
            {
                use_host = new MyHost();
                use_host.hostname = hostname;
                all_hosts.Add(use_host);
            }
            else
            {
                use_host = found[0];
            }
            use_host.AddService(port, description, sc);
        }

        private void UpdateHosts()
        {
            foreach (MyHost host in all_hosts)
            {
                foreach (MyHostService service in host.services)
                {
                    service.state = "checking";
                    service.control.UpdateControl();
                }
                new Thread(() =>
                {
                    host.Ping();
                    foreach (MyHostService service in host.services)
                    {
                        service.control.Invoke(new MethodInvoker(delegate
                        {
                            service.control.UpdateControl();
                        }));
                    }
                }).Start();
            }
        }

        private void CreateHostControls(MyHost host)
        {
            List<MyHostService> services = host.services.OrderBy(s => s.port).Reverse().ToList();
            foreach (MyHostService service in services)
            {
                service.control = new HostStatusControl();
                service.control.Dock = DockStyle.Top;
                service.control.service = service;
                service.image_list = imageList1;
                service.control.UpdateControl();
                panel1.Controls.Add(service.control);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateHosts();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshThread.Abort();
        }
    }
}
