using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        public T GetById(int id)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(e=>e.id == id);
        }
        public async Task<List<T>> AddRange(List<T> list)
        {
            await _context.Set<T>().AddRangeAsync(list);
            return list;
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return (T)_context.Set<T>().Where(expression).FirstOrDefault();
        }
       

        public async Task<T> GetByID(int id, string property1)
        {
            return await _context.Set<T>().Include(property1)
                .FirstOrDefaultAsync(x=>x.id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public  IEnumerable<T> GetAll(string obj)
        {
            return _context.Set<T>().AsNoTracking().Include(obj).ToList();
        }
        public  async Task Update(T entity)
        {
         var obj =  _context.Set<T>().Update(entity);

            //return obj;
        }
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);  
           return entity;
        }

        public  void Delete(int id)
        {
           var entity =  _context.Set<T>().Find(id);
            entity.deleted = true;
            _context.Set<T>().Update(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, string model)
        {
           return  _context.Set<T>().AsNoTracking().Include(model).FirstOrDefault();
        }





        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AsNoTracking().Where(expression);
        }

        T IRepository<T>.Get(Expression<Func<T, bool>> expression, string model)
        {
            throw new NotImplementedException();
        }
    }
}
