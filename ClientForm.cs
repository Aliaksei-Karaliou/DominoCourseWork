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
         //   try
            {
                Buffer.Listener = new TcpListener(IPAddress.Parse(IPTextBox.Text), (int)PortUpDown.Value);
                Buffer.Listener.Start();
                Hide();
                Form1 form = new Form1(GameType.Client);
                form.ShowDialog();
                Close();
            }
        /*    catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
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
