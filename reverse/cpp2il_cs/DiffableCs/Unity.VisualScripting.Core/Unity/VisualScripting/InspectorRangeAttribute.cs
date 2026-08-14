namespace Unity.VisualScripting;

[AttributeUsage(2432, AllowMultiple = False, Inherited = True)]
public sealed class InspectorRangeAttribute : Attribute
{
	[CompilerGenerated]
	private float <min>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private float <max>k__BackingField; //Field offset: 0x14

	public private float max
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public private float min
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public InspectorRangeAttribute(float min, float max) { }

	[CompilerGenerated]
	public float get_max() { }

	[CompilerGenerated]
	public float get_min() { }

	[CompilerGenerated]
	private void set_max(float value) { }

	[CompilerGenerated]
	private void set_min(float value) { }

}

