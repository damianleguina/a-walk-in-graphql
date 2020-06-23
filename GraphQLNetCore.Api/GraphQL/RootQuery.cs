using GraphQL.Types;
using GraphQLNetCore.Api.GraphQL.Types;
using GraphQLNetCore.Data.Repositories.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNetCore.Api.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IPersonRepository personRepository, ISkillRepository skillRepository)
        {
            Field<ListGraphType<PersonType>>
            (
                "people",
                resolve: context => personRepository.Get()
            );
            Field<ListGraphType<SkillType>>
            (
                "skills",
                resolve: context => skillRepository.Get()
            );
        }
    }
}
