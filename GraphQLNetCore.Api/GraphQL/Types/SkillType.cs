using GraphQL.Types;
using GraphQLNetCore.Entities;

namespace GraphQLNetCore.Api.GraphQL.Types
{
    public class SkillType : ObjectGraphType<Skill>
    {
        public SkillType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.ParentId, nullable: true, type: typeof(IntGraphType));
            Field<SkillType>("Parent", resolve: context => context.Source.Parent);
        }
    }
}