namespace Unity.VisualScripting;

[Extension]
public static class EnumUtility
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<FieldInfo, Boolean> <>9__1_0; //Field offset: 0x8
		public static Func<FieldInfo, String> <>9__1_1; //Field offset: 0x10
		public static Func<FieldInfo, Enum> <>9__1_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <ValuesByNames>b__1_0(FieldInfo f) { }

		internal string <ValuesByNames>b__1_1(FieldInfo f) { }

		internal Enum <ValuesByNames>b__1_2(FieldInfo f) { }

	}

	[CompilerGenerated]
	private sealed class <>c__2
	{
		public static readonly <>c__2<T> <>9; //Field offset: 0x0
		public static Func<FieldInfo, Boolean> <>9__2_0; //Field offset: 0x0
		public static Func<FieldInfo, String> <>9__2_1; //Field offset: 0x0
		public static Func<FieldInfo, T> <>9__2_2; //Field offset: 0x0

		private static <>c__2`1() { }

		public <>c__2`1() { }

		internal bool <ValuesByNames>b__2_0(FieldInfo f) { }

		internal string <ValuesByNames>b__2_1(FieldInfo f) { }

		internal T <ValuesByNames>b__2_2(FieldInfo f) { }

	}


	[Extension]
	public static bool HasFlag(Enum value, Enum flag) { }

	public static Dictionary<String, Enum> ValuesByNames(Type enumType, bool obsolete = false) { }

	public static Dictionary<String, T> ValuesByNames(bool obsolete = false) { }

}

