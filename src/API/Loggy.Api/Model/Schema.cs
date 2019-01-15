using GraphQL;
using Loggy.Api.Model.Queries;

namespace Loggy.Api.Model
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
