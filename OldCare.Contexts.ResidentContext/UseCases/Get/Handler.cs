using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Get;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly IRepository _repository;

    #endregion

    #region Constructors

    public Handler(IRepository repository) => _repository = repository;

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        List<Resident>? residents = await _repository.GetAllResidentsOrderedByName();
        #region 05. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("", residents));

        #endregion
    }
}