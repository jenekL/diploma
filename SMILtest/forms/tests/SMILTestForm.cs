using SMILtest.db;
using SMILtest.elements;
using SMILtest.forms;
using SMILtest.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILtest
{
    public partial class SMILTestForm : Form
    {
        private List<QuestionElement> questionElements = new List<QuestionElement>();
        private int nextTab = 0;
        private int count = 1;
        private bool finished = false;
        private List<Task<TabPage>> tasks = new List<Task<TabPage>>();

        public SMILTestForm()
        {
            InitializeComponent();

            questionsTabControl.Visible = false;

            pictureBox2.Image = Image.FromFile("./res/images/big_snale_loader.gif");
            pictureBox2.Location = new System.Drawing.Point(this.Width / 2, this.Height / 2);

        }

        private async void SMILTestForm_Shown(object sender, EventArgs e)
        {
            await Task.Run(() => LoadQuestions());
        }

        private async void SetQuestions(List<string> questions, Dictionary<int, int> temp = null)
        {

            try
            {
                //if (temp != null)
                //{
                for (int j = 0; j < 566; j += 114)
                {
                    //tasks.Add(Task<TabPage>.Factory.StartNew(()=>SetTabs(questions, temp, j)));
                    await Task.Run(() => SetTabs(questions, temp, j));
                }
                //}
                //else
                //{
                //    SetTabs(questions);

                //    await Task.Run(() =>
                //    {
                //        //Thread thread = new Thread(() => SetTabs(questions, temp, nextTab * 114));
                //        //thread.Start();
                //        SetTabs(questions, temp, nextTab * 114);
                //    });

                //}
            }
            catch (Exception ex)
            {
                //костыль
                //MessageBox.Show(ex.Message);
            }
        }

        private void SetTabs(List<string> questions, Dictionary<int, int> temp = null, int j = 0)
        {
            Random random = new Random();

            int x = 20, y = 20;
            int next = nextTab;

            TabPage tabPage = new TabPage();

            for (int i = j; i < ((j + 114) < 566 ? (j + 114) : 566); i++)
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

                byte[] bytes = Encoding.Default.GetBytes(questions[i]);
                string myString = Encoding.UTF8.GetString(bytes);

                label.Text = count + ". " + myString.Substring(1, myString.Length - 2);
                label.AutoSize = true;

                cb1.Location = new System.Drawing.Point(x + 10, y + 20);
                cb1.Text = "Да";
                cb1.Font = new Font("Segoe UI", 9.0f);

                cb2.Location = new System.Drawing.Point(x + 120, y + 20);
                cb2.Text = "Нет";
                cb2.Font = new Font("Segoe UI", 9.0f);

                if (temp != null)
                {
                    if (temp.ContainsKey(count))
                    {
                        if (temp[count] == 1)
                        {
                            cb1.Checked = true;

                        }
                        else
                        {
                            cb2.Checked = true;

                        }
                    }
                }
                //else
                //{

                //    int number = random.Next(0, 2);
                //    if (number == 0)
                //    {
                //        cb1.Checked = true;

                //    }
                //    else
                //    {
                //        cb2.Checked = true;

                //    }

                //}




                if (questionsTabControl.InvokeRequired)
                {
                    questionsTabControl.Invoke(new Action(() => questionsTabControl.TabPages[nextTab].Controls.AddRange(new System.Windows.Forms.Control[] { label, cb1, cb2 })));
                }
                //tabPage.Controls.AddRange(new System.Windows.Forms.Control[] { label, cb1, cb2 });

                questionElements.Add(new QuestionElement(cb1, cb2, label, errorProvider, count));
                y += 80;
                count++;
            }

            MetroFramework.Controls.MetroButton button = new MetroFramework.Controls.MetroButton
            {
                Location = new System.Drawing.Point(x, y + 10),
                Size = new Size(100, 48),
                Text = "Далее"
            };


            if (questionsTabControl.InvokeRequired)
            {
                questionsTabControl.Invoke(new Action(() => questionsTabControl.TabPages[nextTab].Controls.Add(button)));
            }
            if (nextTab < 4)
            {
                button.Click += (object sender, EventArgs e) =>
                {

                    GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Light;
                    questionsTabControl.SelectedTab = GetTabPage(next + 1);
                    GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Dark;


                };
            }
            else
            {
                button.Text = "Завершить";
                button.Click += (object sender, EventArgs e) =>
                {
                    EndTest();
                };

            }

            GetTabButton(nextTab).Invoke(new Action(() => GetTabButton(nextTab).Enabled = true));

            nextTab++;
        }

        private TabPage GetTabPage(int ind)
        {
            switch (ind)
            {
                case 0:
                    return tabPage6;
                case 1:
                    return tabPage7;
                case 2:
                    return tabPage8;
                case 3:
                    return tabPage9;
                case 4:
                    return tabPage10;
                default:
                    return GetTabPage(ind - 1);
            }
        }

        private MetroFramework.Controls.MetroButton GetTabButton(int ind)
        {
            switch (ind)
            {
                case 0:
                    return metroButton1;
                case 1:
                    return metroButton2;
                case 2:
                    return metroButton3;
                case 3:
                    return metroButton4;
                case 4:
                    return metroButton5;
                default:
                    return GetTabButton(ind - 1);
            }
        }

        private void LoadQuestions()
        {
            var questions = SMILRepo.GetAllQuestions();

            var temp = SMILRepo.GetAllTempAnswers();

            if (temp.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("У вас есть незавершенный тест. Восстановить?", "Незавершенный тест", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    SetQuestions(questions, temp);
                    var person = SMILRepo.GetTempPerson();
                    FIOTextBox.Text = person.Name;
                    ageTextBox.Text = person.Age.ToString();
                    if (person.Sex == "М")
                    {
                        maleGender.Checked = true;
                    }
                    else
                    {
                        femaleGender.Checked = true;
                    }
                }
                else
                {
                    SMILRepo.DeleteTemporaryAnswer("smil");
                    SetQuestions(questions);
                }
            }
            else
            {
                SetQuestions(questions);
            }

            //tabControl1.TabPages.Remove(tabPage1);
            //tabControl1.TabPages.Remove(tabPage2);
            //tabControl1.TabPages.Remove(tabPage3);
            //tabControl1.TabPages.Remove(tabPage4);
            //tabControl1.TabPages.Remove(tabPage5);

            pictureBox2.Invoke(new Action<bool>((s) => pictureBox2.Visible = s), false);
            questionsTabControl.Invoke(new Action<bool>((s) => questionsTabControl.Visible = s), true);
            dataPanel.Invoke(new Action<bool>((s) => dataPanel.Visible = s), true);
        }

        private void SMILTestForm_Load(object sender, EventArgs e)
        {

        }

        private bool CheckAll(out List<int> nums)
        {
            nums = new List<int>();
            bool returnValue = true;
            //TODO errorproviders
            if (ageTextBox.Text.Equals(""))
            {

                returnValue = false;
            }
            if (FIOTextBox.Text.Equals(""))
            {
                returnValue = false;
            }
            if (!maleGender.Checked && !femaleGender.Checked)
            {
                returnValue = false;
            }

            foreach (var qe in questionElements)
            {
                if (!qe.IsChecked())
                {
                    qe.ErrorProvider.SetError(qe.Label, "Нет ответа");
                    nums.Add(qe.Ind);
                    returnValue = false;
                }
            }

            return returnValue;
        }

        public void Clear()
        {
            FIOTextBox.Clear();
            ageTextBox.Clear();
            maleGender.Checked = false;
            femaleGender.Checked = false;

            foreach (var qe in questionElements)
            {
                qe.Cb1.Checked = false;
                qe.Cb2.Checked = false;
            }
        }

        private bool AnyQuestionChecked()
        {
            foreach (var qe in questionElements)
            {
                if (qe.IsChecked())
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EndTest();

        }

        private void EndTest()
        {
            bool value = CheckAll(out List<int> nums);
            if (value)
            {
                var gender = maleGender.Checked ? "М" : "Ж";

                var results = SMILPointCalculator.GetSMILResult(questionElements, gender);
                SmilResultForm resultForm = new SmilResultForm(this, results, FIOTextBox.Text, Int16.Parse(ageTextBox.Text), maleGender.Checked ? "Мужской" : "Женский");
                finished = true;

                SaveResults(results, FIOTextBox.Text, Int16.Parse(ageTextBox.Text), maleGender.Checked ? "Мужской" : "Женский");

                this.Hide();
                resultForm.Show();

            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Заполните все поля и ответьте на все вопросы!");
                if (nums.Count > 0)
                {
                    stringBuilder.Append("\nПропущенные вопросы:\n");
                }
                foreach (int i in nums)
                {
                    stringBuilder.Append($"{i}, ");
                }
                MessageBox.Show(stringBuilder.ToString().Substring(0, stringBuilder.Length - 2));

            }
        }

        private void SaveResults(Dictionary<string, int> results, string name, short age, string sex)
        {
            SMILRepo.AddPerson(name, sex, age);
            SMILRepo.AddSmilResult(
                SMILRepo.GetLastPerson(), results["L"], results["F"], results["K"],
                results["Hs"], results["D"], results["Hy"],
                results["Pd"], results["Mf"], results["Pa"], results["Pt"],
                results["Sc"], results["Ma"], results["Si"]
                );
        }

        private void SMILTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form1 = Application.OpenForms["MainForm"];
            form1.Show();
        }

        private void SMILTestForm_SizeChanged(object sender, EventArgs e)
        {
            questionsTabControl.Width = this.Width - 250;
            questionsTabControl.Height = this.Height - 100;
            pictureBox2.Location = new System.Drawing.Point(this.Width / 2, this.Height / 2);
        }

        private void FIOTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"([0-9])");
            MatchCollection matches = regex.Matches(FIOTextBox.Text);

            if (matches.Count > 0)
            {
                errorProvider1.SetError(FIOTextBox, "Некоректный ввод!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void FIOTextBox_Leave(object sender, EventArgs e)
        {
            SMILRepo.UpdateNameTemporaryUser(FIOTextBox.Text, "smil");
        }

        private void ageTextBox_Leave(object sender, EventArgs e)
        {
            int suc;
            if (Int32.TryParse(ageTextBox.Text, out suc))
            {
                SMILRepo.UpdateAgeTemporaryUser(suc, "smil");
            }
        }

        private void maleGender_CheckedChanged(object sender, EventArgs e)
        {
            if (maleGender.Checked)
            {
                SMILRepo.UpdateGenderTemporaryUser("М", "smil");
            }
        }

        private void femaleGender_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleGender.Checked)
            {
                SMILRepo.UpdateGenderTemporaryUser("Ж", "smil");
            }
        }

        private void SMILTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!finished)
                {
                    if (MessageBox.Show("Тест не пройден. Вы действительно хотите выйти?",
                              "Незавершенный тест",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (AnyQuestionChecked())
                        {
                            if (MessageBox.Show("Сохранить результат, чтобы вернуться к нему потом?",
                                 "Незавершенный тест",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.No)
                            {
                                SMILRepo.DeleteTemporaryAnswer("smil");
                                SMILRepo.DeleteTemporaryClient("smil");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"([A-Za-zА-Яа-я.,])");
            MatchCollection matches = regex.Matches(ageTextBox.Text);

            if (matches.Count > 0)
            {
                errorProvider2.SetError(ageTextBox, "Убедитесь, что введено корректное значение!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Light;
            questionsTabControl.SelectedTab = questionsTabControl.TabPages[0];
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Light;
            questionsTabControl.SelectedTab = questionsTabControl.TabPages[1];
            metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Light;
            questionsTabControl.SelectedTab = questionsTabControl.TabPages[2];
            metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Light;
            questionsTabControl.SelectedTab = questionsTabControl.TabPages[3];
            metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            GetTabButton(questionsTabControl.SelectedIndex).Theme = MetroFramework.MetroThemeStyle.Light;
            questionsTabControl.SelectedTab = questionsTabControl.TabPages[4];
            metroButton5.Theme = MetroFramework.MetroThemeStyle.Dark;
        }
    }
}
