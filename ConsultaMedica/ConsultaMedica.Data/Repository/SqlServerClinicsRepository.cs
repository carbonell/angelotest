using ConsultaMedica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ConsultaMedica.Data.Repository
{
    public class SqlServerClinicsRepository : IWritableRepository<Clinic>
    {
        private DataContext _context = DataContext.Create();

        public void Create(Clinic model)
        {
            model.CreatedAt = DateTime.Now;

            _context.Clinics.Add(model);
        }

        public void Disable(Clinic model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clinic> GetAll(Expression<Func<Clinic, bool>> query = null, Expression<Func<Clinic, object>> include = null)
        {
            if (query == null)
                return include == null
                    ? _context.Clinics
                    : _context.Clinics.Include(include);

            return include == null
                ? _context.Clinics.Where(query)
                : _context.Clinics.Where(query).Include(include);
        }

        public Clinic GetById(object id)
        {
            return _context.Clinics.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Clinic model)
        {
            throw new NotImplementedException();
        }
    }
}
