using Core.Base.Interface.Repository;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _db;
        public Repository()
        {
            _db = new S2Models();
        }

        public bool Delete(T entity)
        {
            try
            {
                _db.Set<T>().Remove(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public bool Insert(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
