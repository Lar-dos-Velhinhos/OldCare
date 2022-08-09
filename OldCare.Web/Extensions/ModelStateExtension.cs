using OldCare.Contexts.SharedContext.ValueObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Web.Extensions;

public static class ModelStateExtension
{
    public static void AddResultErrors(this ModelStateDictionary modelState, IReadOnlyCollection<Error>? errors)
    {
        if (errors == null)
            return;

        foreach (var item in errors)
            modelState.AddModelError(item.Key, item.Value);
    }
}