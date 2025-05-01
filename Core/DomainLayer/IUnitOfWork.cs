using DomainLayer.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public interface IUnitOfWork
    {
        IGenericRepository <TEntity, Tkey> GetRepository<TEntity,Tkey>()where TEntity : BaseEntity<Tkey>;
        Task <int> SaveChangesAsync();
    }

}
