namespace Ejournal
{
    partial class FormAuthorization
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
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ErorrLabel = new System.Windows.Forms.Label();
            this.RememberCheckBox = new System.Windows.Forms.CheckBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.Location = new System.Drawing.Point(87, 67);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(175, 24);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.Text = "Пароль";
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.WordWrap = false;
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.PasswordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginLabel.Location = new System.Drawing.Point(13, 26);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(54, 18);
            this.LoginLabel.TabIndex = 2;
            this.LoginLabel.Text = "Логин:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLabel.Location = new System.Drawing.Point(13, 69);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(65, 18);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Пароль:";
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.LoginButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Location = new System.Drawing.Point(187, 115);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ErorrLabel
            // 
            this.ErorrLabel.AutoSize = true;
            this.ErorrLabel.ForeColor = System.Drawing.Color.Red;
            this.ErorrLabel.Location = new System.Drawing.Point(95, 8);
            this.ErorrLabel.Name = "ErorrLabel";
            this.ErorrLabel.Size = new System.Drawing.Size(151, 13);
            this.ErorrLabel.TabIndex = 6;
            this.ErorrLabel.Text = "Неверный логин или пароль";
            this.ErorrLabel.Visible = false;
            // 
            // RememberCheckBox
            // 
            this.RememberCheckBox.AutoSize = true;
            this.RememberCheckBox.Location = new System.Drawing.Point(87, 119);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(82, 17);
            this.RememberCheckBox.TabIndex = 4;
            this.RememberCheckBox.Text = "Запомнить";
            this.RememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTextBox.Location = new System.Drawing.Point(87, 26);
            this.LoginTextBox.Multiline = true;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(175, 24);
            this.LoginTextBox.TabIndex = 8;
            this.LoginTextBox.Text = "Логин";
            this.LoginTextBox.Enter += new System.EventHandler(this.LoginTextBox_Enter);
            this.LoginTextBox.Leave += new System.EventHandler(this.LoginTextBox_Leave);
            // 
            // FormAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.ErorrLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.RememberCheckBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 197);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 197);
            this.Name = "FormAuthorization";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.FormAuthorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label ErorrLabel;
        private System.Windows.Forms.CheckBox RememberCheckBox;
        private System.Windows.Forms.TextBox LoginTextBox;
    }
}