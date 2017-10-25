using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Data.Repository
{
    public interface IRepository<T>
    {
        T GetById(object id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> query = null, Expression<Func<T, object>> include = null);
    }

    public interface IWritableRepository<T> : IRepository<T>
    {
        void Create(T model);

        void SaveChanges();

        void Update(T model);

        void Disable(T model);
    }
}
