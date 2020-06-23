using GraphQLNetCore.Entities.Abstractions;

namespace GraphQLNetCore.Entities
{
    public class Skill : BaseEntity
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }

        public Skill Parent { get; set; }
    }
}