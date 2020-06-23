using GraphQLNetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetCore.Data
{
    public class GraphQLContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public GraphQLContext(DbContextOptions<GraphQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Person>()
            //    .HasMany<Person>(x => x.Friends);
            //modelBuilder.Entity<Person>()
            //    .HasMany<Skills>(x => x.Skills);
        }
    }
}