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
    }
}
