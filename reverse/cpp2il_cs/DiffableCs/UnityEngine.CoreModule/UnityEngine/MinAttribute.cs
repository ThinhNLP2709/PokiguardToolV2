namespace UnityEngine;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public sealed class MinAttribute : PropertyAttribute
{
	public readonly float min; //Field offset: 0x18

	public MinAttribute(float min) { }

}

