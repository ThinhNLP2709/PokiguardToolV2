namespace Unity.VisualScripting.FullSerializer;

[AttributeUsage(384)]
public class fsPropertyAttribute : Attribute
{
	public string Name; //Field offset: 0x10
	public Type Converter; //Field offset: 0x18

	public fsPropertyAttribute() { }

	public fsPropertyAttribute(string name) { }

}

