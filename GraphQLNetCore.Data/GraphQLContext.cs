using GraphQLNetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetCore.Data
{
    public class GraphQLContext : DbContext
    {
        public GraphQLContext(DbContextOptions<GraphQLContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}