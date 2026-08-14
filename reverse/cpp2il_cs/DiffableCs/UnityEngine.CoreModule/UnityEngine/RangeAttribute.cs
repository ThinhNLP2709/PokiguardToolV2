namespace UnityEngine;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public sealed class RangeAttribute : PropertyAttribute
{
	public readonly float min; //Field offset: 0x18
	public readonly float max; //Field offset: 0x1C

	public RangeAttribute(float min, float max) { }

}

