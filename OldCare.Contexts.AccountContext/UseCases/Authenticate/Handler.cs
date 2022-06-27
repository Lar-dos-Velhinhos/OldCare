using OldCare.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Authenticate;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) => _repository = repository;

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByUserNameAsync(request.Email);
        if (user is null)
            return new BaseResponse<ResponseData>("Usuário ou senha inválidos");

        try
        {
            user.Authenticate(request.Password);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        try
        {
            await _repository.UpdateAsync(user);
        }
        catch
        {
            // ignored
        }

        var roles = Array.Empty<string>();
        try
        {
            roles = await _repository.GetRolesAsync(user.Id);
        }
        catch
        {
            // ignored
        }

        return new BaseResponse<ResponseData>(new ResponseData(
            user.Id.ToString(),
            user.Person.Name,
            user.Username,
            roles ?? Array.Empty<string>())
        );
    }
}