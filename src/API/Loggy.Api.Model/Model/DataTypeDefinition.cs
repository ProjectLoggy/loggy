namespace Loggy.Api.Model.Model
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
}
