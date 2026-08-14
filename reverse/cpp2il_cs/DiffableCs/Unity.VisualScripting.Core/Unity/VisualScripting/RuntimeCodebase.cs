namespace Unity.VisualScripting;

public static class RuntimeCodebase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public TypeName typeName; //Field offset: 0x10
		public Func<Assembly, Boolean> <>9__0; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal bool <TrySystemTypeLookup>b__0(Assembly a) { }

	}

	[CompilerGenerated]
	private sealed class <GetAssemblyAttributes>d__15 : IEnumerable<Attribute>, IEnumerable, IEnumerator<Attribute>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private Attribute <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Type attributeType; //Field offset: 0x28
		public Type <>3__attributeType; //Field offset: 0x30
		private IEnumerable<Assembly> assemblies; //Field offset: 0x38
		public IEnumerable<Assembly> <>3__assemblies; //Field offset: 0x40
		private IEnumerator<Assembly> <>7__wrap1; //Field offset: 0x48
		private IEnumerator<Attribute> <>7__wrap2; //Field offset: 0x50

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
		public <GetAssemblyAttributes>d__15(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

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

	private static readonly object lock; //Field offset: 0x0
	private static readonly List<Type> _types; //Field offset: 0x8
	private static readonly List<Assembly> _assemblies; //Field offset: 0x10
	public static HashSet<String> disallowedAssemblies; //Field offset: 0x18
	private static readonly Dictionary<String, Type> typeSerializations; //Field offset: 0x20
	private static Dictionary<String, Type> _renamedTypes; //Field offset: 0x28
	private static Dictionary<String, String> _renamedNamespaces; //Field offset: 0x30
	private static Dictionary<String, String> _renamedAssemblies; //Field offset: 0x38
	private static readonly Dictionary<Type, Dictionary`2<String, String>> _renamedMembers; //Field offset: 0x40

	public static IEnumerable<Assembly> assemblies
	{
		 get { } //Length: 79
	}

	public static Dictionary<String, String> renamedAssemblies
	{
		 get { } //Length: 199
	}

	public static Dictionary<String, String> renamedNamespaces
	{
		 get { } //Length: 199
	}

	public static Dictionary<String, Type> renamedTypes
	{
		 get { } //Length: 199
	}

	public static IEnumerable<Type> types
	{
		 get { } //Length: 79
	}

	private static RuntimeCodebase() { }

	public static void ClearCachedTypes() { }

	public static Type DeserializeType(string typeName) { }

	private static Dictionary<String, String> FetchRenamedAssemblies() { }

	private static Dictionary<String, String> FetchRenamedMembers(Type type) { }

	private static Dictionary<String, String> FetchRenamedNamespaces() { }

	private static Dictionary<String, Type> FetchRenamedTypes() { }

	public static IEnumerable<Assembly> get_assemblies() { }

	public static Dictionary<String, String> get_renamedAssemblies() { }

	public static Dictionary<String, String> get_renamedNamespaces() { }

	public static Dictionary<String, Type> get_renamedTypes() { }

	public static IEnumerable<Type> get_types() { }

	public static IEnumerable<Attribute> GetAssemblyAttributes(Type attributeType) { }

	public static IEnumerable<TAttribute> GetAssemblyAttributes(IEnumerable<Assembly> assemblies) { }

	[IteratorStateMachine(typeof(<GetAssemblyAttributes>d__15))]
	public static IEnumerable<Attribute> GetAssemblyAttributes(Type attributeType, IEnumerable<Assembly> assemblies) { }

	public static IEnumerable<TAttribute> GetAssemblyAttributes() { }

	public static void PrewarmTypeDeserialization(Type type) { }

	public static Dictionary<String, String> RenamedMembers(Type type) { }

	public static string SerializeType(Type type) { }

	private static bool TryCachedTypeLookup(string typeName, out Type type) { }

	public static bool TryDeserializeType(string typeName, out Type type) { }

	private static bool TryRenamedTypeLookup(string previousTypeName, out Type type) { }

	private static bool TrySystemTypeLookup(string typeName, out Type type) { }

	private static bool TrySystemTypeLookup(TypeName typeName, out Type type) { }

}

