using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Ejournal
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
                LoginTextBox.Text = MySettings.Login;
                PasswordTextBox.Text = MySettings.Password;
                RememberCheckBox.Checked = true;
                MySettings.isLogin = false;
                MySettings.Save();
        }

        public int ProfessorId = -1;
        public string PrfessorName = "";
        private Properties.Settings MySettings = Properties.Settings.Default;

        private void FormAuthorization_Load(object sender, EventArgs e)
        {
        }

        private void LoginTextBox_Enter(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Length > 0&& LoginTextBox.Text != "Логин")
                ErorrLabel.Visible = false;
            if (LoginTextBox.Text == "Логин")
            {
                LoginTextBox.Text = null;
                LoginTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextBox.TextLength > 0 && PasswordTextBox.Text != "Пароль")
                ErorrLabel.Visible = false;
            if (PasswordTextBox.Text == "Пароль")
            {
                PasswordTextBox.Text = null;
                PasswordTextBox.ForeColor = Color.Black;
            }
        }

        private void LoginTextBox_Leave(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "")
            {
                LoginTextBox.Text = "Логин";//подсказка
                LoginTextBox.ForeColor = Color.Gray;
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                PasswordTextBox.Text = "Пароль";//подсказка
                PasswordTextBox.ForeColor = Color.Gray;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Length > 0 && LoginTextBox.Text!= "Логин")
            {
                if (PasswordTextBox.TextLength > 0 && PasswordTextBox.Text!= "Пароль")
                {
                    string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30";
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox.Text));
                    string tempString = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    string String_SELECT = "SELECT Id, Username,Password, FIO FROM Lecturer WHERE Username = N'" + LoginTextBox.Text + "' AND Password = '"+tempString+"'";
                    DataBaseWork Dbw = new DataBaseWork(connection);
                    DataTable Users = Dbw.QuerySelect(String_SELECT);
                        if (Users.Rows.Count ==1)
                        {
                            ProfessorId = Users.Rows[0].Field<int>("Id");
                            PrfessorName = Users.Rows[0].Field<string>("FIO");
                            if (RememberCheckBox.Checked)
                            {
                                MySettings.Login = LoginTextBox.Text;
                                MySettings.Password = PasswordTextBox.Text;
                                MySettings.isSave = true;
                                MySettings.isLogin = true;
                                MySettings.Save();
                            }
                            else
                            {
                                MySettings.Login = null;
                                MySettings.Password = null;
                                MySettings.isSave = false;
                                MySettings.Save();
                            }
                            DialogResult = DialogResult.OK;

                        }
                        else
                        {
                            ErorrLabel.Text = "Неверный логин или пароль";
                            ErorrLabel.Visible = true;
                        }
                }
            else
                {
                    ErorrLabel.Visible = true;
                    ErorrLabel.Text = "Введите пароль";
                }
            }
            else
            {
                if (PasswordTextBox.TextLength == 0 || PasswordTextBox.Text == "Пароль")
                {

                    ErorrLabel.Text = "Введите логин и пароль";
                }
                else
                {
                    ErorrLabel.Text = "Введите логин";
                }
                ErorrLabel.Visible = true;
            }
        }
    }
}
