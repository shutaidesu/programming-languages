using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

/// <summary>
/// Get history of executed commands.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly DatesContext _context;

    public HistoryController(DatesContext context, ILogger<HistoryController> logger)
    {
        _context = context;
    }

    [HttpGet]
    public IQueryable<HistoryEntity> Get()
    {
        _context.HistoryEntities.Add(new HistoryEntity(Command.History, "History viewed"));
        _context.SaveChanges();
        return _context.HistoryEntities;
    }
}
