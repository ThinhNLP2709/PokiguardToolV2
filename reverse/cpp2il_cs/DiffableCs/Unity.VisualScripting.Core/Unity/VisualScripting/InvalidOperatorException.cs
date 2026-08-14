namespace Unity.VisualScripting;

public sealed class InvalidOperatorException : OperatorException
{

	public InvalidOperatorException(string symbol, Type type) { }

	public InvalidOperatorException(string symbol, Type leftType, Type rightType) { }

}

