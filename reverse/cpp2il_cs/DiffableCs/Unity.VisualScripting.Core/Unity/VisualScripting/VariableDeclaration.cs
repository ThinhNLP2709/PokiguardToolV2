namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public sealed class VariableDeclaration
{
	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private object <value>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private SerializableType <typeHandle>k__BackingField; //Field offset: 0x20

	[Serialize]
	public private string name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[Serialize]
	public SerializableType typeHandle
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 15
	}

	[Serialize]
	[Value]
	public object value
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public VariableDeclaration() { }

	public VariableDeclaration(string name, object value) { }

	[CompilerGenerated]
	public string get_name() { }

	[CompilerGenerated]
	public SerializableType get_typeHandle() { }

	[CompilerGenerated]
	public object get_value() { }

	[CompilerGenerated]
	private void set_name(string value) { }

	[CompilerGenerated]
	public void set_typeHandle(SerializableType value) { }

	[CompilerGenerated]
	public void set_value(object value) { }

}

