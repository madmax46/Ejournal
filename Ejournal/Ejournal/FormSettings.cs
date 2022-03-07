using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Xml;

namespace Ejournal
{
    public partial class FormSettings : Form, UserSettings
    {
        public struct Save
        {
            public int proffesorId;
            public int treeViewFillValue;
            public List<string> prefItems;
            public List<string[]> notes;
            public Save(int inputProffesorId, List<string[]> inputnotes, int inputTreeViewFillValue, List<string> inputPrefItems)
            {
                proffesorId = inputProffesorId;
                notes = inputnotes;
                treeViewFillValue = inputTreeViewFillValue;
                prefItems = inputPrefItems;
            }
        }

        int ColumnSelect = -1;
        int RowSelect = -1;     
        bool isDefault = true;

        int proffesorId;
        int treeViewFillValue;
        List<string> prefItems;
        List<string[]> notes;

        public int ProffesorId
        {
            get
            {
                return proffesorId;
            }

            set
            {
                proffesorId = value;
            }
        }
        public int TreeViewFillValue
        {
            get
            {
                return treeViewFillValue;
            }

            set
            {
                treeViewFillValue = value;
            }
        }
        public List<string> PrefItems
        {
            get
            {
                return prefItems;
            }

            set
            {
                prefItems = value;
            }
        }
        public List<string[]> Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30";

        DataBaseWork Dbw;
        public FormSettings(int _proffesorId)
        {
            Dbw = new DataBaseWork(Connection);
            InitializeComponent();
            ProffesorId = _proffesorId;
            InitializeSettings();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ProffesorsRemarksDataGridView.Rows.Count; i++)
            {
                ProffesorsRemarksDataGridView[0, i].ContextMenuStrip = ColorContextMenuStrip;
            }
        }

        private void ColorAddButton_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            ColorAddPictureBox.BackColor = colorDialog.Color;
        }

        private void AddDescriptionButton_Click(object sender, EventArgs e)
        {
            ProffesorsRemarksDataGridView.Rows.Add("", DescriptionTextBox.Text);
            ProffesorsRemarksDataGridView[0, ProffesorsRemarksDataGridView.Rows.Count - 2].Style.BackColor = ColorAddPictureBox.BackColor;
            ProffesorsRemarksDataGridView[0, ProffesorsRemarksDataGridView.Rows.Count - 2].ContextMenuStrip = ColorContextMenuStrip;
        }

        private void ProffesorsRemarksDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            var h = ProffesorsRemarksDataGridView.HitTest(e.X, e.Y);
            if (h.Type == DataGridViewHitTestType.Cell)
            {
                ColumnSelect = h.ColumnIndex;
                RowSelect = h.RowIndex;
                ProffesorsRemarksDataGridView[h.ColumnIndex, h.RowIndex].Selected = true;
            }
        }

        private void SelectColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            ProffesorsRemarksDataGridView[ColumnSelect, RowSelect].Style.BackColor = colorDialog.Color;
        }

        private void PreferencesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PreferencesListBox.SelectedItem != null)
            {
                AddPrefTtextBox.Text = PreferencesListBox.SelectedItem.ToString(); ;
            }
        }

        private void AddNewPrefButton_Click(object sender, EventArgs e)
        {
            if (PreferencesListBox.Items.Count < 15)
            {
                string temp = AddPrefTtextBox.Text;
                temp = temp.Trim();
                if (temp.Length != 0 && !PreferencesListBox.Items.Contains(temp))
                {
                    PreferencesListBox.Items.Add(temp);
                }
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }

        private void DeletCurPrefButton_Click(object sender, EventArgs e)
        {
            if (PreferencesListBox.SelectedItem != null)
            {
                PreferencesListBox.Items.Remove(PreferencesListBox.SelectedItem);
            }
            if (ErrorLabel.Visible)
                ErrorLabel.Visible = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            //DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        public void SaveSettings()
        {
            FileStream fs = new FileStream(@"UserSettings.xml", FileMode.Create, FileAccess.Write);
            List<string> _PrefItems = new List<string>();
            int inputTreeViewFillValue = 0;
            if (GroupByGroupRadioButton.Checked)
                inputTreeViewFillValue = 1;
            List<string[]> templist = new List<string[]>();
            for (int i = 0; i < ProffesorsRemarksDataGridView.RowCount; i++)
            {
                string[] temp = new string[2];
                if (ProffesorsRemarksDataGridView[1, i].Value != null)
                {
                    temp[0] = ProffesorsRemarksDataGridView[0,i].Style.BackColor.ToArgb().ToString();
                    temp[1] = ProffesorsRemarksDataGridView[1,i].Value.ToString();
                    templist.Add(temp);
                }
            }
            for (int i = 0; i < PreferencesListBox.Items.Count; i++)
            {
                _PrefItems.Add(PreferencesListBox.Items[i].ToString());
            }
             Save settings = new Save(ProffesorId, templist, inputTreeViewFillValue, _PrefItems);
             XmlSerializer xmls = new XmlSerializer(settings.GetType());
             fs.Seek(0, SeekOrigin.Begin);
             xmls.Serialize(fs, settings);
             fs.Flush();
             fs.Close();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"UserSettings.xml");
            string String_Update = "UPDATE Lecturer SET Preferences = N'" +xmlDoc.InnerXml +"' WHERE Id = " + ProffesorId;
            Dbw.NonQuery(String_Update);

            TreeViewFillValue = settings.treeViewFillValue;
            Notes = settings.notes;
            PrefItems = settings.prefItems;
        }

        private void ProffesorsRemarksDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ProffesorsRemarksDataGridView[0, ProffesorsRemarksDataGridView.Rows.Count - 1].ContextMenuStrip = ColorContextMenuStrip;
        }

        public Save LoadSettings(out bool isDefault)
        {
            if (File.Exists(@"UserSettings.xml"))
            {
                Save settings = new Save();
                FileStream fs = new FileStream(@"UserSettings.xml", FileMode.Open, FileAccess.ReadWrite);
                XmlSerializer xmls = new XmlSerializer(settings.GetType());
                fs.Seek(0, SeekOrigin.Begin);
                settings = (Save)xmls.Deserialize(fs);
                fs.Close();
                if (settings.proffesorId == ProffesorId)
                {
                    isDefault = false;
                    return settings;
                }
            }
            
            string String_SELECT = "SELECT Preferences FROM Lecturer WHERE Id = " + ProffesorId;
            DataTable dt = Dbw.QuerySelect(String_SELECT);
            if (dt.Rows.Count > 0)
            {
                string tempXml = dt.Rows[0].Field<string>("Preferences");
                if (tempXml != null)
                { 
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(tempXml);
                xmlDoc.Save(@"UserSettings.xml");
                FileStream fs = new FileStream(@"UserSettings.xml", FileMode.Open, FileAccess.Read);
                fs.Seek(0, SeekOrigin.Begin);
                Save settings = new Save();
                XmlSerializer xmls = new XmlSerializer(settings.GetType());
                settings = (Save)xmls.Deserialize(fs);
                fs.Close();
                isDefault = false;
                return settings;
            }
            }
            isDefault = true;
            return new Save();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitializeSettings()
        {
            Save settings = LoadSettings(out isDefault);
            if (!isDefault)
            {
                if (settings.treeViewFillValue == 0)
                    GroupBySpecialityRadioButton.Checked = true;
                else GroupByGroupRadioButton.Checked = true;
                for (int i = 0; i < settings.notes.Count; i++)
                {
                    ProffesorsRemarksDataGridView.Rows.Add();
                    string[] temp = settings.notes[i];
                    ProffesorsRemarksDataGridView[0, i].Style.BackColor = Color.FromArgb(int.Parse(temp[0]));
                    ProffesorsRemarksDataGridView[1, i].Value = temp[1];
                }
                PreferencesListBox.Items.Clear();
                for (int i = 0; i < settings.prefItems.Count; i++)
                {
                    PreferencesListBox.Items.Add(settings.prefItems[i]);
                }
                TreeViewFillValue = settings.treeViewFillValue;
                Notes = settings.notes;
                PrefItems = settings.prefItems;
            }
            else
            {
                List<string> tempItems = new List<string>();
                for (int i = 0; i < PreferencesListBox.Items.Count; i++)
                {
                    tempItems.Add(PreferencesListBox.Items[i].ToString());
                }
                TreeViewFillValue = 1;
                Notes = null;
                PrefItems = tempItems;
            }
        }
       
    }
    public interface UserSettings
        {
            int ProffesorId { get; set; }
            int TreeViewFillValue { get; set; }
            List<string> PrefItems { get; set; }
            List<string[]> Notes { get; set; }
        }
}
