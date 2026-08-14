namespace Unity.VisualScripting.Antlr3.Runtime;

public interface ITokenStream : IIntStream
{

	public ITokenSource TokenSource
	{
		 get { } //Length: 0
	}

	public IToken Get(int i) { }

	public ITokenSource get_TokenSource() { }

	public IToken LT(int k) { }

	public string ToString(int start, int stop) { }

	public string ToString(IToken start, IToken stop) { }

}

