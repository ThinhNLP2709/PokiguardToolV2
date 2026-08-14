namespace Unity.VisualScripting;

public class ReflectionInvoker : IOptimizedInvoker
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ParameterInfo, Type> <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Type <GetParameterTypes>b__10_0(ParameterInfo pi) { }

	}

	private static readonly Object[] EmptyObjects; //Field offset: 0x0
	private readonly MethodInfo methodInfo; //Field offset: 0x10

	private static ReflectionInvoker() { }

	public ReflectionInvoker(MethodInfo methodInfo) { }

	public override void Compile() { }

	public Type[] GetParameterTypes() { }

	public override object Invoke(object target, Object[] args) { }

	public override object Invoke(object target) { }

	public override object Invoke(object target, object arg0) { }

	public override object Invoke(object target, object arg0, object arg1) { }

	public override object Invoke(object target, object arg0, object arg1, object arg2) { }

	public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3) { }

	public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

}

