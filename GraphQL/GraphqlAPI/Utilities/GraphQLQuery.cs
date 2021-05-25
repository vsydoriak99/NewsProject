using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace NewsProject.GraphqlAPI.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
