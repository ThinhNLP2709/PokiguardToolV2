namespace Unity.VisualScripting.Antlr3.Runtime;

public class NoViableAltException : RecognitionException
{
	public string grammarDecisionDescription; //Field offset: 0xC0
	public int decisionNumber; //Field offset: 0xC8
	public int stateNumber; //Field offset: 0xCC

	public NoViableAltException() { }

	public NoViableAltException(string grammarDecisionDescription, int decisionNumber, int stateNumber, IIntStream input) { }

	public virtual string ToString() { }

}

