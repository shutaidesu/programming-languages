using lab5.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lab5.Services;

public class YearListService
{
    static public ObservableCollection<CalendarYear> Years = new ObservableCollection<CalendarYear>();

    static public CalendarYear? FindCalendarYear(int year)
    {
        for (var i = 0; i < Years.Count; i++)
        {
            var calendarYear = Years[i];
            if (calendarYear.Year == year)
            {
                return calendarYear;
            }
        }
        return null;
    }

    static public CalendarYear FindOrCreateCalendarYear(int year)
    {
        for (var i = 0; i < Years.Count; i++)
        {
            var calendarYear = Years[i];
            if (calendarYear.Year == year)
            {
                return calendarYear;
            }
            else if (calendarYear.Year > year)
            {
                var newCalendarYear = new CalendarYear(year, new ObservableCollection<CalendarMonth>());
                Years.Insert(i, newCalendarYear);
                return newCalendarYear;
            }
        }
        var newLastCalendarYear = new CalendarYear(year, new ObservableCollection<CalendarMonth>());
        Years.Add(newLastCalendarYear);
        return newLastCalendarYear;
    }

    static public bool HasMonth(CalendarYear? calendarYear, Month month)
    {
        if (calendarYear == null) return false;
        foreach (CalendarMonth calendarMonth in calendarYear.Months)
        {
            if (calendarMonth.Month == (Month)month)
            {
                return true;
            }
        }
        return false;
    }

    static public CalendarMonth CreateCalendarMonth(int year, Month month)
    {
        var daysNumber = DateTime.DaysInMonth(year, (int)month);
        var calendarDays = Enumerable.Range(1, daysNumber).Select(day => new DateTime(year, (int)month, day)).Select(dt => new CalendarDay(dt)).ToList();
        var i = 0;
        var weeks = 0;
        var calendarWeeks = new ObservableCollection<CalendarWeek>();
        while (i < daysNumber)
        {
            weeks++;
            var currentWeek = new CalendarWeek(weeks, new ObservableCollection<CalendarDay>
            {
                calendarDays[i]
            });
            calendarWeeks.Add(currentWeek);
            i++;
            while (i < daysNumber && calendarDays[i].DateTime.DayOfWeek != DayOfWeek.Monday)
            {
                currentWeek.Days.Add(calendarDays[i]);
                i++;
            }
        }
        return new CalendarMonth(month, calendarWeeks);
    }

    static public void InsertCalendarMonth(CalendarYear calendarYear, CalendarMonth newCalendarMonth)
    {
        for (var i = 0; i < calendarYear.Months.Count; i++)
        {
            if (calendarYear.Months[i].Month > newCalendarMonth.Month)
            {
                calendarYear.Months.Insert(i, newCalendarMonth);
                return;
            }
        }
        calendarYear.Months.Add(newCalendarMonth);
    }
}