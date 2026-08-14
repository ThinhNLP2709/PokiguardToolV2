namespace UnityEngine.InputSystem.Utilities;

[Extension]
internal static class StringHelpers
{
	[CompilerGenerated]
	private sealed class <Split>d__9 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private string str; //Field offset: 0x28
		public string <>3__str; //Field offset: 0x30
		private Func<Char, Boolean> predicate; //Field offset: 0x38
		public Func<Char, Boolean> <>3__predicate; //Field offset: 0x40
		private int <length>5__2; //Field offset: 0x48
		private int <position>5__3; //Field offset: 0x4C

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <Split>d__9(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <Tokenize>d__8 : IEnumerable<Substring>, IEnumerable, IEnumerator<Substring>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private Substring <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x28
		private string str; //Field offset: 0x30
		public string <>3__str; //Field offset: 0x38
		private int <length>5__2; //Field offset: 0x40
		private int <endPos>5__3; //Field offset: 0x44

		private override Substring System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.Utilities.Substring>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 11
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 69
		}

		[DebuggerHidden]
		public <Tokenize>d__8(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Substring> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.Utilities.Substring>.GetEnumerator() { }

		[DebuggerHidden]
		private override Substring System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.Utilities.Substring>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}


	public static bool CharacterSeparatedListsHaveAtLeastOneCommonElement(string firstList, string secondList, char separator) { }

	[Extension]
	public static bool Contains(string str, char ch) { }

	[Extension]
	public static bool Contains(string str, string text, StringComparison comparison) { }

	[Extension]
	public static int CountOccurrences(string str, char ch) { }

	[Extension]
	public static string Escape(string str, string chars = "
	\"", string replacements = "ntr\"") { }

	public static string ExpandTemplateString(string template, Func<String, String> mapFunc) { }

	public static bool FromNicifiedMemorySize(string text, out long result, long defaultMultiplier = 1) { }

	[Extension]
	public static string GetPlural(string str) { }

	[Extension]
	public static bool InvariantEqualsIgnoreCase(string left, string right) { }

	[Extension]
	public static bool IsPrintable(char ch) { }

	public static string Join(IEnumerable<TValue> values, string separator) { }

	public static string Join(string separator, TValue[] values) { }

	public static string MakeUniqueName(string baseName, IEnumerable<TExisting> existingSet, Func<TExisting, String> getNameFunc) { }

	public static string NicifyMemorySize(long numBytes) { }

	public static int ParseInt(string str, int pos) { }

	public static string ReadStringFromBuffer(IntPtr buffer, int bufferSize) { }

	public static string ReadStringFromBuffer(IntPtr buffer, int bufferSize, ref uint offset) { }

	[Extension]
	[IteratorStateMachine(typeof(<Split>d__9))]
	public static IEnumerable<String> Split(string str, Func<Char, Boolean> predicate) { }

	[Extension]
	[IteratorStateMachine(typeof(<Tokenize>d__8))]
	public static IEnumerable<Substring> Tokenize(string str) { }

	[Extension]
	public static string Unescape(string str, string chars = "ntr\"", string replacements = "
	\"") { }

	[Extension]
	public static string WithAllWhitespaceStripped(string str) { }

	public static bool WriteStringToBuffer(string text, IntPtr buffer, int bufferSizeInCharacters) { }

	public static bool WriteStringToBuffer(string text, IntPtr buffer, int bufferSizeInCharacters, ref uint offset) { }

}

