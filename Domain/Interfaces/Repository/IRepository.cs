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
        public T Get(Expression<Func<T, bool>> expression,string model, string model2, string model3);
        public T Get(string model,string model2,string model3);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetAll(string obj);
        public void AddRange(List<T> list);

        public T GetByID(int id, string property1, string property2, string property3);

        public T Update(T entity);
        public void Delete(int id);
         T Create(T entity);
    }
}
