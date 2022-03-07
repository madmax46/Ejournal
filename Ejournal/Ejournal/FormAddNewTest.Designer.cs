namespace Ejournal
{
    partial class FormAddNewTest
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.ShortNameTextBox = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.FullNameGroupBox = new System.Windows.Forms.GroupBox();
            this.ShortNameGroupBox = new System.Windows.Forms.GroupBox();
            this.DateGroupBox = new System.Windows.Forms.GroupBox();
            this.FullNameGroupBox.SuspendLayout();
            this.ShortNameGroupBox.SuspendLayout();
            this.DateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(6, 19);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker.TabIndex = 7;
            this.dateTimePicker.Value = new System.DateTime(2016, 5, 6, 0, 0, 0, 0);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(27, 188);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(130, 188);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(65, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.FullNameTextBox.TabIndex = 8;
            this.FullNameTextBox.TextChanged += new System.EventHandler(this.FullNameTextBox_TextChanged);
            // 
            // ShortNameTextBox
            // 
            this.ShortNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.ShortNameTextBox.Name = "ShortNameTextBox";
            this.ShortNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.ShortNameTextBox.TabIndex = 10;
            this.ShortNameTextBox.TextChanged += new System.EventHandler(this.ShortNameTextBox_TextChanged);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(12, 0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(183, 13);
            this.ErrorLabel.TabIndex = 12;
            this.ErrorLabel.Text = "Все поля должны быть заполнены";
            this.ErrorLabel.Visible = false;
            // 
            // FullNameGroupBox
            // 
            this.FullNameGroupBox.Controls.Add(this.FullNameTextBox);
            this.FullNameGroupBox.Location = new System.Drawing.Point(9, 12);
            this.FullNameGroupBox.Name = "FullNameGroupBox";
            this.FullNameGroupBox.Size = new System.Drawing.Size(198, 54);
            this.FullNameGroupBox.TabIndex = 14;
            this.FullNameGroupBox.TabStop = false;
            this.FullNameGroupBox.Text = "Полное название работы";
            // 
            // ShortNameGroupBox
            // 
            this.ShortNameGroupBox.Controls.Add(this.ShortNameTextBox);
            this.ShortNameGroupBox.Location = new System.Drawing.Point(9, 72);
            this.ShortNameGroupBox.Name = "ShortNameGroupBox";
            this.ShortNameGroupBox.Size = new System.Drawing.Size(198, 48);
            this.ShortNameGroupBox.TabIndex = 15;
            this.ShortNameGroupBox.TabStop = false;
            this.ShortNameGroupBox.Text = "Краткое название для ведомости";
            // 
            // DateGroupBox
            // 
            this.DateGroupBox.Controls.Add(this.dateTimePicker);
            this.DateGroupBox.Location = new System.Drawing.Point(9, 126);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Size = new System.Drawing.Size(198, 56);
            this.DateGroupBox.TabIndex = 16;
            this.DateGroupBox.TabStop = false;
            this.DateGroupBox.Text = "Дата";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(216, 232);
            this.Controls.Add(this.DateGroupBox);
            this.Controls.Add(this.ShortNameGroupBox);
            this.Controls.Add(this.FullNameGroupBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить новый столбец";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.FullNameGroupBox.ResumeLayout(false);
            this.FullNameGroupBox.PerformLayout();
            this.ShortNameGroupBox.ResumeLayout(false);
            this.ShortNameGroupBox.PerformLayout();
            this.DateGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.TextBox FullNameTextBox;
        public System.Windows.Forms.TextBox ShortNameTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.GroupBox FullNameGroupBox;
        private System.Windows.Forms.GroupBox ShortNameGroupBox;
        private System.Windows.Forms.GroupBox DateGroupBox;
    }
}