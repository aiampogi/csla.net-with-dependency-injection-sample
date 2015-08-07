using CSLAWithDependencyInjection.Data.Models;
using System;
using System.Collections.Generic;

namespace CSLAWithDependencyInjection.Data.Interface
{
    /// <summary>
    /// Just a sample DataContext
    /// </summary>
    public interface IDataContext : IDisposable
    {
        ICollection<PersonEntity> Persons { get; set; }

        int SaveChanges();
    }
}
