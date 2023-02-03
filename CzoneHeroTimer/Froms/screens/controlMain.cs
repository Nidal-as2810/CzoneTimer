using CzoneHeroTimer.Data;
using CzoneHeroTimer.Data.Repository;
using CzoneHeroTimer.Froms.formScreens;
using CzoneHeroTimer.Froms.Reports;
using CzoneHeroTimer.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CzoneHeroTimer.Froms.screens
{
    public partial class controlMain : UserControl
    {
        public controlMain()
        {
            InitializeComponent();
        }


        List<WorkingHour> workingHours;
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            workingHours=new List<WorkingHour>();

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains(".accdb") || ofd.FileName.Contains(".mdb"))
                {
                    string connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName;
                    importFromAccess(connect);
                }
                else
                    importFromFile(ofd.FileName);

                saveAll();
                workingHours.Clear();
            }
        }

        private void importFromFile(string fileName)
        {
            List<string> data = new List<string>();
            data = File.ReadAllLines(fileName).ToList();

            foreach(string line in data)
            {
                char h = '	';
                string tab = h.ToString();
                string myLine=line.Trim();
                string[] myData = myLine.Split(tab);

                WorkingHour working = new WorkingHour();
                working.DateId = myData[0]+DateTime.Parse(myData[1]).Date.ToString("dd/MM/yy");
                working.Date = DateTime.Parse(myData[1]).Date;
                working.EnrollNumber = int.Parse(myData[0]);

                sortTime(working, myData[3], DateTime.Parse(myData[1]), "file");
            }
        }

        private void sortTime(WorkingHour working, string printType, DateTime printTime, string fileType)
        {
            
            WorkingHour hour = workingHours.FirstOrDefault(x => x.DateId == working.DateId);
            if (hour == null)
            {
                hour = working;
                if (fileType == "file")
                {
                    switch (printType)
                    {
                        case "0":
                            hour.TimeIn = printTime;
                            break;
                        case "1":
                            hour.TimeOut = printTime;
                            break;
                    }
                }
                else
                {
                    switch (printType)
                    {
                        case "I":
                            hour.TimeIn = printTime;
                            break;
                        case "O":
                            hour.TimeOut = printTime;
                            break;
                    }
                }
                workingHours.Add(hour);
                //TimeSpan ts = hour.TimeOut.TimeOfDay - hour.TimeIn.TimeOfDay;
                //MessageBox.Show(ts.Hours.ToString());
                //MessageBox.Show(hour.TimeOut.ToString());
                //MessageBox.Show(hour.TimeIn.ToString());
            }
            else
            {
                int index=workingHours.FindIndex(x=>x.DateId==working.DateId);
                if (fileType == "file")
                {
                    switch (printType)
                    {
                        case "0":
                            workingHours[index].TimeIn = printTime;
                            break;
                        case "1":
                            workingHours[index].TimeOut = printTime;
                            break;
                    }
                }
                else
                {
                    switch (printType)
                    {
                        case "I":
                            workingHours[index].TimeIn = printTime;
                            break;
                        case "O":
                            workingHours[index].TimeOut = printTime;
                            break;
                    }
                }
                //TimeSpan ts = workingHours[index].TimeOut.TimeOfDay - workingHours[index].TimeIn.TimeOfDay;
                //MessageBox.Show(ts.Hours.ToString());
                //MessageBox.Show(workingHours[index].TimeOut.ToString());
                //MessageBox.Show(workingHours[index].TimeIn.ToString());
            }
        }

        private void importFromAccess(string connect)
        {
            OleDbConnection con = new OleDbConnection(connect);
            OleDbCommand cmd=new OleDbCommand("Select * From CHECKINOUT",con);
            DataTable dt = new DataTable();

            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                WorkingHour working = new WorkingHour();
                working.DateId = dt.Rows[i][0].ToString() + DateTime.Parse(dt.Rows[i][1].ToString()).Date.ToString("dd/MM/yy");
                working.EnrollNumber= int.Parse(dt.Rows[i][0].ToString());
                working.Date= DateTime.Parse(dt.Rows[i][1].ToString()).Date;

                sortTime(working, dt.Rows[i][2].ToString(), DateTime.Parse(dt.Rows[i][1].ToString()), "access");
            }
        }

        private void saveAll()
        {
            var db = new WorkingHoursRepository();
            db.AddAll(workingHours);
            MessageBox.Show("Data saved succefully");
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_Departments();
            frm.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_Users();
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_Employees();
            frm.Show();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_EmployeeReport();
            frm.ShowDialog();
        }

        private void departmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_DepartmentReport();
            frm.ShowDialog();
        }
    }
}
