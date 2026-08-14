namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), Inherited = True, AllowMultiple = False)]
public sealed class SingletonAttribute : Attribute
{
	[CompilerGenerated]
	private bool <Persistent>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <Automatic>k__BackingField; //Field offset: 0x11
	[CompilerGenerated]
	private HideFlags <HideFlags>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private string <Name>k__BackingField; //Field offset: 0x18

	public bool Automatic
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public HideFlags HideFlags
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public bool Persistent
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public SingletonAttribute() { }

	[CompilerGenerated]
	public bool get_Automatic() { }

	[CompilerGenerated]
	public HideFlags get_HideFlags() { }

	[CompilerGenerated]
	public string get_Name() { }

	[CompilerGenerated]
	public bool get_Persistent() { }

	[CompilerGenerated]
	public void set_Automatic(bool value) { }

	[CompilerGenerated]
	public void set_HideFlags(HideFlags value) { }

	[CompilerGenerated]
	public void set_Name(string value) { }

	[CompilerGenerated]
	public void set_Persistent(bool value) { }

}

