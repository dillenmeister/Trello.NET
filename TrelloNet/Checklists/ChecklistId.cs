using TrelloNet.Internal;

namespace TrelloNet
{
	public class ChecklistId : IChecklistId
	{
		private readonly string _checklistId;

		public ChecklistId(string checklistId)
		{
			Guard.NotNullOrEmpty(checklistId, "checklistId");
			_checklistId = checklistId;
		}

		public string GetChecklistId()
		{
			return _checklistId;
		}
	}
}