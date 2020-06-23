using GraphQL.Types;
using GraphQLNetCore.Api.GraphQL.Types;
using GraphQLNetCore.Data.Repositories.Interfaces.Entities;

namespace GraphQLNetCore.Api.GraphQL.Queries
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<ListGraphType<PersonType>>
            (
                "people",
                resolve: context => personRepository.Get()
            );
        }
    }
}