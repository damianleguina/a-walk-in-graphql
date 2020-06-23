using GraphQLNetCore.DatabaseSeedHelper.Models;
using GraphQLNetCore.DatabaseSeedHelper.Utils;
using GraphQLNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLNetCore.DatabaseSeedHelper
{
    internal static class JsonHelper
    {
        #region Public Methods

        public static (List<Skill>, List<Person>) GetEntities()
        {
            SeedJsonModel seed = GetSeed();
            SeedJsonMapper seedJsonMapper = new SeedJsonMapper();
            List<Skill> skills = seedJsonMapper.MapSkills(seed.Skills);
            List<Person> people = seedJsonMapper.MapPeople(seed.People);
            NormalizePeopleProperties(people, skills);
            return (skills, people);
        }

        #endregion Public Methods

        #region Private Methods

        private static SeedJsonModel GetSeed()
        {
            SeedDeserializer seedDeserializer = new SeedDeserializer();
            return seedDeserializer.GetDeserializedSeedJson();
        }

        private static void NormalizePeopleProperties(List<Person> people, List<Skill> allSkills)
        {
            foreach (var person in people)
            {
                var personSkills = person.Skills.ToList();
                for (int i = 0; i < personSkills.Count; i++)
                {
                    personSkills[i] = allSkills.Find(x => x.Id == personSkills[i].Id);
                }
                var friends = person.Friends.ToList();
                for (int i = 0; i < friends.Count; i++)
                {
                    friends[i] = people.Find(x => x.Id == friends[i].Id);
                }
                person.Skills = personSkills;
                person.Friends = friends;
            }
        }

        #endregion Private Methods
    }
}