namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public class RewriteCardinalityException : Exception
{
	public string elementDescription; //Field offset: 0x90

	public virtual string Message
	{
		 get { } //Length: 21
	}

	public RewriteCardinalityException(string elementDescription) { }

	public virtual string get_Message() { }

}

