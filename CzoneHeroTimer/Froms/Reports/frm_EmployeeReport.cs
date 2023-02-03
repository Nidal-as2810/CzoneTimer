using CzoneHeroTimer.Data.Repository;
using CzoneHeroTimer.Modules;
using CzoneHeroTimer.Modules.Helpers;
using System.Data;

namespace CzoneHeroTimer.Froms.Reports
{
    public partial class frm_EmployeeReport : Form
    {
        public frm_EmployeeReport()
        {
            InitializeComponent();
            getAllEmployees();
            tbDate.Value = DateTime.Now.AddMonths(-1);
        }

        EmployeeSalary employeeSalary;
        List<Employee> employees;

        private void getAllEmployees()
        {
            EmployeeRepository db = new EmployeeRepository();

            string[] includes = { "wages"};
            employees = db.getAll();

            SalaryWageRepository salary = new SalaryWageRepository();
            List<SalaryWage> wages = salary.getAll();

            foreach(Employee employee in employees)
            {
                employee.wages=wages.Where(w=>w.Id==employee.Id).ToList();
            }

            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.DataSource = employees;
        }

        private void getReport()
        {
            int index = dgvEmployees.CurrentRow.Index;
            Employee emp = employees[index];
            EnrollNumber = emp.EnrollNumber;
            SalaryWage wage = emp.wages.Where(x => x.StartDate <= tbDate.Value).Max();

            
            WorkingHoursRepository db = new WorkingHoursRepository();

            List<WorkingHour> hours=db.getAll().Where(x => x.Date.Month == tbDate.Value.Month &&
                                                           x.Date.Year == tbDate.Value.Year &&
                                                           x.EnrollNumber==emp.EnrollNumber).ToList();
            employeeSalary = new EmployeeSalary(emp, wage, hours);

            salaryDetailedShow(employeeSalary.salaryDetails);
        }
        List<SalaryDetailed> monthShow;
        private void salaryDetailedShow(List<SalaryDetailed> salaries)
        {
            DateTime day = new DateTime(tbDate.Value.Year, tbDate.Value.Month, 1);
            DateTime lastDay = day.AddMonths(1).AddDays(-1);
            monthShow=new List<SalaryDetailed>();
            for(int i = 0; i < lastDay.Day; i++)
            {
                SalaryDetailed detailed=new SalaryDetailed(day.AddDays(i));
                if (salaries.FirstOrDefault(x => x.Date == detailed.Date) != null)
                {
                    detailed = salaries.FirstOrDefault(x => x.Date == detailed.Date);
                }

                monthShow.Add(detailed);
            }

            dgvReport.AutoGenerateColumns = false;
            dgvReport.DataSource = monthShow;
        }
        private void dgvEmployees_Click(object sender, EventArgs e)
        {
            getReport();
        }
        int EnrollNumber;
        private void dgvReport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            WorkingHoursRepository db = new WorkingHoursRepository();

            WorkingHour hour;
            int index = dgvReport.CurrentRow.Index;

            SalaryDetailed salary = monthShow[index];
            TimeSpan tsTimeIn = DateTime.Parse(dgvReport.CurrentRow.Cells[3].Value.ToString()).TimeOfDay - DateTime.Now.Date.TimeOfDay;
            TimeSpan tsTimeOut = DateTime.Parse(dgvReport.CurrentRow.Cells[4].Value.ToString()).TimeOfDay - DateTime.Now.Date.TimeOfDay;


            if (salary.Id == 0)
            {
                hour = new WorkingHour();
                hour.EnrollNumber = EnrollNumber;
                hour.DateId = hour.Id.ToString() + hour.Date.Date.ToString();
            }
            else
            {
                hour = db.getAll().First(x => x.Id == salary.Id);
            }

            hour.Date= salary.Date;
            hour.TimeIn = salary.Date.Date.Add(tsTimeIn);
            hour.TimeOut = salary.Date.Date.Add(tsTimeOut);
            
            
            if (hour.Id==0)
                db.Add(hour);
            else
                db.Update(hour);
            getReport();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintEmployee printEmployee = new PrintEmployee(e, tbDate.Value, employeeSalary, monthShow);
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
