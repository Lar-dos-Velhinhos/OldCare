namespace OldCare.Contexts.SharedContext.Converters.Exceptions;

public class IsoDateTimeConverterException: Exception
{
    public IsoDateTimeConverterException(string message = "Data inválida (Formato ISO inválido)") : base()
    {
    }
}