namespace Unity.VisualScripting;

public sealed class Recursion : Recursion<Object>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Recursion> <>9__12_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Recursion <New>b__12_0() { }

	}

	[CompilerGenerated]
	private static int <defaultMaxDepth>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <safeMode>k__BackingField; //Field offset: 0x4

	public static int defaultMaxDepth
	{
		[CompilerGenerated]
		 get { } //Length: 77
		[CompilerGenerated]
		 set { } //Length: 82
	}

	public static bool safeMode
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		 set { } //Length: 84
	}

	private static Recursion() { }

	private Recursion() { }

	protected virtual void Free() { }

	[CompilerGenerated]
	public static int get_defaultMaxDepth() { }

	[CompilerGenerated]
	public static bool get_safeMode() { }

	public static Recursion New() { }

	public static Recursion New(int maxDepth) { }

	internal static void OnRuntimeMethodLoad() { }

	[CompilerGenerated]
	public static void set_defaultMaxDepth(int value) { }

	[CompilerGenerated]
	public static void set_safeMode(bool value) { }

}

