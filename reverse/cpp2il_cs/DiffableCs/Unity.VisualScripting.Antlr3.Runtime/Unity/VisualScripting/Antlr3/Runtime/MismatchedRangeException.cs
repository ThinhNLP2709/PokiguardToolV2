namespace Unity.VisualScripting.Antlr3.Runtime;

public class MismatchedRangeException : RecognitionException
{
	private int a; //Field offset: 0xC0
	private int b; //Field offset: 0xC4

	public int A
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public int B
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public MismatchedRangeException() { }

	public MismatchedRangeException(int a, int b, IIntStream input) { }

	public int get_A() { }

	public int get_B() { }

	public void set_A(int value) { }

	public void set_B(int value) { }

	public virtual string ToString() { }

}

