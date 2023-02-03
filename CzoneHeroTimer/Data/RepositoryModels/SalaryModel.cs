using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Data.RepositoryModels
{
    public class SalaryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string EmploymentType { get; set; }
        public double Wage { get; set; }

        public int EmployeeId { get; set; }
    }
}
