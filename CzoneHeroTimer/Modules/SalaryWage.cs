using CzoneHeroTimer.Data.RepositoryModels;
using SQLite;

namespace CzoneHeroTimer.Modules
{
    public class SalaryWage:SalaryModel
    {
        
        public Employee Employee { get; set; }
    }
}