namespace UnityEngine.Rendering.Universal;

[AttributeUsage(AttributeTargets::Field (256))]
internal sealed class RenderPathCompatibleAttribute : Attribute
{
	public RenderPathCompatibility renderPath; //Field offset: 0x10

	public RenderPathCompatibleAttribute(RenderPathCompatibility renderPath) { }

}

