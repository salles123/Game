using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Interface.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        bool Insert(T entity);
        bool SaveChanges();
        bool Delete(T entity);
    }
}
