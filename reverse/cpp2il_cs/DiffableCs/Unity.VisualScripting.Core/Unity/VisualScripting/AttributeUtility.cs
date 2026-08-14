namespace Unity.VisualScripting;

[Extension]
public static class AttributeUtility
{
	private class AttributeCache
	{
		[CompilerGenerated]
		private sealed class <GetAttributes>d__12 : IEnumerable<Attribute>, IEnumerable, IEnumerator<Attribute>, IEnumerator, IDisposable
		{
			private int <>1__state; //Field offset: 0x10
			private Attribute <>2__current; //Field offset: 0x18
			private int <>l__initialThreadId; //Field offset: 0x20
			private List<Attribute> cache; //Field offset: 0x28
			public List<Attribute> <>3__cache; //Field offset: 0x30
			private Type attributeType; //Field offset: 0x38
			public Type <>3__attributeType; //Field offset: 0x40
			private int <i>5__2; //Field offset: 0x48

			private override Attribute System.Collections.Generic.IEnumerator<System.Attribute>.Current
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
			public <GetAttributes>d__12(int <>1__state) { }

			private override bool MoveNext() { }

			[DebuggerHidden]
			private override IEnumerator<Attribute> System.Collections.Generic.IEnumerable<System.Attribute>.GetEnumerator() { }

			[DebuggerHidden]
			private override Attribute System.Collections.Generic.IEnumerator<System.Attribute>.get_Current() { }

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
		private readonly List<Attribute> <inheritedAttributes>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private readonly List<Attribute> <definedAttributes>k__BackingField; //Field offset: 0x18

		public List<Attribute> definedAttributes
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public List<Attribute> inheritedAttributes
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public AttributeCache(MemberInfo element) { }

		public AttributeCache(ParameterInfo element) { }

		public AttributeCache(IAttributeProvider element) { }

		private void Cache(Attribute[] attributeObjects, List<Attribute> cache) { }

		[CompilerGenerated]
		public List<Attribute> get_definedAttributes() { }

		[CompilerGenerated]
		public List<Attribute> get_inheritedAttributes() { }

		private Attribute GetAttribute(Type attributeType, List<Attribute> cache) { }

		public Attribute GetAttribute(Type attributeType, bool inherit = true) { }

		public TAttribute GetAttribute(bool inherit = true) { }

		[IteratorStateMachine(typeof(<GetAttributes>d__12))]
		private IEnumerable<Attribute> GetAttributes(Type attributeType, List<Attribute> cache) { }

		public IEnumerable<Attribute> GetAttributes(Type attributeType, bool inherit = true) { }

		public IEnumerable<TAttribute> GetAttributes(bool inherit = true) { }

		private bool HasAttribute(Type attributeType, List<Attribute> cache) { }

		public bool HasAttribute(Type attributeType, bool inherit = true) { }

		public bool HasAttribute(bool inherit = true) { }

	}

	private static readonly Dictionary<Object, AttributeCache> optimizedCaches; //Field offset: 0x0

	private static AttributeUtility() { }

	public static void CacheAttributes(MemberInfo element) { }

	public static void CacheAttributes(IAttributeProvider element) { }

	public static void CacheAttributes(ParameterInfo element) { }

	public static bool CheckCondition(Type type, object target, string conditionMemberName, bool fallback) { }

	public static bool CheckCondition(T target, string conditionMemberName, bool fallback) { }

	[Extension]
	public static TAttribute GetAttribute(IAttributeProvider element, bool inherit = true) { }

	[Extension]
	public static Attribute GetAttribute(IAttributeProvider element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static TAttribute GetAttribute(ParameterInfo element, bool inherit = true) { }

	[Extension]
	public static Attribute GetAttribute(ParameterInfo element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static Attribute GetAttribute(MemberInfo element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static TAttribute GetAttribute(MemberInfo element, bool inherit = true) { }

	private static AttributeCache GetAttributeCache(MemberInfo element) { }

	private static AttributeCache GetAttributeCache(ParameterInfo element) { }

	private static AttributeCache GetAttributeCache(IAttributeProvider element) { }

	[Extension]
	internal static IEnumerable<T> GetAttributeOfEnumMember(Enum enumVal) { }

	[Extension]
	public static IEnumerable<TAttribute> GetAttributes(IAttributeProvider element, bool inherit = true) { }

	[Extension]
	public static IEnumerable<Attribute> GetAttributes(IAttributeProvider element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static IEnumerable<TAttribute> GetAttributes(MemberInfo element, bool inherit = true) { }

	[Extension]
	public static IEnumerable<Attribute> GetAttributes(ParameterInfo element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static IEnumerable<Attribute> GetAttributes(MemberInfo element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static IEnumerable<TAttribute> GetAttributes(ParameterInfo element, bool inherit = true) { }

	[Extension]
	public static bool HasAttribute(IAttributeProvider element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static bool HasAttribute(ParameterInfo element, bool inherit = true) { }

	[Extension]
	public static bool HasAttribute(IAttributeProvider element, bool inherit = true) { }

	[Extension]
	public static bool HasAttribute(ParameterInfo element, Type attributeType, bool inherit = true) { }

	[Extension]
	public static bool HasAttribute(MemberInfo element, bool inherit = true) { }

	[Extension]
	public static bool HasAttribute(MemberInfo element, Type attributeType, bool inherit = true) { }

}

