using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLNetCore.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLNetCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecuter;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            this.schema = schema;
            this.documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var inputs = query.Variables?.ToInputs();
            var executionOption = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await documentExecuter.ExecuteAsync(executionOption);

            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
