using SMILtest.entitites;
using SMILtest.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILtest.forms
{
    public partial class SmilResultForm : Form
    {
        private SMILTestForm prevForm;
        private Dictionary<string, int> results;
        private Person person;
        public SmilResultForm(SMILTestForm prevForm, Dictionary<string, int> results, string name, int age, string sex)
        {
            InitializeComponent();

            this.prevForm = prevForm;
            this.results = results;

            person = new Person(name, age, sex);

            StringBuilder stringBuilder = new StringBuilder();

            int FK = results["F"] - results["K"];
            if (FK < -6 || FK > 6)
            {
                stringBuilder.Append("Во время прохождения теста Вы были неоткровенны!\n");
            }

            stringBuilder.Append($"Имя : {name}\nВозраст: {age} \nПол: {sex}\nРезультаты:\n");
            //metroButton4.Enabled = false;

            foreach (KeyValuePair<string, int> bu in results)
            {
                stringBuilder.Append(bu.Key + " : " + bu.Value + " \n");
            }
            mainLabel.Text = stringBuilder.ToString();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            prevForm.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            prevForm.Clear();
            prevForm.Show();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form form1 = Application.OpenForms["MainForm"];
            this.Close();
            form1.Show();
        }

        private void SmilResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form1 = Application.OpenForms["MainForm"];
            form1.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            FileEditor.loadShortFileSMIL(person.Name, person.Age.ToString(), person.Sex,
              DateTime.Now.ToShortDateString(), results["F"], results["L"],
              results["K"], results["Hs"], results["D"], results["Hy"], results["Ma"],
              results["Mf"], results["Pa"], results["Pt"], results["Si"], results["Sc"], results["Pd"]
              );
        }
    }
}
