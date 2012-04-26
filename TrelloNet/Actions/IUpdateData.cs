namespace TrelloNet
{
	public interface IUpdateData
	{
		dynamic OldValue { set;  }
		dynamic NewValue { set; }
		string UpdatedProperty { set; }
	}
}