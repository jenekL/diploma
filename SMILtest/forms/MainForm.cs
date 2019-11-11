using SMILtest.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SMILtest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
                     

            //pictureBox1.Image = Image.FromFile("./res/images/big_snale_loader.gif");
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            RecordsShowForm recordsShowForm = new RecordsShowForm(this);
            this.Hide();
            recordsShowForm.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            ONPDTestForm oNPDTestForm = new ONPDTestForm();
            this.Hide();
            oNPDTestForm.Show();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            SMILTestForm smiltest = new SMILTestForm();
            this.Hide();
            smiltest.Show();
        }
    }
}
