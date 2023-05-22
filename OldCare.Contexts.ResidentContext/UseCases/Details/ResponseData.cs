using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCare.Contexts.ResidentContext.UseCases.Details
{
    public class ResponseData : IResponseData
    {
        public ResponseData(string message) => Message = message;
        public ResponseData(string message, Resident resident) =>
            (Message, Resident) = (message, resident);

        #region Public Properties

        public string? Message { get;}
        public Resident? Resident { get; set; }

        #endregion
    }
}
