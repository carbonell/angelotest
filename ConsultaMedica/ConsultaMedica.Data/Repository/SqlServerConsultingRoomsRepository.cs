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
    public class SqlServerConsultingRoomsRepository : IWritableRepository<ConsultingRoom>
    {
        private DataContext _context = DataContext.Create();

        public void Create(ConsultingRoom model)
        {
            model.CreatedAt = DateTime.Now;

            _context.ConsultingRooms.Add(model);
        }

        public void Disable(ConsultingRoom model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsultingRoom> GetAll(Expression<Func<ConsultingRoom, bool>> query = null, Expression<Func<ConsultingRoom, object>> include = null)
        {
            if (query == null)
                return include == null
                    ? _context.ConsultingRooms
                    : _context.ConsultingRooms.Include(include);

            return include == null
                ? _context.ConsultingRooms.Where(query)
                : _context.ConsultingRooms.Where(query).Include(include);
        }

        public ConsultingRoom GetById(object id)
        {
            return _context.ConsultingRooms.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(ConsultingRoom model)
        {
            throw new NotImplementedException();
        }
    }
}
