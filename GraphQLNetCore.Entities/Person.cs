using GraphQLNetCore.Entities.Abstractions;
using System.Collections.Generic;

namespace GraphQLNetCore.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {
            this.Friends = new HashSet<Person>();
            this.Skills = new HashSet<Skill>();
        } 

        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? FavSkillId { get; set; }

        public ICollection<Person> Friends { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public Skill FavSkill { get; set; }
    }
}