using GraphQLNetCore.Data;
using GraphQLNetCore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

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
                context.SaveChanges();
                foreach (var person in people)
                {
                    NormalizeLists(person, context);
                    context.Add(person);
                    context.SaveChanges();
                }
            }
        }

        private static void NormalizeLists(Person person, GraphQLContext context)
        {
            var skills = person.Skills.ToList();
            for (int i = 0; i < skills.Count; i++)
            {
                skills[i] = context.Skills.FirstOrDefault(x => x.Id == skills[i].Id);
            }
            var friends = person.Friends.ToList();
            for (int i = 0; i < friends.Count; i++)
            {
                friends[i] = context.People.FirstOrDefault(x => x.Id == friends[i].Id);
            }
            person.Skills = skills;
            person.Friends = friends;
        }
    }
}
