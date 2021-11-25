namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class HistoryController : Controller
{
    ApplicationDbContext context;

    public HistoryController(ApplicationDbContext _context) => context = _context;
    public async Task<IActionResult> Index()
    {
        var histories = await context.Histories
            .AsNoTracking()
            .OrderBy(x => x.Description)
            .AsQueryable()
            .ToListAsync();

        if (histories == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(histories);
    }

    [HttpGet]
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(History history)
    {
        //if (!ModelState.IsValid)    
        //    return View();
        if (context.Histories.Any(x => x.Description == history.Description))
        {
            //throw new BadHttpRequestException("Registro duplicado");
            return View(history);
        }

        try
        {
            context.Histories.Add(history);
            await context.SaveChangesAsync();
            RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
        return View(history);
    }

    [HttpGet]
    public async Task<ActionResult> Edit([FromQuery] Guid historyId)
    {
        if (!ModelState.IsValid)
            return View();

        var history = await context.Histories
                      .AsNoTracking()
                      .Where(x => x.Id == historyId)
                      .FirstOrDefaultAsync();
        if (history == null)
            throw new KeyNotFoundException("Nenhum quarto com este Id foi encontrado.");

        return View(history);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(History history)
    {
        if (!ModelState.IsValid)
            return View(history);

        try
        {
            context.Histories.Update(history);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }
}
