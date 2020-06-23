using GraphQL.Types;
using GraphQLNetCore.Entities;

namespace GraphQLNetCore.Api.GraphQL.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Age);
            Field(x => x.EyeColor);
            Field(x => x.Name);
            Field(x => x.Surname);
            Field(x => x.Email);
            Field(x => x.FavSkillId, nullable: true, type: typeof(IntGraphType));
            Field<StringGraphType>("fullName", resolve: context => context.Source.Name + " " + context.Source.Surname);
            Field<SkillType>("favSkill", resolve: context => context.Source.FavSkill);
            Field<ListGraphType<PersonType>>("friends", resolve: context => context.Source.Friends);
            Field<ListGraphType<SkillType>>("skills", resolve: context => context.Source.Skills);
        }
    }
}