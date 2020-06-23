using Newtonsoft.Json;
using System.Collections.Generic;

namespace GraphQLNetCore.DatabaseSeedHelper.Models
{
    internal class SeedJsonModel
    {
        [JsonProperty("skills")]
        public List<SkillJsonModel> Skills { get; set; }

        [JsonProperty("persons")]
        public List<PersonJsonModel> People { get; set; }
    }
}