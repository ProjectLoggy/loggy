using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Loggy.Api.GraphQlSchema;
using Loggy.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Loggy.Api.Controllers
{
	[Route("[controller]")] 
	public class GraphQlController : Controller
	{
		private readonly IDocumentExecuter _documentExecuter;
		private readonly ISchema _schema;

		// ReSharper disable once IdentifierTypo
		public GraphQlController(ISchema schema, IDocumentExecuter documentExecuter)
		{
			_schema = schema;
			_documentExecuter = documentExecuter;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]GraphQlQueryPostBody queryPostBody)
		{
			if (queryPostBody == null) throw new ArgumentNullException(nameof(queryPostBody));
			Inputs inputs = queryPostBody.Variables.ToInputs();
			var executionOptions = new ExecutionOptions
			{
				Schema = _schema,
				Query = queryPostBody.Query,
				Inputs = inputs
			};

			var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

			if (result.Errors?.Count > 0)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}