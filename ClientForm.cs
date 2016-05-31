using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoCourseWork
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Buffer.Client = new TcpClient();
            try
            {
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(IPTextBox.Text), (int)PortUpDown.Value);
                Buffer.Client.Connect(IpEnd);
                if (Buffer.Client.Connected)
                {
                    NetworkStream stream = Buffer.Client.GetStream();
                    byte[] buffer = new byte[64];
                    stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(TcpSender.OnRead), buffer);
                    Hide();
                    Form1 form = new Form1(GameType.Client);

                    form.ShowDialog();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            OnlineForm form = new OnlineForm();
            form.ShowDialog();
            Close();
        }
    }
}
