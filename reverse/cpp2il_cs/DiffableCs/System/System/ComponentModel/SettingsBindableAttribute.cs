namespace System.ComponentModel;

[AttributeUsage(AttributeTargets::Property (128))]
public sealed class SettingsBindableAttribute : Attribute
{
	public static readonly SettingsBindableAttribute Yes; //Field offset: 0x0
	public static readonly SettingsBindableAttribute No; //Field offset: 0x8
	[CompilerGenerated]
	private readonly bool <Bindable>k__BackingField; //Field offset: 0x10

	public bool Bindable
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	private static SettingsBindableAttribute() { }

	public SettingsBindableAttribute(bool bindable) { }

	public virtual bool Equals(object obj) { }

	[CompilerGenerated]
	public bool get_Bindable() { }

	public virtual int GetHashCode() { }

}

