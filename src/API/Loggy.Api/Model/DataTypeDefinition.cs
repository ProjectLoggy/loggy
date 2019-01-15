using GraphQL.Types;

namespace Loggy.Api.Model
{
	public class DataTypeDefinition
	{
		public string DataTypeId { get; set; }
		public string DataTypeName { get; set; }

		public DataTypeDefinition(string dataTypeId, string dataTypeName)
		{
			DataTypeId = dataTypeId;
			DataTypeName = dataTypeName;
		}
	}

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
