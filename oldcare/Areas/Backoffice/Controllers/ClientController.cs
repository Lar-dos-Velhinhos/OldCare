namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class ClientController : Controller
{
    internal ApplicationDbContext context;

    public ClientController(ApplicationDbContext _context) => context = _context;

    public async Task<IActionResult> Index()
    {
        var client = await context.Clients
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .AsQueryable()
            .ToListAsync();

        if (client == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(client);
    }

    [HttpGet]
    public async Task<ActionResult> Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Client client)
    {
        //if (!ModelState.IsValid)
        //    return View(client);

        if (context.Clients.Any(x => x.CPFCNPJ == client.CPFCNPJ))
        {
            //throw new BadHttpRequestException("Registro duplicado");
            return View(client);
        }

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

    //Get Client
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
            throw new KeyNotFoundException("Uma cliente com este Id não foi encontrado.");

        return View(client);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Client client)
    {
        if (!ModelState.IsValid)  
            return View();
        try
        {
            context.Clients.Update(client);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }
}