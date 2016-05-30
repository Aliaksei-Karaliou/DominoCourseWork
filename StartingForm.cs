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
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void localButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form = new Form1(GameType.Local);
            form.ShowDialog();
            Close();
        }

        private void onlineButton_Click(object sender, EventArgs e)
        {
            Hide();
            OnlineForm form = new OnlineForm();
            form.ShowDialog();
            Close();
        }
    }
}
