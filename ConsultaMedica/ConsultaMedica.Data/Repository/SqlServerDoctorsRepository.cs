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
    public class SqlServerDoctorsRepository : IRepository<ApplicationUser>
    {
        private DataContext _context = DataContext.Create();

        public IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> query = null, Expression<Func<ApplicationUser, object>> include = null)
        {
            if (query == null)
                return include == null
                    ? _context.Users
                    : _context.Users.Include(include);

            return include == null
                ? _context.Users.Where(query)
                : _context.Users.Where(query).Include(include);
        }

        public ApplicationUser GetById(object id)
        {
            return _context.Users.Find(id);
        }
    }
}
