using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CalendarLibrary
{
    public class Day
    {
        public DateTime Date { get; set; }
        public bool IsTagged { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
