using SQLite;

namespace CzoneHeroTimer.Modules
{
    public class WorkingHour
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EnrollNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string DateId { get; set; }
    }
}