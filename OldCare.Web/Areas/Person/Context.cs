using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.SharedContext;
using OldCare.Data;

namespace OldCare.Web.Areas.Person;

public class Context
{
    public static void ConfigureDataContext(IServiceCollection services)
    {
        services.AddDbContext<DataContext>(
            x =>
            {
                x.UseSqlServer(
                    Configuration.Database.ConnectionString,
                    options => { options.MigrationsAssembly("OldCare.Web"); });
            });
    }

    public static void ConfigureServices(IServiceCollection services)
    {        
        services
            .AddTransient<Contexts.PersonContext.UseCases.Create.Contracts.IRepository,
                Data.Contexts.PersonContext.UseCases.Create.Repository>();        
    }
}