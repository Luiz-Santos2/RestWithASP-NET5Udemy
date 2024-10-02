using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySqlContext _context;

        private DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;

            }
            catch (Exception)
            {

                throw;
            }            
        }

        public void Delete(long id)
        {
            var result = dataSet.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindByID(long id)
        {
            return dataSet.FirstOrDefault(p => p.Id.Equals(id)); ;
        }

        public T Update(T item)
        {
            var result = dataSet.FirstOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else 
            {
                return null;
            }
        }
    }
}
