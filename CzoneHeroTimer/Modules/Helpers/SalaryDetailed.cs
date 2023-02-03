using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Modules.Helpers
{
    public class SalaryDetailed
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public double NormalHours { get; set; }
        public double OverTimeTwoHours { get; set; }
        public double OverTimeMoreThanTwoHours { get; set; }

        public SalaryDetailed(DateTime date)
        {
            this.Date = date;
            this.Day = Date.ToString("dddd");
        }

        public SalaryDetailed(WorkingHour workingHour)
        {
            getDetailedHours(workingHour);
        }

        private void getDetailedHours(WorkingHour workingHour)
        {
            this.Id=workingHour.Id;
            this.Date = workingHour.Date.Date;
            this.Day = Date.ToString("dddd");
            this.TimeIn = workingHour.TimeIn;
            this.TimeOut = workingHour.TimeOut;
            if (this.TimeIn.Year < 2010 || this.TimeOut.Year < 2010)
            {
                return;
            }
            else
            {
                if (this.TimeOut < this.TimeIn)
                {
                    return;
                }
                else
                {
                    TimeSpan ts = this.TimeOut - this.TimeIn;
                    double totalHours = ts.TotalHours;

                    if (totalHours > 8)
                    {
                        this.NormalHours = 8;
                        totalHours -= this.NormalHours;
                        if (totalHours > 2)
                        {
                            this.OverTimeTwoHours = 2;
                            this.OverTimeMoreThanTwoHours = totalHours - this.OverTimeTwoHours;
                        }
                        else
                        {
                            this.OverTimeTwoHours = totalHours;
                            this.OverTimeMoreThanTwoHours = 0;
                        }
                    }
                    else
                    {
                        this.NormalHours = totalHours;
                        this.OverTimeTwoHours = 0;
                        this.OverTimeMoreThanTwoHours = 0;
                    }
                }
            }
        }
    }
}
