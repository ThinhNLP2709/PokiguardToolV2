namespace Unity.VisualScripting.FullSerializer;

public class fsMetaProperty
{
	internal MemberInfo _memberInfo; //Field offset: 0x10
	[CompilerGenerated]
	private Type <StorageType>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private Type <OverrideConverterType>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <CanRead>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <CanWrite>k__BackingField; //Field offset: 0x29
	[CompilerGenerated]
	private string <JsonName>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private string <MemberName>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private bool <IsPublic>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private bool <IsReadOnly>k__BackingField; //Field offset: 0x41

	public private bool CanRead
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private bool CanWrite
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private bool IsPublic
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private bool IsReadOnly
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private string JsonName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string MemberName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private Type OverrideConverterType
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private Type StorageType
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal fsMetaProperty(fsConfig config, FieldInfo field) { }

	internal fsMetaProperty(fsConfig config, PropertyInfo property) { }

	private void CommonInitialize(fsConfig config) { }

	[CompilerGenerated]
	public bool get_CanRead() { }

	[CompilerGenerated]
	public bool get_CanWrite() { }

	[CompilerGenerated]
	public bool get_IsPublic() { }

	[CompilerGenerated]
	public bool get_IsReadOnly() { }

	[CompilerGenerated]
	public string get_JsonName() { }

	[CompilerGenerated]
	public string get_MemberName() { }

	[CompilerGenerated]
	public Type get_OverrideConverterType() { }

	[CompilerGenerated]
	public Type get_StorageType() { }

	public object Read(object context) { }

	[CompilerGenerated]
	private void set_CanRead(bool value) { }

	[CompilerGenerated]
	private void set_CanWrite(bool value) { }

	[CompilerGenerated]
	private void set_IsPublic(bool value) { }

	[CompilerGenerated]
	private void set_IsReadOnly(bool value) { }

	[CompilerGenerated]
	private void set_JsonName(string value) { }

	[CompilerGenerated]
	private void set_MemberName(string value) { }

	[CompilerGenerated]
	private void set_OverrideConverterType(Type value) { }

	[CompilerGenerated]
	private void set_StorageType(Type value) { }

	public void Write(object context, object value) { }

}

