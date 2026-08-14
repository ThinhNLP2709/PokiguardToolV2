namespace UnityEngine;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public sealed class MultilineAttribute : PropertyAttribute
{
	public readonly int lines; //Field offset: 0x18

	public MultilineAttribute() { }

}

