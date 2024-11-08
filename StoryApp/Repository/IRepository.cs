using StoryApp.Entities;
using StoryApp.Models;

namespace StoryApp.Repository
{
    public interface IRepository<T> where T : class { 
        IEnumerable<T> GetAll(); 
        T GetById(int id); 
        void Add(T entity); 
        void Update(T entity); 
        void Delete(int id); 
    }

    public interface IStoryRepository : IRepository<Story>
    { 
    } 
    public interface IUserRepository : IRepository<User> 
    {
    }
}
