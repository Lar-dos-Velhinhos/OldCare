using Microsoft.AspNetCore.Mvc;
using OldCare.Core.Data;
using OldCare.Core.Entities;
using OldCare.Core.ViewModels.People;

namespace OldCare.Web.Controllers;

public class PeopleController : Controller
{
    private OldCareDataContext _context;

    public PeopleController(OldCareDataContext context) => _context = context;
    
    public IActionResult Index() => View();

    public IActionResult Create()
    {
        CreatePeopleViewModel model = new();

        return View(model);
    }
    
    [HttpPost]
    public IActionResult Create(CreatePeopleViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.Persons.Add(new Person
        {
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
            RG = model.RG,
            UF = model.UF
        });
        _context.SaveChanges();

        return View(model);
    }
}
