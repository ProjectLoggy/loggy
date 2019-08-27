namespace Loggy.Api.Model
{
	public class LogSubjectDefinition
	{
		public string SubjectId { get; set; }
		public string SubjectName { get; set; }

		public LogSubjectDefinition(string subjectId, string subjectName)
		{
			SubjectId = subjectId;
			SubjectName = subjectName;
		}
	}
}
