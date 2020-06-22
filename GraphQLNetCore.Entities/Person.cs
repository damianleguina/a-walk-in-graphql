using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLNetCore.Entities
{
    public class Person
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string AgeColor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string FavSkill { get; set; }
        public ICollection<Person> Friends { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
