namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class ListException : Exception
{
    public ListException(string message = "Argumento vazio ou inexistente") : base(message)
    {
        
    }
    
    public static void ThrowIfEmpty<T>(List<T> data) where T : class?
    {
        if (data.Count == 0)
            throw new ListException($"Não foram encontrados registros");
    }
}