using SMILtest.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILtest.elements
{
    class QuestionElement
    {
        private CheckBox cb1;
        private CheckBox cb2;
        private Label label;
        private ErrorProvider errorProvider;
        private int ind;

        public QuestionElement(CheckBox cb1, CheckBox cb2, Label label, ErrorProvider errorProvider, int ind)
        {

            this.cb1 = cb1;
            this.cb2 = cb2;
            this.label = label;
            ErrorProvider = errorProvider;
            this.ind = ind;

            cb1.Click += Cb1_Click;
            cb2.Click += Cb2_Click;

            cb1.CheckedChanged += Cb_CheckedChanged;
            cb2.CheckedChanged += Cb_CheckedChanged;

        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (errorProvider.GetError(label) != String.Empty)
            {
                errorProvider.SetError(label, String.Empty);
            }
        }

        private void Cb2_Click(object sender, EventArgs e)
        {
            if (cb1.Checked)
            {
                cb1.Checked = false;
            }
            SMILRepo.SaveTemporaryAnswer(0, ind, "smil", 1);
            // throw new NotImplementedException();
        }

        private void Cb1_Click(object sender, EventArgs e)
        {
            if (cb2.Checked)
            {
                cb2.Checked = false;
            }
            SMILRepo.SaveTemporaryAnswer(1, ind, "smil", 1);
            // throw new NotImplementedException();
        }

        public bool IsChecked() { return cb1.Checked || cb2.Checked; }

        public CheckBox Cb1 { get => cb1; set => cb1 = value; }
        public CheckBox Cb2 { get => cb2; set => cb2 = value; }
        public Label Label { get => label; set => label = value; }
        public ErrorProvider ErrorProvider { get => errorProvider; set => errorProvider = value; }
        public int Ind { get => ind; set => ind = value; }
    }
}
