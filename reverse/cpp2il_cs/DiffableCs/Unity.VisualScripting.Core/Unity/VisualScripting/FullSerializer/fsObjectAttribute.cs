namespace Unity.VisualScripting.FullSerializer;

[AttributeUsage(12)]
public class fsObjectAttribute : Attribute
{
	public Type[] PreviousModels; //Field offset: 0x10
	public string VersionString; //Field offset: 0x18
	public fsMemberSerialization MemberSerialization; //Field offset: 0x20
	public Type Converter; //Field offset: 0x28
	public Type Processor; //Field offset: 0x30

	public fsObjectAttribute() { }

	public fsObjectAttribute(string versionString, Type[] previousModels) { }

}

