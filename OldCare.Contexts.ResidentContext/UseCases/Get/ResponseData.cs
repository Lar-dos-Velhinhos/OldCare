using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.ResidentContext.UseCases.Get;

public class ResponseData : IResponseData
{

    #region Public Constructors

    public ResponseData(string message) => Message = message;

    public ResponseData(string message, List<Resident?> residents)
    {
        Message = message;
        Residents = residents;
    }

    #endregion

    #region Public Properties

    public string? Message { get; }
    public List<Resident?> Residents { get; private set;}

    #endregion
}