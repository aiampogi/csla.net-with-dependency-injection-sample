using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Business.Interfaces
{
    public interface IPerson : IBusinessBase
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
