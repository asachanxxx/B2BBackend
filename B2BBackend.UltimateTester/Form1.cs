using B2BService.Domain.Log;
using B2BService.Repository.LogRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2BBackend.UltimateTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_checklog_Click(object sender, EventArgs e)
        {
            var log = new Log
            {
                CLIENT_IP = "192.168.1.150",
                CLIENT_PORT = "1528",
                CPU_TIME = DateTime.Now,
                LOG_DATE = DateTime.Now,
                MESSAGE = "First message from log system",
                STACK_TRACE = "",
                USER_ID = "52407f97-97b7-4dea-a550-8465bf811ec2"
            };

            LogRepository logrepo = new LogRepository();
            logrepo.AddLogEntry(log);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LogRepository log = new B2BService.Repository.LogRepositories.LogRepository();
            //log.AddLogEntry("192.168.1.150", "Client Name", "Message", "stcak Trace", "52407f97-97b7-4dea-a550-8465bf811ec2");
        }
    }
}
