namespace UnityEngine.InputSystem.Layouts;

public struct InputDeviceMatcher : IEquatable<InputDeviceMatcher>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Char, Boolean> <>9__12_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <With>b__12_0(char ch) { }

	}

	[CompilerGenerated]
	private sealed class <get_patterns>d__4 : IEnumerable<KeyValuePair`2<String, Object>>, IEnumerable, IEnumerator<KeyValuePair`2<String, Object>>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private KeyValuePair<String, Object> <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x28
		public InputDeviceMatcher <>4__this; //Field offset: 0x30
		public InputDeviceMatcher <>3__<>4__this; //Field offset: 0x38
		private int <count>5__2; //Field offset: 0x40
		private int <i>5__3; //Field offset: 0x44

		private override KeyValuePair<String, Object> System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Current
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
		public <get_patterns>d__4(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<KeyValuePair`2<String, Object>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.GetEnumerator() { }

		[DebuggerHidden]
		private override KeyValuePair<String, Object> System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public struct MatcherJson
	{
		internal struct Capability
		{
			public string path; //Field offset: 0x0
			public string value; //Field offset: 0x8

		}

		public string interface; //Field offset: 0x0
		public String[] interfaces; //Field offset: 0x8
		public string deviceClass; //Field offset: 0x10
		public String[] deviceClasses; //Field offset: 0x18
		public string manufacturer; //Field offset: 0x20
		public string manufacturerContains; //Field offset: 0x28
		public String[] manufacturers; //Field offset: 0x30
		public string product; //Field offset: 0x38
		public String[] products; //Field offset: 0x40
		public string version; //Field offset: 0x48
		public String[] versions; //Field offset: 0x50
		public Capability[] capabilities; //Field offset: 0x58

		public static MatcherJson FromMatcher(InputDeviceMatcher matcher) { }

		public InputDeviceMatcher ToMatcher() { }

	}

	private static readonly InternedString kInterfaceKey; //Field offset: 0x0
	private static readonly InternedString kDeviceClassKey; //Field offset: 0x10
	private static readonly InternedString kManufacturerKey; //Field offset: 0x20
	private static readonly InternedString kManufacturerContainsKey; //Field offset: 0x30
	private static readonly InternedString kProductKey; //Field offset: 0x40
	private static readonly InternedString kVersionKey; //Field offset: 0x50
	private KeyValuePair<InternedString, Object>[] m_Patterns; //Field offset: 0x0

	public bool empty
	{
		 get { } //Length: 8
	}

	public IEnumerable<KeyValuePair`2<String, Object>> patterns
	{
		[IteratorStateMachine(typeof(<get_patterns>d__4))]
		 get { } //Length: 115
	}

	private static InputDeviceMatcher() { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(InputDeviceMatcher other) { }

	public static InputDeviceMatcher FromDeviceDescription(InputDeviceDescription deviceDescription) { }

	public bool get_empty() { }

	[IteratorStateMachine(typeof(<get_patterns>d__4))]
	public IEnumerable<KeyValuePair`2<String, Object>> get_patterns() { }

	public virtual int GetHashCode() { }

	private static int GetNumPropertiesIn(InputDeviceDescription description) { }

	public float MatchPercentage(InputDeviceDescription deviceDescription) { }

	private static bool MatchSingleProperty(object pattern, string value) { }

	private static bool MatchSinglePropertyContains(object pattern, string value) { }

	public static bool op_Equality(InputDeviceMatcher left, InputDeviceMatcher right) { }

	public static bool op_Inequality(InputDeviceMatcher left, InputDeviceMatcher right) { }

	public virtual string ToString() { }

	private InputDeviceMatcher With(InternedString key, object value, bool supportRegex = true) { }

	public InputDeviceMatcher WithCapability(string path, TValue value) { }

	public InputDeviceMatcher WithDeviceClass(string pattern, bool supportRegex = true) { }

	public InputDeviceMatcher WithInterface(string pattern, bool supportRegex = true) { }

	public InputDeviceMatcher WithManufacturer(string pattern, bool supportRegex = true) { }

	public InputDeviceMatcher WithManufacturerContains(string noRegExPattern) { }

	public InputDeviceMatcher WithProduct(string pattern, bool supportRegex = true) { }

	public InputDeviceMatcher WithVersion(string pattern, bool supportRegex = true) { }

}

