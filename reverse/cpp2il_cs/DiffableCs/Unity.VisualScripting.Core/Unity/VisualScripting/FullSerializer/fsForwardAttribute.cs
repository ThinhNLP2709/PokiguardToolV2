namespace Unity.VisualScripting.FullSerializer;

[AttributeUsage(1036)]
public sealed class fsForwardAttribute : Attribute
{
	public string MemberName; //Field offset: 0x10

	public fsForwardAttribute(string memberName) { }

}

