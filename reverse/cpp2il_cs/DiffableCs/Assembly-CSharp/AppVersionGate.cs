//Type is in global namespace

public static class AppVersionGate
{
	[CompilerGenerated]
	private sealed class <Fetch>d__31 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private string <raw>5__2; //Field offset: 0x20
		private bool <ok>5__3; //Field offset: 0x28
		private string <err>5__4; //Field offset: 0x30
		private UnityWebRequest <req>5__5; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <Fetch>d__31(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public const string MODE_NONE = "NONE"; //Field offset: 0x0
	public const string MODE_SOFT = "SOFT"; //Field offset: 0x0
	public const string MODE_FORCE = "FORCE"; //Field offset: 0x0
	public const string MODE_MAINTENANCE = "MAINTENANCE"; //Field offset: 0x0
	private const int TIMEOUT_SECONDS = 5; //Field offset: 0x0
	private const double STICKY_HOURS = 12; //Field offset: 0x0
	private const string PREF_STICKY_MODE = "GateStickyMode"; //Field offset: 0x0
	private const string PREF_STICKY_AT = "GateStickyAtUtcTicks"; //Field offset: 0x0
	private const string PREF_STICKY_MSG = "GateStickyMessage"; //Field offset: 0x0
	[CompilerGenerated]
	private static AppBootstrapData <Data>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static string <Mode>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static bool <UsedFailOpen>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static string <BlockMessage>k__BackingField; //Field offset: 0x18

	public private static string BlockMessage
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	public static string CurrentPlatform
	{
		 get { } //Length: 44
	}

	public private static AppBootstrapData Data
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	public static bool IsBlocking
	{
		 get { } //Length: 277
	}

	public private static string Mode
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	public static string UpdateUrl
	{
		 get { } //Length: 472
	}

	public private static bool UsedFailOpen
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	private static AppVersionGate() { }

	private static void ApplyFailOpenOrSticky(string reason) { }

	private static void ClearSticky() { }

	[IteratorStateMachine(typeof(<Fetch>d__31))]
	public static IEnumerator Fetch() { }

	[CompilerGenerated]
	public static string get_BlockMessage() { }

	public static string get_CurrentPlatform() { }

	[CompilerGenerated]
	public static AppBootstrapData get_Data() { }

	public static bool get_IsBlocking() { }

	[CompilerGenerated]
	public static string get_Mode() { }

	public static string get_UpdateUrl() { }

	[CompilerGenerated]
	public static bool get_UsedFailOpen() { }

	private static string NormalizeMode(string m) { }

	public static void OpenUpdateUrl() { }

	private static string ReadStickyMode() { }

	private static void RememberSticky(string mode, string message) { }

	[CompilerGenerated]
	private static void set_BlockMessage(string value) { }

	[CompilerGenerated]
	private static void set_Data(AppBootstrapData value) { }

	[CompilerGenerated]
	private static void set_Mode(string value) { }

	[CompilerGenerated]
	private static void set_UsedFailOpen(bool value) { }

}

