using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoCourseWork
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            GetOwnIP();
        }
        private void GetOwnIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in localIP)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPTextBox.Text = ip.ToString();
                }
        
        }



        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            OnlineForm form = new OnlineForm();
            form.ShowDialog();
            Close();
        }
 private void CreateButton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(IPTextBox.Text));
            listener.Start();
            Buffer.Client = listener.AcceptTcpClient();
           /* Reader = new StreamReader(Client.GetStream());
            Writer = new StreamWriter(Client.GetStream());
            Writer.AutoFlush = true;
            ReceiveDataBW.RunWorkerAsync();//ReceiveData
            SendDataBW.WorkerSupportsCancellation = true;
            (this as Form).Text = "Server";*/
        }
    }
}
