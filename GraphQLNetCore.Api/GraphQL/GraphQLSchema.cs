using GraphQL;
using GraphQL.Types;
using GraphQLNetCore.Api.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNetCore.Api.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<SkillQuery>();
        }
    }
}
