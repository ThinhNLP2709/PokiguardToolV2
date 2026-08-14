namespace Unity.VisualScripting.Antlr3.Runtime;

public static class Token
{
	public const int EOR_TOKEN_TYPE = 1; //Field offset: 0x0
	public const int DOWN = 2; //Field offset: 0x0
	public const int UP = 3; //Field offset: 0x0
	public const int INVALID_TOKEN_TYPE = 0; //Field offset: 0x0
	public const int DEFAULT_CHANNEL = 0; //Field offset: 0x0
	public const int HIDDEN_CHANNEL = 99; //Field offset: 0x0
	public static readonly int MIN_TOKEN_TYPE; //Field offset: 0x0
	public static readonly int EOF; //Field offset: 0x4
	public static readonly IToken EOF_TOKEN; //Field offset: 0x8
	public static readonly IToken INVALID_TOKEN; //Field offset: 0x10
	public static readonly IToken SKIP_TOKEN; //Field offset: 0x18

	private static Token() { }

}

