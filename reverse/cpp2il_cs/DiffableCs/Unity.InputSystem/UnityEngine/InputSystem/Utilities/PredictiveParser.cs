namespace UnityEngine.InputSystem.Utilities;

internal struct PredictiveParser
{
	private int m_Position; //Field offset: 0x0

	public void AcceptInt(ReadOnlySpan<Char> str) { }

	public bool AcceptSingleChar(ReadOnlySpan<Char> str, char c) { }

	public bool AcceptString(ReadOnlySpan<Char> input, out ReadOnlySpan<Char>& output) { }

	public int ExpectInt(ReadOnlySpan<Char> str) { }

	public void ExpectSingleChar(ReadOnlySpan<Char> str, char c) { }

	public ReadOnlySpan<Char> ExpectString(ReadOnlySpan<Char> str) { }

}

