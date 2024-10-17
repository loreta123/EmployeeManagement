using BlogPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogPlatform.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
