using CzoneHeroTimer.Data.RepositoryModels;
using CzoneHeroTimer.Modules;
using CzoneHeroTimer.Properties;
using SQLite;

namespace CzoneHeroTimer.Data.Repository
{
    public class DepartmentRepository
    {
         string path;
        public DepartmentRepository()
        {
            path = Application.StartupPath + @"data\hero.db";
        }



        public void Add(Department entity)
        {
            Departmentmodule ent=new Departmentmodule();
            ent.Name = entity.Name;

            var _context = new SQLiteConnection(path);
            _context.Insert(ent);
            _context.Close();
        }

        public void AddAll(List<Department> entities)
        {
            
            var _context = new SQLiteConnection(path);
            foreach (var entity in entities)
            {
                Departmentmodule ent = new Departmentmodule();
                ent.Name = entity.Name;
                ent.Id= entity.Id;
                _context.Insert(ent);
            }
            _context.Close();
        }

        public void Update(Department entity)
        {
            Departmentmodule ent = new Departmentmodule();
            ent.Name = entity.Name;
            ent.Id = entity.Id;
            var _context = new SQLiteConnection(path);
            _context.Update(ent);
            _context.Close();
        }

        public void Delete(Department entity)
        {
            Departmentmodule ent = new Departmentmodule();
            ent.Name = entity.Name;
            ent.Id = entity.Id;
            var _context = new SQLiteConnection(path);
            _context.Delete(ent);
            _context.Close();
        }

        public List<Department> getAll(string query= "Select * From Departmentmodule")
        {
            var db = new SQLiteConnection(path);
            List<Departmentmodule> list = db.Query<Departmentmodule>(query);
            List<Department> result = new List<Department>();
            foreach (var item in list)
            {
                Department department= new Department();
                department.Name = item.Name;
                department.Id = item.Id;
                result.Add(department);
            }
            db.Close();
            return result;
        }
    }
}
