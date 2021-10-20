using Microsoft.AspNetCore.Mvc;
using OldCare.Core.Data;
using OldCare.Core.Entities;
using OldCare.Core.ViewModels;
using OldCare.Core.ViewModels.Person;

namespace OldCare.Web.Controllers;

public class PersonController : Controller
{
    private OldCareDataContext _context;

    public PersonController(OldCareDataContext context) => _context = context;
    
    public IActionResult Index() => View();

    public IActionResult Create()
    {
        CreatePersonViewModel model = new();

        return View(model);
    }
    
    [HttpPost]
    public IActionResult Create(CreatePersonViewModel model)
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
