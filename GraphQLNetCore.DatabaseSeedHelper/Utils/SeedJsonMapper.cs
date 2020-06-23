using GraphQLNetCore.DatabaseSeedHelper.Models;
using GraphQLNetCore.Entities;
using System;
using System.Collections.Generic;

namespace GraphQLNetCore.DatabaseSeedHelper.Utils
{
    internal class SeedJsonMapper
    {
        #region Public Methods

        public List<Person> MapPeople(List<PersonJsonModel> people)
        {
            var result = new List<Person>();
            foreach (var person in people)
            {
                result.Add(MapPerson(person));
            }
            return result;
        }

        public List<Skill> MapSkills(List<SkillJsonModel> skills)
        {
            var result = new List<Skill>();
            foreach (var skill in skills)
            {
                result.Add(MapSkill(skill));
            }
            return result;
        }

        #endregion Public Methods

        #region Private Methods

        #region Map Methods

        private Person MapPerson(PersonJsonModel person)
        {
            return new Person
            {
                Id = GetPersonId(person),
                Age = person.Age,
                EyeColor = person.EyeColor,
                Name = person.Name,
                Surname = person.Surname,
                Email = person.Email,
                FavSkillId = GetPersonFavSkillId(person),
                Friends = GetPersonFriends(person),
                Skills = GetPersonSkills(person)
            };
        }

        private Skill MapSkill(SkillJsonModel skill)
        {
            return new Skill()
            {
                Id = GetSkillId(skill),
                ParentId = GetSkillParentId(skill),
                Name = skill.Name
            };
        }

        #endregion Map Methods

        #region Person Properties Methods

        private static int? GetPersonFavSkillId(PersonJsonModel person)
        {
            return person.FavSkill != null ? (int?)Int32.Parse(person.FavSkill) : null;
        }

        private static ICollection<Person> GetPersonFriends(PersonJsonModel person)
        {
            List<Person> result = new List<Person>();
            if (person.Friends != null)
            {
                foreach (var friend in person.Friends)
                {
                    result.Add(new Person() { Id = Int32.Parse(friend) });
                }
            }
            return result;
        }

        private static int GetPersonId(PersonJsonModel person)
        {
            return Int32.Parse(person.Id);
        }

        private static ICollection<Skill> GetPersonSkills(PersonJsonModel person)
        {
            List<Skill> result = new List<Skill>();
            if (person.Friends != null)
            {
                foreach (var skill in person.Skills)
                {
                    result.Add(new Skill() { Id = Int32.Parse(skill) });
                }
            }
            return result;
        }

        #endregion Person Properties Methods

        #region Skill Properties Methods

        private static int GetSkillId(SkillJsonModel skill)
        {
            return Int32.Parse(skill.Id);
        }

        private static int? GetSkillParentId(SkillJsonModel skill)
        {
            return skill.Parent != null ? (int?)Int32.Parse(skill.Parent) : null;
        }

        #endregion Skill Properties Methods

        #endregion Private Methods
    }
}