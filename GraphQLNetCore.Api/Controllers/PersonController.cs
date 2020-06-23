using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLNetCore.Data;
using GraphQLNetCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        GraphQLContext context;

        public PersonController(GraphQLContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return context.People.ToList();
        }
    }
}
