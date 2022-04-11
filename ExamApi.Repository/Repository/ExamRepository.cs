using ExamApi.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Repository.Repository
{
    public class ExamRepository<T> : IRepository<T> where T : class
    {
        private readonly Context.Context _context;
        private readonly DbSet<T> _dbSet;
        public ExamRepository(Context.Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddAsync(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate) => _dbSet.FirstOrDefault(predicate);

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
