namespace Ejournal
{
    partial class FormSettings
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
            this.GroupingGroupBox = new System.Windows.Forms.GroupBox();
            this.GroupBySpecialityRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupByGroupRadioButton = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.ProffesorsRemarksDataGridView = new System.Windows.Forms.DataGridView();
            this.ColorColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddDescriptionButton = new System.Windows.Forms.Button();
            this.ColorAddButton = new System.Windows.Forms.Button();
            this.ColorAddPictureBox = new System.Windows.Forms.PictureBox();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.PreferencesListBox = new System.Windows.Forms.ListBox();
            this.AddPrefTtextBox = new System.Windows.Forms.TextBox();
            this.AddPrefLabel = new System.Windows.Forms.Label();
            this.AddNewPrefButton = new System.Windows.Forms.Button();
            this.DeletCurPrefButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PrefGroupBox = new System.Windows.Forms.GroupBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.GroupingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProffesorsRemarksDataGridView)).BeginInit();
            this.ColorContextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorAddPictureBox)).BeginInit();
            this.PrefGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupingGroupBox
            // 
            this.GroupingGroupBox.Controls.Add(this.GroupBySpecialityRadioButton);
            this.GroupingGroupBox.Controls.Add(this.GroupByGroupRadioButton);
            this.GroupingGroupBox.Location = new System.Drawing.Point(12, 12);
            this.GroupingGroupBox.Name = "GroupingGroupBox";
            this.GroupingGroupBox.Size = new System.Drawing.Size(200, 69);
            this.GroupingGroupBox.TabIndex = 0;
            this.GroupingGroupBox.TabStop = false;
            this.GroupingGroupBox.Text = "Группировка панели";
            // 
            // GroupBySpecialityRadioButton
            // 
            this.GroupBySpecialityRadioButton.AutoSize = true;
            this.GroupBySpecialityRadioButton.Location = new System.Drawing.Point(7, 43);
            this.GroupBySpecialityRadioButton.Name = "GroupBySpecialityRadioButton";
            this.GroupBySpecialityRadioButton.Size = new System.Drawing.Size(110, 17);
            this.GroupBySpecialityRadioButton.TabIndex = 1;
            this.GroupBySpecialityRadioButton.Text = "По дисциплинам";
            this.GroupBySpecialityRadioButton.UseVisualStyleBackColor = true;
            // 
            // GroupByGroupRadioButton
            // 
            this.GroupByGroupRadioButton.AutoSize = true;
            this.GroupByGroupRadioButton.Checked = true;
            this.GroupByGroupRadioButton.Location = new System.Drawing.Point(7, 20);
            this.GroupByGroupRadioButton.Name = "GroupByGroupRadioButton";
            this.GroupByGroupRadioButton.Size = new System.Drawing.Size(84, 17);
            this.GroupByGroupRadioButton.TabIndex = 0;
            this.GroupByGroupRadioButton.TabStop = true;
            this.GroupByGroupRadioButton.Text = "По группам";
            this.GroupByGroupRadioButton.UseVisualStyleBackColor = true;
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Transparent;
            // 
            // ProffesorsRemarksDataGridView
            // 
            this.ProffesorsRemarksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ProffesorsRemarksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColorColumn,
            this.description});
            this.ProffesorsRemarksDataGridView.Location = new System.Drawing.Point(6, 19);
            this.ProffesorsRemarksDataGridView.MultiSelect = false;
            this.ProffesorsRemarksDataGridView.Name = "ProffesorsRemarksDataGridView";
            this.ProffesorsRemarksDataGridView.RowHeadersWidth = 25;
            this.ProffesorsRemarksDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProffesorsRemarksDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProffesorsRemarksDataGridView.Size = new System.Drawing.Size(188, 150);
            this.ProffesorsRemarksDataGridView.TabIndex = 2;
            this.ProffesorsRemarksDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ProffesorsRemarksDataGridView_RowsAdded);
            this.ProffesorsRemarksDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProffesorsRemarksDataGridView_MouseDown);
            // 
            // ColorColumn
            // 
            this.ColorColumn.Frozen = true;
            this.ColorColumn.HeaderText = "Цвет";
            this.ColorColumn.Name = "ColorColumn";
            this.ColorColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorColumn.ToolTipText = "Цвет";
            this.ColorColumn.Width = 50;
            // 
            // description
            // 
            this.description.Frozen = true;
            this.description.HeaderText = "Описание";
            this.description.Name = "description";
            this.description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.description.Width = 150;
            // 
            // ColorContextMenuStrip
            // 
            this.ColorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectColorToolStripMenuItem});
            this.ColorContextMenuStrip.Name = "ColorContextMenuStrip";
            this.ColorContextMenuStrip.Size = new System.Drawing.Size(149, 26);
            // 
            // SelectColorToolStripMenuItem
            // 
            this.SelectColorToolStripMenuItem.Name = "SelectColorToolStripMenuItem";
            this.SelectColorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.SelectColorToolStripMenuItem.Text = "Выбрать цвет";
            this.SelectColorToolStripMenuItem.Click += new System.EventHandler(this.SelectColorToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddDescriptionButton);
            this.groupBox1.Controls.Add(this.ColorAddButton);
            this.groupBox1.Controls.Add(this.ColorAddPictureBox);
            this.groupBox1.Controls.Add(this.ColorLabel);
            this.groupBox1.Controls.Add(this.DescriptionLabel);
            this.groupBox1.Controls.Add(this.DescriptionTextBox);
            this.groupBox1.Controls.Add(this.ProffesorsRemarksDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 276);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // AddDescriptionButton
            // 
            this.AddDescriptionButton.Location = new System.Drawing.Point(116, 243);
            this.AddDescriptionButton.Name = "AddDescriptionButton";
            this.AddDescriptionButton.Size = new System.Drawing.Size(75, 27);
            this.AddDescriptionButton.TabIndex = 8;
            this.AddDescriptionButton.Text = "Добавить";
            this.AddDescriptionButton.UseVisualStyleBackColor = true;
            this.AddDescriptionButton.Click += new System.EventHandler(this.AddDescriptionButton_Click);
            // 
            // ColorAddButton
            // 
            this.ColorAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorAddButton.Location = new System.Drawing.Point(116, 206);
            this.ColorAddButton.Name = "ColorAddButton";
            this.ColorAddButton.Size = new System.Drawing.Size(78, 33);
            this.ColorAddButton.TabIndex = 7;
            this.ColorAddButton.Text = "Выбрать цвет";
            this.ColorAddButton.UseVisualStyleBackColor = true;
            this.ColorAddButton.Click += new System.EventHandler(this.ColorAddButton_Click);
            // 
            // ColorAddPictureBox
            // 
            this.ColorAddPictureBox.BackColor = System.Drawing.Color.White;
            this.ColorAddPictureBox.Location = new System.Drawing.Point(70, 206);
            this.ColorAddPictureBox.Name = "ColorAddPictureBox";
            this.ColorAddPictureBox.Size = new System.Drawing.Size(40, 33);
            this.ColorAddPictureBox.TabIndex = 6;
            this.ColorAddPictureBox.TabStop = false;
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Location = new System.Drawing.Point(6, 215);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(35, 13);
            this.ColorLabel.TabIndex = 5;
            this.ColorLabel.Text = "Цвет:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(6, 178);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 4;
            this.DescriptionLabel.Text = "Описание:";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(70, 175);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(124, 25);
            this.DescriptionTextBox.TabIndex = 3;
            // 
            // PreferencesListBox
            // 
            this.PreferencesListBox.FormattingEnabled = true;
            this.PreferencesListBox.Items.AddRange(new object[] {
            "-",
            "+",
            "2",
            "3",
            "4",
            "5",
            "нб"});
            this.PreferencesListBox.Location = new System.Drawing.Point(6, 20);
            this.PreferencesListBox.Name = "PreferencesListBox";
            this.PreferencesListBox.Size = new System.Drawing.Size(184, 238);
            this.PreferencesListBox.Sorted = true;
            this.PreferencesListBox.TabIndex = 5;
            this.PreferencesListBox.SelectedIndexChanged += new System.EventHandler(this.PreferencesListBox_SelectedIndexChanged);
            // 
            // AddPrefTtextBox
            // 
            this.AddPrefTtextBox.Location = new System.Drawing.Point(67, 288);
            this.AddPrefTtextBox.Name = "AddPrefTtextBox";
            this.AddPrefTtextBox.Size = new System.Drawing.Size(124, 20);
            this.AddPrefTtextBox.TabIndex = 6;
            // 
            // AddPrefLabel
            // 
            this.AddPrefLabel.AutoSize = true;
            this.AddPrefLabel.Location = new System.Drawing.Point(4, 291);
            this.AddPrefLabel.Name = "AddPrefLabel";
            this.AddPrefLabel.Size = new System.Drawing.Size(58, 13);
            this.AddPrefLabel.TabIndex = 7;
            this.AddPrefLabel.Text = "Значение:";
            // 
            // AddNewPrefButton
            // 
            this.AddNewPrefButton.Location = new System.Drawing.Point(108, 318);
            this.AddNewPrefButton.Name = "AddNewPrefButton";
            this.AddNewPrefButton.Size = new System.Drawing.Size(83, 27);
            this.AddNewPrefButton.TabIndex = 8;
            this.AddNewPrefButton.Text = "Добавить";
            this.AddNewPrefButton.UseVisualStyleBackColor = true;
            this.AddNewPrefButton.Click += new System.EventHandler(this.AddNewPrefButton_Click);
            // 
            // DeletCurPrefButton
            // 
            this.DeletCurPrefButton.Location = new System.Drawing.Point(7, 318);
            this.DeletCurPrefButton.Name = "DeletCurPrefButton";
            this.DeletCurPrefButton.Size = new System.Drawing.Size(80, 27);
            this.DeletCurPrefButton.TabIndex = 9;
            this.DeletCurPrefButton.Text = "Удалить";
            this.DeletCurPrefButton.UseVisualStyleBackColor = true;
            this.DeletCurPrefButton.Click += new System.EventHandler(this.DeletCurPrefButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(175, 376);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(256, 377);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(337, 377);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 12;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // PrefGroupBox
            // 
            this.PrefGroupBox.Controls.Add(this.ErrorLabel);
            this.PrefGroupBox.Controls.Add(this.AddPrefLabel);
            this.PrefGroupBox.Controls.Add(this.PreferencesListBox);
            this.PrefGroupBox.Controls.Add(this.AddPrefTtextBox);
            this.PrefGroupBox.Controls.Add(this.AddNewPrefButton);
            this.PrefGroupBox.Controls.Add(this.DeletCurPrefButton);
            this.PrefGroupBox.Location = new System.Drawing.Point(228, 12);
            this.PrefGroupBox.Name = "PrefGroupBox";
            this.PrefGroupBox.Size = new System.Drawing.Size(197, 351);
            this.PrefGroupBox.TabIndex = 13;
            this.PrefGroupBox.TabStop = false;
            this.PrefGroupBox.Text = "Меню быстрого доступа";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(35, 260);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(135, 26);
            this.ErrorLabel.TabIndex = 10;
            this.ErrorLabel.Text = "Количество объектов \r\nне должно превышать 15";
            this.ErrorLabel.Visible = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 412);
            this.Controls.Add(this.PrefGroupBox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupingGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 451);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(453, 451);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.GroupingGroupBox.ResumeLayout(false);
            this.GroupingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProffesorsRemarksDataGridView)).EndInit();
            this.ColorContextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorAddPictureBox)).EndInit();
            this.PrefGroupBox.ResumeLayout(false);
            this.PrefGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupingGroupBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ContextMenuStrip ColorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SelectColorToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddDescriptionButton;
        private System.Windows.Forms.Button ColorAddButton;
        private System.Windows.Forms.PictureBox ColorAddPictureBox;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.DataGridViewLinkColumn ColorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.TextBox AddPrefTtextBox;
        private System.Windows.Forms.Label AddPrefLabel;
        private System.Windows.Forms.Button AddNewPrefButton;
        private System.Windows.Forms.Button DeletCurPrefButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.GroupBox PrefGroupBox;
        private System.Windows.Forms.Label ErrorLabel;
        public System.Windows.Forms.RadioButton GroupBySpecialityRadioButton;
        public System.Windows.Forms.RadioButton GroupByGroupRadioButton;
        public System.Windows.Forms.DataGridView ProffesorsRemarksDataGridView;
        public System.Windows.Forms.ListBox PreferencesListBox;
    }
}