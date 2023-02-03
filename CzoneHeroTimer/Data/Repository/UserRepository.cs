using CzoneHeroTimer.Data.RepositoryModels;
using CzoneHeroTimer.Modules;
using CzoneHeroTimer.Properties;
using SQLite;

namespace CzoneHeroTimer.Data.Repository
{
    public class UserRepository: BaseRepository<User>
    {
        protected string path;
        public UserRepository() { path = Application.StartupPath + @"data\hero.db"; }
    


        public void Add(User entity)
        {
            UserModel emp = new UserModel();
            emp.Id = entity.Id;
            emp.DepartmentId = entity.DepartmentId;
            emp.UserRole = entity.UserRole;
            emp.Username = entity.Username;
            emp.Password = entity.Password;
            
            var _context = new SQLiteConnection(path);
            _context.Insert(emp);
            _context.Close();
        }

        public void AddAll(List<User> entities)
        {
            var _context = new SQLiteConnection(path);
            foreach (var entity in entities)
            {
                UserModel emp = new UserModel();
                emp.Id = entity.Id;
                emp.DepartmentId = entity.DepartmentId;
                emp.UserRole = entity.UserRole;
                emp.Username = entity.Username;
                emp.Password = entity.Password;
                _context.Insert(emp);
            }
            _context.Close();
        }

        public void Update(User entity)
        {
            UserModel emp = new UserModel();
            emp.Id = entity.Id;
            emp.DepartmentId = entity.DepartmentId;
            emp.UserRole = entity.UserRole;
            emp.Username = entity.Username;
            emp.Password = entity.Password;
            var _context = new SQLiteConnection(path);
            _context.Update(emp);
            _context.Close();
        }

        public void Delete(User entity)
        {
            UserModel emp = new UserModel();
            emp.Id = entity.Id;
            emp.DepartmentId = entity.DepartmentId;
            emp.UserRole = entity.UserRole;
            emp.Username = entity.Username;
            emp.Password = entity.Password;
            var _context = new SQLiteConnection(path);
            _context.Delete(emp);
            _context.Close();
        }
        public List<User> getAll(String query = "Select * From UserModel")
        {
            var db = new SQLiteConnection(path);
            List<UserModel> list = db.Query<UserModel>(query);
            List<User> users = new List<User>();
            foreach (var entity in list)
            {
                User emp= new User();
                emp.Id = entity.Id;
                emp.DepartmentId = entity.DepartmentId;
                emp.UserRole = entity.UserRole;
                emp.Username = entity.Username;
                emp.Password = entity.Password;
                users.Add(emp);
            }
            db.Close();
            return users;
        }
    }
}
