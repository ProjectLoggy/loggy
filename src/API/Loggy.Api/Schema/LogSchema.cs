using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;

namespace Loggy.Api.Schema
{
	public class LogSchema: GraphQL.Types.Schema
	{
		public LogSchema(IDependencyResolver resolver): base(resolver)
		{
			Query = resolver.Resolve<LogsQuery>();	
			Mutation = null;
		}
	}
}
