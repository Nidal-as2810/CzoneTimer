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
    public class WorkingHoursRepository: BaseRepository<WorkingHour>
    {
        public WorkingHoursRepository() { }
        public List<WorkingHour> getAll(String query = "Select * From WorkingHour")
        {

            var db = new SQLiteConnection(Application.StartupPath + @"data\hero.db");
            List<WorkingHour> list = db.Query<WorkingHour>(query);
            db.Close();
            return list;
        }
    }
}
