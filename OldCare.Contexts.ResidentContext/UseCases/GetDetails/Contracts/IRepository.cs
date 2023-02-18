using OldCare.Contexts.ResidentContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCare.Contexts.ResidentContext.UseCases.Details.Contracts
{
    public interface IRepository
    {
        /// <summary>
        /// Fetch all resident details 
        /// </summary>
        /// <param name="id">Resident's global unique identifier</param>
        /// <returns></returns>
        Task<Resident?> GetDetailsByIdAsync(Guid id);
    }
}
