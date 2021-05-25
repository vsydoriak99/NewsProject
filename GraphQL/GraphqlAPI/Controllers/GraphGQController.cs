using System;
using GraphQL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQL.Types;

namespace NewsProject.GraphqlAPI.Controllers
{
    [Route("graphql")]
    public class GraphGQController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documensExecutor;

        public GraphGQController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documensExecutor = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Utilities.GraphQLQuery query)
        {
            if(query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }




            var inputs = query.Variables?.ToInputs();
            var executionOptions = new ExecutionOptions()
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documensExecutor.ExecuteAsync(executionOptions);

            if(result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
