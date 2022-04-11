using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Repository.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddAsync(T entity);
        void Delete (T entity);
        void Update (T entity);
        T Get (Expression<Func<T,bool>> predicate);
        IQueryable<T> GetAll ();
    }
}
