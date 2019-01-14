using GraphQL;
using GraphQL.Types;
using Loggy.Api.DataAccess;
using Loggy.Api.Model.Queries;

namespace Loggy.Api.Schema.Queries
{
	public class RootQuery: ObjectGraphType
	{
		public RootQuery(IDependencyResolver resolver)
		{
			Name = "Query";

			Field<MySubQuery>(
				name: "subQuery",
				resolve: ctx => new{ });
		}
	}


	public class MySubQuery: ObjectGraphType
	{
		public MySubQuery()
		{
			Name = "TempSubQuery";

			Field<StringGraphType>("SubQueryName", resolve: ctx => "Some string value");

			Field<MySubObjectGraphType>(
				name: "subObjectGraph",
				resolve: ctx => FetchFromRepo());
		}

		
		//Repo access would go here, but just new-ing the object for now.
		private SubObject FetchFromRepo()
		{
			return new SubObject() { Name = "some sub object" };
		}
	}


	public class SubObject
	{
		public string Name { get; set; }
	}
	
	public class MySubObjectGraphType: ObjectGraphType<SubObject>
	{
		public MySubObjectGraphType()
		{
			Name = "MySubObject";
			Description = "An object with leaf nodes";

			Field(l => l.Name);
		}
	}

}
