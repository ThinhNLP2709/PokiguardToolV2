namespace UnityEngine.Rendering;

[AttributeUsage(260, AllowMultiple = False)]
public class DisplayInfoAttribute : Attribute
{
	public string name; //Field offset: 0x10
	public int order; //Field offset: 0x18

	public DisplayInfoAttribute() { }

}

