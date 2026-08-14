namespace Unity.VisualScripting;

public static class EditorTimeBinding
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal int <.cctor>b__6_0() { }

		internal float <.cctor>b__6_1() { }

	}

	public static Func<Int32> frameBinding; //Field offset: 0x0
	public static Func<Single> timeBinding; //Field offset: 0x8

	public static int frame
	{
		 get { } //Length: 197
	}

	public static float time
	{
		 get { } //Length: 200
	}

	private static EditorTimeBinding() { }

	public static int get_frame() { }

	public static float get_time() { }

}

