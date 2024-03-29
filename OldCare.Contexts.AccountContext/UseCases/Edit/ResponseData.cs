﻿using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.Edit;

public class ResponseData : IResponseData
{
    public ResponseData(string message) => Message = message;

    public ResponseData(string message, List<Resident> residents)
    {
        Message = message;
        Residents = residents;
    }

    public string? Message { get; }
    public List<Resident> Residents { get; private set; }
}