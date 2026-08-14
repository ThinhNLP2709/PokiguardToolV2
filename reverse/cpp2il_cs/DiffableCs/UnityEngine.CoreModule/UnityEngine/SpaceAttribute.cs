namespace UnityEngine;

[AttributeUsage(AttributeTargets::Field (256), Inherited = True, AllowMultiple = True)]
public class SpaceAttribute : PropertyAttribute
{
	public readonly float height; //Field offset: 0x18

	public SpaceAttribute() { }

	public SpaceAttribute(float height) { }

}

