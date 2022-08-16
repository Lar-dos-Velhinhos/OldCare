using OldCare.Core.Data;
using OldCare.Core.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/v1/persons", (AppDbContext context) =>
{
    var persons = context.Persons;
    return Results.Ok(persons);
}).Produces<Person>();

app.Run();
