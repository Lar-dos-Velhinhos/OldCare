using Microsoft.AspNetCore.Mvc;
using Oldcare.Core.Data;

namespace Oldcare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class PersonController : Controller
{
    private readonly AppDbContext _context;

    public PersonController(AppDbContext context) => _context = context;
    
    public IActionResult Index() => View();
    
    public IActionResult CreateStart() => View();

    [HttpPost]
    public async Task<IActionResult> CreateStart(CreateStartPersonViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        var result = new CreateEndPersonViewModel()
        {
            Id = model.Id,
            Name = model.Name,
            BirthDate = model.BirthDate,
            Citizenship = model.Citizenship,
            Gender = model.Gender,
            RG = model.RG,
            CPF = model.CPF
        };

        return View(nameof(CreateEnd), result);
    }
    
    public IActionResult CreateEnd() => View();

    [HttpPost]
    public async Task<IActionResult> CreateEnd(CreateEndPersonViewModel model)
    {
        var person = new Person();

        if (!ModelState.IsValid)
            return View(nameof(CreateEnd), model);

        person = new Person
        {
            Id = Guid.NewGuid(),
            Address = model.Address,
            BirthDate = model.BirthDate,
            Citizenship = model.Citizenship,
            CEP = model.CEP,
            City = model.City,
            CPF = model.CPF,
            District = model.District,
            Gender = model.Gender,
            Name = model.Name,
            Note = model.Note,
            // Photo = model.Photo,
            RG = model.RG,
            UF = model.UF
        };

        try
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            // TODO: error handler
            throw new Exception(e.Message);
        }

        return RedirectToAction("Index", "Resident", "Backoffice");
    }
}