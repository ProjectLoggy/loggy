using GraphQL.Types;
using Loggy.Api.DataAccess;

namespace Loggy.Api.Model
{
	public class LogFieldDefinition
	{
		public string FieldId { get; set; }
		public string FieldName { get; set; }

		public string DataTypeId { get; set; }

		public LogFieldDefinition(string fieldId, string fieldName, string dataTypeId)
		{
			FieldId = fieldId;
			FieldName = fieldName;
		}
	}

	public class LogFieldDefinitionGraphType: ObjectGraphType<LogFieldDefinition>
	{
		public LogFieldDefinitionGraphType(IDataTypeRepository dataTypeRepo)
		{
			Name = "LogFieldDefinition";
			Field(l => l.FieldId);
			Field(l => l.FieldName);
			Field(l => l.DataTypeId);

			Field<DataTypeDefinitionGraphType>(
				name: "dataType",
				resolve: ctx => dataTypeRepo.GetById(ctx.Source.DataTypeId).Result);
		}

	}
}
