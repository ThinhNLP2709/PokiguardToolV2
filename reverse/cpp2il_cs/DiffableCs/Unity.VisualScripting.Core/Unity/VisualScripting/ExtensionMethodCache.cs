namespace Unity.VisualScripting;

internal class ExtensionMethodCache
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Type, Boolean> <>9__0_0; //Field offset: 0x8
		public static Func<Type, IEnumerable`1<MethodInfo>> <>9__0_1; //Field offset: 0x10
		public static Func<MethodInfo, Boolean> <>9__0_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <.ctor>b__0_0(Type type) { }

		internal IEnumerable<MethodInfo> <.ctor>b__0_1(Type type) { }

		internal bool <.ctor>b__0_2(MethodInfo method) { }

	}

	internal readonly MethodInfo[] Cache; //Field offset: 0x10

	internal ExtensionMethodCache() { }

}

