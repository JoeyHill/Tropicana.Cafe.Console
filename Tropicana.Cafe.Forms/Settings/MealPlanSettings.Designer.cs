namespace Tropicana.Cafe.Forms.Settings
{
    partial class MealPlanSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Tropicana.Cafe.Main.Settings.MainSettings mainSettings1 = new Tropicana.Cafe.Main.Settings.MainSettings();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tg_Radio = new System.Windows.Forms.RadioButton();
            this.tdn_Radio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sServer = new System.Windows.Forms.TextBox();
            this.sDB = new System.Windows.Forms.TextBox();
            this.sUser = new System.Windows.Forms.TextBox();
            this.sPass = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mUser = new System.Windows.Forms.TextBox();
            this.mPass = new System.Windows.Forms.TextBox();
            this.sTestCon = new System.Windows.Forms.Button();
            this.mTestCon = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.enforceSingleCheck = new System.Windows.Forms.CheckBox();
            this.restrictToBuilding = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(224, 382);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(316, 382);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tg_Radio);
            this.groupBox1.Controls.Add(this.tdn_Radio);
            this.groupBox1.Location = new System.Drawing.Point(6, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Building";
            // 
            // tg_Radio
            // 
            this.tg_Radio.AutoSize = true;
            this.tg_Radio.Location = new System.Drawing.Point(6, 19);
            this.tg_Radio.Name = "tg_Radio";
            this.tg_Radio.Size = new System.Drawing.Size(116, 17);
            this.tg_Radio.TabIndex = 0;
            this.tg_Radio.TabStop = true;
            this.tg_Radio.Text = "Tropicana Gardens";
            this.tg_Radio.UseVisualStyleBackColor = true;
            this.tg_Radio.CheckedChanged += new System.EventHandler(this.buildingRadioChanged);
            // 
            // tdn_Radio
            // 
            this.tdn_Radio.AutoSize = true;
            this.tdn_Radio.Location = new System.Drawing.Point(6, 42);
            this.tdn_Radio.Name = "tdn_Radio";
            this.tdn_Radio.Size = new System.Drawing.Size(121, 17);
            this.tdn_Radio.TabIndex = 1;
            this.tdn_Radio.TabStop = true;
            this.tdn_Radio.Text = "Tropicana Del Norte";
            this.tdn_Radio.UseVisualStyleBackColor = true;
            this.tdn_Radio.CheckedChanged += new System.EventHandler(this.buildingRadioChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Password";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.sServer);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.sDB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.sUser);
            this.groupBox2.Controls.Add(this.sPass);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 216);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Student Server";
            // 
            // sServer
            // 
            this.sServer.Location = new System.Drawing.Point(11, 31);
            this.sServer.Name = "sServer";
            this.sServer.Size = new System.Drawing.Size(178, 20);
            this.sServer.TabIndex = 5;
            this.sServer.Text = "starrezsql";
            this.sServer.Leave += new System.EventHandler(this.SettingTextChanged);
            // 
            // sDB
            // 
            this.sDB.Location = new System.Drawing.Point(11, 84);
            this.sDB.Name = "sDB";
            this.sDB.Size = new System.Drawing.Size(178, 20);
            this.sDB.TabIndex = 6;
            this.sDB.Text = "snRez0_Main";
            this.sDB.Leave += new System.EventHandler(this.SettingTextChanged);
            // 
            // sUser
            // 
            this.sUser.Location = new System.Drawing.Point(11, 137);
            this.sUser.Name = "sUser";
            this.sUser.Size = new System.Drawing.Size(178, 20);
            this.sUser.TabIndex = 7;
            this.sUser.Text = "remote";
            this.sUser.Leave += new System.EventHandler(this.SettingTextChanged);
            // 
            // sPass
            // 
            this.sPass.Location = new System.Drawing.Point(11, 190);
            this.sPass.Name = "sPass";
            this.sPass.Size = new System.Drawing.Size(178, 20);
            this.sPass.TabIndex = 8;
            this.sPass.Text = "Srez4dm1n";
            this.sPass.UseSystemPasswordChar = true;
            this.sPass.Leave += new System.EventHandler(this.SettingTextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.mServer);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.mDB);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.mUser);
            this.groupBox3.Controls.Add(this.mPass);
            this.groupBox3.Location = new System.Drawing.Point(218, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 216);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Meal Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password";
            // 
            // mServer
            // 
            this.mServer.Location = new System.Drawing.Point(11, 31);
            this.mServer.Name = "mServer";
            this.mServer.Size = new System.Drawing.Size(178, 20);
            this.mServer.TabIndex = 5;
            this.mServer.Text = "192.168.1.164\\SQLEXPRESS";
            this.mServer.Leave += new System.EventHandler(this.SettingTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Username";
            // 
            // mDB
            // 
            this.mDB.Location = new System.Drawing.Point(11, 84);
            this.mDB.Name = "mDB";
            this.mDB.Size = new System.Drawing.Size(178, 20);
            this.mDB.TabIndex = 6;
            this.mDB.Text = "TropicanaMeals";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Database";
            // 
            // mUser
            // 
            this.mUser.Location = new System.Drawing.Point(11, 137);
            this.mUser.Name = "mUser";
            this.mUser.Size = new System.Drawing.Size(178, 20);
            this.mUser.TabIndex = 7;
            this.mUser.Text = "sa";
            this.mUser.Leave += new System.EventHandler(this.SettingTextChanged);
            // 
            // mPass
            // 
            this.mPass.Location = new System.Drawing.Point(11, 190);
            this.mPass.Name = "mPass";
            this.mPass.Size = new System.Drawing.Size(178, 20);
            this.mPass.TabIndex = 8;
            this.mPass.Text = "new5horizon7";
            this.mPass.UseSystemPasswordChar = true;
            // 
            // sTestCon
            // 
            this.sTestCon.Location = new System.Drawing.Point(74, 234);
            this.sTestCon.Name = "sTestCon";
            this.sTestCon.Size = new System.Drawing.Size(75, 23);
            this.sTestCon.TabIndex = 16;
            this.sTestCon.Text = "Test";
            this.sTestCon.UseVisualStyleBackColor = true;
            this.sTestCon.Click += new System.EventHandler(this.TestConnection);
            // 
            // mTestCon
            // 
            this.mTestCon.Location = new System.Drawing.Point(286, 234);
            this.mTestCon.Name = "mTestCon";
            this.mTestCon.Size = new System.Drawing.Size(75, 23);
            this.mTestCon.TabIndex = 17;
            this.mTestCon.Text = "Test";
            this.mTestCon.UseVisualStyleBackColor = true;
            this.mTestCon.Click += new System.EventHandler(this.TestConnection);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            mainSettings1.Building = "Tropicana Gardens";
            mainSettings1.CommitMeals = true;
            mainSettings1.EnforceSingleMeal = false;
            mainSettings1.MailPass = "Tr0p1cana";
            mainSettings1.MailUser = "frontdesk@tropicanastudentliving.com";
            mainSettings1.MealDB = "TropicanaMeals";
            mainSettings1.MealPass = "new5horizon7";
            mainSettings1.MealServer = "192.168.1.164\\SQLEXPRESS";
            mainSettings1.MealUser = "sa";
            mainSettings1.RestrictToBuilding = false;
            mainSettings1.SettingsKey = "";
            mainSettings1.StuDB = "snRez1_Main";
            mainSettings1.StuPass = "Srez4dm1n";
            mainSettings1.StuServer = "starrez";
            mainSettings1.StuUser = "remote";
            this.checkBox1.Checked = mainSettings1.CommitMeals;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", mainSettings1, "CommitMeals", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(12, 267);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Commit Meals";
            this.checkBox1.UseVisualStyleBackColor = true;
            
            // 
            // enforceSingleCheck
            // 
            this.enforceSingleCheck.AutoSize = true;
            this.enforceSingleCheck.Location = new System.Drawing.Point(12, 291);
            this.enforceSingleCheck.Name = "enforceSingleCheck";
            this.enforceSingleCheck.Size = new System.Drawing.Size(121, 17);
            this.enforceSingleCheck.TabIndex = 18;
            this.enforceSingleCheck.Text = "Enforce Single Meal";
            this.enforceSingleCheck.UseVisualStyleBackColor = true;
            // 
            // restrictToBuilding
            // 
            this.restrictToBuilding.AutoSize = true;
            this.restrictToBuilding.Checked = mainSettings1.RestrictToBuilding;
            //this.restrictToBuilding.DataBindings.Add(new System.Windows.Forms.Binding("Checked", mainSettings1, "RestrictToBuilding", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.restrictToBuilding.Location = new System.Drawing.Point(135, 267);
            this.restrictToBuilding.Name = "restrictToBuilding";
            this.restrictToBuilding.Size = new System.Drawing.Size(118, 17);
            this.restrictToBuilding.TabIndex = 19;
            this.restrictToBuilding.Text = "Restrict To Building";
            this.restrictToBuilding.UseVisualStyleBackColor = true;
            
            // 
            // MealPlanSettings
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 417);
            this.Controls.Add(this.restrictToBuilding);
            this.Controls.Add(this.enforceSingleCheck);
            this.Controls.Add(this.mTestCon);
            this.Controls.Add(this.sTestCon);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "MealPlanSettings";
            this.Text = "MealPlanSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton tg_Radio;
        private System.Windows.Forms.RadioButton tdn_Radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox sServer;
        private System.Windows.Forms.TextBox sDB;
        private System.Windows.Forms.TextBox sUser;
        private System.Windows.Forms.TextBox sPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mUser;
        private System.Windows.Forms.TextBox mPass;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button sTestCon;
        private System.Windows.Forms.Button mTestCon;
        private System.Windows.Forms.CheckBox enforceSingleCheck;
        private System.Windows.Forms.CheckBox restrictToBuilding;
    }
}