namespace UnityEngine.Rendering.Universal;

[AttributeUsage(AttributeTargets::Class (4))]
public class SupportedOnRendererAttribute : Attribute
{
	[CompilerGenerated]
	private readonly Type[] <rendererTypes>k__BackingField; //Field offset: 0x10

	public Type[] rendererTypes
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public SupportedOnRendererAttribute(Type renderer) { }

	public SupportedOnRendererAttribute(Type[] renderers) { }

	[CompilerGenerated]
	public Type[] get_rendererTypes() { }

}

