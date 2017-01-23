using System;
using System.Drawing;
using System.Windows.Forms;
using MediEL;

namespace MediClient
{
	public partial class AlertOnRedClick : Form
    {
        public AlertOnRedClick()
        {
            InitializeComponent();
        }

        private void AlertOnRedClick_Load(object sender, EventArgs e)
        {
            Clients clt = new Preferences().GetLatestClient();
            label1.Text += clt.ClientName;
           
            label2.Text = clt.AlertMessage;
            label3.Text = DateTime.Now.ToShortTimeString().ToString() + " - " + DateTime.Now.ToShortDateString();
            label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
            label2.Location = new Point((this.Width - label2.Width) / 2, label2.Location.Y);
            label3.Location = new Point((this.Width - label3.Width) / 2, label3.Location.Y);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
