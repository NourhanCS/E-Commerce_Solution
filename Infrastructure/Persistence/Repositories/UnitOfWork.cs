using DomainLayer;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = []; 

        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            //get type name 

            var typename = typeof(TEntity).Name;
            // Dictionary ,Object ==> string key [name of type] -- Object from generic repository
            //if (_repositories.ContainsKey(typename))
            //     return (IGenericRepository < TEntity, Tkey >) _repositories[typename] ;

            if(_repositories.TryGetValue(typename,out object? value))
           return     (IGenericRepository < TEntity, Tkey >) value;

            else
            {
                //create bject
                var Repo = new GenericRepository<TEntity, Tkey>(_dbContext);
                //store object in dictionary
                _repositories["typename"] = Repo;
                //return object
                return Repo;
            }
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
       
    }
}
