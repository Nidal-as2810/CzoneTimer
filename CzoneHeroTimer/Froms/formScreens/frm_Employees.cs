using CzoneHeroTimer.Data.Repository;
using CzoneHeroTimer.Modules;
using System.Data;

namespace CzoneHeroTimer.Froms.formScreens
{
    public partial class frm_Employees : frm_Default
    {
        public frm_Employees()
        {
            InitializeComponent();
            onload();
            Reload();
        }
         private void onload()
        {

            DepartmentRepository db = new DepartmentRepository();


            tbDepartment.DataSource = db.getAll();
            tbDepartment.DisplayMember = "Name";
            tbDepartment.ValueMember = "Id";
        }
        List<Employee> employees;
        Employee employee;
        SalaryWage salary;

        public override void New()
        {
            employee = new Employee();
            salary = new SalaryWage();

            tbName.Text = employee.Name;
            tbEnroll.Text = employee.EnrollNumber.ToString();
            tbDateStart.Value = DateTime.Now;
            tbDateEnd.Value = DateTime.Now;
            tbWage.Text = "";
            tbWageDate.Value=DateTime.Now;
            tbWageType.SelectedIndex = 0;


            dgvWage.DataSource = employee.wages;
            base.New();
        }
        public override void Save()
        {
            employee.Name = tbName.Text;
            employee.EmploymentStartDate = tbDateStart.Value.Date;
            employee.EmploymentEndDate = tbDateEnd.Value.Date;
            employee.EnrollNumber = int.Parse(tbEnroll.Text);
            employee.DepartmentId = (int)tbDepartment.SelectedValue;

            EmployeeRepository db = new EmployeeRepository();
            if (employee.Id == 0)
                db.Add(employee);
            else
                db.Update(employee);
            base.Save();
        }
        public override void Delete()
        {
            MessageBox.Show("Delete is not valid!");
        }
        public override void Reload()
        {
            EmployeeRepository db = new EmployeeRepository();

            employees = db.getAll();

            SalaryWageRepository wage = new SalaryWageRepository();
            List<SalaryWage> wages = wage.getAll();

            foreach(var employee in employees)
            {
                employee.wages = wages.Where(w => w.EmployeeId == employee.Id).ToList();
            }

            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.DataSource = employees;

            base.Reload();
        }

        private void tbWage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(tbWage.Text!="" && tbWageType.SelectedIndex>0 && employee.Id > 0)
                {
                    salary = new SalaryWage();
                    salary.StartDate = tbWageDate.Value.Date;
                    salary.EmployeeId = employee.Id;
                    salary.Wage = int.Parse(tbWage.Text);
                    salary.EmploymentType = tbWageType.Text;

                    SalaryWageRepository db = new SalaryWageRepository();
                    db.Add(salary);
                    Reload();
                }
            }
        }

        private void dgvEmployees_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvEmployees.CurrentRow.Cells[0].Value.ToString());

            employee = employees.FirstOrDefault(x => x.Id == id);

            tbName.Text = employee.Name;
            tbName.Text = employee.Name;
            tbEnroll.Text = employee.EnrollNumber.ToString();
            tbDateStart.Value = employee.EmploymentStartDate;
            tbDateEnd.Value = employee.EmploymentEndDate;
            tbDepartment.SelectedValue = employee.DepartmentId;

            dgvWage.AutoGenerateColumns = false;
            dgvWage.DataSource = employee.wages;
        }

        private void tbEnroll_Leave(object sender, EventArgs e)
        {

            int enroll = int.Parse(tbEnroll.Text);
            Employee testExist = employees.FirstOrDefault(x => x.EnrollNumber == enroll);
            if(testExist != null)
                if (testExist.Id != employee.Id)
                {
                    MessageBox.Show("You can't use same enroll number for several employees!");
                    tbEnroll.SelectAll();
                    tbEnroll.Focus();
                }
                    
        }
    }
}
