using CzoneHeroTimer.Data.RepositoryModels;
using SQLite;

namespace CzoneHeroTimer.Modules
{
    public class Employee:EmployeeModel
    {
        
        public List<SalaryWage> wages { get; set; }
        public List<WorkingHour> workingHours { get; set; }
    }
}