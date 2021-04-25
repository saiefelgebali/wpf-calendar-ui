using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalendarLibrary;

namespace CalendarUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime currentDateTime = DateTime.Now;
        Month currentMonth;
        string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

        public MainWindow()
        {
            InitializeComponent();
            UpdateCalendar();
            nextButton.Click += NextButton_Click;
            previousButton.Click += PreviousButton_Click;

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentDateTime = currentDateTime.Subtract(TimeSpan.FromDays(currentMonth.NumOfDays));
            ClearCalendar();
            UpdateCalendar();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentDateTime = currentDateTime.AddMonths(1);
            ClearCalendar();
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            currentMonth = new Month(currentDateTime);
            titleTextBox.Text = string.Format("{0}, {1}", MonthNames[currentMonth.MonthNumber - 1], currentMonth.Year);
            for (int day = 0; day < currentMonth.DaysList.Count; day++)
            {
                Day currentDay = currentMonth.DaysList[day];
                DayUI currentDayUI = new DayUI(currentDay);
                Border currentBorder = currentDayUI.border;
                calendarGrid.Children.Add(currentBorder);
            }
        }

        private void ClearCalendar()
        {
            calendarGrid.Children.RemoveRange(7, calendarGrid.Children.Count);
        }
    }
}
