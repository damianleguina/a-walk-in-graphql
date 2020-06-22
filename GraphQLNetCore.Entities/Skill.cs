using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLNetCore.Entities
{
    public class Skill
    {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Name { get; set; }
    }
}
