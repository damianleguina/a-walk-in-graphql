using GraphQLNetCore.Data.Repositories.Abstractions;
using GraphQLNetCore.Data.Repositories.Interfaces.Entities;
using GraphQLNetCore.Entities;

namespace GraphQLNetCore.Data.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(GraphQLContext context) : base(context)
        {
        }
    }
}