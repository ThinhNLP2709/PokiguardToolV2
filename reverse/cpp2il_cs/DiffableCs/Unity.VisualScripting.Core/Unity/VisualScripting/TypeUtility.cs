namespace Unity.VisualScripting;

[Extension]
public static class TypeUtility
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Object, Type> <>9__9_0; //Field offset: 0x8
		public static Func<Object, Type> <>9__10_0; //Field offset: 0x10
		public static Func<Type, Boolean> <>9__23_0; //Field offset: 0x18
		public static Func<Type, Boolean> <>9__24_0; //Field offset: 0x20
		public static Func<Type, Boolean> <>9__25_0; //Field offset: 0x28
		public static Func<Type, Boolean> <>9__35_0; //Field offset: 0x30
		public static Func<Type, Boolean> <>9__35_1; //Field offset: 0x38

		private static <>c() { }

		public <>c() { }

		internal bool <GetDictionaryItemType>b__25_0(Type i) { }

		internal bool <GetEnumerableElementType>b__24_0(Type i) { }

		internal bool <GetListElementType>b__23_0(Type i) { }

		internal bool <GetTypesSafely>b__35_0(Type t) { }

		internal bool <GetTypesSafely>b__35_1(Type t) { }

		internal Type <Instantiate>b__10_0(object arg) { }

		internal Type <TryInstantiate>b__9_0(object arg) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Func<Object[], Object> instantiator; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal object <Instantiator>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Type type; //Field offset: 0x10
		public ConstructorInfo constructor; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal object <Instantiator>b__0(Object[] args) { }

		internal object <Instantiator>b__1(Object[] args) { }

	}

	[CompilerGenerated]
	private sealed class <GetTypesSafely>d__35 : IEnumerable<Type>, IEnumerable, IEnumerator<Type>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private Type <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Assembly assembly; //Field offset: 0x28
		public Assembly <>3__assembly; //Field offset: 0x30
		private Type[] <>7__wrap1; //Field offset: 0x38
		private int <>7__wrap2; //Field offset: 0x40

		private override Type System.Collections.Generic.IEnumerator<System.Type>.Current
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
		public <GetTypesSafely>d__35(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Type> System.Collections.Generic.IEnumerable<System.Type>.GetEnumerator() { }

		[DebuggerHidden]
		private override Type System.Collections.Generic.IEnumerator<System.Type>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <Hierarchy>d__19 : IEnumerable<Type>, IEnumerable, IEnumerator<Type>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private Type <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Type type; //Field offset: 0x28
		public Type <>3__type; //Field offset: 0x30
		private Type <baseType>5__2; //Field offset: 0x38
		private IEnumerator<Type> <>7__wrap2; //Field offset: 0x40

		private override Type System.Collections.Generic.IEnumerator<System.Type>.Current
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
		public <Hierarchy>d__19(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Type> System.Collections.Generic.IEnumerable<System.Type>.GetEnumerator() { }

		[DebuggerHidden]
		private override Type System.Collections.Generic.IEnumerator<System.Type>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly HashSet<Type> _numericTypes; //Field offset: 0x0
	private static readonly HashSet<Type> _numericConstructTypes; //Field offset: 0x8
	private static readonly HashSet<Type> typesWithShortStrings; //Field offset: 0x10
	private static readonly Dictionary<Type, Object> defaultPrimitives; //Field offset: 0x18

	private static TypeUtility() { }

	[Extension]
	public static IEnumerable<Type> AndBaseTypeAndInterfaces(Type type) { }

	[Extension]
	public static IEnumerable<Type> AndHierarchy(Type type) { }

	[Extension]
	public static IEnumerable<Type> AndInterfaces(Type type) { }

	[Extension]
	public static IEnumerable<Type> BaseTypeAndInterfaces(Type type, bool inheritedInterfaces = true) { }

	[Extension]
	public static bool CanMakeGenericTypeVia(Type openConstructedType, Type closedConstructedType) { }

	[Extension]
	public static object Default(Type type) { }

	public static Type GetDictionaryItemType(Type dictionaryType, bool allowNonGeneric, int genericArgumentIndex) { }

	public static Type GetDictionaryKeyType(Type dictionaryType, bool allowNonGeneric) { }

	public static Type GetDictionaryValueType(Type dictionaryType, bool allowNonGeneric) { }

	public static Type GetEnumerableElementType(Type enumerableType, bool allowNonGeneric) { }

	[Extension]
	public static IEnumerable<Type> GetInterfaces(Type type, bool includeInherited) { }

	public static Type GetListElementType(Type listType, bool allowNonGeneric) { }

	[Extension]
	[IteratorStateMachine(typeof(<GetTypesSafely>d__35))]
	public static IEnumerable<Type> GetTypesSafely(Assembly assembly) { }

	[Extension]
	[IteratorStateMachine(typeof(<Hierarchy>d__19))]
	public static IEnumerable<Type> Hierarchy(Type type) { }

	[Extension]
	public static object Instantiate(Type type, bool nonPublic = true, Object[] args) { }

	[Extension]
	public static Func<Object[], Object> Instantiator(Type type, bool nonPublic = true, Type[] parameterTypes) { }

	[Extension]
	public static Func<Object> Instantiator(Type type, bool nonPublic = true) { }

	[Extension]
	public static bool IsAbstract(Type type) { }

	[Extension]
	public static bool IsAssignableFrom(Type type, object value) { }

	[Extension]
	public static bool IsBasic(Type type) { }

	[Extension]
	public static bool IsConcrete(Type type) { }

	[Extension]
	public static bool IsNullable(Type type) { }

	[Extension]
	public static bool IsNumeric(Type type) { }

	[Extension]
	public static bool IsNumericConstruct(Type type) { }

	[Extension]
	public static bool IsReferenceType(Type type) { }

	[Extension]
	public static bool IsStatic(Type type) { }

	[Extension]
	public static bool IsStruct(Type type) { }

	[Extension]
	public static Type MakeGenericTypeVia(Type openConstructedType, Type closedConstructedType, Dictionary<Type, Type> resolvedGenericParameters, bool safe = true) { }

	[Extension]
	public static Namespace Namespace(Type type) { }

	[Extension]
	public static object PseudoDefault(Type type) { }

	[Extension]
	public static string ToShortString(object o, int maxLength = 20) { }

	[Extension]
	public static object TryInstantiate(Type type, bool nonPublic = true, Object[] args) { }

}

