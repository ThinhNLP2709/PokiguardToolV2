namespace Unity.VisualScripting.Antlr3.Runtime;

public interface ITokenSource
{

	public string SourceName
	{
		 get { } //Length: 0
	}

	public string get_SourceName() { }

	public IToken NextToken() { }

}

