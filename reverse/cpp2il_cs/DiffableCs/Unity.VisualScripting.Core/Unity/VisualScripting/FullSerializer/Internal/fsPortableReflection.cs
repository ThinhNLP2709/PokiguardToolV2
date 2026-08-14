namespace Unity.VisualScripting.FullSerializer.Internal;

[Extension]
public static class fsPortableReflection
{
	[CompilerGenerated]
	private sealed class <GetFlattenedMethods>d__18 : IEnumerable<MethodInfo>, IEnumerable, IEnumerator<MethodInfo>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private MethodInfo <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Type type; //Field offset: 0x28
		public Type <>3__type; //Field offset: 0x30
		private string methodName; //Field offset: 0x38
		public string <>3__methodName; //Field offset: 0x40
		private MethodInfo[] <methods>5__2; //Field offset: 0x48
		private int <i>5__3; //Field offset: 0x50

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
		public <GetFlattenedMethods>d__18(int <>1__state) { }

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

	private struct AttributeQuery
	{
		public MemberInfo MemberInfo; //Field offset: 0x0
		public Type AttributeType; //Field offset: 0x8

	}

	private class AttributeQueryComparator : IEqualityComparer<AttributeQuery>
	{

		public AttributeQueryComparator() { }

		public override bool Equals(AttributeQuery x, AttributeQuery y) { }

		public override int GetHashCode(AttributeQuery obj) { }

	}

	public static Type[] EmptyTypes; //Field offset: 0x0
	private static IDictionary<AttributeQuery, Attribute> _cachedAttributeQueries; //Field offset: 0x8
	private static BindingFlags DeclaredFlags; //Field offset: 0x10

	private static fsPortableReflection() { }

	public static MemberInfo AsMemberInfo(Type type) { }

	public static Type AsType(MemberInfo member) { }

	public static Attribute GetAttribute(MemberInfo element, Type attributeType, bool shouldCache) { }

	public static TAttribute GetAttribute(MemberInfo element, bool shouldCache) { }

	public static TAttribute GetAttribute(MemberInfo element) { }

	[Extension]
	public static ConstructorInfo GetDeclaredConstructor(Type type, Type[] parameters) { }

	[Extension]
	public static ConstructorInfo[] GetDeclaredConstructors(Type type) { }

	[Extension]
	public static FieldInfo[] GetDeclaredFields(Type type) { }

	[Extension]
	public static MemberInfo GetDeclaredMember(Type type, string memberName) { }

	[Extension]
	public static MemberInfo[] GetDeclaredMembers(Type type) { }

	[Extension]
	public static MethodInfo GetDeclaredMethod(Type type, string methodName) { }

	[Extension]
	public static MethodInfo[] GetDeclaredMethods(Type type) { }

	[Extension]
	public static PropertyInfo[] GetDeclaredProperties(Type type) { }

	[Extension]
	public static PropertyInfo GetDeclaredProperty(Type type, string propertyName) { }

	[Extension]
	public static MemberInfo[] GetFlattenedMember(Type type, string memberName) { }

	[Extension]
	public static MethodInfo GetFlattenedMethod(Type type, string methodName) { }

	[Extension]
	[IteratorStateMachine(typeof(<GetFlattenedMethods>d__18))]
	public static IEnumerable<MethodInfo> GetFlattenedMethods(Type type, string methodName) { }

	[Extension]
	public static PropertyInfo GetFlattenedProperty(Type type, string propertyName) { }

	public static bool HasAttribute(MemberInfo element, Type attributeType, bool shouldCache) { }

	public static bool HasAttribute(MemberInfo element, Type attributeType) { }

	public static bool HasAttribute(MemberInfo element, bool shouldCache) { }

	public static bool HasAttribute(MemberInfo element) { }

	public static bool IsType(MemberInfo member) { }

	[Extension]
	public static Type Resolve(Type type) { }

}

