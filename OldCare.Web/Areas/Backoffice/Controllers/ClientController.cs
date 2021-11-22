namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class ClientController : Controller
{
    internal ApplicationDbContext context;

    public ClientController(ApplicationDbContext _context) => context = _context;

    public async Task<IActionResult> Index()
    {
        var clients = await context.Clients
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .AsQueryable()
            .ToListAsync();

        if (clients == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(clients);
    }

    [HttpGet]
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        //if (!ModelState.IsValid)
        //    return View(person);

        //if (existingClient(client))
        //    return View(client);

        try
        {
            context.Clients.Add(client);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit([FromQuery] Guid clientId)
    {
        if (!ModelState.IsValid)
            return View();

        var client = await context.Clients
            .AsNoTracking()
            .Where(x => x.Id == clientId)
            .FirstOrDefaultAsync();

        if (client == null)
            throw new KeyNotFoundException("Uma pessoa com este Id não foi encontrada.");

        return View(client);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Client model)
    {
        if (!ModelState.IsValid)
            return View();

        context.Clients.Update(model);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public bool existingClient(Client client)
    {
        if (client.CPFCNPJ == null)
            return false;

        var result = context.Clients
            .AsNoTracking()
            .Where(x => x.CPFCNPJ == client.CPFCNPJ);

        return (result == null ? false : true);
    }
}
