using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;

namespace Expert.Data.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : CoreEntity
    {
    }
}
