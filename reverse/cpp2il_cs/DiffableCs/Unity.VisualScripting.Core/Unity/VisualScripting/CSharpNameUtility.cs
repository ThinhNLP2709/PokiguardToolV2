namespace Unity.VisualScripting;

[Extension]
public static class CSharpNameUtility
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public TypeQualifier qualifier; //Field offset: 0x10
		public bool includeGenericParameters; //Field offset: 0x14

		public <>c__DisplayClass8_0() { }

		internal string <CSharpName>b__0(Type t) { }

	}

	private static readonly Dictionary<Type, String> primitives; //Field offset: 0x0
	public static readonly Dictionary<String, String> operators; //Field offset: 0x8
	private static readonly HashSet<Char> illegalTypeFileNameCharacters; //Field offset: 0x10

	private static CSharpNameUtility() { }

	[Extension]
	public static string CSharpFileName(Type type, bool includeNamespace, bool includeGenericParameters = false) { }

	[Extension]
	public static string CSharpFullName(Type type, bool includeGenericParameters = true) { }

	[Extension]
	public static string CSharpName(MemberInfo member, ActionDirection direction) { }

	[Extension]
	public static string CSharpName(Type type, bool includeGenericParameters = true) { }

	[Extension]
	private static string CSharpName(Type type, TypeQualifier qualifier, bool includeGenericParameters = true) { }

	[Extension]
	public static string CSharpUniqueName(Type type, bool includeGenericParameters = true) { }

}

