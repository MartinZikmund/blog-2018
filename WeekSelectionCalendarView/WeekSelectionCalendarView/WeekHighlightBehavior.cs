using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace WeekSelectionCalendarView
{
public class WeekHighlightBehavior : Behavior
{
    public CalendarView CalendarControl
    {
        get { return (CalendarView)GetValue(CalendarProperty); }
        set { SetValue(CalendarProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Calendar.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CalendarProperty =
        DependencyProperty.Register("CalendarControl", typeof(CalendarView), typeof(WeekHighlightBehavior), new PropertyMetadata(0));
        
    protected override void OnAttached()
    {
        base.OnAttached();
        CalendarControl.SelectedDatesChanged += Calendar_SelectedDatesChanged;
    }

    private void Calendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
    {
        var dayItem = this.AssociatedObject as CalendarViewDayItem;
        var calendar = CultureInfo.CurrentUICulture.Calendar;
        bool highlight = false;
        foreach (var date in args.AddedDates)
        {
            if (calendar.GetWeekOfYear(date.DateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday) ==
                calendar.GetWeekOfYear(dayItem.Date.DateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
            {
                highlight = true;
            }
        }

        if (highlight)
        {
            dayItem.Background = new SolidColorBrush(Colors.Yellow);
        }
        else
        {
            dayItem.Background = null;
        }
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        CalendarControl.SelectedDatesChanged -= Calendar_SelectedDatesChanged;
    }
}
}
