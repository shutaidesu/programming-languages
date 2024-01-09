using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CalcController : ControllerBase
{
    private readonly DatesContext _context;

    public CalcController(DatesContext context, ILogger<CalcController> logger)
    {
        _context = context;
    }

    [HttpGet]
    public double Get(DateTime dateFrom, DateTime dateTo)
    {
        var differenceDays = (dateTo - dateFrom).TotalDays;
        string message = string.Format("Interval is {0} days.", differenceDays);
        _context.HistoryEntities.Add(new HistoryEntity(Command.Calc, message));
        return differenceDays;
    }
}