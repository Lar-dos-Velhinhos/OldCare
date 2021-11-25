namespace OldCare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class ProductController : Controller
{
    internal ApplicationDbContext context;

    public ProductController(ApplicationDbContext _context) => context = _context;

    public async Task<IActionResult> Index()
    {
        var products = await context.Products
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .AsQueryable()
            .ToListAsync();

        if (products == null)
            throw new KeyNotFoundException("Não existem dados para serem exibidos");

        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        //if (!ModelState.IsValid)
        //    return View(person);

        if (existingProduct(product))
            return View(product);

        try
        {
            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao tentar salvar os dados. Recarregue a página e tente novamente.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit([FromQuery] Guid productId)
    {
        if (!ModelState.IsValid)
            return View();

        var product = await context.Products
            .Where(x => x.Id == productId)
            .FirstOrDefaultAsync();

        if (product == null)
            throw new KeyNotFoundException("Uma pessoa com este Id não foi encontrada.");

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (!ModelState.IsValid)
            return View();

        context.Products.Update(product);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public bool existingProduct(Product product)
    {
        var result = context.Products
            .AsNoTracking()
            .Where(x => x.Name == product.Name)
            .FirstOrDefault();

        return (result == null ? false : true);
    }
}
