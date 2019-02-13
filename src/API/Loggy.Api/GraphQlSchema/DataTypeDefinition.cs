using GraphQL.Types;
using Loggy.Api.Model.Model;

namespace Loggy.Api.GraphQlSchema
{
	public class DataTypeDefinitionGraphType: ObjectGraphType<DataTypeDefinition>
	{
		public DataTypeDefinitionGraphType()
		{
			Name = "DataTypeDefinition";
			Field(l => l.DataTypeId);
			Field(l => l.DataTypeName);
		}
	}
}
