using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.NetworkInformation;

namespace markform
{
    public partial class network_pingl : UserControl
    {
        CustomClass cf = new CustomClass();

        public network_pingl()
        {
            InitializeComponent();
        }

        private async void PingSvr()
        {
            try
            {
                await Task.Run(()=> {
                    string host = "accomediasvr";
                    Ping pingreq = new Ping();
                    PingReply pingrep = pingreq.Send(host);
                    long res = pingrep.RoundtripTime;
                    Color txtColor;
                    if (res >= 0 && res <= 100)
                    {
                        txtColor = Color.DarkGreen;
                    }
                    else if (res > 100 && res <= 200)
                    {
                        txtColor = Color.DarkGoldenrod;
                    }
                    else if (res > 200 && res <= 300)
                    {
                        txtColor = Color.OrangeRed;
                    }
                    else
                    {
                        txtColor = Color.DarkRed;
                    }
                    lbl_ping.Text = res.ToString() + "ms";
                    lbl_ping.ForeColor = txtColor;
                });
            }
            catch (Exception ex)
            {
                lbl_ping.Text = "Error";
                lbl_ping.ForeColor = Color.DarkRed;
                cf.WriteToFile("{0}==>" + ex.ToString(), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
            }

        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            PingSvr();
        }
    }
}
