using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OldCare.Core.Data;
using OldCare.Core.Entities;
using OldCare.Web.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OldCare.Web.Controllers;

[Authorize(Roles = "admin")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly OldCareDataContext _context;

    public HomeController(ILogger<HomeController> logger, OldCareDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var model = await _context
            .Residents
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
