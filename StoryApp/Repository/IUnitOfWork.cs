namespace StoryApp.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IStoryRepository StoryRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
        void Rollback();
    }

}
