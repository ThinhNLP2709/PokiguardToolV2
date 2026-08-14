namespace Unity.VisualScripting.Antlr3.Runtime;

public class MissingTokenException : MismatchedTokenException
{
	private object inserted; //Field offset: 0xC8

	public object Inserted
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public int MissingType
	{
		 get { } //Length: 7
	}

	public MissingTokenException() { }

	public MissingTokenException(int expecting, IIntStream input, object inserted) { }

	public object get_Inserted() { }

	public int get_MissingType() { }

	public void set_Inserted(object value) { }

	public virtual string ToString() { }

}

