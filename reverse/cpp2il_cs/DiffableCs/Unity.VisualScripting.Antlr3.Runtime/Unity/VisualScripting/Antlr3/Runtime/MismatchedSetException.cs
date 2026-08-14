namespace Unity.VisualScripting.Antlr3.Runtime;

public class MismatchedSetException : RecognitionException
{
	public BitSet expecting; //Field offset: 0xC0

	public MismatchedSetException() { }

	public MismatchedSetException(BitSet expecting, IIntStream input) { }

	public virtual string ToString() { }

}

