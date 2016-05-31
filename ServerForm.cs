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
            Buffer.Listener = new TcpListener(IPAddress.Any, (int)PortUpDown.Value);
            try
            {
                Clipboard.SetText(IPTextBox.Text);
                Buffer.Listener.Start();
                Buffer.Client = Buffer.Listener.AcceptTcpClient();
                //Console.WriteLine(Buffer.Client.Connected);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Hide();
            Form1 form = new Form1(GameType.Server);
            form.ShowDialog();
            Close();
            /* Reader = new StreamReader(Client.GetStream());
             Writer = new StreamWriter(Client.GetStream());
             Writer.AutoFlush = true;
             ReceiveDataBW.RunWorkerAsync();//ReceiveData
             SendDataBW.WorkerSupportsCancellation = true;
             (this as Form).Text = "Server";*/
        }
    }
}
