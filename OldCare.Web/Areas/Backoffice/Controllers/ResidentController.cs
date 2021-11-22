namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class ResidentController : Controller
{
    internal ApplicationDbContext context;

    public ResidentController(ApplicationDbContext _context) => context = _context;

    public async Task<IActionResult> Index()
    {
        var residents = await context.Residents
            .Include(x => x.Person)
            .Include(x => x.Bedroom)
            .AsNoTracking()
            .AsQueryable()
            .ToListAsync();

        if (residents == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(residents);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new CreateResidentViewModel();
        model.Bedrooms = await context.Bedrooms
            .AsNoTracking()
            .ToListAsync();

        model.Persons = await context.Persons
            .AsNoTracking()
            .ToListAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ResidentModel resident)
    {
        //if (!ModelState.IsValid)
        //    return View(person);

        try
        {
            context.Residents.Add(resident);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit([FromQuery] Guid residentId)
    {
        //if (!ModelState.IsValid)
        //    return View();

        var resident = await context.Residents
            .AsNoTracking()
            .Where(x => x.Id == residentId)
            .FirstOrDefaultAsync();

        var result = new EditResidentViewModel(resident);

        if (resident == null)
            throw new KeyNotFoundException("Um residente com este Id não foi encontrado.");

        return View(result);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(EditResidentViewModel model)
    {
        if (!ModelState.IsValid)
            return View();

        var resident = new ResidentModel(model);

        context.Residents.Update(resident);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}