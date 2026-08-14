namespace Unity.VisualScripting;

public sealed class AmbiguousOperatorException : OperatorException
{

	public AmbiguousOperatorException(string symbol, Type leftType, Type rightType) { }

}

