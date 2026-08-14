namespace Unity.VisualScripting;

[Extension]
public static class OptimizedReflection
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ParameterInfo, Boolean> <>9__39_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <SupportsOptimization>b__39_0(ParameterInfo parameter) { }

	}

	private static readonly Dictionary<FieldInfo, IOptimizedAccessor> fieldAccessors; //Field offset: 0x0
	private static readonly Dictionary<PropertyInfo, IOptimizedAccessor> propertyAccessors; //Field offset: 0x8
	private static readonly Dictionary<MethodInfo, IOptimizedInvoker> methodInvokers; //Field offset: 0x10
	public static readonly bool jitAvailable; //Field offset: 0x18
	private static bool _useJitIfAvailable; //Field offset: 0x19
	[CompilerGenerated]
	private static bool <safeMode>k__BackingField; //Field offset: 0x1A

	public static bool safeMode
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		 set { } //Length: 84
	}

	internal static bool useJit
	{
		internal get { } //Length: 173
	}

	public static bool useJitIfAvailable
	{
		 get { } //Length: 79
		 set { } //Length: 280
	}

	private static OptimizedReflection() { }

	public static void ClearCache() { }

	[CompilerGenerated]
	public static bool get_safeMode() { }

	internal static bool get_useJit() { }

	public static bool get_useJitIfAvailable() { }

	private static IOptimizedAccessor GetFieldAccessor(FieldInfo fieldInfo) { }

	private static IOptimizedInvoker GetMethodInvoker(MethodInfo methodInfo) { }

	private static IOptimizedAccessor GetPropertyAccessor(PropertyInfo propertyInfo) { }

	[Extension]
	public static object GetValueOptimized(FieldInfo fieldInfo, object target) { }

	[Extension]
	public static object GetValueOptimized(PropertyInfo propertyInfo, object target) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target, object arg0, object arg1, object arg2, object arg3) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target, object arg0, object arg1, object arg2) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target, object arg0, object arg1) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target, object arg0) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target) { }

	[Extension]
	public static object InvokeOptimized(MethodInfo methodInfo, object target, Object[] args) { }

	internal static void OnRuntimeMethodLoad() { }

	[Extension]
	public static IOptimizedAccessor Prewarm(FieldInfo fieldInfo) { }

	[Extension]
	public static IOptimizedAccessor Prewarm(PropertyInfo propertyInfo) { }

	[Extension]
	public static IOptimizedInvoker Prewarm(MethodInfo methodInfo) { }

	[CompilerGenerated]
	public static void set_safeMode(bool value) { }

	public static void set_useJitIfAvailable(bool value) { }

	[Extension]
	public static void SetValueOptimized(PropertyInfo propertyInfo, object target, object value) { }

	[Extension]
	public static void SetValueOptimized(FieldInfo fieldInfo, object target, object value) { }

	[Extension]
	public static bool SupportsOptimization(MethodInfo methodInfo) { }

	private static bool SupportsOptimization(MemberInfo memberInfo) { }

	[Extension]
	public static bool SupportsOptimization(PropertyInfo propertyInfo) { }

	[Extension]
	public static bool SupportsOptimization(FieldInfo fieldInfo) { }

	internal static void VerifyInstanceTarget(object target) { }

	internal static void VerifyStaticTarget(Type targetType, object target) { }

	private static void VerifyTarget(Type targetType, object target, bool static) { }

}

