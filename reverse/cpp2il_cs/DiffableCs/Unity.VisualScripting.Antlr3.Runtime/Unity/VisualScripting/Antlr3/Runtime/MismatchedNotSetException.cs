namespace Unity.VisualScripting.Antlr3.Runtime;

public class MismatchedNotSetException : MismatchedSetException
{

	public MismatchedNotSetException() { }

	public MismatchedNotSetException(BitSet expecting, IIntStream input) { }

	public virtual string ToString() { }

}

