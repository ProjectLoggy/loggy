namespace Loggy.Api.Model.Model
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
}
