

using Microsoft.EntityFrameworkCore;
using StoryApp.Entities;

namespace StoryApp.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Story> Stories { get; set; }
    }
}
