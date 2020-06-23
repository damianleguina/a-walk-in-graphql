using GraphQLNetCore.Data;
using GraphQLNetCore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GraphQLNetCore.DatabaseSeedHelper
{
    public static class DatabaseSeedHelper
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GraphQLContext>();
                List<Skill> skills;
                List<Person> people;
                (skills, people) = JsonHelper.GetEntities();
                context.AddRange(skills);
                context.AddRange(people);
                context.SaveChanges();
            }
        }
    }
}