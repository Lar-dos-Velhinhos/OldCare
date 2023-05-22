using System.Text.Json.Serialization;
using OldCare.Contexts.SharedContext;
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
        builder.Configuration.GetSection("Google").Bind(Configuration.Google);
        builder.Configuration.GetSection("Facebook").Bind(Configuration.Facebook);
        builder.Configuration.GetSection("OneSignal").Bind(Configuration.OneSignal);
        builder.Configuration.GetSection("Discord").Bind(Configuration.Discord);
    }

    public static void AddBaseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<
            OldCare.Contexts.SharedContext.Services.Log.Contracts.IService,
            OldCare.Contexts.SharedContext.Services.Log.Service>();

        builder.Services.AddTransient<
            Services.Google.ReCaptcha.Contracts.IService,
            Services.Google.ReCaptcha.Service>();

        builder.Services
            .Configure<ApiBehaviorOptions>(x => { x.SuppressModelStateInvalidFilter = true; })
            .Configure<JsonOptions>(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
        
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Contexts.AccountContext.Configuration).Assembly));

        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Contexts.PersonContext.Configuration).Assembly));
            
        builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Contexts.ResidentContext.Configuration).Assembly));
    }
}