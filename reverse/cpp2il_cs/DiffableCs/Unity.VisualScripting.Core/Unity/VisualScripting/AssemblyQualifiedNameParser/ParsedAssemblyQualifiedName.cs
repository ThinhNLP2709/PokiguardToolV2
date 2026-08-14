namespace Unity.VisualScripting.AssemblyQualifiedNameParser;

public class ParsedAssemblyQualifiedName
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, String> <>9__25_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <.ctor>b__25_0(string x) { }

	}

	private class Block
	{
		internal int startIndex; //Field offset: 0x10
		internal int endIndex; //Field offset: 0x14
		internal int level; //Field offset: 0x18
		internal Block parentBlock; //Field offset: 0x20
		internal readonly List<Block> innerBlocks; //Field offset: 0x28
		internal ParsedAssemblyQualifiedName parsedAssemblyQualifiedName; //Field offset: 0x30

		public Block() { }

	}

	[CompilerGenerated]
	private readonly string <AssemblyDescriptionString>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <TypeName>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <ShortAssemblyName>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <Version>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly string <Culture>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly string <PublicKeyToken>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private readonly List<ParsedAssemblyQualifiedName> <GenericParameters>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private readonly int <GenericParameterCount>k__BackingField; //Field offset: 0x48

	public string AssemblyDescriptionString
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string Culture
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public int GenericParameterCount
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public List<ParsedAssemblyQualifiedName> GenericParameters
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string PublicKeyToken
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string ShortAssemblyName
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public private string TypeName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public string Version
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public ParsedAssemblyQualifiedName(string AssemblyQualifiedName) { }

	[CompilerGenerated]
	public string get_AssemblyDescriptionString() { }

	[CompilerGenerated]
	public string get_Culture() { }

	[CompilerGenerated]
	public int get_GenericParameterCount() { }

	[CompilerGenerated]
	public List<ParsedAssemblyQualifiedName> get_GenericParameters() { }

	[CompilerGenerated]
	public string get_PublicKeyToken() { }

	[CompilerGenerated]
	public string get_ShortAssemblyName() { }

	[CompilerGenerated]
	public string get_TypeName() { }

	[CompilerGenerated]
	public string get_Version() { }

	private static string LookForPairThenRemove(List<String> strings, string Name) { }

	public void Replace(string oldTypeName, string newTypeName) { }

	[CompilerGenerated]
	private void set_TypeName(string value) { }

	private string ToString(bool includeAssemblyDescription) { }

	public virtual string ToString() { }

}

