using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

/// <summary>
/// Return weekday of the specific date.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DayController : ControllerBase
{
    private readonly DatesContext _context;

    public DayController(DatesContext context, ILogger<DayController> logger)
    {
        _context = context;
    }

    [HttpGet]
    public string Get(DateTime date)
    {
        var dayOfWeek = date.DayOfWeek;
        string message = string.Format("{0} is {1}.", date.ToString("dd.MM.yyyy"), dayOfWeek.ToString());
        _context.HistoryEntities.Add(new HistoryEntity(Command.Day, message));
        _context.SaveChanges();
        return dayOfWeek.ToString();
    }
}
