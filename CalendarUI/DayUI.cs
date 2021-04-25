using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CalendarLibrary;

namespace CalendarUI
{
    class DayUI
    {
        SolidColorBrush defaultBorderColor = Brushes.Black;
        SolidColorBrush defaultTagColor = Brushes.Red;
        public Border border = new Border();
        private TextBlock textBlock = new TextBlock();
        private Day day;

        public DayUI(Day _day)
        {
            day = _day;
            textBlock = new TextBlock();
            border = new Border();
            FormatBorder();
            FormatTextBlock();

            Grid.SetRow(border, day.Row);
            Grid.SetColumn(border, day.Column);

            textBlock.Text = day.Date.Day.ToString();
            
            border.Child = textBlock;

            border.MouseEnter += Border_MouseEnter;
            border.MouseLeave += Border_MouseLeave;
            border.MouseLeftButtonDown += Border_MouseLeftButtonDown;
        }

        private void FormatTextBlock()
        {
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlock.VerticalAlignment = VerticalAlignment.Stretch;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 24;
            textBlock.FontWeight = FontWeights.Thin;
            if (day.IsTagged)
            {
                textBlock.Foreground = Brushes.White;
                textBlock.Background = defaultTagColor;
            }
        }

        private void FormatBorder()
        {
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.VerticalAlignment = VerticalAlignment.Stretch;
            border.BorderBrush = defaultBorderColor;
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            border.BorderThickness = new Thickness(2);
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!day.IsTagged)
            {
                border.BorderThickness = new Thickness(0);
            }
            else
            {
                border.BorderThickness = new Thickness(1);
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            day.IsTagged = true;
            FormatTextBlock();
        }
    }
}
