namespace UnityEngine.UIElements;

[AttributeUsage(AttributeTargets::Class (4), Inherited = False)]
public class UxmlElementAttribute : Attribute
{
	public readonly string name; //Field offset: 0x10

	public UxmlElementAttribute(string uxmlName) { }

}

