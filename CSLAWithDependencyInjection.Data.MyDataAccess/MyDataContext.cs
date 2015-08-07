using CSLAWithDependencyInjection.Data.Interface;
using CSLAWithDependencyInjection.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Data.MyDataAccess
{
    /// <summary>
    /// A Custom DataContext to just purely demonstrate the DI
    /// </summary>
    public class MyDataContext : IDataContext
    {
        static List<PersonEntity> persons = new List<PersonEntity>();

        public ICollection<PersonEntity> Persons
        {
            get
            {
                return persons;
            }
            set
            {
                persons = value.ToList();
            }
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void Dispose()
        {
            // dispose context like DBContext
        }
    }
}
