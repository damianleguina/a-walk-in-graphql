using Newtonsoft.Json;
using System.Collections.Generic;

namespace GraphQLNetCore.DatabaseSeedHelper.Models
{
    internal class PersonJsonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("eyeColor")]
        public string EyeColor { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("favSkill")]
        public string FavSkill { get; set; }

        [JsonProperty("friends")]
        public ICollection<string> Friends { get; set; }

        [JsonProperty("skills")]
        public ICollection<string> Skills { get; set; }
    }
}