namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class PersonController : Controller
{
    internal ApplicationDbContext context;

    public PersonController(ApplicationDbContext _context) => context = _context;

    public async Task<IActionResult> Index()
    {
        var persons = await context.Persons
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .AsQueryable()
            .ToListAsync();

        if (persons == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(persons);
    }

    [HttpGet]
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {
        //if (!ModelState.IsValid)
        //    return View(person);

        if (existingPerson(person))
            return View(person);

        try
        {
            context.Persons.Add(person);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit([FromQuery] Guid personId)
    {
        if (!ModelState.IsValid)
            return View();

        var person = await context.Persons
            .AsNoTracking()
            .Where(x => x.Id == personId)
            .FirstOrDefaultAsync();

        if (person == null)
            throw new KeyNotFoundException("Uma pessoa com este Id não foi encontrada.");

        return View(person);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Person model)
    {
        if (!ModelState.IsValid)
            return View();

        context.Persons.Update(model);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public bool existingPerson(Person person)
    {
        if (person.CPF == null || person.RG == null)
            return false;

        var result = context.Persons
            .AsNoTracking()
            .Where(x => x.CPF == person.CPF
                     || x.RG == person.RG)
            .FirstOrDefault();

        return (result == null ? false : true);
    }
}