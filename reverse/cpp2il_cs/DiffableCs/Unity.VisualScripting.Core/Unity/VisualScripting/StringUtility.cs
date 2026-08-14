namespace Unity.VisualScripting;

[Extension]
public static class StringUtility
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Object, String> <>9__4_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <ToSeparatedString>b__4_0(object o) { }

	}

	[CompilerGenerated]
	private sealed class <AllIndexesOf>d__8 : IEnumerable<Int32>, IEnumerable, IEnumerator<Int32>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private int <>2__current; //Field offset: 0x14
		private int <>l__initialThreadId; //Field offset: 0x18
		private string needle; //Field offset: 0x20
		public string <>3__needle; //Field offset: 0x28
		private string haystack; //Field offset: 0x30
		public string <>3__haystack; //Field offset: 0x38
		private int <index>5__2; //Field offset: 0x40

		private override int System.Collections.Generic.IEnumerator<System.Int32>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 4
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 1078
		}

		[DebuggerHidden]
		public <AllIndexesOf>d__8(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Int32> System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator() { }

		[DebuggerHidden]
		private override int System.Collections.Generic.IEnumerator<System.Int32>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly Regex guidRegex; //Field offset: 0x0

	private static StringUtility() { }

	[Extension]
	[IteratorStateMachine(typeof(<AllIndexesOf>d__8))]
	public static IEnumerable<Int32> AllIndexesOf(string haystack, string needle) { }

	[Extension]
	public static void AppendLineFormat(StringBuilder sb, string format, Object[] args) { }

	[Extension]
	public static bool Contains(string s, char c) { }

	[Extension]
	public static bool ContainsInsensitive(string haystack, string needle) { }

	[Extension]
	public static int CountIndices(string s, char c) { }

	[Extension]
	public static bool EndsWith(string s, char c) { }

	public static string FallbackEmpty(string s, string fallback) { }

	public static string FallbackWhitespace(string s, string fallback) { }

	[Extension]
	public static string Filter(string s, bool letters = true, bool numbers = true, bool whitespace = true, bool symbols = true, bool punctuation = true) { }

	[Extension]
	public static string FilterReplace(string s, char replacement, bool merge, bool letters = true, bool numbers = true, bool whitespace = true, bool symbols = true, bool punctuation = true) { }

	[Extension]
	public static string FirstCharacterToLower(string s) { }

	[Extension]
	public static string FirstCharacterToUpper(string s) { }

	public static bool IsGuid(string value) { }

	public static bool IsNullOrWhiteSpace(string s) { }

	public static bool IsWordBeginning(string s, int index) { }

	public static bool IsWordBeginning(Nullable<Char> previous, char current, Nullable<Char> next) { }

	public static bool IsWordDelimiter(char c) { }

	[Extension]
	public static string NullIfEmpty(string s) { }

	[Extension]
	public static string PartAfter(string s, char c) { }

	[Extension]
	public static string PartBefore(string s, char c) { }

	[Extension]
	public static void PartsAround(string s, char c, out string before, out string after) { }

	public static string PathEllipsis(string s, int maxLength) { }

	[Extension]
	public static string Prettify(string s) { }

	[Extension]
	public static string RemoveConsecutiveCharacters(string s, char c) { }

	[Extension]
	public static string ReplaceMultiple(string s, HashSet<Char> haystacks, char replacement) { }

	[Extension]
	public static string SplitWords(string s, char separator) { }

	[Extension]
	public static bool StartsWith(string s, char c) { }

	[Extension]
	public static string ToBinaryString(int value) { }

	[Extension]
	public static string ToBinaryString(long value) { }

	[Extension]
	public static string ToBinaryString(Enum value) { }

	[Extension]
	public static string ToCommaSeparatedString(IEnumerable enumerable) { }

	[Extension]
	public static string ToHexString(Byte[] bytes) { }

	[Extension]
	public static string ToLineSeparatedString(IEnumerable enumerable) { }

	[Extension]
	public static string ToSeparatedString(IEnumerable enumerable, string separator) { }

	[Extension]
	public static string TrimEnd(string source, string value) { }

	[Extension]
	public static string TrimStart(string source, string value) { }

	[Extension]
	public static string Truncate(string value, int maxLength, string suffix = "...") { }

}

