namespace Unity.VisualScripting.Antlr3.Runtime;

public class MismatchedTreeNodeException : RecognitionException
{
	public int expecting; //Field offset: 0xC0

	public MismatchedTreeNodeException() { }

	public MismatchedTreeNodeException(int expecting, ITreeNodeStream input) { }

	public virtual string ToString() { }

}

