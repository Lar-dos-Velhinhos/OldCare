using MediatR;
using OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;


namespace OldCare.Contexts.ResidentContext.UseCases.GetDetails;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
	#region Private Properties

	private readonly LogService _logService;
	private readonly IRepository _repository;

    #endregion

    #region Public Construtors

    public Handler(LogService logService, IRepository repository) =>
		(_logService, _repository) = (logService, repository);

    public Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    #endregion

}
