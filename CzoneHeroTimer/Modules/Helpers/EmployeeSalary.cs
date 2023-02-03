using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Modules.Helpers
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public int EnrollNumber { get; set; }
        public string Name { get; set; }
        public double Wage { get; set; }
        public string EmploymentType { get; set; }
        public double TotalHours { get; set; } = 0;
        public double NormalHours { get; set; }= 0;
        public double TwoHoursOver { get; set; } = 0;
        public double OverHours { get; set; } = 0;
        public double Salary { get; set; }
        public List<SalaryDetailed> salaryDetails { get; set; }

        public EmployeeSalary(Employee employee, SalaryWage wage, List<WorkingHour> workingHours)
        {
            try
            {
                this.Id = employee.Id;
                this.EnrollNumber = employee.EnrollNumber;
                this.Name = employee.Name;
                this.Wage = wage.Wage;
                this.EmploymentType = wage.EmploymentType;
                this.salaryDetails = getTotals(workingHours);
            }catch(Exception ex)
            {
                MessageBox.Show("Something went Wrong ^_^");
            }
        }

        private List<SalaryDetailed> getTotals(List<WorkingHour> workingHours)
        {
            List < SalaryDetailed > salaries=new List<SalaryDetailed> ();
            foreach (WorkingHour workingHour in workingHours)
            {
                SalaryDetailed salary = new SalaryDetailed(workingHour);
                if (salaries.FirstOrDefault(s => s.Date == salary.Date) == null)
                {
                    salaries.Add(salary);
                    this.NormalHours += salary.NormalHours;
                    this.TwoHoursOver += salary.OverTimeTwoHours;
                    this.OverHours += salary.OverTimeMoreThanTwoHours;
                    this.TotalHours += salary.NormalHours + salary.OverTimeTwoHours + salary.OverTimeMoreThanTwoHours;
                    
                    switch (this.EmploymentType)
                    {
                        case "Hourly":
                            this.Salary += (salary.NormalHours * this.Wage) + (salary.OverTimeTwoHours * 1.25) + (salary.OverTimeMoreThanTwoHours * 1.5);
                            break;
                        case "Daily":
                            this.Salary += this.Wage;
                            break;
                        case "Monthly":
                            this.Salary = this.Wage;
                            break;
                    }
                }
            }
            return salaries;
        }

        
    }
}
