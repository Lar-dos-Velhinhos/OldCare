using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCare.Contexts.ResidentContext.UseCases.GetDetails
{
    public class ResponseData : IResponseData
    {
        public ResponseData(string message) => Message = message;
        public ResponseData(string message, List<Resident?> residents) =>
            (Message, Residents) = (message, residents);

        #region Public Properties

        public string? Message { get;}
        public List<Resident?> Residents { get; private set; }

        #endregion
    }
}
