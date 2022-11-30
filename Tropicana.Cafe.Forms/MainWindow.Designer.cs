using System;

namespace Tropicana.Cafe.Forms
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EntryList = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LogList = new System.Windows.Forms.ListView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mealPeriodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byMealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byMealPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individualMealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.entryIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemainingCountLabel = new System.Windows.Forms.Label();
            this.hourlyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.halfHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.LogListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Log";
            columnHeader1.Width = 412;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(37, 455);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(518, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_KeyUp);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnEnterKey);
            // 
            // EntryList
            // 
            this.EntryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryList.FormattingEnabled = true;
            this.EntryList.ItemHeight = 25;
            this.EntryList.Location = new System.Drawing.Point(37, 43);
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(239, 254);
            this.EntryList.TabIndex = 1;
            this.EntryList.SelectedIndexChanged += new System.EventHandler(this.EntryList_SelectedIndexChanged);
            this.EntryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnEnterKey);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(292, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 254);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LogList
            // 
            this.LogList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
            this.LogList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogList.Location = new System.Drawing.Point(37, 314);
            this.LogList.MultiSelect = false;
            this.LogList.Name = "LogList";
            this.LogList.ShowItemToolTips = true;
            this.LogList.Size = new System.Drawing.Size(416, 135);
            this.LogList.TabIndex = 3;
            this.LogList.UseCompatibleStateImageBehavior = false;
            this.LogList.View = System.Windows.Forms.View.Details;
            this.LogList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LogList_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox2.Location = new System.Drawing.Point(459, 315);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(96, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.showDetailsToolStripMenuItem,
            this.mealPeriodsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // mealPeriodsToolStripMenuItem
            // 
            this.mealPeriodsToolStripMenuItem.Name = "mealPeriodsToolStripMenuItem";
            this.mealPeriodsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mealPeriodsToolStripMenuItem.Text = "Meal Periods";
            this.mealPeriodsToolStripMenuItem.Click += new System.EventHandler(this.mealPeriodsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hourlyToolStripMenuItem,
            this.byMealToolStripMenuItem,
            this.byMealPlanToolStripMenuItem,
            this.individualMealsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // hourlyToolStripMenuItem
            // 
            this.hourlyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hourlyToolStripMenuItem1,
            this.halfHourToolStripMenuItem});
            this.hourlyToolStripMenuItem.Name = "hourlyToolStripMenuItem";
            this.hourlyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hourlyToolStripMenuItem.Text = "Time";
            // 
            // byMealToolStripMenuItem
            // 
            this.byMealToolStripMenuItem.Name = "byMealToolStripMenuItem";
            this.byMealToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.byMealToolStripMenuItem.Text = "By Meal Period";
            this.byMealToolStripMenuItem.Click += new System.EventHandler(this.byMealToolStripMenuItem_Click);
            // 
            // byMealPlanToolStripMenuItem
            // 
            this.byMealPlanToolStripMenuItem.Name = "byMealPlanToolStripMenuItem";
            this.byMealPlanToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.byMealPlanToolStripMenuItem.Text = "By MealPlan";
            this.byMealPlanToolStripMenuItem.Click += new System.EventHandler(this.byMealPlanToolStripMenuItem_Click);
            // 
            // individualMealsToolStripMenuItem
            // 
            this.individualMealsToolStripMenuItem.Name = "individualMealsToolStripMenuItem";
            this.individualMealsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.individualMealsToolStripMenuItem.Text = "Individual Meals";
            this.individualMealsToolStripMenuItem.Click += new System.EventHandler(this.individualMealsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // LogListContextMenu
            // 
            this.LogListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entryIDToolStripMenuItem,
            this.showPhotoToolStripMenuItem,
            this.reverseEntryToolStripMenuItem});
            this.LogListContextMenu.Name = "LogListContextMenu";
            this.LogListContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // entryIDToolStripMenuItem
            // 
            this.entryIDToolStripMenuItem.Name = "entryIDToolStripMenuItem";
            this.entryIDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.entryIDToolStripMenuItem.Text = "Show Message";
            this.entryIDToolStripMenuItem.Click += new System.EventHandler(this.showMessageMenuItem_Click);
            // 
            // showPhotoToolStripMenuItem
            // 
            this.showPhotoToolStripMenuItem.Name = "showPhotoToolStripMenuItem";
            this.showPhotoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showPhotoToolStripMenuItem.Text = "ShowPhoto";
            this.showPhotoToolStripMenuItem.Click += new System.EventHandler(this.showPhotoToolStripMenuItem_Click);
            // 
            // reverseEntryToolStripMenuItem
            // 
            this.reverseEntryToolStripMenuItem.Name = "reverseEntryToolStripMenuItem";
            this.reverseEntryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reverseEntryToolStripMenuItem.Text = "Reverse Entry";
            this.reverseEntryToolStripMenuItem.Click += new System.EventHandler(this.reverseEntryToolStripMenuItem_Click);
            // 
            // RemainingCountLabel
            // 
            this.RemainingCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemainingCountLabel.AutoSize = true;
            this.RemainingCountLabel.BackColor = System.Drawing.Color.OrangeRed;
            this.RemainingCountLabel.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainingCountLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RemainingCountLabel.Location = new System.Drawing.Point(479, 337);
            this.RemainingCountLabel.Name = "RemainingCountLabel";
            this.RemainingCountLabel.Size = new System.Drawing.Size(57, 43);
            this.RemainingCountLabel.TabIndex = 6;
            this.RemainingCountLabel.Text = "00";
            this.RemainingCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hourlyToolStripMenuItem1
            // 
            this.hourlyToolStripMenuItem1.Name = "hourlyToolStripMenuItem1";
            this.hourlyToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.hourlyToolStripMenuItem1.Text = "Hourly";
            this.hourlyToolStripMenuItem1.Click += new System.EventHandler(this.hourlyToolStripMenuItem_Click);
            // 
            // halfHourToolStripMenuItem
            // 
            this.halfHourToolStripMenuItem.Name = "halfHourToolStripMenuItem";
            this.halfHourToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.halfHourToolStripMenuItem.Text = "Half Hour";
            this.halfHourToolStripMenuItem.Click += new System.EventHandler(this.halfhourlyToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 503);
            this.Controls.Add(this.RemainingCountLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LogList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EntryList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Tropicana Finger Veins";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnUpOrDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.LogListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox EntryList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView LogList;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip LogListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem entryIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseEntryToolStripMenuItem;
        private System.Windows.Forms.Label RemainingCountLabel;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byMealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mealPeriodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individualMealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byMealPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourlyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem halfHourToolStripMenuItem;
    }
}

