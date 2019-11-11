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

namespace SMILtest.forms.resultForms
{
    public partial class OnpdResultForm : Form
    {
        ONPDTestForm formTest;
        Person person;
        Dictionary<string, int> results;
        List<int> boolResults;
        public OnpdResultForm(ONPDTestForm formTest, Person person, Dictionary<string, int> results, List<int> boolResults)
        {
            InitializeComponent();
            this.formTest = formTest;
            this.person = person;
            this.results = results;
            this.boolResults = boolResults;

            metroLabel1.Text = "Результат для " + person.Name + ":";
            metroLabel2.Text = "1 = " + results["First"] + " (Шкала соматического благополучия)";
            metroLabel3.Text = "2 = " + results["Second"] + " (Шкала психического благополучия)";
            metroLabel4.Text = "Д = " + results["D"] + " (Шкала депрессии)";
            metroLabel5.Text = "А = " + results["A"] + " (Шкала астении)";
            metroLabel6.Text = "ДР = " + results["DP"] + " (Шкала психического дискомфорта)";
            metroLabel7.Text = "1 + 2 = " + (results["First"] + results["Second"]);
            metroLabel8.Text = "Д + А + ДР = " + (results["D"] + results["A"] + results["DP"]);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            FileEditor.loadFile(person.Name, person.Age.ToString(), person.Sex,
               DateTime.Now.ToShortDateString(), boolResults, results["First"], results["Second"],
               results["A"], results["D"], results["DP"]);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            formTest.clearData();
            formTest.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form form1 = Application.OpenForms["MainForm"];
            this.Close();
            form1.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            FileEditor.loadShortFile(person.Name, person.Age.ToString(), person.Sex,
               DateTime.Now.ToShortDateString(), results["First"], results["Second"],
               results["A"], results["D"], results["DP"]);
        }

        private void OnpdResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form1 = Application.OpenForms["MainForm"];
            form1.Show();
        }
    }
}
