using System.Text.Json.Serialization;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.SharedContext.UseCases;

public class BaseResponse<TData> : IResponse
{
    #region Private Properties

    private readonly IList<Error>? _errors;

    #endregion

    #region Ctors

    public BaseResponse(TData data, int statusCode = 200)
    {
        Data = data;
        StatusCode = statusCode;
    }

    public BaseResponse(string error, string key = "", int statusCode = 400)
    {
        _errors = new List<Error>();
        _errors.Add(new Error(error, key));
        StatusCode = statusCode;
    }

    public BaseResponse(Error error, int statusCode = 400)
    {
        _errors = new List<Error>();
        _errors.Add(error);
        StatusCode = statusCode;
    }

    public BaseResponse(Exception exception, int statusCode = 400)
    {
        _errors = new List<Error>();
        _errors.Add(new Error(exception.Message));
        StatusCode = statusCode;
    }

    #endregion

    #region Properties

    public TData? Data { get; }

    public IReadOnlyCollection<Error>? Errors
        => _errors?.ToArray();

    [JsonIgnore] public int StatusCode { get; }

    [JsonIgnore] public bool IsSuccess => StatusCode <= 399;

    #endregion
}