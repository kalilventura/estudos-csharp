using System.Threading.Tasks;
using app.GraphQL;
using app.GraphQL.Interfaces;
using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route ("graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {
        private IMySchema _schema;
        public GraphqlController (IMySchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(exec => 
            {
                exec.Schema = _schema.GraphQLSchema;
                exec.Query = query.Query;
                exec.OperationName = query.OperationName;
                exec.Inputs = inputs;
            });

            if(result.Errors?.Count > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {result});
            }

            return Ok(result);
        }
    }
}