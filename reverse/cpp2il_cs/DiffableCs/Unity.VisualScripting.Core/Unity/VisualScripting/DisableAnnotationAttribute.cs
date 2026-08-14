namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4))]
public class DisableAnnotationAttribute : Attribute
{
	[CompilerGenerated]
	private bool <disableIcon>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <disableGizmo>k__BackingField; //Field offset: 0x11

	public bool disableGizmo
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool disableIcon
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DisableAnnotationAttribute() { }

	[CompilerGenerated]
	public bool get_disableGizmo() { }

	[CompilerGenerated]
	public bool get_disableIcon() { }

	[CompilerGenerated]
	public void set_disableGizmo(bool value) { }

	[CompilerGenerated]
	public void set_disableIcon(bool value) { }

}

