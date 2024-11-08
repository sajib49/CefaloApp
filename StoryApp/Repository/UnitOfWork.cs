using StoryApp.Data;

namespace StoryApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IStoryRepository _storyRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IStoryRepository StoryRepository
        {
            get { return _storyRepository ??= new StoryRepository(_context); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Implement rollback logic if necessary
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
