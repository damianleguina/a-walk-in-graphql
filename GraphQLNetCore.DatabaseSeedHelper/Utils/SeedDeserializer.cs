using GraphQLNetCore.DatabaseSeedHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLNetCore.DatabaseSeedHelper.Utils
{
    internal class SeedDeserializer
    {
        public SeedJsonModel GetDeserializedSeedJson()
        {
            return JsonConvert.DeserializeObject<SeedJsonModel>(Seed.Json);
        }
    }
}
