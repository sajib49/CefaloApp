

using Microsoft.EntityFrameworkCore;
using StoryApp.Entities;

namespace StoryApp.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public class DbInitializer
        {
            private readonly ModelBuilder modelBuilder;

            public DbInitializer(ModelBuilder modelBuilder)
            {
                this.modelBuilder = modelBuilder;
            }

            public void Seed()
            {
                modelBuilder.Entity<Story>().HasData(
                       new Story() 
                       {
                           Id = 1,
                           Body = "Body Something 1",
                           Tile = "Title Something 1",
                           PublishedDate = DateTime.Now
                       },
                       new Story()
                       {
                           Id = 2,
                           Body = "Body Something 2",
                           Tile = "Title Something 2",
                           PublishedDate = DateTime.Now.AddDays(1)
                       },
                       new Story()
                       {
                           Id = 3,
                           Body = "Body Something 3",
                           Tile = "Title Something 3",
                           PublishedDate = DateTime.Now.AddDays(2)
                       },
                       new Story()
                       {
                           Id = 4,
                           Body = "Body Something 4",
                           Tile = "Title Something 4",
                           PublishedDate = DateTime.Now.AddDays(3)
                       },
                       new Story()
                       {
                           Id = 5,
                           Body = "Body Something 5",
                           Tile = "Title Something 5",
                           PublishedDate = DateTime.Now.AddDays(5)
                       }
                );
            }
        }

    }
}
