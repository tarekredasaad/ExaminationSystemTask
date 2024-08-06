using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<T>
    {
       public T GetById(int id);
        public T Get(Expression<Func<T, bool>> expression);
        public T Get(Expression<Func<T, bool>> expression,string model);
        //public T Get(string model,string model2,string model3);
        public IQueryable<T> GetAll();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        public IEnumerable<T> GetAll(string obj);
        public Task<List<T>> AddRange(List<T> list);

        public Task<T> GetByID(int id, string property1);

        public Task Update(T entity);
        public void Delete(int id);
         Task<T> Create(T entity);
    }
}
