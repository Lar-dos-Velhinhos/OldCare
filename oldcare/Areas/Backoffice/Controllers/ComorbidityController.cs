namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class ComorbidityController : Controller
{
    ApplicationDbContext context;

    public ComorbidityController(ApplicationDbContext _context) => context = _context;

    [HttpGet]
    public async Task<IActionResult> Create([FromQuery] Guid residentId)
    {
        var resident = await context.Residents
                      .Include(x => x.Person)
                      .AsNoTracking()
                      .Where(x => x.Id == residentId)
                      .FirstOrDefaultAsync();

        if (resident == null)
        {
            ModelState.AddModelError("Resident", "Não foi encontrado um residente com o código informado.");
            return View();
        }

        var comorbidity = new Comorbidity();

        return View(comorbidity);
        
    } 

    
    [HttpPost]
    public async Task<IActionResult> Create(Comorbidity comorbidity)
    {
        if (!ModelState.IsValid)
            return View(comorbidity);

        try
        {    
            context.Comorbidities.Add(comorbidity);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }

    //Get Comorbidity
    [HttpGet]
    public async Task<IActionResult> Edit([FromQuery] Guid comorbidityId)
    {
        if(!ModelState.IsValid)
            return View();

        var comorbidity = await context.Comorbidities
                          .AsNoTracking()
                          .Where(x => x.Id == comorbidityId)
                          .FirstOrDefaultAsync();

        if(comorbidity == null) 
            throw new KeyNotFoundException("Uma comorbidade com este Id não foi encontrado.");

        return View(comorbidity);
    } 
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Comorbidity comorbidity)
    {
        if(!ModelState.IsValid)
            return View(comorbidity);

        try
        {
            context.Comorbidities.Update(comorbidity);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
        return View();
    }
}

