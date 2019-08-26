using GraphQL.Types;
using Loggy.Api.DataAccess.MongoDb.DataAccess;
using Loggy.Api.Model.Model;

namespace Loggy.Api.GraphQlSchema
{
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
