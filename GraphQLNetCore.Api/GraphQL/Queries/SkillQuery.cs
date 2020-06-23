using GraphQL.Types;
using GraphQLNetCore.Api.GraphQL.Types;
using GraphQLNetCore.Data.Repositories.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNetCore.Api.GraphQL.Queries
{
    public class SkillQuery : ObjectGraphType
    {
        public SkillQuery(ISkillRepository skillRepository)
        {
            Field<ListGraphType<SkillType>>
            (
                "skills",
                resolve: context => skillRepository.Get()
            );
        }
    }
}
