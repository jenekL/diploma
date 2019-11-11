using SMILtest.db;
using SMILtest.entitites;
using SMILtest.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILtest.forms
{
    public partial class RecordsShowForm : Form
    {
        private Form prevForm;
        private List<Panel> panelPages = new List<Panel>();
        private int currentPage = 1;

        public RecordsShowForm()
        {
            InitializeComponent();
            loadPictureBox.Image = new Bitmap(@"res/images/big_snale_loader.gif");
            loadPictureBox.Visible = false;
            ONPDRadioButton.Font = MetroFramework.MetroFonts.Label(MetroFramework.MetroLabelSize.Medium, MetroFramework.MetroLabelWeight.Bold);
        }

        public RecordsShowForm(Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;

            textBoxName.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            buttonShowFilter.Enabled = false;
        }

        private void FormRecordsShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            prevForm.Show();
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            GetRecords(() => SMILRepo.GetAllRecords(), () => ONPDRepo.LoadRecords());

            //try
            //{
            //    Thread thread = new Thread(()=>PlaceAllRecords(rows));
            //    thread.Start();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //dataGridView1.Rows.Clear();

            // var rows = DataBase.LoadRecords();

            //LoadDataGridView(rows);

        }

        private void GetRecords(Func<List<RecordsSmil>> funcSMIL, Func<List<RecordsOnpd>> funcONPD)
        {
            splitContainer1.Panel2.Controls.Clear();
            panelPages.Clear();


            if (SMILRadioButton.Checked)
            {
                var rows = funcSMIL.Invoke();

                if (rows.Count > 0)
                {
                    curPageLabel.Text = "1";
                    PlaceSMILRecords(rows);
                }
                else
                {
                    curPageLabel.Text = "0";
                    LastPageLabel.Text = "0";
                    MessageBox.Show("Нет записей");
                }
            }
            else
            {
                var rows = funcONPD.Invoke();

                if (rows.Count > 0)
                {
                    curPageLabel.Text = "1";
                    PlaceONPDRecords(rows);
                }
                else
                {
                    curPageLabel.Text = "0";
                    LastPageLabel.Text = "0";
                    MessageBox.Show("Нет записей");
                }
            }
        }

        private void PlaceSMILRecords(List<RecordsSmil> records)
        {
            int x = 30;
            int y = 20;
            int counter = 0;

            loadPictureBox.Visible = true;

            Panel panelPage = new Panel
            {
                AutoScroll = true,
                AutoSize = true,
                Visible = false
            };
            //splitContainer1.Panel2.Invoke(new Action(()=>splitContainer1.Panel2.Controls.Add(panelPage)));
            splitContainer1.Panel2.Controls.Add(panelPage);


            foreach (RecordsSmil record in records)
            {
                var person = SMILRepo.GetPersonById(record.Person_id);

                Panel panel = new Panel
                {
                    Location = new Point(x, y),
                    Width = splitContainer1.Panel2.Width,
                    Height = 65,
                    BackColor = Color.LightGray,
                    ForeColor = Color.LightGray
                };


                PictureBox picture = new PictureBox
                {
                    Location = new Point(10, 8),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = new Bitmap(@"res/images/person.png")
                };

                MetroFramework.Controls.MetroLabel nameLabel = new MetroFramework.Controls.MetroLabel
                {
                    Location = new Point(51, 8),
                    Text = person.Name,
                    AutoSize = true,
                    CustomBackground = true
                };
                MetroFramework.Controls.MetroLabel dateLabel = new MetroFramework.Controls.MetroLabel
                {
                    Location = new Point(51, 38),
                    Text = record.Date,
                    AutoSize = true,
                    CustomBackground = true
                };
                MetroFramework.Controls.MetroLabel testNameLabel = new MetroFramework.Controls.MetroLabel
                {
                    Location = new Point(dateLabel.Width + 70, 38),
                    Text = "Тест СМИЛ",
                    AutoSize = true,
                    CustomBackground = true
                };
                MetroFramework.Controls.MetroButton resultButton = new MetroFramework.Controls.MetroButton
                {
                    Location = new Point(278, 8),
                    Text = "Результат",
                    Size = new Size(123, 49)
                };
                resultButton.Click += (object sender, EventArgs e) =>
                {
                    MessageBox.Show(record.ToString());
                };
                MetroFramework.Controls.MetroButton printButton = new MetroFramework.Controls.MetroButton
                {
                    Location = new Point(407, 8),
                    Text = "Печать",
                    Size = new Size(123, 49)
                };
                printButton.Click += (object sender, EventArgs e) =>
                {
                    FileEditor.loadShortFileSMIL(person.Name, person.Age.ToString(), person.Sex,
                            DateTime.Now.ToShortDateString(), record.F, record.L,
                            record.K, record.Hs, record.D, record.Hy, record.Ma,
                             record.Mf, record.Pa, record.Pt, record.Si, record.Sc, record.Pd
                    );
                };
                panel.Controls.AddRange(new Control[] { nameLabel, dateLabel, testNameLabel, resultButton, printButton, picture });

                panelPage.Controls.Add(panel);
                //panelPage.Invoke(new Action<Panel>((panel1) => panelPage.Controls.Add(panel1)), panel);

                y += 75;
                counter++;
                if (counter % 30 == 0)
                {
                    panelPages.Add(panelPage);
                    panelPage = new Panel
                    {
                        AutoScroll = true,
                        AutoSize = true,
                        Visible = false
                    };
                    y = 20;
                    counter = 0;
                }
            }
            panelPages.Add(panelPage);
            //splitContainer1.Panel2.Invoke(new Action(() => splitContainer1.Panel2.Controls.Add(panelPage)));
            splitContainer1.Panel2.Controls.Add(panelPage);

            LastPageLabel.Text = panelPages.Count.ToString();
            loadPictureBox.Visible = false;
            foreach (Panel page in panelPages)
            {
                page.Visible = true;
            }
        }
        private void PlaceONPDRecords(List<RecordsOnpd> records)
        {
            int x = 30;
            int y = 20;
            int counter = 0;

            loadPictureBox.Visible = true;

            Panel panelPage = new Panel
            {
                AutoScroll = true,
                AutoSize = true,
                Visible = false
            };
            //splitContainer1.Panel2.Invoke(new Action(()=>splitContainer1.Panel2.Controls.Add(panelPage)));
            splitContainer1.Panel2.Controls.Add(panelPage);


            foreach (RecordsOnpd record in records)
            {
                Panel panel = new Panel
                {
                    Location = new Point(x, y),
                    Width = splitContainer1.Panel2.Width,
                    Height = 65,
                    BackColor = Color.LightGray,
                    ForeColor = Color.LightGray

                };


                PictureBox picture = new PictureBox();
                picture.Location = new Point(10, 8);
                picture.Size = new Size(35, 35);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Image = new Bitmap(@"res/images/person.png");

                var person = ONPDRepo.GetPersonById(record.Person_id);

                MetroFramework.Controls.MetroLabel nameLabel = new MetroFramework.Controls.MetroLabel
                {
                    Location = new Point(51, 8),
                    Text = person.Name,
                    AutoSize = true,
                    CustomBackground = true
                };
                MetroFramework.Controls.MetroLabel dateLabel = new MetroFramework.Controls.MetroLabel
                {
                    Location = new Point(51, 38),
                    Text = record.Date,
                    AutoSize = true,
                    CustomBackground = true

                };
                MetroFramework.Controls.MetroLabel testNameLabel = new MetroFramework.Controls.MetroLabel
                {
                    Location = new Point(dateLabel.Width + 70, 38),
                    Text = "Тест ОНПД",
                    AutoSize = true,
                    CustomBackground = true

                };
                MetroFramework.Controls.MetroButton resultButton = new MetroFramework.Controls.MetroButton
                {
                    Location = new Point(278, 8),
                    Text = "Результат",
                    Size = new Size(123, 49)
                };
                resultButton.Click += (object sender, EventArgs e) =>
                {
                    MessageBox.Show(record.ToString());
                };
                MetroFramework.Controls.MetroButton printButton = new MetroFramework.Controls.MetroButton
                {
                    Location = new Point(407, 8),
                    Text = "Печать",
                    Size = new Size(123, 49)
                };
                printButton.Click += (object sender, EventArgs e) =>
                {
                    FileEditor.loadShortFile(person.Name, person.Age.ToString(), person.Sex,
                                                record.Date, record.First, record.Second,
                                                record.A, record.D, record.DP);
                };
                panel.Controls.AddRange(new Control[] { nameLabel, dateLabel, testNameLabel, resultButton, printButton, picture });

                panelPage.Controls.Add(panel);
                //panelPage.Invoke(new Action<Panel>((panel1) => panelPage.Controls.Add(panel1)), panel);

                y += 75;
                counter++;
                if (counter % 30 == 0)
                {
                    panelPages.Add(panelPage);
                    panelPage = new Panel
                    {
                        AutoScroll = true,
                        AutoSize = true,
                        Visible = false
                    };
                    y = 20;
                    counter = 0;
                }
            }
            panelPages.Add(panelPage);
            //splitContainer1.Panel2.Invoke(new Action(() => splitContainer1.Panel2.Controls.Add(panelPage)));
            splitContainer1.Panel2.Controls.Add(panelPage);

            LastPageLabel.Text = panelPages.Count.ToString();
            loadPictureBox.Visible = false;
            foreach (Panel page in panelPages)
            {
                page.Visible = true;
            }
        }



        private void buttonShowFilter_Click(object sender, EventArgs e)
        {

            if (checkBoxName.Checked && checkBoxDate.Checked)
            {
                GetRecords(
                    () => SMILRepo.GetRecordsByNameAndDate(textBoxName.Text, dateTimePicker1.Value.ToShortDateString()),
                    () => ONPDRepo.GetRecordsByNameAndDate(textBoxName.Text, dateTimePicker1.Value.ToShortDateString())
                );

            }
            else
            {
                if (checkBoxName.Checked && !checkBoxDate.Checked)
                {
                    GetRecords(
                        () => SMILRepo.GetRecordsByName(textBoxName.Text),
                        () => ONPDRepo.GetRecordsByName(textBoxName.Text)
                    );

                }
                else
                {
                    if (!checkBoxName.Checked && checkBoxDate.Checked)
                    {
                        GetRecords(
                            () => SMILRepo.GetRecordsByDate(dateTimePicker1.Value.ToShortDateString()),
                            () => ONPDRepo.GetRecordsByDate(dateTimePicker1.Value.ToShortDateString())
                        );

                    }
                }
            }



        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
            {
                textBoxName.ReadOnly = false;
                buttonShowFilter.Enabled = true;
            }
            else
            {
                textBoxName.ReadOnly = true;
                if (!checkBoxDate.Checked)
                {
                    buttonShowFilter.Enabled = false;
                }
            }
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
            {
                dateTimePicker1.Enabled = true;
                buttonShowFilter.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                if (!checkBoxName.Checked)
                {
                    buttonShowFilter.Enabled = false;
                }

            }
        }

        private void RecordsShowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            prevForm.Show();
        }
        
        private void RecordsShowForm_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.Width = this.Width;

            //foreach (Panel page in panelPages)
            //{
            //    foreach(Panel panel in page.Controls)
            //    {
            //        panel.Width = this.Width - splitContainer1.Panel1.Width;
            //    }
            //}
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                panelPages[currentPage - 1].Hide();
                currentPage--;
                curPageLabel.Text = currentPage.ToString();
                panelPages[currentPage - 1].Show();
            }
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            if (currentPage < panelPages.Count)
            {
                panelPages[currentPage - 1].Hide();
                currentPage++;
                curPageLabel.Text = currentPage.ToString();
                panelPages[currentPage - 1].Show();
            }
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
