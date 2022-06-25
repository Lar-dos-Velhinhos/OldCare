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

    [HttpGet]
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Bedroom bedroom)
    {
        //if (!ModelState.IsValid)    
        //    return View();
        if (context.Bedrooms.Any(x => x.Number == bedroom.Number))
        {
            //throw new BadHttpRequestException("Registro duplicado");
            return View(bedroom);
        }

        try
        {
            context.Bedrooms.Add(bedroom);
            await context.SaveChangesAsync();
            RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
        return View(bedroom);
    }

    [HttpGet]
    public async Task<ActionResult> Edit([FromQuery] Guid bedroomId)
    {
        if (!ModelState.IsValid)
            return View();

        var bedroom = await context.Bedrooms
                      .AsNoTracking()
                      .Where(x => x.Id == bedroomId)
                      .FirstOrDefaultAsync();
        if (bedroom == null)
            throw new KeyNotFoundException("Nenhum quarto com este Id foi encontrado.");

        return View(bedroom);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Bedroom bedroom)
    {
        if (!ModelState.IsValid)
            return View(bedroom);

        try
        {
            context.Bedrooms.Update(bedroom);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }
}