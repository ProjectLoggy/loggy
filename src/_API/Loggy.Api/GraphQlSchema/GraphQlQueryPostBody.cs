using Newtonsoft.Json.Linq;

namespace Loggy.Api.GraphQlSchema
{
	/// <summary>
	/// Represents a graphQl query string, as POSTed to our GraphQlController.
	/// From: https://github.com/mmacneil/ASPNetCoreGraphQL/blob/ed80a8d05b92e21db8be74f65a774c545bc33231/src/backend/NHLStats.Api/Models/GraphQLQuery.cs
	/// </summary>
	public class GraphQlQueryPostBody
	{
		public string OperationName { get; set; }
		public string NamedQuery { get; set; }
		public string Query { get; set; }
		public JObject Variables { get; set; }
	}
}
