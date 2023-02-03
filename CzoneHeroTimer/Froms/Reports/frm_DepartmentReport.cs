using CzoneHeroTimer.Data.Repository;
using CzoneHeroTimer.Modules;
using CzoneHeroTimer.Modules.Helpers;
using System.Data;
using System.Drawing.Printing;

namespace CzoneHeroTimer.Froms.Reports
{
    public partial class frm_DepartmentReport : Form
    {
        public frm_DepartmentReport()
        {
            InitializeComponent();
            getDepartments();
        }

        List<Department> departments;

        public void getDepartments()
        {
            DepartmentRepository db= new DepartmentRepository();
            departments = db.getAll();

            dgvDepartments.AutoGenerateColumns = false;
            dgvDepartments.DataSource = departments;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            List<Department> search = departments.Where(d => d.Name.Contains(tbSearch.Text)).ToList();
            dgvDepartments.AutoGenerateColumns=false;
            dgvDepartments.DataSource = search;

            if (tbSearch.Text == "")
                dgvDepartments.DataSource = departments;
        }

        List<EmployeeSalary> employeesSalary = new List<EmployeeSalary>();

        private void getEmployeesHours(int departmentId)
        {

            EmployeeRepository db= new EmployeeRepository();

            
            List<Employee> employees = db.getAll().Where(x=>x.DepartmentId==departmentId && 
                                                                    x.EmploymentEndDate>=dateTimePicker1.Value &&
                                                                    x.EmploymentStartDate<=dateTimePicker1.Value).ToList();

            SalaryWageRepository salaryWageRepository= new SalaryWageRepository();
            List<SalaryWage> salaryWages = salaryWageRepository.getAll();
            foreach(var employee in employees)
            {
                employee.wages= salaryWages.Where(s=>s.Id==employee.Id).ToList();
            }

            employeesSalary =new List<EmployeeSalary>();
            try
            {
                foreach (Employee employee in employees)
                {
                    SalaryWage wage = employee.wages.Where(x => x.StartDate < dateTimePicker1.Value).Max();
                    WorkingHoursRepository dbW = new WorkingHoursRepository();
                    List<WorkingHour> workingHours = dbW.getAll().Where(x => x.Date.Month == dateTimePicker1.Value.Month &&
                                                                                  x.Date.Year == dateTimePicker1.Value.Year
                                                                                  && x.EnrollNumber == employee.EnrollNumber).ToList();

                    EmployeeSalary employeeSalary = new EmployeeSalary(employee, wage, workingHours);
                    if(employeeSalary.TotalHours>0)
                        employeesSalary.Add(employeeSalary);
                }
            }
            catch { MessageBox.Show("No Data!!"); }
            dgvReport.AutoGenerateColumns = false;
            dgvReport.DataSource=employeesSalary;
        }

        private void dgvDepartments_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvDepartments.CurrentRow.Cells[0].Value.ToString());
            getEmployeesHours(id);
        }

        private List<SalaryDetailed> salaryDetailedShow(List<SalaryDetailed> salaries)
        {
            List<SalaryDetailed> monthShow;
            DateTime day = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);
            DateTime lastDay = day.AddMonths(1).AddDays(-1);
            monthShow = new List<SalaryDetailed>();
            for (int i = 0; i < lastDay.Day; i++)
            {
                SalaryDetailed detailed = new SalaryDetailed(day.AddDays(i));
                if (salaries.FirstOrDefault(x => x.Date == detailed.Date) != null)
                {
                    detailed = salaries.FirstOrDefault(x => x.Date == detailed.Date);
                }

                monthShow.Add(detailed);
            }
            return monthShow;
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                index=e.RowIndex;
                PrintPreviewDialog print = new PrintPreviewDialog();
                print.Document=printDocument1;

                ((Form)print).WindowState = FormWindowState.Maximized;
                if (print.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }
        int index;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            EmployeeSalary salary = employeesSalary[index];
            salary.salaryDetails = salaryDetailedShow(salary.salaryDetails);
            PrintEmployee printEmployee = new PrintEmployee(e, dateTimePicker1.Value, salary, salary.salaryDetails);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog print = new PrintPreviewDialog();
            print.Document = printDocument2;

            ((Form)print).WindowState = FormWindowState.Maximized;
            if (print.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headers = new Font("Calibri", 16, FontStyle.Bold);
            Font titles = new Font("Calibri", 12);
            Font normal = new Font("Calibri", 10);
            Brush headersBrush = Brushes.DarkSlateGray;
            Brush brush = Brushes.Black;


            float margin = 20;
            float marginTop = 20;
            Bitmap logo = new Bitmap(Properties.Resources.czone);
            Rectangle logoRectangle = new Rectangle((int)margin, (int)marginTop, 150, 150);
            Rectangle rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 70);

            e.Graphics.DrawRectangle(Pens.Silver, rectangle);
            e.Graphics.DrawImage(logo, logoRectangle);
            e.Graphics.DrawString("Hero Time Transactions", new Font("Calibri", 9), Brushes.Silver, margin + 15, marginTop + 80);

            string Title = "Work Report Of " + dateTimePicker1.Value.ToString("MM - yyyy");
            e.Graphics.DrawString(Title, headers, headersBrush, centerPoint(margin, marginTop, rectangle.Width, 70, measureString(Title, headers, e)));

            marginTop += 120;
            rectangle = new Rectangle((int)margin, (int)marginTop, 300, 111);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            rectangle = new Rectangle((int)margin + 1, (int)marginTop + 1, 298, 108);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            e.Graphics.DrawString("Department: ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 15);
            e.Graphics.DrawString(departments[dgvDepartments.CurrentRow.Index].Name, titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 10);
            e.Graphics.DrawString("Total Employees : ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 40);
            e.Graphics.DrawString(employeesSalary.Count.ToString(), titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 35);
            e.Graphics.DrawString("Total Salaries : ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 65);
            e.Graphics.DrawString(countTotal(employeesSalary, "Salary").ToString("c2"), titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 60);
            e.Graphics.DrawString("Total Hours : ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 90);
            e.Graphics.DrawString(countTotal(employeesSalary, "Hours").ToString("n2")+" Hours", titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 85);

            marginTop += 120;
            rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 40);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);


            float colWidth = rectangle.Width / 4;
            float col1 = margin;
            float col2 = col1 + colWidth;
            float col3 = col2 + colWidth;
            float col4 = col3 + colWidth;
            

            e.Graphics.DrawLine(Pens.Silver, new Point((int)col2, (int)marginTop), new Point((int)col2, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col3, (int)marginTop), new Point((int)col3, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col4, (int)marginTop), new Point((int)col4, (int)marginTop + (int)rectangle.Height));
            

            e.Graphics.DrawString("Name", normal, brush, centerPoint(col1, marginTop, colWidth, rectangle.Height, measureString("Date", normal, e)));
            e.Graphics.DrawString("Wage", normal, brush, centerPoint(col2, marginTop, colWidth, rectangle.Height, measureString("Day", normal, e)));
            e.Graphics.DrawString("Total Hours", normal, brush, centerPoint(col3, marginTop, colWidth, rectangle.Height, measureString("Time In", normal, e)));
            e.Graphics.DrawString("Salary", normal, brush, centerPoint(col4, marginTop, colWidth, rectangle.Height, measureString("Time Out", normal, e)));

            int counter = 0;
            for( int i=0;i< employeesSalary.Count;i++)
            {
                EmployeeSalary salaryDay=employeesSalary[i];

                counter++;
                marginTop += rectangle.Height;
                rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 23);
                if (counter % 2 == 0)
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
                e.Graphics.DrawRectangle(Pens.Silver, rectangle);

                e.Graphics.DrawLine(Pens.Silver, new Point((int)col2, (int)marginTop), new Point((int)col2, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col3, (int)marginTop), new Point((int)col3, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col4, (int)marginTop), new Point((int)col4, (int)marginTop + (int)rectangle.Height));
                

                e.Graphics.DrawString(salaryDay.Name, normal, brush, new PointF(col1 + 5, marginTop + 5));
                e.Graphics.DrawString(salaryDay.Wage.ToString("n2"), normal, brush, new PointF(col2 + 5, marginTop + 5));
                e.Graphics.DrawString(salaryDay.TotalHours.ToString("n2"), normal, brush, new PointF(col3 + 5, marginTop + 5));
                e.Graphics.DrawString(salaryDay.Salary.ToString("n2"), normal, brush, new PointF(col4 + 5, marginTop + 5));
            }
        }

        private double countTotal(List<EmployeeSalary> employeesSalary,string TotalType)
        {
            double total = 0;
            foreach(EmployeeSalary employee in employeesSalary)
            {
                if (TotalType == "Salary")
                    total += employee.Salary;
                else
                    total += employee.TotalHours;
            }
            return total;
        }

        private SizeF measureString(string text, Font f, System.Drawing.Printing.PrintPageEventArgs e)
        {
            return e.Graphics.MeasureString(text, f);
        }
        private PointF centerPoint(float x, float y, float width, float height, SizeF obj)
        {
            return new PointF((width - obj.Width) / 2 + x, (height - obj.Height) / 2 + y);
        }
    }
}
