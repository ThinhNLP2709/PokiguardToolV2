namespace Unity.VisualScripting.Antlr3.Runtime;

public class MismatchedTokenException : RecognitionException
{
	private int expecting; //Field offset: 0xC0

	public int Expecting
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public MismatchedTokenException() { }

	public MismatchedTokenException(int expecting, IIntStream input) { }

	public int get_Expecting() { }

	public void set_Expecting(int value) { }

	public virtual string ToString() { }

}

