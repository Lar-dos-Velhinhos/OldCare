using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using SecureIdentity.Password;

namespace OldCare.Contexts.AccountContext.UseCases.Authenticate;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetByEmailAsync(request.Email);
        if (student is null)
            return new BaseResponse<ResponseData>("Usuário ou senha inválidos");

        try
        {
            student.Authenticate(request.Password);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        try
        {
            await _repository.UpdateAsync(student);
        }
        catch
        {
            // ignored
        }

        var roles = Array.Empty<string>();
        try
        {
            roles = await _repository.GetRolesAsync(student.User.Id);
        }
        catch
        {
            // ignored
        }

        return new BaseResponse<ResponseData>(new ResponseData(
            student.Id.ToString(),
            student.Name,
            student.Email,
            roles ?? Array.Empty<string>())
        );
    }
}