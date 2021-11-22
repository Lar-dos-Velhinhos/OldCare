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
    public async Task<IActionResult> Create(Resident resident)
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

        if (resident == null)
            throw new KeyNotFoundException("Um residente com este Id não foi encontrado.");

        var result = new EditResidentViewModel()
        {
            Id = resident.Id,
            PersonId = resident.PersonId,
            Person = resident.Person,
            BedroomId = resident.BedroomId,
            Bedroom = resident.Bedroom,
            AdmissionDate = resident.AdmissionDate,
            DepartureDate = resident.DepartureDate,
            Father = resident.Father,
            HealthInsurance = resident.HealthInsurance,
            MaritalStatus = resident.MaritalStatus,
            Mobility = resident.Mobility,
            Mother = resident.Mother,
            Note = resident.Note,
            Profession = resident.Profession,
            EducationLevel = resident.EducationLevel,
            SUS = resident.SUS,
            VoterRegCardNumber = resident.VoterRegCardNumber
        };

        result.Bedrooms = await context.Bedrooms
            .AsNoTracking()
            .ToListAsync();

        result.Persons = await context.Persons
            .AsNoTracking()
            .ToListAsync();

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditResidentViewModel model)
    {
        if (!ModelState.IsValid)
            return View();

        var result = new Resident()
        {
            Id = model.Id,
            PersonId = model.PersonId,
            Person = model.Person,
            BedroomId = model.BedroomId,
            Bedroom = model.Bedroom,
            AdmissionDate = model.AdmissionDate,
            DepartureDate = model.DepartureDate,
            Father = model.Father,
            HealthInsurance = model.HealthInsurance,
            MaritalStatus = model.MaritalStatus,
            Mobility = model.Mobility,
            Mother = model.Mother,
            Note = model.Note,
            Profession = model.Profession,
            EducationLevel = model.EducationLevel,
            SUS = model.SUS,
            VoterRegCardNumber = model.VoterRegCardNumber
        };

        context.Residents.Update(result);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}