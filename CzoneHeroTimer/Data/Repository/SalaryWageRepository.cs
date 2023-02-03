using CzoneHeroTimer.Data.RepositoryModels;
using CzoneHeroTimer.Modules;
using CzoneHeroTimer.Properties;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Data.Repository
{
    public class SalaryWageRepository : BaseRepository<SalaryWage>
    {
        protected string path;
        public SalaryWageRepository() {
            path = Application.StartupPath + @"data\hero.db";
        }


        public void Add(SalaryWage entity)
        {
            SalaryModel emp = new SalaryModel();
            emp.Id = entity.Id;
            emp.EmployeeId = entity.EmployeeId;
            emp.StartDate = entity.StartDate;
            emp.Wage = entity.Wage;
            emp.EmploymentType = entity.EmploymentType;

            var _context = new SQLiteConnection(path);
            _context.Insert(emp);
            _context.Close();
        }

        public void AddAll(List<SalaryWage> entities)
        {
            var _context = new SQLiteConnection(path);
            foreach (var entity in entities)
            {
                SalaryModel emp = new SalaryModel();
                emp.Id = entity.Id;
                emp.EmployeeId = entity.EmployeeId;
                emp.StartDate = entity.StartDate;
                emp.Wage = entity.Wage;
                emp.EmploymentType = entity.EmploymentType;
                _context.Insert(emp);
            }
            _context.Close();
        }

        public void Update(SalaryWage entity)
        {
            SalaryModel emp = new SalaryModel();
            emp.Id = entity.Id;
            emp.EmployeeId = entity.EmployeeId;
            emp.StartDate = entity.StartDate;
            emp.Wage = entity.Wage;
            emp.EmploymentType = entity.EmploymentType;
            var _context = new SQLiteConnection(path);
            _context.Update(emp);
            _context.Close();
        }

        public void Delete(SalaryWage entity)
        {
            SalaryModel emp = new SalaryModel();
            emp.Id = entity.Id;
            emp.EmployeeId = entity.EmployeeId;
            emp.StartDate = entity.StartDate;
            emp.Wage = entity.Wage;
            emp.EmploymentType = entity.EmploymentType;
            var _context = new SQLiteConnection(path);
            _context.Delete(emp);
            _context.Close();
        }

        public List<SalaryWage> getAll(String query = "Select * From SalaryModel")
        {
            var db = new SQLiteConnection(path);
            List<SalaryModel> list = db.Query<SalaryModel>(query);
            List<SalaryWage> result = new List<SalaryWage>();
            foreach (var entity in list)
            {
                SalaryWage salaryWage= new SalaryWage();
                salaryWage.Id = entity.Id;
                salaryWage.EmployeeId = entity.EmployeeId;
                salaryWage.StartDate = entity.StartDate;
                salaryWage.Wage = entity.Wage;
                salaryWage.EmploymentType = entity.EmploymentType;

                result.Add(salaryWage);
            }
            db.Close();
            return result;
        }
    }
}
