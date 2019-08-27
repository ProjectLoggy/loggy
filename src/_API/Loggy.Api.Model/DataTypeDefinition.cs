namespace Loggy.Api.Model
{
	/// <summary>
	/// A log field is of a certain dataType.
	/// </summary>
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
