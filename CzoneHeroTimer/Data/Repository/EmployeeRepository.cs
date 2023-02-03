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
    public class EmployeeRepository
    {
        protected string path;
        public EmployeeRepository() { path = Application.StartupPath + @"data\hero.db"; }
       

        public void Add(Employee entity)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.Id = entity.Id;
            emp.DepartmentId = entity.DepartmentId;
            emp.Name = entity.Name;
            emp.EnrollNumber = entity.EnrollNumber;
            emp.EmploymentStartDate = entity.EmploymentStartDate;
            emp.EmploymentEndDate = entity.EmploymentEndDate;

            var _context = new SQLiteConnection(path);
            _context.Insert(emp);
            _context.Close();
        }

        public void AddAll(List<Employee> entities)
        {
            var _context = new SQLiteConnection(path);
            foreach (var entity in entities)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.Id = entity.Id;
                emp.DepartmentId = entity.DepartmentId;
                emp.Name = entity.Name;
                emp.EnrollNumber = entity.EnrollNumber;
                emp.EmploymentStartDate = entity.EmploymentStartDate;
                emp.EmploymentEndDate = entity.EmploymentEndDate;
                _context.Insert(emp);
            }
            _context.Close();
        }

        public void Update(Employee entity)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.Id = entity.Id;
            emp.DepartmentId = entity.DepartmentId;
            emp.Name = entity.Name;
            emp.EnrollNumber = entity.EnrollNumber;
            emp.EmploymentStartDate = entity.EmploymentStartDate;
            emp.EmploymentEndDate = entity.EmploymentEndDate;
            var _context = new SQLiteConnection(path);
            _context.Update(emp);
            _context.Close();
        }

        public void Delete(Employee entity)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.Id = entity.Id;
            emp.DepartmentId = entity.DepartmentId;
            emp.Name = entity.Name;
            emp.EnrollNumber = entity.EnrollNumber;
            emp.EmploymentStartDate = entity.EmploymentStartDate;
            emp.EmploymentEndDate = entity.EmploymentEndDate;
            var _context = new SQLiteConnection(path);
            _context.Delete(emp);
            _context.Close();
        }

        public List<Employee> getAll(string query = "Select * From EmployeeModel")
        {
            var db = new SQLiteConnection(path);
            List<EmployeeModel> list = db.Query<EmployeeModel>(query);
            List<Employee> result = new List<Employee>();
            foreach (var entity in list)
            {
                Employee emp = new Employee();
                emp.Id = entity.Id;
                emp.DepartmentId = entity.DepartmentId;
                emp.Name = entity.Name;
                emp.EnrollNumber = entity.EnrollNumber;
                emp.EmploymentStartDate = entity.EmploymentStartDate;
                emp.EmploymentEndDate = entity.EmploymentEndDate;

                result.Add(emp);
            }
            db.Close();
            return result;
        }
    }
}
