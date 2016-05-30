using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoCourseWork
{
    public partial class OnlineForm : Form
    {
        public OnlineForm()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            StartingForm form = new StartingForm();
            form.ShowDialog();
            Close();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            Hide();
            ServerForm form = new ServerForm();
            form.ShowDialog();
            Close();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Hide();
            ClientForm form = new ClientForm();
            form.ShowDialog();
            Close();
        }
    }
}
