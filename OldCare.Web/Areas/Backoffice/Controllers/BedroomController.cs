namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class BedroomController : Controller
{
    ApplicationDbContext context;

    public BedroomController(ApplicationDbContext _context) => context = _context;
    public async Task<IActionResult> Index()
    {
        var bedrooms = await context.Bedrooms
            .AsNoTracking()
            .OrderBy(x => x.Number)
            .AsQueryable()
            .ToListAsync();

        if (bedrooms == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(bedrooms);
    }
}