using Oldcare.Core.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("v1/todos", (AppDbContext context) =>
{
    var todo = context.Persons.ToList();
    return Results.Ok(todo);
});

app.Run();
