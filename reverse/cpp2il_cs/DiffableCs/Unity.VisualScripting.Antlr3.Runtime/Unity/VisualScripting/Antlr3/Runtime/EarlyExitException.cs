namespace Unity.VisualScripting.Antlr3.Runtime;

public class EarlyExitException : RecognitionException
{
	public int decisionNumber; //Field offset: 0xC0

	public EarlyExitException() { }

	public EarlyExitException(int decisionNumber, IIntStream input) { }

}

