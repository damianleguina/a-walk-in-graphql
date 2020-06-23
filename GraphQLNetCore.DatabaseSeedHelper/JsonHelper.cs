using GraphQLNetCore.DatabaseSeedHelper.Models;
using GraphQLNetCore.DatabaseSeedHelper.Utils;
using GraphQLNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLNetCore.DatabaseSeedHelper
{
    internal static class JsonHelper
    {
        public static (List<Skill>, List<Person>) GetEntities()
        {
            SeedJsonModel seed = GetSeed();
            SeedJsonMapper seedJsonMapper = new SeedJsonMapper();
            List<Skill> skills = seedJsonMapper.MapSkills(seed.Skills);
            List<Person> people = seedJsonMapper.MapPeople(seed.People);
            return (skills, people);
        }


        private static SeedJsonModel GetSeed()
        {
            SeedDeserializer seedDeserializer = new SeedDeserializer();
            var seed = seedDeserializer.GetDeserializedSeedJson();
            return seed;
        }
    }
}
