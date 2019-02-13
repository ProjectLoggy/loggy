using GraphQL;
using Loggy.Api.GraphQlSchema.Queries;

namespace Loggy.Api.GraphQlSchema
{
	public class Schema: GraphQL.Types.Schema
	{
		public Schema(IDependencyResolver resolver): base(resolver)
		{
			Query = resolver.Resolve<RootQuery>();	
			Mutation = null;
		}
	}
}
