namespace Unity.VisualScripting.Antlr3.Runtime;

public class FailedPredicateException : RecognitionException
{
	public string ruleName; //Field offset: 0xC0
	public string predicateText; //Field offset: 0xC8

	public FailedPredicateException() { }

	public FailedPredicateException(IIntStream input, string ruleName, string predicateText) { }

	public virtual string ToString() { }

}

