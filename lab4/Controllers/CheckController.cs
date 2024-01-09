using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

/// <summary>
/// Checks if the year is leap.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CheckController : ControllerBase
{
    private readonly DatesContext _context;

    public CheckController(DatesContext context, ILogger<CheckController> logger)
    {
        _context = context;
    }

    [HttpGet]
    public bool Get(int year)
    {
        var isLeap = year % 4 == 0;
        string message = isLeap ? string.Format("{0} is leap.", year) : string.Format("{0} is not leap.", year);
        _context.HistoryEntities.Add(new HistoryEntity(Command.Check, message));
        return isLeap;
    }
}
