namespace Oldcare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class ResidentController : Controller
{
    // GET: ResidentController
    public ActionResult Index() => View();

    // GET: ResidentController/Details/5
    public ActionResult Details(int id) => View();
    
    public ActionResult Create() => View();

    [Route("Cadastrar-Inicio")]
    public IActionResult CreateStart() => View();

    [Route("Cadastrar-Final")]
    public IActionResult CreateEnd() => View();

    // POST: ResidentController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ResidentController/Edit/5
    public ActionResult Edit(int id) => View(id);

    // POST: ResidentController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ResidentController/Delete/5
    public ActionResult Delete(int id) => View(id);

    // POST: ResidentController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
