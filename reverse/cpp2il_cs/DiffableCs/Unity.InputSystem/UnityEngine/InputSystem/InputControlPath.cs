namespace UnityEngine.InputSystem;

[Extension]
public static class InputControlPath
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Substring, String> <>9__9_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <TryGetDeviceUsages>b__9_0(Substring x) { }

	}

	[CompilerGenerated]
	private sealed class <Parse>d__34 : IEnumerable<ParsedPathComponent>, IEnumerable, IEnumerator<ParsedPathComponent>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private ParsedPathComponent <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x68
		private string path; //Field offset: 0x70
		public string <>3__path; //Field offset: 0x78
		private PathParser <parser>5__2; //Field offset: 0x80

		private override ParsedPathComponent System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.InputControlPath.ParsedPathComponent>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 43
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 105
		}

		[DebuggerHidden]
		public <Parse>d__34(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<ParsedPathComponent> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputControlPath.ParsedPathComponent>.GetEnumerator() { }

		[DebuggerHidden]
		private override ParsedPathComponent System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.InputControlPath.ParsedPathComponent>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[Flags]
	internal enum HumanReadableStringOptions
	{
		None = 0,
		OmitDevice = 2,
		UseShortNames = 4,
	}

	internal struct ParsedPathComponent
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<Substring, String> <>9__7_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal string <get_usages>b__7_0(Substring x) { }

		}

		internal Substring m_Layout; //Field offset: 0x0
		internal InlinedArray<Substring> m_Usages; //Field offset: 0x10
		internal Substring m_Name; //Field offset: 0x30
		internal Substring m_DisplayName; //Field offset: 0x40

		public string displayName
		{
			 get { } //Length: 11
		}

		internal bool isDoubleWildcard
		{
			internal get { } //Length: 109
		}

		internal bool isWildcard
		{
			internal get { } //Length: 109
		}

		public string layout
		{
			 get { } //Length: 7
		}

		public string name
		{
			 get { } //Length: 11
		}

		public IEnumerable<String> usages
		{
			 get { } //Length: 326
		}

		private static bool ComparePathElementToString(Substring pathElement, string element) { }

		public string get_displayName() { }

		internal bool get_isDoubleWildcard() { }

		internal bool get_isWildcard() { }

		public string get_layout() { }

		public string get_name() { }

		public IEnumerable<String> get_usages() { }

		public bool Matches(InputControl control) { }

		internal string ToHumanReadableString(string parentLayoutName, string parentControlPath, out string referencedLayoutName, out string controlPath, HumanReadableStringOptions options) { }

		private static string ToHumanReadableString(Substring substring) { }

	}

	private enum PathComponentType
	{
		Name = 0,
		DisplayName = 1,
		Usage = 2,
		Layout = 3,
	}

	private struct PathParser
	{
		private string path; //Field offset: 0x0
		private int length; //Field offset: 0x8
		private int leftIndexInPath; //Field offset: 0xC
		private int rightIndexInPath; //Field offset: 0x10
		public ParsedPathComponent current; //Field offset: 0x18

		public bool isAtEnd
		{
			 get { } //Length: 10
		}

		public PathParser(string path) { }

		public bool get_isAtEnd() { }

		public bool MoveToNextComponent() { }

		private Substring ParseComponentPart(char terminator) { }

	}

	public const string Wildcard = "*"; //Field offset: 0x0
	public const string DoubleWildcard = "**"; //Field offset: 0x0
	public const char Separator = '\u2F'; //Field offset: 0x0
	internal const char SeparatorReplacement = '\u20'; //Field offset: 0x0

	[Extension]
	internal static string CleanSlashes(string pathComponent) { }

	public static string Combine(InputControl parent, string path) { }

	private static bool ControlLayoutMatchesPathComponent(ref ControlItem controlItem, ref PathParser parser) { }

	private static string FindControlLayoutRecursive(ref PathParser parser, string layoutName) { }

	private static string FindControlLayoutRecursive(ref PathParser parser, InputControlLayout layout) { }

	private static TControl MatchByUsageAtDeviceRootRecursive(InputDevice device, string path, int indexInPath, ref InputControlList<TControl>& matches, bool matchMultiple) { }

	private static TControl MatchChildrenRecursive(InputControl control, string path, int indexInPath, ref InputControlList<TControl>& matches, bool matchMultiple) { }

	internal static bool MatchControlComponent(ref ParsedPathComponent expectedControlComponent, ref ControlItem controlItem, bool matchAlias = false) { }

	private static TControl MatchControlsRecursive(InputControl control, string path, int indexInPath, ref InputControlList<TControl>& matches, bool matchMultiple) { }

	public static bool Matches(string expected, InputControl control) { }

	public static bool MatchesPrefix(string expected, InputControl control) { }

	private static bool MatchesRecursive(ref PathParser parser, InputControl currentControl, bool prefixOnly = false) { }

	private static bool MatchPathComponent(string component, string path, ref int indexInPath, PathComponentType componentType, int startIndexInComponent = 0) { }

	[IteratorStateMachine(typeof(<Parse>d__34))]
	public static IEnumerable<ParsedPathComponent> Parse(string path) { }

	private static bool PathComponentCanYieldMultipleMatches(string path, int indexInPath) { }

	private static bool StringMatches(Substring str, InternedString matchTo) { }

	public static string ToHumanReadableString(string path, out string deviceLayoutName, out string controlPath, HumanReadableStringOptions options = 0, InputControl control = null) { }

	public static string ToHumanReadableString(string path, HumanReadableStringOptions options = 0, InputControl control = null) { }

	public static InputControl TryFindChild(InputControl control, string path, int indexInPath = 0) { }

	public static TControl TryFindChild(InputControl control, string path, int indexInPath = 0) { }

	public static TControl TryFindControl(InputControl control, string path, int indexInPath = 0) { }

	public static InputControl TryFindControl(InputControl control, string path, int indexInPath = 0) { }

	public static int TryFindControls(InputControl control, string path, int indexInPath, ref InputControlList<TControl>& matches) { }

	public static InputControl[] TryFindControls(InputControl control, string path, int indexInPath = 0) { }

	public static int TryFindControls(InputControl control, string path, ref InputControlList<InputControl>& matches, int indexInPath = 0) { }

	public static string TryGetControlLayout(string path) { }

	public static string TryGetDeviceLayout(string path) { }

	public static String[] TryGetDeviceUsages(string path) { }

}

