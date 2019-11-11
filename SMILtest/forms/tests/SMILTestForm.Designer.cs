namespace SMILtest
{
    partial class SMILTestForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMILTestForm));
            this.femaleGender = new System.Windows.Forms.RadioButton();
            this.maleGender = new System.Windows.Forms.RadioButton();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.FIOTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.questionsTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.FIOlabel = new MetroFramework.Controls.MetroLabel();
            this.ageLabel = new MetroFramework.Controls.MetroLabel();
            this.genderLabel = new MetroFramework.Controls.MetroLabel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.questionsTabControl.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // femaleGender
            // 
            this.femaleGender.AutoSize = true;
            this.femaleGender.Location = new System.Drawing.Point(99, 133);
            this.femaleGender.Name = "femaleGender";
            this.femaleGender.Size = new System.Drawing.Size(14, 13);
            this.femaleGender.TabIndex = 15;
            this.femaleGender.TabStop = true;
            this.femaleGender.UseVisualStyleBackColor = true;
            this.femaleGender.CheckedChanged += new System.EventHandler(this.femaleGender_CheckedChanged);
            // 
            // maleGender
            // 
            this.maleGender.AutoSize = true;
            this.maleGender.Location = new System.Drawing.Point(15, 133);
            this.maleGender.Name = "maleGender";
            this.maleGender.Size = new System.Drawing.Size(14, 13);
            this.maleGender.TabIndex = 14;
            this.maleGender.TabStop = true;
            this.maleGender.UseVisualStyleBackColor = true;
            this.maleGender.CheckedChanged += new System.EventHandler(this.maleGender_CheckedChanged);
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(15, 80);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(100, 20);
            this.ageTextBox.TabIndex = 11;
            this.ageTextBox.TextChanged += new System.EventHandler(this.ageTextBox_TextChanged);
            this.ageTextBox.Leave += new System.EventHandler(this.ageTextBox_Leave);
            // 
            // FIOTextBox
            // 
            this.FIOTextBox.Location = new System.Drawing.Point(15, 31);
            this.FIOTextBox.Name = "FIOTextBox";
            this.FIOTextBox.Size = new System.Drawing.Size(100, 20);
            this.FIOTextBox.TabIndex = 10;
            this.FIOTextBox.TextChanged += new System.EventHandler(this.FIOTextBox_TextChanged);
            this.FIOTextBox.Leave += new System.EventHandler(this.FIOTextBox_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(56, 335);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // questionsTabControl
            // 
            this.questionsTabControl.Controls.Add(this.tabPage6);
            this.questionsTabControl.Controls.Add(this.tabPage7);
            this.questionsTabControl.Controls.Add(this.tabPage8);
            this.questionsTabControl.Controls.Add(this.tabPage9);
            this.questionsTabControl.Controls.Add(this.tabPage10);
            this.questionsTabControl.Depth = 0;
            this.questionsTabControl.Location = new System.Drawing.Point(215, 46);
            this.questionsTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.questionsTabControl.Name = "questionsTabControl";
            this.questionsTabControl.SelectedIndex = 0;
            this.questionsTabControl.Size = new System.Drawing.Size(583, 404);
            this.questionsTabControl.TabIndex = 20;
            // 
            // tabPage6
            // 
            this.tabPage6.AutoScroll = true;
            this.tabPage6.BackColor = System.Drawing.Color.LightGray;
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(575, 378);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "tabPage6";
            // 
            // tabPage7
            // 
            this.tabPage7.AutoScroll = true;
            this.tabPage7.BackColor = System.Drawing.Color.LightGray;
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(575, 378);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "tabPage7";
            // 
            // tabPage8
            // 
            this.tabPage8.AutoScroll = true;
            this.tabPage8.BackColor = System.Drawing.Color.LightGray;
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(575, 378);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "tabPage8";
            // 
            // tabPage9
            // 
            this.tabPage9.AutoScroll = true;
            this.tabPage9.BackColor = System.Drawing.Color.LightGray;
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(575, 378);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "tabPage9";
            // 
            // tabPage10
            // 
            this.tabPage10.AutoScroll = true;
            this.tabPage10.BackColor = System.Drawing.Color.LightGray;
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(575, 378);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "tabPage10";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(308, 12);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(100, 28);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 21;
            this.metroButton1.Text = "1 - 114";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Enabled = false;
            this.metroButton2.Location = new System.Drawing.Point(414, 12);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(100, 28);
            this.metroButton2.TabIndex = 22;
            this.metroButton2.Text = "115 - 228";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Enabled = false;
            this.metroButton3.Location = new System.Drawing.Point(520, 12);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(100, 28);
            this.metroButton3.TabIndex = 23;
            this.metroButton3.Text = "229 - 342";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Enabled = false;
            this.metroButton4.Location = new System.Drawing.Point(626, 12);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(100, 28);
            this.metroButton4.TabIndex = 24;
            this.metroButton4.Text = "343 - 456";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Enabled = false;
            this.metroButton5.Location = new System.Drawing.Point(732, 12);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(100, 28);
            this.metroButton5.TabIndex = 25;
            this.metroButton5.Text = "457 - 566";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FIOlabel
            // 
            this.FIOlabel.AutoSize = true;
            this.FIOlabel.CustomBackground = true;
            this.FIOlabel.Location = new System.Drawing.Point(15, 9);
            this.FIOlabel.Name = "FIOlabel";
            this.FIOlabel.Size = new System.Drawing.Size(43, 19);
            this.FIOlabel.TabIndex = 26;
            this.FIOlabel.Text = "ФИО:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.CustomBackground = true;
            this.ageLabel.Location = new System.Drawing.Point(15, 58);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(60, 19);
            this.ageLabel.TabIndex = 27;
            this.ageLabel.Text = "Возраст:";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.CustomBackground = true;
            this.genderLabel.Location = new System.Drawing.Point(21, 111);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(36, 19);
            this.genderLabel.TabIndex = 28;
            this.genderLabel.Text = "Пол:";
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(47, 170);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(100, 48);
            this.metroButton6.TabIndex = 29;
            this.metroButton6.Text = "Завершить";
            this.metroButton6.Click += new System.EventHandler(this.button1_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = true;
            this.metroLabel4.Location = new System.Drawing.Point(29, 130);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(64, 19);
            this.metroLabel4.TabIndex = 30;
            this.metroLabel4.Text = "Мужской";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = true;
            this.metroLabel5.Location = new System.Drawing.Point(113, 130);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(64, 19);
            this.metroLabel5.TabIndex = 31;
            this.metroLabel5.Text = "Женский";
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.FIOlabel);
            this.dataPanel.Controls.Add(this.metroLabel5);
            this.dataPanel.Controls.Add(this.ageLabel);
            this.dataPanel.Controls.Add(this.FIOTextBox);
            this.dataPanel.Controls.Add(this.femaleGender);
            this.dataPanel.Controls.Add(this.metroLabel4);
            this.dataPanel.Controls.Add(this.genderLabel);
            this.dataPanel.Controls.Add(this.ageTextBox);
            this.dataPanel.Controls.Add(this.maleGender);
            this.dataPanel.Controls.Add(this.metroButton6);
            this.dataPanel.Location = new System.Drawing.Point(9, 12);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(200, 274);
            this.dataPanel.TabIndex = 0;
            this.dataPanel.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = true;
            this.metroLabel1.Location = new System.Drawing.Point(215, 12);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 19);
            this.metroLabel1.TabIndex = 26;
            this.metroLabel1.Text = "Вопросы №";
            // 
            // SMILTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(995, 450);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.questionsTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMILTestForm";
            this.Text = "Тест СМИЛ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SMILTestForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SMILTestForm_FormClosed);
            this.Load += new System.EventHandler(this.SMILTestForm_Load);
            this.Shown += new System.EventHandler(this.SMILTestForm_Shown);
            this.SizeChanged += new System.EventHandler(this.SMILTestForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.questionsTabControl.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton femaleGender;
        private System.Windows.Forms.RadioButton maleGender;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox FIOTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private MaterialSkin.Controls.MaterialTabControl questionsTabControl;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroLabel genderLabel;
        private MetroFramework.Controls.MetroLabel ageLabel;
        private MetroFramework.Controls.MetroLabel FIOlabel;
        private System.Windows.Forms.Panel dataPanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}

