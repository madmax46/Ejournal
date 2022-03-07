using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.IO;

namespace Ejournal
{
    public partial class FormMainEJournal : Form
    {

        public FormMainEJournal()
        {
            InitializeComponent();
            if (File.Exists(@"Database.mdf"))
            {
                Dbw = new DataBaseWork(ConnectionString);
                InitializeEntry();
            }
            else
            {
                MessageBox.Show("База данных не найдена", "Внимание", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        ///<summary>
        ///Основные поля программы
        ///</summary>
        #region MainFields
        //строка подключения
        //string ConnectionString = @"Datasourse= Database.mdf; Integrated Security = True; Connect Timeout=30";
        string ConnectionString = @"Server=(LocalDB)\MSSQLLocalDB; Integrated Security=true; AttachDbFileName= |DataDirectory|Database.mdf;";
        //Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = C:\USERS\МАКСИМ\DESKTOP\EJOURNAL\EJOURNAL\BIN\DEBUG\DATABASE.MDF;Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        int ProfessorId = -1;
        int DisciplineId = 1;
        int GroupId = 0;
        int treeViewFillValue = -1;
        int Count = 0;
        int ColumnSelect = -1;
        int RowSelect = -1;
        int ColumnClick = -1;
        int pageCount = 0;
        int col_print_wait = 1;
        int row_print_wait = 0;
        bool isAuthorized = false;
        DataBaseWork Dbw;
        TreeNode t1;
        FormSettings formSettings;
        #endregion
        
        ///<summary>
        ///Основные обрабочики событий программы
        ///</summary>
        #region MainEventHandlers
        private void Form1_Load(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
        }

        private void Tsb_Click(object sender, EventArgs e)
        {
            if (ColumnSelect > 0 && RowSelect >= 0)
            {
                if (sender as ToolStripButton != null)
                    MainDataGridView[ColumnSelect, RowSelect].Value = ((ToolStripButton)sender).Text;
                else
                    if (sender as ToolStripMenuItem != null)
                    MainDataGridView[ColumnSelect, RowSelect].Value = ((ToolStripMenuItem)sender).Text;
            }
        }

        private void GroupsOutTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StartFillList(timer1);
        }

        private void MainDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CellValueChanged(e.ColumnIndex, e.RowIndex);
        }

        private void addNewDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewDate();
        }

        private void MainDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            CellPainting(e);
        }

        private void addNewTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewTest();
        }

        private void MainDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)  
        {
            CellClicNoteView(e.ColumnIndex, e.RowIndex, true);
        }

        private void deleteTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteTest(ColumnClick);
        }
        private void deleteDateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteDate(ColumnClick);
        }

        private void MainDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            col_row_select(e);
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MainDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {          
            CellClicNoteView(e.ColumnIndex, e.RowIndex, false);
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNoteClick();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDoc();
        }

        private void printSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintList(e);
        }

        private void excelExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ExportExcel();
        }

        private void AuthorizatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetParams();
            Autorization();
        }

        private void MainDataGridView_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            if (MainDataGridView.RowHeadersWidth < 175)
            { MainDataGridView.RowHeadersWidth = 175; }
        }

        private void ProffesorsRemarksDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ProffesorsRemarksDataGridView[e.ColumnIndex, e.RowIndex].Selected = false;
        }

        private void ProffesorsRemarksDataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Height = 25;
        }

        private void ProffesorsRemarksDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ProffesorsRemarksDataGridView.ClearSelection();
        }

        private void ExcelStripButton_Click(object sender, EventArgs e)
        {
                ExportExcel();
        }

        private void PrintStripButton_Click(object sender, EventArgs e)
        {
            PrintDoc();
        }

        private void AddNoteStripButton_Click(object sender, EventArgs e)
        {
            AddNoteClick();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formSettings.ShowDialog();
            LoadSettings();
        }

        private void ClearColortoolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditColor(true);
        }

        private void EditColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditColor(false);
        }

        private void EditColotoolStripMenuItem_Click(object sender, EventArgs e)
        {
           EditColor(false);
        }

        private void ColorStripButton_Click(object sender, EventArgs e)
        {
            EditColor(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FillList();
            timer1.Stop();
        }

        private void AddNoteMenuItem_Click(object sender, EventArgs e)
        {
            AddNoteClick();
        }

        private void DeleteStripButton_Click(object sender, EventArgs e)
        {
            DeleteColumn();
        }
        private void CutValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAuthorized)
            {
                if (MainDataGridView[ColumnSelect, RowSelect].Value != null)
                {
                    Clipboard.SetText(MainDataGridView[ColumnSelect, RowSelect].Value.ToString());
                    MainDataGridView[ColumnSelect, RowSelect].Value = "";
                }
            }
        }

        private void CopyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAuthorized)
            {
                if (MainDataGridView[ColumnSelect, RowSelect].Value != null)
                {
                    Clipboard.SetText(MainDataGridView[ColumnSelect, RowSelect].Value.ToString());
                }
            }
        }

        private void InsertValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAuthorized)
            {
                MainDataGridView[ColumnSelect, RowSelect].Value = Clipboard.GetText();
            }
        }
        #endregion


        ///<summary>
        ///Основные методы работы программы
        ///</summary>
        #region MainMethods
        public void InitializeEntry()
        {
            Properties.Settings MySettings = Properties.Settings.Default;
            if (MySettings.isLogin)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(MySettings.Password));
                string tempString = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                string String_SELECT = "SELECT Id, FIO FROM Lecturer WHERE Username = N'" + MySettings.Login + "' AND Password = '" + tempString + "'";
                DataTable Users = Dbw.QuerySelect(String_SELECT);
                ProfessorId = Users.Rows[0].Field<int>("Id");
                this.Text = Users.Rows[0].Field<string>("FIO");
                isAuthorized = true;
            }
            formSettings = new FormSettings(ProfessorId);
            LoadSettings();
        }

        public void Autorization()
        {
            GroupsOutTreeView.Nodes.Clear();
            MainDataGridView.Columns.Clear();
            NoteOutTextBox.Text = null;
            this.Text = null;
            FormAuthorization FA = new FormAuthorization();
            FA.ShowDialog();
            if (FA.DialogResult == DialogResult.OK)
            {
                isAuthorized = true;
                ProfessorId = FA.ProfessorId;
                this.Text = FA.PrfessorName;
                treevievFill();
            }
            FA.Dispose();
            formSettings =  new FormSettings(ProfessorId);
            LoadSettings();
        }

        public void treevievFill()
        {
            if (isAuthorized)
            {
                if (treeViewFillValue == 0)
                {
                    string String_SELECT = "SELECT Name, IdDiscipline FROM  Discipline WHERE [Discipline].[Lecturer] = " + ProfessorId + " ORDER BY Name ASC";
                    DataTable dt = Dbw.QuerySelect(String_SELECT);
                    int t = 0;
                    foreach (DataRow d in dt.Rows)
                    {
                        String_SELECT = "SELECT Groups.[Short Title], Groups.IdGroup FROM Groups INNER JOIN GroupsAndDisciplines ON Groups.IdGroup = GroupsAndDisciplines.IdGroup"
                            + " WHERE (GroupsAndDisciplines.IdDiscipline = " + d.Field<int>("IdDiscipline") + ")";
                        DataTable dt1 = Dbw.QuerySelect(String_SELECT);
                        if (dt1.Rows.Count > 0)
                        {
                            GroupsOutTreeView.Nodes.Add(d.Field<string>("Name"));
                            foreach (DataRow d1 in dt1.Rows)
                            {
                                GroupsOutTreeView.Nodes[t].Nodes.Add(d1.Field<string>("Short Title")).Tag = d1.Field<int>("IdGroup").ToString() + "," + d.Field<int>("IdDiscipline").ToString();
                            }
                            t++;
                        }
                    }
                }
                else
                {
                    string String_SELECT = "SELECT DISTINCT Groups.[Short Title], Groups.[IdGroup] FROM GroupsAndDisciplines INNER JOIN Discipline ON GroupsAndDisciplines.IdDiscipline = Discipline.IdDiscipline INNER JOIN Groups ON GroupsAndDisciplines.IdGroup = Groups.IdGroup WHERE(Discipline.Lecturer = 2) ORDER BY Groups.[Short Title] ASC";
                    DataTable dt = Dbw.QuerySelect(String_SELECT);
                    int t = 0;
                    foreach (DataRow d in dt.Rows)
                    {
                        String_SELECT = " SELECT Discipline.Name, GroupsAndDisciplines.IdDiscipline FROM GroupsAndDisciplines INNER JOIN Discipline ON GroupsAndDisciplines.IdDiscipline = Discipline.IdDiscipline WHERE(Discipline.Lecturer = " + ProfessorId + ") AND(GroupsAndDisciplines.IdGroup = " + d.Field<int>("IdGroup") + ") ORDER BY Discipline.Name ASC ";
                        DataTable dt1 = Dbw.QuerySelect(String_SELECT);
                        if (dt1.Rows.Count > 0)
                        {
                            GroupsOutTreeView.Nodes.Add(d.Field<string>("Short Title"));
                            foreach (DataRow d1 in dt1.Rows)
                            {
                                GroupsOutTreeView.Nodes[t].Nodes.Add(d1.Field<string>("Name")).Tag = d.Field<int>("IdGroup").ToString() + "," + d1.Field<int>("IdDiscipline").ToString();
                            }
                            t++;
                        }
                    }
                }
            }
        }

        public void StartFillList(Timer _timer)
        {
            t1 = GroupsOutTreeView.SelectedNode;
            if (t1.Nodes.Count == 0)
            {
                _timer.Start();
            }
        }
        public void FillList()
        {
            string TagString = (string)t1.Tag;
            DisciplineId = Convert.ToInt32(TagString.Substring(TagString.IndexOf(',') + 1)); ;
            string String_SELECT;
            GroupId = Convert.ToInt32(TagString.Substring(0, TagString.IndexOf(',')));
            MainDataGridView.DataSource = null;
            MainDataGridView.Columns.Clear();

            DataTable studentTable = new DataTable("studentTable");
            String_SELECT = "SELECT [Students].[StudentId] FROM  Students  WHERE [Students].[Group] = " + GroupId;
            studentTable = Dbw.QuerySelect(String_SELECT);

            String_SELECT = "SELECT distinct(Date) FROM  Results INNER JOIN Students ON Results.StudentId = Students.StudentId  WHERE "
                + "Results.IdDiscipline = " + DisciplineId +
                " AND [Students].[Group] = " + GroupId;
            DataTable dt1 = Dbw.QuerySelect(String_SELECT);
            foreach (DataRow row in dt1.Rows)
            {
                studentTable.Columns.Add(new DataColumn(row.Field<DateTime>("Date").ToString("d")));
            }
            Count = studentTable.Columns.Count;
            MainDataGridView.DataSource = studentTable;

            for (int i = 0; i < MainDataGridView.Rows.Count; i++)
            {
                for (int j = 1; j < MainDataGridView.Columns.Count; j++)
                {
                    DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[j].Name);
                    String_SELECT = "SELECT Mark,Remark FROM  Results  WHERE"
                        + "(StudentId = " + studentTable.Rows[i].Field<int>("StudentID")
                        + " AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                        + "' AND [Results].[IdDiscipline] = " + DisciplineId + ")";
                    DataTable dt2 = Dbw.QuerySelect(String_SELECT);
                    if (dt2.Rows.Count == 1)
                    {
                        string dsaas = dt2.Rows[0].Field<string>("Mark");
                        if (dsaas != null)
                            MainDataGridView[j, i].Value = dsaas;
                        if (dt2.Rows[0].Field<string>("Remark") != null)
                        {
                            Color color = Color.FromArgb(int.Parse(dt2.Rows[0].Field<string>("Remark")));
                            MainDataGridView[j, i].Style.BackColor = color;
                        }
                    }
                }
            }

            String_SELECT = "SELECT [NameAdditionalResults].[Full Name], [NameAdditionalResults].[Short Name], Id FROM NameAdditionalResults "
                + "WHERE  [NameAdditionalResults].IdDiscipline = " + DisciplineId
                + " AND [NameAdditionalResults].[Group] = "
                + GroupId + " ORDER BY Date ASC";
            DataTable dt3 = Dbw.QuerySelect(String_SELECT);
            if (dt3.Rows.Count != 0)
            {
                foreach (DataRow row in dt3.Rows)
                {
                    DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn();
                    dgc.Name = row.Field<int>("Id").ToString();
                    dgc.HeaderText = row.Field<string>("Short Name");
                    dgc.ToolTipText = row.Field<string>("Full Name");
                    dgc.Width = 25;
                    dgc.MinimumWidth = 25;
                    dgc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgc.HeaderCell.ContextMenuStrip = contextMenuTest;
                    dgc.ContextMenuStrip = contextMenuMarks;
                    MainDataGridView.Columns.Add(dgc);
                }
                for (int i = 0; i < MainDataGridView.Rows.Count; i++)
                {
                    for (int j = Count; j < MainDataGridView.Columns.Count; j++)
                    {
                        String_SELECT = "SELECT Result,Remark FROM  AdditionalResults "
                            + "WHERE (StudentId = " + studentTable.Rows[i].Field<int>("StudentId")
                            + " AND IdOfNameResult = "
                            + MainDataGridView.Columns[j].Name + ")";
                        DataTable dt4 = Dbw.QuerySelect(String_SELECT);
                        if (dt4.Rows.Count == 1)
                        {
                            string dsaas = dt4.Rows[0].Field<string>("Result");
                            if (dsaas != null)
                                MainDataGridView[j, i].Value = dsaas;
                            if (dt4.Rows[0].Field<string>("Remark") != null)
                            {
                                Color color = Color.FromArgb(int.Parse(dt4.Rows[0].Field<string>("Remark")));
                                MainDataGridView[j, i].Style.BackColor = color;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < MainDataGridView.Columns.Count; i++)
            {
                MainDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i < Count)
                    MainDataGridView.Columns[i].HeaderCell.ContextMenuStrip = contextMenuDate;
                MainDataGridView.Columns[i].Width = 25;
                MainDataGridView.Columns[i].MinimumWidth = 25;
            }

            MainDataGridView.Columns[0].Visible = false;
            MainDataGridView.Columns[0].ReadOnly = true;
            MainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            String_SELECT = "SELECT [Students].[FIO] FROM  Students  WHERE [Students].[Group] = " + GroupId;
            DataTable dt5 = Dbw.QuerySelect(String_SELECT);
            for (int i = 0; (i < MainDataGridView.Rows.Count); i++)
            {
                MainDataGridView.Rows[i].MinimumHeight = 25;
                MainDataGridView.Rows[i].HeaderCell.Value = (dt5.Rows[i].Field<string>("FIO")).ToString();
            }
            MainDataGridView.TopLeftHeaderCell.Value = "FIO";
            for (int i = 1; i < Count; i++)
            {
                MainDataGridView.Columns[i].ToolTipText = MainDataGridView.Columns[i].HeaderText;
                MainDataGridView.Columns[i].HeaderText = MainDataGridView.Columns[i].HeaderText.Substring(0, 5);
            }
            for (int i = 0; i < studentTable.Rows.Count; i++)
            {
                for (int j = 1; j < studentTable.Columns.Count; j++)
                {
                    MainDataGridView[j, i].ContextMenuStrip = contextMenuMarks;
                }
            }
        }

        public void LoadSettings()
        {
            int Tempcount = 0;
            ProffesorsRemarksDataGridView.Rows.Clear();  
            for (int i = 0; i < contextMenuMarks.Items.Count - 5; i++)
            {
                contextMenuMarks.Items[i].Click -= Tsb_Click;
                contextMenuMarks.Items.RemoveAt(i);
                i--;
                Tempcount++;
            }
            int temp = MainToolStrip.Items.Count-1;
            for (int i = MainToolStrip.Items.Count-1;i> (temp -Tempcount);i--)
            {
                MainToolStrip.Items[i].Click-= Tsb_Click;
                MainToolStrip.Items.RemoveAt(i);
            }
            if (formSettings.TreeViewFillValue == 1)
            {
                if (treeViewFillValue != 1)
                {
                    GroupsOutTreeView.Nodes.Clear();
                    treeViewFillValue = 1;
                    treevievFill();
                }
            }
            else
            {
                if (treeViewFillValue != 0)
                {
                    GroupsOutTreeView.Nodes.Clear();
                    treeViewFillValue = 0;
                    treevievFill();
                }
            }
            if (formSettings.Notes!=null)
            for (int i = 0; i < formSettings.Notes.Count; i++)
            {
                ProffesorsRemarksDataGridView.Rows.Add();
                this.ProffesorsRemarksDataGridView[0, i].Style.BackColor = Color.FromArgb(int.Parse(formSettings.Notes[i][0]));
                ProffesorsRemarksDataGridView[1, i].Value = formSettings.Notes[i][1];
            }
            for (int i = 0; i < formSettings.PrefItems.Count; i++)
            {
                contextMenuMarks.Items.Insert(i, new ToolStripMenuItem(formSettings.PrefItems[i].ToString()));
            }
          
            for (int i = 0; i < contextMenuMarks.Items.Count - 5; i++)
            {
                contextMenuMarks.Items[i].Click += Tsb_Click;
                ToolStripButton tsb = new ToolStripButton(contextMenuMarks.Items[i].Text);
                tsb.Click += Tsb_Click;
                MainToolStrip.Items.Add(tsb);
            }
        }


        public void AddNoteClick()
        {
            if (isAuthorized)
            {
                if (ColumnSelect > 0 && ColumnSelect < Count)
                    AddNote(true);
                else
                   if (ColumnSelect >= Count)
                    AddNote(false);
            }
        }
        public void AddNote(bool IsLecture)
        {
            if (isAuthorized)
            {
                DataTable tempDataTable = new DataTable();
                FormAddNote AddNoteForm = new FormAddNote();
                string String_SELECT = "";
                if (IsLecture)
                {
                    DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[ColumnSelect].Name);
                    String_SELECT = "SELECT Mark,Note,Remark FROM Results WHERE "
                       + " (StudentId = N'" + MainDataGridView[0, RowSelect].Value
                       + "' AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                       + "' AND IdDiscipline = " + DisciplineId + ")";

                    tempDataTable = Dbw.QuerySelect(String_SELECT);
                    if (tempDataTable.Rows.Count > 0)
                        AddNoteForm.NotetextBox.Text = tempDataTable.Rows[0].Field<string>("Note");
                }
                else
                {
                    String_SELECT = "SELECT Result,Note,Remark FROM AdditionalResults WHERE "
                        + "(StudentId = N'" + MainDataGridView[0, RowSelect].Value
                        + "' AND IdOfNameResult = " + MainDataGridView.Columns[ColumnSelect].Name + ")";
                    tempDataTable = Dbw.QuerySelect(String_SELECT);
                    if (tempDataTable.Rows.Count > 0)
                        AddNoteForm.NotetextBox.Text = tempDataTable.Rows[0].Field<string>("Note");
                }
                if (AddNoteForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (IsLecture)
                    {
                        DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[ColumnSelect].Name);
                        if (tempDataTable.Rows.Count == 1)
                        {
                            string String_Update = "UPDATE Results SET "
                                + "Note = N'" + AddNoteForm.NotetextBox.Text + "' "
                                + "WHERE StudentId = " + MainDataGridView[0, RowSelect].Value
                                + " AND  IdDiscipline = " + DisciplineId
                                + " AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year + "'";
                            Dbw.NonQuery(String_Update);
                        }
                        else if (tempDataTable.Rows.Count == 0)
                        {
                            string String_Insert = " INSERT INTO Results (StudentId, IdDiscipline, Date, Note) VALUES"
                                  + "(N'" + MainDataGridView[0, RowSelect].Value + "', "
                                  + DisciplineId
                                  + ", '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                                  + "', N'" + AddNoteForm.NotetextBox.Text + "')";
                            Dbw.NonQuery(String_Insert);
                        }
                    }
                    else
                    {
                        if (tempDataTable.Rows.Count == 1)
                        {
                            string String_Update = "UPDATE AdditionalResults SET "
                                  + "Note = N'" + AddNoteForm.NotetextBox.Text
                                  + "' WHERE StudentId = " + MainDataGridView[0, RowSelect].Value
                                  + " AND  IdOfNameResult = " + MainDataGridView.Columns[ColumnSelect].Name;
                            Dbw.NonQuery(String_Update);
                        }
                        else if (tempDataTable.Rows.Count == 0)
                        {
                            string String_Insert = " INSERT INTO AdditionalResults (IdOfNameResult, StudentId, Note) "
                                 + "VALUES(" + MainDataGridView.Columns[ColumnSelect].Name + ", "
                                 + MainDataGridView[0, RowSelect].Value
                                 + ", N'" + AddNoteForm.NotetextBox.Text + "')";
                            Dbw.NonQuery(String_Insert);
                        }
                    }
                }
            }
        }
        public void AddNewDate()
        {
            if (isAuthorized)
            {
                FormAddNewDate testDialog = new FormAddNewDate();
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        if (MainDataGridView.Columns.Contains(testDialog.dateTimePicker1.Text))
                        {
                            throw new DuplicateNameException();
                        }
                        DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn();
                        dgc.Name = testDialog.dateTimePicker1.Text;
                        dgc.HeaderText = testDialog.dateTimePicker1.Text.Substring(0, 5);
                        dgc.Width = 25;
                        dgc.MinimumWidth = 25;
                        dgc.SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgc.HeaderCell.ContextMenuStrip = contextMenuDate;
                        dgc.ContextMenuStrip = contextMenuMarks;
                        dgc.ToolTipText = testDialog.dateTimePicker1.Text;
                        for (int i = 1; i <= Count; i++)
                        {
                            if (i == Count)
                            {
                                Count++;
                                MainDataGridView.Columns.Insert(i, dgc);
                                break;
                            }
                            if ((DateTime)testDialog.dateTimePicker1.Value < DateTime.Parse(MainDataGridView.Columns[i].Name))
                            {
                                Count++;
                                MainDataGridView.Columns.Insert(i, dgc);
                                break;
                            }
                        }
                    }
                    catch (System.Data.DuplicateNameException)
                    {
                        MessageBox.Show("Введеная дата уже есть в ведомости");
                    }
                }
                testDialog.Dispose();
            }
        }
        public void AddNewTest()
        {
            if (isAuthorized)
            {
                FormAddNewTest testDialog = new FormAddNewTest();
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    DateTime tempDate = testDialog.dateTimePicker.Value;
                    string String_Insert = " INSERT INTO NameAdditionalResults (IdDiscipline, Date, [Full Name], [Short Name], [Group]) VALUES(" + DisciplineId + ", '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year + "', N'" + testDialog.FullNameTextBox.Text + "', N'" + testDialog.ShortNameTextBox.Text + "', " + GroupId + ")";
                    Dbw.NonQuery(String_Insert);
                    DataTable dt = new DataTable();
                    string String_SELECT = "SELECT Id,Date FROM NameAdditionalResults ORDER BY Id DESC";
                    dt = Dbw.QuerySelect(String_SELECT);
                    DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn();
                    dgc.Name = dt.Rows[0].Field<int>("Id").ToString();
                    dgc.HeaderText = testDialog.ShortNameTextBox.Text;
                    dgc.ToolTipText = testDialog.FullNameTextBox.Text;
                    dgc.Width = 25;
                    dgc.MinimumWidth = 25;
                    dgc.HeaderCell.ContextMenuStrip = contextMenuTest;
                    dgc.ContextMenuStrip = contextMenuMarks;
                    dgc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (Count != MainDataGridView.ColumnCount)
                    {
                        for (int i = Count; i < MainDataGridView.ColumnCount; i++)
                        {
                            String_SELECT = "SELECT Date FROM NameAdditionalResults WHERE Id = " + MainDataGridView.Columns[i].Name;
                            dt = Dbw.QuerySelect(String_SELECT);
                            if (i == MainDataGridView.ColumnCount - 1)
                            {
                                MainDataGridView.Columns.Insert(i + 1, dgc);
                                break;
                            }
                            DateTime temp = dt.Rows[0].Field<DateTime>("Date");
                            if (testDialog.dateTimePicker.Value < temp)
                            {
                                MainDataGridView.Columns.Insert(i, dgc);
                                break;
                            }
                        }
                    }
                    else MainDataGridView.Columns.Add(dgc);
                    dgc.Dispose();
                }
                testDialog.Dispose();
            }
        }
        public void AddRemark(bool IsLecture)
        {
            if (isAuthorized)
            {
                string String_SELECT = "";
                DataTable tempDataTable = new DataTable();
                if (IsLecture)
                {
                    DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[ColumnSelect].Name);
                    String_SELECT = "SELECT Mark,Note,Remark FROM Results"
                        + " WHERE (StudentId = N'" + MainDataGridView[0, RowSelect].Value
                        + "' AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                        + "' AND IdDiscipline = " + DisciplineId + ")";
                    tempDataTable = Dbw.QuerySelect(String_SELECT);
                    if (tempDataTable.Rows.Count == 1)
                    {
                        string String_Update = "UPDATE Results SET "
                            + "Remark = N'" + colorDialog1.Color.ToArgb()
                            + "' WHERE StudentId = " + MainDataGridView[0, RowSelect].Value
                            + " AND  IdDiscipline = " + DisciplineId + " AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year + "'";
                        Dbw.NonQuery(String_Update);
                    }
                    else if (tempDataTable.Rows.Count == 0)
                    {
                        string String_Insert = " INSERT INTO Results (StudentId, IdDiscipline, Date, Remark) "
                            + "VALUES(N'" + MainDataGridView[0, RowSelect].Value + "', " + DisciplineId + ", '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                            + "', N'" + colorDialog1.Color.ToArgb() + "')";
                        Dbw.NonQuery(String_Insert);
                    }
                }
                else
                {
                    String_SELECT = "SELECT Result,Note,Remark FROM AdditionalResults "
                        + "WHERE (StudentId = N'" + MainDataGridView[0, RowSelect].Value
                        + "' AND IdOfNameResult = " + MainDataGridView.Columns[ColumnSelect].Name + ")";
                    tempDataTable = Dbw.QuerySelect(String_SELECT);
                    if (tempDataTable.Rows.Count == 1)
                    {
                        string String_Update = "UPDATE AdditionalResults SET Remark = N'" + colorDialog1.Color.ToArgb()
                            + "' WHERE StudentId = " + MainDataGridView[0, RowSelect].Value
                            + " AND  IdOfNameResult = " + MainDataGridView.Columns[ColumnSelect].Name;
                        Dbw.NonQuery(String_Update);
                    }
                    else if (tempDataTable.Rows.Count == 0)
                    {
                        string String_Insert = " INSERT INTO AdditionalResults (IdOfNameResult, StudentId, Remark) VALUES("
                            + MainDataGridView.Columns[ColumnSelect].Name + ", " + MainDataGridView[0, RowSelect].Value
                            + ", N'" + colorDialog1.Color.ToArgb() + "')";
                        Dbw.NonQuery(String_Insert);
                    }
                }
            }
        }

 
        public void DeleteColumn()
        {
                if (ColumnSelect < Count && ColumnSelect > 0)
                      DeleteDate(ColumnSelect);
                else
                if (ColumnSelect >= Count && ColumnSelect > 0)
                       DeleteTest(ColumnSelect);
        }
        public void DeleteTest(int columnClick)
        {
            if (isAuthorized)
            {
                if (columnClick >= Count && columnClick > 0 )
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить запись " + MainDataGridView.Columns[columnClick].ToolTipText, "Внимание", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string String_SELECT = "DELETE FROM AdditionalResults WHERE(IdOfNameResult = " + MainDataGridView.Columns[columnClick].Name + ")";
                        Dbw.NonQuery(String_SELECT);
                        String_SELECT = "DELETE FROM NameAdditionalResults WHERE(Id = " + MainDataGridView.Columns[columnClick].Name + ")";
                        Dbw.NonQuery(String_SELECT);
                        MainDataGridView.Columns.RemoveAt(columnClick);
                    }
                }
            }
        }
        public void DeleteDate(int columnClick)
        {
            if (isAuthorized)
            {
                if (columnClick < Count && columnClick > 0)
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить запись " + MainDataGridView.Columns[columnClick].Name, "Внимание", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[columnClick].Name);
                        string String_Delete = "DELETE FROM Results FROM Results INNER JOIN Students ON Results.StudentId = Students.StudentId "
                            + " WHERE(Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                            + "' AND Students.[Group] = " + GroupId + ")";
                        Dbw.NonQuery(String_Delete);
                        MainDataGridView.Columns.RemoveAt(columnClick);
                        Count--;
                    }
                }
            }
        }

        public void EditColor(bool isClear)
        {
            if (isAuthorized)
            {
                if (MainDataGridView.ColumnCount > 0)
                {
                    bool isChanged = false;
                    if (!isClear)
                    {
                        if (colorDialog1.ShowDialog() == DialogResult.OK)
                        {
                            MainDataGridView[ColumnSelect, RowSelect].Style.BackColor = colorDialog1.Color;
                            isChanged = true;
                        }
                    }
                    else
                    {
                        MainDataGridView[ColumnSelect, RowSelect].Style.BackColor = Color.White;
                        isChanged = true;
                    }
                    if (isChanged)
                    {
                        if (ColumnSelect > 0 && ColumnSelect < Count)
                            AddRemark(true);
                        else
                                if (ColumnSelect >= Count)
                            AddRemark(false);
                    }
                }
            }
        }
        public void ExportExcel()
        {
            if (isAuthorized)
            {
                if (MainDataGridView.Rows.Count > 0)
                {
                    RegistryKey hkcr = Registry.ClassesRoot;
                    RegistryKey excelKey = hkcr.OpenSubKey("Excel.Application");
                    bool excelInstalled = excelKey == null ? false : true;
                    if (excelInstalled)
                    {
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                        Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                        //Книга.
                        ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                        //Таблица.
                        ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                        ExcelApp.Cells[1, 1] = MainDataGridView.TopLeftHeaderCell.Value;
                        (ExcelApp.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range).ColumnWidth = 30;
                        for (int j = 1; j < MainDataGridView.ColumnCount; j++)
                        {
                            ExcelApp.Cells[1, j + 1] = MainDataGridView.Columns[j].HeaderCell.Value;
                        }
                        for (int i = 0; i < MainDataGridView.Rows.Count; i++)
                        {
                            ExcelApp.Cells[i + 2, 1] = MainDataGridView.Rows[i].HeaderCell.Value;
                            for (int j = 1; j < MainDataGridView.ColumnCount; j++)
                            {
                                ExcelApp.Cells[i + 2, j + 1] = MainDataGridView.Rows[i].Cells[j].Value;
                                if (MainDataGridView.Rows[i].Cells[j].Style.BackColor.Name != "0")
                                {
                                    if (MainDataGridView.Rows[i].Cells[j].Style.BackColor.Name != "ffffffff")
                                        (ExcelApp.Cells[i + 2, j + 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = MainDataGridView.Rows[i].Cells[j].Style.BackColor;
                                }

                            }
                        }
                        //Вызываем нашу эксель.
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.ShowDialog();
                        if (sfd.FileName.Length > 0)
                            ExcelWorkBook.SaveAs(sfd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        ExcelApp.Quit();
                        ExcelApp = null;
                        ExcelWorkBook = null;
                        ExcelWorkSheet = null;
                        sfd.Dispose();
                        GC.Collect();
                    }
                    else
                        MessageBox.Show("Excel не установлен", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        public void PrintDoc()
        {
            if (isAuthorized)
            {
                if (MainDataGridView.Rows.Count > 0)
                {
                    MainDataGridView.ClearSelection();
                    PrintDialog dlg = new PrintDialog();
                    dlg.Document = printDocument1;
                    if (dlg.ShowDialog() != DialogResult.Cancel)
                    {
                        printDocument1.Print();
                        printDialog1.Dispose();
                        printDocument1.Dispose();
                    }
                }
            }
        }

        public void CellValueChanged(int columnIndex, int rowIndex)
        {
            if (rowIndex != -1 && columnIndex > 0)
            {
                if (columnIndex < Count)
                {
                    DataTable dt = new DataTable();
                    DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[columnIndex].Name);
                    string String_SELECT = "SELECT Mark FROM Results WHERE "
                        + "(StudentId = N'" + MainDataGridView[0, rowIndex].Value
                        + "' AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                        + "' AND IdDiscipline = " + DisciplineId + ")";
                    dt = Dbw.QuerySelect(String_SELECT);
                    if (dt.Rows.Count == 1)
                    {
                        string String_Update = "UPDATE Results SET "
                            + "Mark = N'" + MainDataGridView[columnIndex, rowIndex].Value
                            + "'  WHERE (StudentId = N'" + MainDataGridView[0, rowIndex].Value
                            + "' AND Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year + "')";
                        Dbw.NonQuery(String_Update);
                    }
                    else if (dt.Rows.Count == 0)
                    {
                        string String_Insert = " INSERT INTO Results (StudentId, IdDiscipline, Date, Mark) "
                            + "VALUES(N'" + MainDataGridView[0, rowIndex].Value
                            + "', " + DisciplineId + ", '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year
                            + "', N'" + MainDataGridView[columnIndex, rowIndex].Value + "')";
                        Dbw.NonQuery(String_Insert);
                    }
                }
                else
                    if (columnIndex >= Count)
                {
                    string String_SELECT = "SELECT Result FROM AdditionalResults "
                        + "WHERE (StudentId = N'" + MainDataGridView[0, rowIndex].Value
                        + "' AND IdOfNameResult = " + MainDataGridView.Columns[columnIndex].Name + ")";
                    DataTable dt1 = Dbw.QuerySelect(String_SELECT);
                    if (dt1.Rows.Count == 1)
                    {
                        string String_Update = "UPDATE AdditionalResults SET "
                             + "Result = N'" + MainDataGridView[columnIndex, rowIndex].Value
                             + "'  WHERE (StudentId = N'" + MainDataGridView[0, rowIndex].Value
                             + "' AND IdOfNameResult = " + MainDataGridView.Columns[columnIndex].Name + ")";
                        Dbw.NonQuery(String_Update);
                    }
                    else if (dt1.Rows.Count == 0)
                    {
                        string String_Insert = " INSERT INTO AdditionalResults (IdOfNameResult, StudentId, Result)"
                              + "VALUES(" + MainDataGridView.Columns[columnIndex].Name
                              + ", " + MainDataGridView[0, rowIndex].Value
                              + ", N'" + MainDataGridView[columnIndex, rowIndex].Value + "')";
                        Dbw.NonQuery(String_Insert);
                    }
                }
            }
        }
        public void CellClicNoteView(int selectColumn, int selectRow, bool isHeaderColumnClick)
        {
            if (!isHeaderColumnClick)
            {
                ColumnSelect = selectColumn;
                RowSelect = selectRow;
            }
            if (selectColumn > 0 && selectColumn < Count)
            {
                DateTime tempDate = DateTime.Parse(MainDataGridView.Columns[selectColumn].Name);
                NoteOutTextBox.Text = "Дата: " + tempDate.ToShortDateString() + Environment.NewLine;
                string String_SELECT;
                if (isHeaderColumnClick)
                    String_SELECT = "SELECT FIO, Note FROM Results INNER JOIN Students ON Results.StudentId = Students.StudentId  WHERE (Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year + "' AND Students.[Group] = " + GroupId + ") ORDER BY Students.FIO ASC"; //добавить чтобы выводились даты по указзному предмету
                else
                {
                    String_SELECT = "SELECT FIO, Note FROM Results INNER JOIN Students ON Results.StudentId = Students.StudentId  WHERE (Date = '" + tempDate.Month + "." + tempDate.Day + "." + tempDate.Year + "' AND Results.StudentId = " + MainDataGridView[0, selectRow].Value + ") ORDER BY FIO DESC"; //добавить чтобы выводились даты по указзному предмету
                }
                DataTable tempTable = Dbw.QuerySelect(String_SELECT);
                foreach (DataRow row in tempTable.Rows)
                {
                    string temp = row.Field<string>("Note");
                    if (temp != null && temp.Length > 0)
                    {
                        NoteOutTextBox.Text += row.Field<string>("FIO") + Environment.NewLine;
                        NoteOutTextBox.Text += temp + Environment.NewLine + Environment.NewLine;
                    }
                }
            }
            if (selectColumn >= Count && selectColumn < MainDataGridView.ColumnCount)
            {
                NoteOutTextBox.Text = MainDataGridView.Columns[selectColumn].ToolTipText + Environment.NewLine;
                string String_SELECT = "SELECT  Date FROM NameAdditionalResults WHERE NameAdditionalResults.Id = " + MainDataGridView.Columns[selectColumn].Name;
                DataTable tempTable = Dbw.QuerySelect(String_SELECT);
                NoteOutTextBox.Text += "Дата: " + tempTable.Rows[0].Field<DateTime>("Date").ToShortDateString() + Environment.NewLine;
                if (isHeaderColumnClick)
                    String_SELECT = "SELECT Note, Date, FIO FROM AdditionalResults INNER JOIN NameAdditionalResults ON AdditionalResults.IdOfNameResult = NameAdditionalResults.Id INNER JOIN Students ON AdditionalResults.StudentId = Students.StudentId WHERE ( NameAdditionalResults.[Group] = " + GroupId + " AND AdditionalResults.IdOfNameResult = " + MainDataGridView.Columns[selectColumn].Name + ") ORDER BY Students.FIO ASC"; //добавить чтобы выводились даты по указзному предмету
                else
                {
                    String_SELECT = "SELECT Note, Date ,FIO FROM  AdditionalResults INNER JOIN NameAdditionalResults ON AdditionalResults.IdOfNameResult = NameAdditionalResults.Id INNER JOIN Students ON AdditionalResults.StudentId = Students.StudentId WHERE(AdditionalResults.StudentId = " + MainDataGridView[0, selectRow].Value + " AND AdditionalResults.IdOfNameResult = " + MainDataGridView.Columns[selectColumn].Name + ")"; //добавить чтобы выводились даты по указзному предмету
                }
                tempTable = Dbw.QuerySelect(String_SELECT);
                if (tempTable.Rows.Count > 0)
                {
                    foreach (DataRow row in tempTable.Rows)
                    {
                        string temp = row.Field<string>("Note");
                        if (temp != null && temp.Length > 0)
                        {
                            NoteOutTextBox.Text += row.Field<string>("FIO") + Environment.NewLine;
                            NoteOutTextBox.Text += temp + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
            }
        }
        public void CellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 1)
            {
                e.PaintBackground(e.ClipBounds, true);
                Rectangle rect = this.MainDataGridView.GetColumnDisplayRectangle(e.ColumnIndex, true);
                Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), new Font("Microsoft Sans Serif", 8));
                if (this.MainDataGridView.ColumnHeadersHeight < titleSize.Width)
                    this.MainDataGridView.ColumnHeadersHeight = titleSize.Width;

                e.Graphics.TranslateTransform(0, titleSize.Width);
                e.Graphics.RotateTransform(-90.0F);
                e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));

                e.Graphics.RotateTransform(90.0F);
                e.Graphics.TranslateTransform(0, -titleSize.Width);
                e.Handled = true;
            }
            if (e.RowIndex == RowSelect && e.ColumnIndex == ColumnSelect)
            {
                e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            }
        }

        public void col_row_select(MouseEventArgs e)
        {
            var h = MainDataGridView.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                if (h.Type == DataGridViewHitTestType.ColumnHeader)
                {
                    ColumnClick = h.ColumnIndex;
                }
                else
                if (h.Type == DataGridViewHitTestType.Cell)
                {
                    ColumnSelect = h.ColumnIndex;
                    RowSelect = h.RowIndex;
                    MainDataGridView[h.ColumnIndex, h.RowIndex].Selected = true;
                }
            }
        }

        public void ResetParams()
        {
            ProfessorId = -1;
            DisciplineId = 1;
            GroupId = 0;
            treeViewFillValue = -1;
            Count = 0;
            ColumnSelect = -1;
            RowSelect = -1;
            ColumnClick = -1;
            pageCount = 0;
            col_print_wait = 1;
            row_print_wait = 0;
            isAuthorized = false;
            ProffesorsRemarksDataGridView.Rows.Clear();
            MainDataGridView.DataSource = null;
        }

        Size size()
        {
            int X = 0;
            int Y = 0;
            X += MainDataGridView.TopLeftHeaderCell.Size.Width;
            for (int i = 1; i < MainDataGridView.ColumnCount; i++)
            {
                X += MainDataGridView.Columns[i].HeaderCell.Size.Width;
            }
            Y += MainDataGridView.TopLeftHeaderCell.Size.Height;
            for (int i = 0; i < MainDataGridView.RowCount; i++)
            {
                Y += MainDataGridView.Rows[i].Height;
            }
            return new Size(X, Y);
        }
        public void PrintList(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (e.MarginBounds.Right < size().Width)
                e.HasMorePages = true;
            Graphics g = e.Graphics;
            int x = 50;
            int y = 50;
            int cell_height = 25;
            int colCount = MainDataGridView.ColumnCount;
            int rowCount = MainDataGridView.RowCount;
            Font font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            int[] widthC = new int[colCount];
            int current_col = col_print_wait;
            int current_row = row_print_wait;
            while (current_col < colCount)
            {
                widthC[current_col] = 25;
                current_col++;
            }
            while (current_row < rowCount)
            {
                while (current_col < colCount)
                {
                    if (MainDataGridView[current_col, current_row].Value != null)
                        if ((int)g.MeasureString(MainDataGridView[current_col, current_row].Value.ToString(), font).Width > widthC[current_col])
                        {
                            widthC[current_col] = (int)g.MeasureString(MainDataGridView[current_col, current_row].Value.ToString(), font).Width;  /*dataGridView1[current_col,current_row].Size.Width;*/ /*(int)g.MeasureString(dataGridView1[current_col, current_row].Value, font).Width;*/
                        }
                    current_col++;
                }
                current_col = col_print_wait;
                current_row++;
            }
            current_col = col_print_wait;
            current_row = row_print_wait;
            string value = "";
            int width = widthC[current_col];
            int height = MainDataGridView[current_col, current_row].Size.Height;
            Rectangle cell_border;
            SolidBrush brush = new SolidBrush(Color.Black);
            value = MainDataGridView.TopLeftHeaderCell.Value.ToString();
            cell_border = new Rectangle(x, y, MainDataGridView.TopLeftHeaderCell.Size.Width, MainDataGridView.Columns[current_col].HeaderCell.Size.Height);
            g.DrawRectangle(new Pen(Color.Black), cell_border);
            g.DrawString(value, font, brush, x, y);
            x += MainDataGridView.TopLeftHeaderCell.Size.Width;
            while (current_col < colCount)
            {
                if (e.MarginBounds.Right - 25 < x)
                {
                    break;
                }
                width = widthC[current_col];
                cell_height = MainDataGridView.Columns[current_col].HeaderCell.Size.Height;
                cell_border = new Rectangle(x, y, width, cell_height);
                value = MainDataGridView.Columns[current_col].HeaderText.ToString();
                g.DrawRectangle(new Pen(Color.Black), cell_border);
                g.RotateTransform(-90.0F);
                g.DrawString(value, new Font("Tahoma", 8, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, -(y + cell_height), x);
                g.RotateTransform(90.0F);
                x += widthC[current_col];
                current_col++;
            }
            x = 50;
            y += cell_height;
            current_col = col_print_wait;
            current_row = row_print_wait;
            while (current_row < rowCount)
            {
                value = MainDataGridView.Rows[current_row].HeaderCell.Value.ToString();
                if (value.Length > 18)
                    value = value.Substring(0, 18) + "...";
                cell_border = new Rectangle(x, y, MainDataGridView.TopLeftHeaderCell.Size.Width, height);
                g.DrawRectangle(new Pen(Color.Black), cell_border);
                g.DrawString(value, font, brush, x, y);
                x += MainDataGridView.TopLeftHeaderCell.Size.Width;
                while (current_col < colCount)
                {
                    if (e.MarginBounds.Right - 25 < x)
                    {
                        col_print_wait = current_col;
                        break;
                    }
                    width = widthC[current_col];
                    cell_height = MainDataGridView[current_col, current_row].Size.Height;
                    cell_border = new Rectangle(x, y, width, height);
                    if (MainDataGridView[current_col, current_row].Value != null)
                        value = MainDataGridView[current_col, current_row].Value.ToString();
                    else
                        value = "";
                    if (MainDataGridView[current_col, current_row].Style.BackColor.Name != "0" && MainDataGridView[current_col, current_row].Style.BackColor != Color.White)
                    {
                        g.FillRectangle(new SolidBrush(MainDataGridView[current_col, current_row].Style.BackColor), cell_border);
                    }
                    g.DrawRectangle(new Pen(Color.Black), cell_border);
                    g.DrawString(value, font, brush, x, y);
                    x += widthC[current_col];
                    current_col++;
                }
                if (pageCount == 1)
                {
                    current_col = col_print_wait;
                }
                else
                    current_col = 1;
                current_row++;
                x = 50;
                y += cell_height;
            }
            if (pageCount == 1)
            {
                col_print_wait = 1;
                row_print_wait = 0;
                pageCount = 0;
                e.HasMorePages = false;
                GC.Collect();
            }
            if (e.HasMorePages)
                pageCount++;
        }

        #endregion

        private void AboutProgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProg aboutprog = new AboutProg();
            aboutprog.ShowDialog();
        }


    }
}
