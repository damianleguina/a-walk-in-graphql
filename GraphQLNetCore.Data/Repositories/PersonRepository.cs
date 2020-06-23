using GraphQLNetCore.Data.Repositories.Abstractions;
using GraphQLNetCore.Data.Repositories.Interfaces.Entities;
using GraphQLNetCore.Entities;

namespace GraphQLNetCore.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
    }
}