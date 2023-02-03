using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using CzoneHeroTimer.Modules.Helpers;

namespace CzoneHeroTimer.Froms.Reports
{
    internal class PrintEmployee
    {
       
        public PrintEmployee(System.Drawing.Printing.PrintPageEventArgs e, DateTime currentDate, EmployeeSalary employeeSalary, List<SalaryDetailed> monthShow)
        {
            this.PrintReport(e, currentDate, employeeSalary, monthShow);
        }

        public void PrintReport(System.Drawing.Printing.PrintPageEventArgs e,DateTime currentDate, EmployeeSalary employeeSalary, List<SalaryDetailed> monthShow)
        {
            Font headers = new Font("Calibri", 16, FontStyle.Bold);
            Font titles = new Font("Calibri", 12);
            Font normal = new Font("Calibri", 10);
            Brush headersBrush = Brushes.DarkSlateGray;
            Brush brush = Brushes.Black;


            float margin = 20;
            float marginTop = 20;
            Bitmap logo = new Bitmap(Properties.Resources.czone);
            Rectangle logoRectangle = new Rectangle((int)margin, (int)marginTop, 150, 150);
            Rectangle rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 70);

            e.Graphics.DrawRectangle(Pens.Silver, rectangle);
            e.Graphics.DrawImage(logo, logoRectangle);
            e.Graphics.DrawString("Hero Time Transactions", new Font("Calibri", 9), Brushes.Silver, margin + 15, marginTop + 80);

            string Title = "Work Report Of " + currentDate.ToString("MM - yyyy");
            e.Graphics.DrawString(Title, headers, headersBrush, centerPoint(margin, marginTop, rectangle.Width, 70, measureString(Title, headers, e)));

            marginTop += 120;
            rectangle = new Rectangle((int)margin, (int)marginTop, 300, 111);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            rectangle = new Rectangle((int)margin + 1, (int)marginTop + 1, 298, 108);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            e.Graphics.DrawString("Name: ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 15);
            e.Graphics.DrawString(employeeSalary.Name, titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 10);
            e.Graphics.DrawString("Enroll Number : ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 40);
            e.Graphics.DrawString(employeeSalary.EnrollNumber.ToString(), titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 35);
            e.Graphics.DrawString("Wage : ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 65);
            e.Graphics.DrawString(employeeSalary.Wage.ToString(), titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 60);
            e.Graphics.DrawString("Employment Type : ", new Font("Calibri", 9), Brushes.Black, margin + 5, marginTop + 90);
            e.Graphics.DrawString(employeeSalary.EmploymentType, titles, headersBrush, margin + 5 + measureString("Employment Type : ", new Font("Calibri", 9), e).Width, marginTop + 85);

            rectangle = new Rectangle((int)(e.PageBounds.Width - margin - 300), (int)marginTop, 300, 111);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            rectangle = new Rectangle((int)(e.PageBounds.Width - margin - 298), (int)marginTop + 1, 296, 108);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            float marginForLeftRect = (e.PageBounds.Width - margin - 300) + 5;
            e.Graphics.DrawString("Normal Hours : ", new Font("Calibri", 9), Brushes.Black, marginForLeftRect, marginTop + 15);
            e.Graphics.DrawString(employeeSalary.NormalHours.ToString("n2"), titles, headersBrush, marginForLeftRect + 5 + measureString("Normal Hours : ", new Font("Calibri", 9), e).Width, marginTop + 10);
            e.Graphics.DrawString("Hours 125% : ", new Font("Calibri", 9), Brushes.Black, marginForLeftRect, marginTop + 40);
            e.Graphics.DrawString(employeeSalary.TwoHoursOver.ToString("n2"), titles, headersBrush, marginForLeftRect + 5 + measureString("Normal Hours : ", new Font("Calibri", 9), e).Width, marginTop + 35);
            e.Graphics.DrawString("Hours 150% : ", new Font("Calibri", 9), Brushes.Black, marginForLeftRect, marginTop + 65);
            e.Graphics.DrawString(employeeSalary.OverHours.ToString("n2"), titles, headersBrush, marginForLeftRect + 5 + measureString("Normal Hours : ", new Font("Calibri", 9), e).Width, marginTop + 60);
            e.Graphics.DrawString("Total Hours : ", new Font("Calibri", 9), Brushes.Black, marginForLeftRect, marginTop + 90);
            e.Graphics.DrawString(employeeSalary.TotalHours.ToString("n2"), titles, headersBrush, marginForLeftRect + 5 + measureString("Normal Hours : ", new Font("Calibri", 9), e).Width, marginTop + 85);

            marginTop += 120;
            rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 40);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);


            float colWidth = rectangle.Width / 8;
            float col1 = margin;
            float col2 = col1 + colWidth;
            float col3 = col2 + colWidth;
            float col4 = col3 + colWidth;
            float col5 = col4 + colWidth;
            float col6 = col5 + colWidth;
            float col7 = col6 + colWidth;
            float col8 = col7 + colWidth;

            e.Graphics.DrawLine(Pens.Silver, new Point((int)col2, (int)marginTop), new Point((int)col2, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col3, (int)marginTop), new Point((int)col3, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col4, (int)marginTop), new Point((int)col4, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col5, (int)marginTop), new Point((int)col5, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col6, (int)marginTop), new Point((int)col6, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col7, (int)marginTop), new Point((int)col7, (int)marginTop + (int)rectangle.Height));
            e.Graphics.DrawLine(Pens.Silver, new Point((int)col8, (int)marginTop), new Point((int)col8, (int)marginTop + (int)rectangle.Height));

            e.Graphics.DrawString("Date", normal, brush, centerPoint(col1, marginTop, colWidth, rectangle.Height, measureString("Date", normal, e)));
            e.Graphics.DrawString("Day", normal, brush, centerPoint(col2, marginTop, colWidth, rectangle.Height, measureString("Day", normal, e)));
            e.Graphics.DrawString("Time In", normal, brush, centerPoint(col3, marginTop, colWidth, rectangle.Height, measureString("Time In", normal, e)));
            e.Graphics.DrawString("Time Out", normal, brush, centerPoint(col4, marginTop, colWidth, rectangle.Height, measureString("Time Out", normal, e)));
            e.Graphics.DrawString("100%", normal, brush, centerPoint(col5, marginTop, colWidth, rectangle.Height, measureString("100%", normal, e)));
            e.Graphics.DrawString("125%", normal, brush, centerPoint(col6, marginTop, colWidth, rectangle.Height, measureString("125%", normal, e)));
            e.Graphics.DrawString("150%", normal, brush, centerPoint(col7, marginTop, colWidth, rectangle.Height, measureString("150%", normal, e)));
            e.Graphics.DrawString("Total", normal, brush, centerPoint(col8, marginTop, colWidth, rectangle.Height, measureString("Total", normal, e)));

            int counter = 0;
            foreach (SalaryDetailed salaryDay in monthShow)
            {
                counter++;
                marginTop += rectangle.Height;
                rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 23);
                if (counter % 2 == 0)
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
                e.Graphics.DrawRectangle(Pens.Silver, rectangle);

                e.Graphics.DrawLine(Pens.Silver, new Point((int)col2, (int)marginTop), new Point((int)col2, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col3, (int)marginTop), new Point((int)col3, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col4, (int)marginTop), new Point((int)col4, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col5, (int)marginTop), new Point((int)col5, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col6, (int)marginTop), new Point((int)col6, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col7, (int)marginTop), new Point((int)col7, (int)marginTop + (int)rectangle.Height));
                e.Graphics.DrawLine(Pens.Silver, new Point((int)col8, (int)marginTop), new Point((int)col8, (int)marginTop + (int)rectangle.Height));

                e.Graphics.DrawString(salaryDay.Date.ToString("dd/MM"), normal, brush, new PointF(col1 + 5, marginTop + 5));
                e.Graphics.DrawString(salaryDay.Date.ToString("dddd"), normal, brush, new PointF(col2 + 5, marginTop + 5));
                if (salaryDay.TimeIn.Hour > 0)
                {
                    e.Graphics.DrawString(salaryDay.TimeIn.ToString("HH:mm"), normal, brush, new PointF(col3 + 5, marginTop + 5));
                    e.Graphics.DrawString(salaryDay.TimeOut.ToString("HH:mm"), normal, brush, new PointF(col4 + 5, marginTop + 5));
                    e.Graphics.DrawString(salaryDay.NormalHours.ToString("n2"), normal, brush, new PointF(col5 + 5, marginTop + 5));
                    e.Graphics.DrawString(salaryDay.OverTimeTwoHours.ToString("n2"), normal, brush, new PointF(col6 + 5, marginTop + 5));
                    e.Graphics.DrawString(salaryDay.OverTimeMoreThanTwoHours.ToString("n2"), normal, brush, new PointF(col7 + 5, marginTop + 5));
                    e.Graphics.DrawString((salaryDay.NormalHours + salaryDay.OverTimeTwoHours + salaryDay.OverTimeMoreThanTwoHours).ToString("n2"), normal, brush, new PointF(col8 + 5, marginTop + 5));
                }
            }

            marginTop += rectangle.Height + 20;
            rectangle = new Rectangle((int)margin, (int)marginTop, (int)(e.PageBounds.Width - margin * 2), 30);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
            e.Graphics.DrawRectangle(Pens.Silver, rectangle);

            e.Graphics.DrawString("Salary: " + employeeSalary.Salary.ToString("n2") + " ₪", titles, headersBrush, centerPoint(margin, marginTop, rectangle.Width, rectangle.Height, measureString("Salary: " + employeeSalary.Salary.ToString("n2") + " ₪", titles, e)));
        }

        private SizeF measureString(string text, Font f, System.Drawing.Printing.PrintPageEventArgs e)
        {
            return e.Graphics.MeasureString(text, f);
        }
        private PointF centerPoint(float x, float y, float width, float height, SizeF obj)
        {
            return new PointF((width - obj.Width) / 2 + x, (height - obj.Height) / 2 + y);
        }
    }
}
