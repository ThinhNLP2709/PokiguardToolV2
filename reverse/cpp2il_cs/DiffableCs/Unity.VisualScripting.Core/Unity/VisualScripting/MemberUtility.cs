namespace Unity.VisualScripting;

[Extension]
public static class MemberUtility
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ParameterInfo, Type> <>9__6_0; //Field offset: 0x8
		public static Func<ParameterInfo, Type> <>9__8_0; //Field offset: 0x10
		public static Func<ParameterInfo, Type> <>9__45_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal ExtensionMethodCache <.cctor>b__0_0() { }

		internal Dictionary<Type, MethodInfo[]> <.cctor>b__0_1() { }

		internal HashSet<MethodInfo> <.cctor>b__0_2() { }

		internal Type <GetInheritedExtensionMethods>b__8_0(ParameterInfo p) { }

		internal Type <MakeGenericMethodVia>b__6_0(ParameterInfo p) { }

		internal Type <ParametersMatch>b__45_0(ParameterInfo paramInfo) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public Type[] paramTypes; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal bool <GetConstructorAccepting>b__0(ConstructorInfo constructor) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public string name; //Field offset: 0x10

		public <>c__DisplayClass42_0() { }

		internal bool <GetExtendedMember>b__0(MethodInfo extension) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass58_0
	{
		public IEnumerable<Type> parameterTypes; //Field offset: 0x10

		public <>c__DisplayClass58_0() { }

		internal bool <Disambiguate>b__0(ConstructorInfo m) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass59_0
	{
		public IEnumerable<Type> parameterTypes; //Field offset: 0x10
		public Type type; //Field offset: 0x18

		public <>c__DisplayClass59_0() { }

		internal bool <Disambiguate>b__0(MethodInfo m) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Dictionary<Type, Type> resolvedGenericParameters; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal Type <MakeGenericMethodVia>b__1(Type openConstructedGenericArgument) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass60_0
	{
		public IEnumerable<Type> parameterTypes; //Field offset: 0x10
		public Type type; //Field offset: 0x18
		public IEnumerable<Type> genericArgumentTypes; //Field offset: 0x20

		public <>c__DisplayClass60_0() { }

		internal bool <Disambiguate>b__0(MethodInfo m) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Type thisArgumentType; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <GetExtensionMethods>b__0(MethodInfo method) { }

	}

	[CompilerGenerated]
	private sealed class <GetInheritedExtensionMethods>d__8 : IEnumerable<MethodInfo>, IEnumerable, IEnumerator<MethodInfo>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private MethodInfo <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Type thisArgumentType; //Field offset: 0x28
		public Type <>3__thisArgumentType; //Field offset: 0x30
		private MethodInfo[] <>7__wrap1; //Field offset: 0x38
		private int <>7__wrap2; //Field offset: 0x40

		private override MethodInfo System.Collections.Generic.IEnumerator<System.Reflection.MethodInfo>.Current
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
		public <GetInheritedExtensionMethods>d__8(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<MethodInfo> System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo>.GetEnumerator() { }

		[DebuggerHidden]
		private override MethodInfo System.Collections.Generic.IEnumerator<System.Reflection.MethodInfo>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly Lazy<ExtensionMethodCache> ExtensionMethodsCache; //Field offset: 0x0
	private static readonly Lazy<Dictionary`2<Type, MethodInfo[]>> InheritedExtensionMethodsCache; //Field offset: 0x8
	private static readonly Lazy<HashSet`1<MethodInfo>> GenericExtensionMethods; //Field offset: 0x10

	private static MemberUtility() { }

	[Extension]
	public static bool AllowsNull(ParameterInfo parameterInfo) { }

	[Extension]
	public static bool CanWrite(FieldInfo fieldInfo) { }

	[Extension]
	public static Delegate CreateDelegate(MethodInfo methodInfo, Type delegateType) { }

	[Extension]
	public static object DefaultValue(ParameterInfo parameterInfo) { }

	[Extension]
	public static ConstructorInfo Disambiguate(IEnumerable<ConstructorInfo> constructors, Type type, IEnumerable<Type> parameterTypes) { }

	[Extension]
	public static PropertyInfo Disambiguate(IEnumerable<PropertyInfo> properties, Type type) { }

	[Extension]
	public static FieldInfo Disambiguate(IEnumerable<FieldInfo> fields, Type type) { }

	[Extension]
	public static MethodInfo Disambiguate(IEnumerable<MethodInfo> methods, Type type, IEnumerable<Type> parameterTypes) { }

	[Extension]
	public static MethodInfo Disambiguate(IEnumerable<MethodInfo> methods, Type type, IEnumerable<Type> parameterTypes, IEnumerable<Type> genericArgumentTypes) { }

	[Extension]
	private static TMemberInfo DisambiguateHierarchy(IEnumerable<TMemberInfo> members, Type type) { }

	[Extension]
	private static Type ExtendedDeclaringType(MemberInfo memberInfo) { }

	[Extension]
	public static Type ExtendedDeclaringType(MemberInfo memberInfo, bool invokeAsExtension) { }

	[Extension]
	private static bool GenericArgumentsMatch(MethodInfo method, IEnumerable<Type> genericArgumentTypes) { }

	[Extension]
	public static Type GetAccessorType(MemberInfo memberInfo) { }

	[Extension]
	public static ConstructorInfo GetConstructorAccepting(Type type, Type[] paramTypes, bool nonPublic) { }

	[Extension]
	public static ConstructorInfo GetConstructorAccepting(Type type, Type[] paramTypes) { }

	[Extension]
	public static ConstructorInfo GetDefaultConstructor(Type type) { }

	[Extension]
	public static MemberInfo[] GetExtendedMember(Type type, string name, MemberTypes types, BindingFlags flags) { }

	[Extension]
	public static MemberInfo[] GetExtendedMembers(Type type, BindingFlags flags) { }

	[Extension]
	public static IEnumerable<MethodInfo> GetExtensionMethods(Type thisArgumentType, bool inherited = true) { }

	[Extension]
	public static FieldInfo GetFieldUnambiguous(Type type, string name, BindingFlags flags) { }

	[IteratorStateMachine(typeof(<GetInheritedExtensionMethods>d__8))]
	private static IEnumerable<MethodInfo> GetInheritedExtensionMethods(Type thisArgumentType) { }

	[Extension]
	public static IEnumerable<ParameterInfo> GetInvocationParameters(MethodBase methodBase, Type targetType) { }

	[Extension]
	public static IEnumerable<ParameterInfo> GetInvocationParameters(MethodBase methodBase, bool invokeAsExtension) { }

	[Extension]
	public static MethodInfo GetMethodUnambiguous(Type type, string name, BindingFlags flags) { }

	[Extension]
	private static IEnumerable<ParameterInfo> GetParametersWithoutThis(MethodBase methodBase) { }

	[Extension]
	public static PropertyInfo GetPropertyUnambiguous(Type type, string name, BindingFlags flags) { }

	[Extension]
	public static ConstructorInfo GetPublicConstructorAccepting(Type type, Type[] paramTypes) { }

	[Extension]
	public static ConstructorInfo GetPublicDefaultConstructor(Type type) { }

	[Extension]
	public static bool HasDefaultValue(ParameterInfo parameterInfo) { }

	[Extension]
	public static bool HasOutModifier(ParameterInfo parameterInfo) { }

	[Extension]
	public static bool IsAccessor(MemberInfo memberInfo) { }

	[Extension]
	public static bool IsExtension(MethodInfo methodInfo) { }

	[Extension]
	public static bool IsExtensionMethod(MemberInfo memberInfo) { }

	[Extension]
	public static bool IsGenericExtension(MethodInfo methodInfo) { }

	[Extension]
	public static bool IsInvokedAsExtension(MethodBase methodBase, Type targetType) { }

	[Extension]
	public static bool IsOperator(MethodInfo method) { }

	[Extension]
	public static bool IsPubliclyGettable(MemberInfo memberInfo) { }

	[Extension]
	public static bool IsStatic(MemberInfo memberInfo) { }

	[Extension]
	public static bool IsStatic(PropertyInfo propertyInfo) { }

	[Extension]
	public static bool IsUserDefinedConversion(MethodInfo method) { }

	[Extension]
	public static MethodInfo MakeGenericMethodVia(MethodInfo openConstructedMethod, Type[] closedConstructedParameterTypes) { }

	[Extension]
	private static bool NameMatches(MemberInfo member, string name) { }

	[Extension]
	private static bool ParametersMatch(MethodBase methodBase, IEnumerable<Type> parameterTypes, bool invokeAsExtension) { }

	[Extension]
	public static object PseudoDefaultValue(ParameterInfo parameterInfo) { }

	[Extension]
	public static bool SignatureMatches(FieldInfo field, string name) { }

	[Extension]
	public static bool SignatureMatches(PropertyInfo property, string name) { }

	[Extension]
	public static bool SignatureMatches(ConstructorInfo constructor, string name, IEnumerable<Type> parameterTypes) { }

	[Extension]
	public static bool SignatureMatches(MethodInfo method, string name, IEnumerable<Type> parameterTypes, bool invokeAsExtension) { }

	[Extension]
	public static bool SignatureMatches(MethodInfo method, string name, IEnumerable<Type> parameterTypes, IEnumerable<Type> genericArgumentTypes, bool invokeAsExtension) { }

	[Extension]
	public static Member ToManipulator(ConstructorInfo constructorInfo, Type targetType) { }

	[Extension]
	public static Member ToManipulator(PropertyInfo propertyInfo, Type targetType) { }

	[Extension]
	public static Member ToManipulator(FieldInfo fieldInfo, Type targetType) { }

	[Extension]
	public static Member ToManipulator(MemberInfo memberInfo, Type targetType) { }

	[Extension]
	public static Member ToManipulator(MethodInfo methodInfo, Type targetType) { }

	[Extension]
	public static Member ToManipulator(MemberInfo memberInfo) { }

	[Extension]
	public static Type UnderlyingParameterType(ParameterInfo parameterInfo) { }

}

