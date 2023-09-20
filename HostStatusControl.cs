using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinger
{
    public partial class HostStatusControl : UserControl
    {
        public HostStatusControl()
        {
            InitializeComponent();
        }

        internal MyHostService service { get; set; }

        internal void UpdateControl()
        {
            lblHostPort.Text = string.Format("{0}:{1}", service.address, service.port);
            lblStatus.Text = service.state;
            lblDescription.Text = service.description;
            lblLastCheckDate.Text = service.lastcheck_date.ToString();
            btnOpen.Visible = service.sc != null && service.sc.hide_button.Equals(true) ? false : true;
            switch (service.state)
            {
                case "closed":
                    pictureBox1.Image = service.image_list.Images[1];
                    if (service.sc != null && service.sc.closed_cmd != null)
                    {
                        lblStatus.Text = service.sc.closed_tip;                        
                        btnOpen.Text = "Copy cmd";
                        if(service.sc.closed_cmd.StartsWith("http"))
                            btnOpen.Text = "Open URL";
                        SetTooltip(btnOpen, service.sc.closed_cmd);
                    }
                    break;
                case "open":
                    pictureBox1.Image = service.image_list.Images[2];
                    btnOpen.Text = "Open";
                    SetTooltip(btnOpen, null);
                    break;
                case "checking":
                    break;
                default:
                    pictureBox1.Image = service.image_list.Images[0];
                    break;
            }
        }
        Dictionary<Button, ToolTip> tooltips = new Dictionary<Button, ToolTip>();
        private void SetTooltip(Button button, string text)
        {
            ToolTip use_tooltip = null;
            if (tooltips.ContainsKey(button))
            {
                use_tooltip = tooltips[button];
            }
            else
            {
                use_tooltip = new ToolTip();
                tooltips[button] = use_tooltip;
            }
            use_tooltip.SetToolTip(button, text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text.Equals("Copy cmd"))
                CopyCmdToClipboard();

            if (service.sc == null)
            {
                if (service.state.Equals("closed"))
                {
                    if (service.sc.closed_instructions != null)
                        MessageBox.Show(string.Join(Environment.NewLine, service.sc.closed_instructions), "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (service.sc.closed_url != null)
                    {
                        Process.Start(service.sc.closed_url);
                        return;
                    }
                }
                if (btnOpen.Text.Equals("Open URL"))
                {
                    Process.Start(service.sc.closed_cmd);
                    return;
                }
            }
            bool ssl = false;
            if (service.sc != null)
                ssl = service.sc.ssl;
            string code = "open http" + (ssl ? "s" : "") + "://[hostname]:[port]";

            code = code.Replace("[hostname]", service.address);
            code = code.Replace("[port]", service.port.ToString());
            string []args = code.Split(' ');
            switch (args[0])
            {
                case "open":
                    Process.Start(args[1]);
                    break;
                default:
                    MessageBox.Show(code);
                    break;
            }
        }

        private void CopyCmdToClipboard()
        {
            MessageBox.Show("Command:" + Environment.NewLine + Environment.NewLine + this.service.sc.closed_cmd, "Copied to Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(this.service.sc.closed_cmd);
        }
    }
}
