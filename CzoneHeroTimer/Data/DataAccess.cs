using CzoneHeroTimer.Data.RepositoryModels;
using CzoneHeroTimer.Modules;
using SQLite;

namespace CzoneHeroTimer.Data
{
    public class DataAccess
    {

        string path;

        public DataAccess()
        {
            path = Application.StartupPath + @"data\hero.db"; 
            createTables();
        }

        private void createTables()
        {
            if(!File.Exists(path))
            {
                var db = new SQLiteConnection(path);
                db.CreateTable<UserModel>();
                db.CreateTable<Departmentmodule>();
                db.CreateTable<EmployeeModel>();
                db.CreateTable<SalaryModel>();
                db.CreateTable<WorkingHour>();
                db.Close();
            }
        }

    }
}
