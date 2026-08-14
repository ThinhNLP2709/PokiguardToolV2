namespace Unity.VisualScripting.FullSerializer;

public class fsJsonParser
{
	private readonly StringBuilder _cachedStringBuilder; //Field offset: 0x10
	private int _start; //Field offset: 0x18
	private string _input; //Field offset: 0x20

	private fsJsonParser(string input) { }

	private char Character() { }

	private char Character(int offset) { }

	private bool HasValue() { }

	private bool HasValue(int offset) { }

	private bool IsHex(char c) { }

	private bool IsSeparator(char c) { }

	private fsResult MakeFailure(string message) { }

	public static fsData Parse(string input) { }

	public static fsResult Parse(string input, out fsData data) { }

	private uint ParseSingleChar(char c1, uint multipliyer) { }

	private uint ParseUnicode(char c1, char c2, char c3, char c4) { }

	private fsResult RunParse(out fsData data) { }

	private void SkipSpace() { }

	private bool TryMoveNext() { }

	private fsResult TryParseArray(out fsData arr) { }

	private fsResult TryParseExact(string content) { }

	private fsResult TryParseFalse(out fsData data) { }

	private fsResult TryParseNull(out fsData data) { }

	private fsResult TryParseNumber(out fsData data) { }

	private fsResult TryParseObject(out fsData obj) { }

	private fsResult TryParseString(out string str) { }

	private fsResult TryParseTrue(out fsData data) { }

	private fsResult TryUnescapeChar(out char escaped) { }

}

