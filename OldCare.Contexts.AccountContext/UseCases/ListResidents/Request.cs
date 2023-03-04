using OldCare.Contexts.ResidentContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCare.Contexts.AccountContext.UseCases.ListResidents
{
    public class Request
    {
        public List<Resident> Residents { get; set; }
    }
}
