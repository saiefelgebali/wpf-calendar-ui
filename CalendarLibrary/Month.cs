using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CalendarLibrary
{
    public class Month
    {
        public int MonthNumber { get; private set; }
        public int Year { get; private set; }
        public List<Day> DaysList { get; private set; }

        public int NumOfDays
        {
            get
            {
                return DateTime.DaysInMonth(Year, MonthNumber);
            }
        }

        public Month(DateTime currenDateTime)
        {
            MonthNumber = currenDateTime.Month;
            Year = currenDateTime.Year;
            DaysList = new List<Day>();
            SetupDaysList();
            SetupDaysGrid();
        }

        private void SetupDaysList()
        {
            for (int day = 1; day <= NumOfDays; day++)
            {
                DaysList.Add(new Day { Date = new DateTime(Year, MonthNumber, day) });
            }
        }

        private void SetupDaysGrid()
        {
            // 7x7 Grid. Rows begin from Row 1, Colums begin from column 0.
            int initialRow = 1;
            int maxRow = 7;
            int maxColumn = 7;

            // First day will be placed depending on what DayOfWeek it represents. 1-7, SUN-SAT
            DayOfWeek firstDayOfWeek = DaysList[0].Date.DayOfWeek;
            int startingColumn = (int)firstDayOfWeek;

            int dayNumber = 0;
            for (int rowNumber = initialRow; rowNumber < maxRow; rowNumber++)
            {
                for (int columnNumber = startingColumn; columnNumber < maxColumn; columnNumber++)
                {
                    if (dayNumber < NumOfDays)
                    {
                        DaysList[dayNumber].Row = rowNumber;
                        DaysList[dayNumber].Column = columnNumber;
                        dayNumber++;
                    }
                    else
                    {
                        columnNumber = maxColumn;
                        rowNumber = maxRow;
                        break;
                    }
                    startingColumn = 0;
                }
            }
        }
    }
}
