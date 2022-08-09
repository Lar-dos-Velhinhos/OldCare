using System.Text.Json.Serialization;
using OldCare.Contexts.SharedContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OldCare.API.Extensions;

public static class AppExtension
{
    public static void AddBaseConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Host = builder.Configuration.GetValue<string>("Host");
        builder.Configuration.GetSection("Secrets").Bind(Configuration.Secrets);
        builder.Configuration.GetSection("Database").Bind(Configuration.Database);
        builder.Configuration.GetSection("SendGrid").Bind(Configuration.SendGrid);
        builder.Configuration.GetSection("Azure").Bind(Configuration.Azure);
        builder.Configuration.GetSection("Discord").Bind(Configuration.Discord);
    }

    public static void AddBaseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<
            OldCare.Contexts.SharedContext.Services.Log.Contracts.IService,
            OldCare.Contexts.SharedContext.Services.Log.Service>();

        builder.Services
            .Configure<ApiBehaviorOptions>(x => { x.SuppressModelStateInvalidFilter = true; })
            .Configure<JsonOptions>(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

        // TODO: Verificar incompatibilidade MeadiatR e formular solução
        // builder.Services.AddMediatR(
        //     typeof(Contexts.AccountContext.Configuration),
        //     typeof(Program));
    }
}