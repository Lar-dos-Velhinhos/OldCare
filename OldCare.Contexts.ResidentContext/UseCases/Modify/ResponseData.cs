using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.ResidentContext.UseCases.Modify;

public class ResponseData : IResponseData
{
	#region Public Contructors

	public ResponseData(string message) => Message = message;



	public ResponseData(string message, Request request) =>
		(Message, Request) = (message, request);

	#endregion

	#region Public Properties

	public string Message { get; set; }
	public Request? Request { get; set; }

	#endregion
}
