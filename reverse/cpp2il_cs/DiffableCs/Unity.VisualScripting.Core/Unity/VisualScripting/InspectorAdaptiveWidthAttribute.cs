namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = True)]
public sealed class InspectorAdaptiveWidthAttribute : Attribute
{
	[CompilerGenerated]
	private float <width>k__BackingField; //Field offset: 0x10

	public private float width
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public InspectorAdaptiveWidthAttribute(float width) { }

	[CompilerGenerated]
	public float get_width() { }

	[CompilerGenerated]
	private void set_width(float value) { }

}

