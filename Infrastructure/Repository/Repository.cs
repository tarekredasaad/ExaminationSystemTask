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

        public T Get(Expression<Func<T, bool>> expression)
        {
            return (T)_context.Set<T>().Where(expression).FirstOrDefault();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> expression,string model, string model2, string model3)
        {
            return _context.Set<T>().Include(model).Include(model2).Include(model3).Where(expression);
        }
        public IEnumerable<T> Get(string model, string model2, string model3)
        {
            return _context.Set<T>().Include(model).Include(model2).Include(model3);
        }

        public T GetByID(int id, string property1, string property2, string property3)
        {
            return _context.Set<T>().Include(property1).Include(property2).Include(property3)
                .FirstOrDefault(x=>x.id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
        public  IEnumerable<T> GetAll(string obj)
        {
            return _context.Set<T>().AsNoTracking().Include(obj).ToList();
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            
            return entity;
        }
        public T Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);  
           return entity;
        }

        public  void Delete(int id)
        {
           var entity =  _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }

        T IRepository<T>.Get(Expression<Func<T, bool>> expression, string model, string model2, string model3)
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.Get(string model, string model2, string model3)
        {
            throw new NotImplementedException();
        }
    }
}
