using Newtonsoft.Json.Linq;
using System;

namespace GraphQLNetCore.Utils
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
