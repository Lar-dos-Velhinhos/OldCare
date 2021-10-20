using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OldCare.Core.Data;
using System.Threading.Tasks;

namespace OldCare.Web.Controllers
{
    public class ResidentController : Controller
    {
        private OldCareDataContext _context;

        public ResidentController(OldCareDataContext context) => _context = context;    
        
        public async Task<IActionResult> Index() 
        {

            var model = await _context.Persons.ToListAsync();

            return View(model);
        }
    }
}
