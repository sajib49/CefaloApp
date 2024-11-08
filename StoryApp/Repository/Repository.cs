using Microsoft.EntityFrameworkCore;
using StoryApp.Data;
using StoryApp.Entities;
using StoryApp.Models;

namespace StoryApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class { protected readonly DataContext _context; 
        protected readonly DbSet<T> _dbSet; 
        public Repository(DataContext context) 
        { 
            _context = context; _dbSet = _context.Set<T>(); 
        } 

        public IEnumerable<T> GetAll() 
        { 
            return _dbSet.ToList(); 
        } 

        public T GetById(int id) { 
            return _dbSet.Find(id); 
        } 

        public void Add(T entity) 
        { 
            _dbSet.Add(entity); 
        } 

        public void Update(T entity) 
        { 
            _dbSet.Update(entity); 
        }

        public void Delete(int id) 
        { 
            var entity = GetById(id); if (entity != null) 
            {
                _dbSet.Remove(entity); 
            } 
      }
    }

    public class StoryRepository : Repository<Story>, IStoryRepository 
    {
        public StoryRepository(DataContext context) : base(context) { } 
    }
    public class UserRepository : Repository<User>, IUserRepository 
    { 
        public UserRepository(DataContext context) : base(context) { } 
    }
}
