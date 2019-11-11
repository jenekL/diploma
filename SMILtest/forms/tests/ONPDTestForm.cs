using SMILtest.db;
using SMILtest.elements;
using SMILtest.entitites;
using SMILtest.forms.resultForms;
using SMILtest.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILtest.forms
{
    public partial class ONPDTestForm : Form
    {
        private OnpdResultForm formResult;
        private List<QuestionElement> panelElements = new List<QuestionElement>();
        private ErrorProvider NameErrorProvider;

        public ONPDTestForm()
        {
            InitializeComponent();

            this.AutoScroll = true;

            nameTextBox.TextChanged += NameTextBox_TextChanged;

            labelDescription.Text = FileReader.readFileInLine("res/text/description.txt");


            setQuestions();

            genderCheckBox1.Click += (object sender, EventArgs e) =>
            {
                if (genderCheckBox2.Checked)
                {
                    genderCheckBox2.Checked = false;
                }
            };
            genderCheckBox2.Click += (object sender, EventArgs e) =>
            {
                if (genderCheckBox1.Checked)
                {
                    genderCheckBox1.Checked = false;
                }
            };

            foreach (Control control in this.Controls.OfType<Control>().ToList())
            {
                control.Font = new Font("Arial", 9, FontStyle.Regular);
            }


            NameErrorProvider = new System.Windows.Forms.ErrorProvider();
            NameErrorProvider.SetIconAlignment(nameTextBox, ErrorIconAlignment.TopRight);
            NameErrorProvider.SetIconPadding(nameTextBox, 2);
            NameErrorProvider.BlinkRate = 800;
            NameErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            //NameErrorProvider.Icon = new Icon("res/icons/icon-alert2.ico");
        }

        private void setQuestions()
        {
            List<string> questions = ONPDRepo.GetQuestions();
            int y = genderCheckBox1.Bottom + 60;
            int x = 30;

            for (int i = 0; i < 30; i++)
            {
                CheckBox cb1 = new CheckBox();
                CheckBox cb2 = new CheckBox();
                MaterialSkin.Controls.MaterialLabel label = new MaterialSkin.Controls.MaterialLabel();
                ErrorProvider errorProvider = new ErrorProvider();

                errorProvider.SetIconAlignment(label, ErrorIconAlignment.TopLeft);
                errorProvider.SetIconPadding(label, 2);
                errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
                //errorProvider.Icon = new Icon("res/icons/icon-alert2.ico");

                label.Location = new System.Drawing.Point(x, y);
                label.Text = questions[i].Substring(1, questions[i].Length - 2);
                label.AutoSize = true;

                cb1.Location = new System.Drawing.Point(x + 20, y + 20);
                cb1.Text = "Да";
                cb1.Font = new Font("Segoe UI", 9);
                cb2.Location = new System.Drawing.Point(x + 130, y + 20);
                cb2.Text = "Нет";
                cb2.Font = new Font("Segoe UI", 9);

                this.Controls.AddRange(new System.Windows.Forms.Control[] { label, cb1, cb2 });

                panelElements.Add(new QuestionElement(cb1, cb2, label, errorProvider, i));
                y += 80;
            }

            Button button = new Button
            {
                Text = "Завершить",
                Location = new Point(x + 150, y),
                AutoSize = true
            };
            button.Click += (object sender, EventArgs e) =>
            {
                endTest();
            };
            this.Controls.Add(button);
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(nameTextBox.Text, @"[а-яА-Яa-zA-Z]"))
            {
                NameErrorProvider.SetError(nameTextBox, "Проверьте корректность ввода");
            }
            else
            {
                NameErrorProvider.SetError(nameTextBox, String.Empty);
            }
        }

        public void clearData()
        {
            foreach (QuestionElement panels in panelElements)
            {
                panels.Cb1.Checked = false;
                panels.Cb2.Checked = false;
            }

            ageTextBox.Text = "";
            nameTextBox.Text = "";
            genderCheckBox1.Checked = false;
            genderCheckBox2.Checked = false;
        }

        private void endTest()
        {
            if (!checkAll())
            {
                MessageBox.Show("Вы ответили не на все вопросы");
            }
            else
            {
                Person person = new Person(nameTextBox.Text, int.Parse(ageTextBox.Text), getSex());
                var results = ONPDPointCalculator.GetResult(panelElements);
                SaveResults(person, results);
                
                SelectNextControl(nameTextBox, true, true, true, true);
                formResult = new OnpdResultForm(this, person, results, ONPDPointCalculator.GetResultsBoolean(panelElements));
                this.Hide();
                formResult.Show();

            }
        }

        private void SaveResults(Person person, Dictionary<string, int> results)
        {
            ONPDRepo.SavePerson(person);
            ONPDRepo.SaveRecord(new RecordsOnpd(
                ONPDRepo.GetLastPerson(),
                results["A"],
                results["D"],
                results["DP"],
                results["First"],
                results["Second"],
                DateTime.Now.ToString()
                ));
        }

        private string getSex()
        {
            if (genderCheckBox1.Checked)
            {
                return "Мужской";
            }
            else
            {
                return "Женский";
            }
        }

        private bool checkAll()
        {
            bool end = true;
            foreach (QuestionElement panelElement in panelElements)
            {
                if (!panelElement.IsChecked())
                {
                    panelElement.ErrorProvider.SetError(panelElement.Label, "Нет ответа");
                    end = false;
                }
            }
            if (nameTextBox.Text == string.Empty)
            {
                end = false;
            }
            return end;

        }

        private void ONPDTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form1 = Application.OpenForms["MainForm"];
            form1.Show();
        }
    }
}
