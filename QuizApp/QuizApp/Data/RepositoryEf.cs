using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class RepositoryEf<T> : IRepositoryEf<T> where T : BaseEntity
    {
        protected readonly QuizAppDbContext _dbContext;
        private readonly DbSet<T> entities;
        private readonly string errorMessage = string.Empty;
        private readonly IList<Expression<Func<T, object>>> _modifiers;

        public RepositoryEf(QuizAppDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<T>();
            _modifiers = new List<Expression<Func<T, object>>>();
        }
        
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> ListAll()
        {
            return entities.AsEnumerable();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.SaveChanges();
        }

        public IQueryable<T> DbSet
        {
            get
            {
                return _modifiers.Aggregate((IQueryable<T>)entities,
                    (current, include) =>
                    current.Include(include));
            }
        }

        public IRepositoryEf<T> Include(Expression<Func<T, object>> path)
        {
            _modifiers.Add(path);

            return this;
        }
    }
}
