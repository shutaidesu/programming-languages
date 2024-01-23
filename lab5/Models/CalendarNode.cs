using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models;

public class CalendarNode
{
    public CalendarNode(DateTime dateTime)
    {
        DateTime = dateTime;
    }
    public DateTime DateTime { get; }
}
