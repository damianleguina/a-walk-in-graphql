using Newtonsoft.Json;

namespace GraphQLNetCore.DatabaseSeedHelper.Models
{
    internal class SkillJsonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parent")]
        public string Parent { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}