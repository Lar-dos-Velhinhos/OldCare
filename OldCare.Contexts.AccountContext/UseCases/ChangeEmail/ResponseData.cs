﻿using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.ChangeEmail;

public class ResponseData : IResponseData
{
    public ResponseData(string message) => Message = message;
    public string Message { get; }
}