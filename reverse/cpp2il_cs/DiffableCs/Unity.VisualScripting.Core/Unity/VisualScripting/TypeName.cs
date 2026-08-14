namespace Unity.VisualScripting;

public class TypeName
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, String> <>9__35_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <.ctor>b__35_0(string x) { }

	}

	private enum ParseState
	{
		Name = 0,
		Array = 1,
		Generics = 2,
		Assembly = 3,
	}

	[CompilerGenerated]
	private string <AssemblyDescription>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <AssemblyName>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <AssemblyVersion>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <AssemblyCulture>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <AssemblyPublicKeyToken>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly List<TypeName> <GenericParameters>k__BackingField; //Field offset: 0x38
	private readonly List<String> names; //Field offset: 0x40
	private readonly List<Int32> genericarities; //Field offset: 0x48
	[CompilerGenerated]
	private string <Name>k__BackingField; //Field offset: 0x50

	public private string AssemblyCulture
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string AssemblyDescription
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string AssemblyName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string AssemblyPublicKeyToken
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string AssemblyVersion
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public List<TypeName> GenericParameters
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public bool IsArray
	{
		 get { } //Length: 71
	}

	public string LastName
	{
		 get { } //Length: 89
	}

	public private string Name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private TypeName(string s, ref int index) { }

	[CompilerGenerated]
	public string get_AssemblyCulture() { }

	[CompilerGenerated]
	public string get_AssemblyDescription() { }

	[CompilerGenerated]
	public string get_AssemblyName() { }

	[CompilerGenerated]
	public string get_AssemblyPublicKeyToken() { }

	[CompilerGenerated]
	public string get_AssemblyVersion() { }

	[CompilerGenerated]
	public List<TypeName> get_GenericParameters() { }

	public bool get_IsArray() { }

	public string get_LastName() { }

	[CompilerGenerated]
	public string get_Name() { }

	private static string LookForPairThenRemove(List<String> strings, string Name) { }

	public static TypeName Parse(string s) { }

	public void ReplaceAssembly(string oldAssembly, string newAssembly) { }

	public void ReplaceName(string oldTypeName, string newTypeName, AssemblyName newAssemblyName = null) { }

	public void ReplaceName(string oldTypeName, Type newType) { }

	public void ReplaceNamespace(string oldNamespace, string newNamespace) { }

	[CompilerGenerated]
	private void set_AssemblyCulture(string value) { }

	[CompilerGenerated]
	private void set_AssemblyDescription(string value) { }

	[CompilerGenerated]
	private void set_AssemblyName(string value) { }

	[CompilerGenerated]
	private void set_AssemblyPublicKeyToken(string value) { }

	[CompilerGenerated]
	private void set_AssemblyVersion(string value) { }

	[CompilerGenerated]
	private void set_Name(string value) { }

	public void SetAssemblyName(AssemblyName newAssemblyName) { }

	public static string Simplify(string typeName) { }

	public static string SimplifyFast(string typeName) { }

	private static string ToArrayOrType(string oldType, string newType) { }

	private static string ToElementTypeName(string s) { }

	public string ToLooseString() { }

	public string ToString(TypeNameDetail specification, TypeNameDetail genericsSpecification) { }

	public virtual string ToString() { }

	private void UpdateName() { }

}

