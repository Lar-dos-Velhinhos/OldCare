namespace Oldcare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class AuthController : Controller
{
    // GET: AuthController
    public ActionResult Index() => View();

    // GET: AuthController/Details/5
    public ActionResult Details(int id) => View();

    // GET: AuthController/Create
    public ActionResult Create() => View();

    // POST: AuthController/Create
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

    // GET: AuthController/Edit/5
    public ActionResult Edit(int id) => View(id);

    // POST: AuthController/Edit/5
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

    // GET: AuthController/Delete/5
    public ActionResult Delete(int id) => View(id);

    // POST: AuthController/Delete/5
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
