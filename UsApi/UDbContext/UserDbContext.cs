using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UsApi.Models;


namespace UsApi.UDbContext
{
    public class UserDbContext : DbContext
    {
    

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
