namespace UnityEngine.Rendering.Universal;

internal class XRPassUniversal : XRPass
{
	[CompilerGenerated]
	private bool <isLateLatchEnabled>k__BackingField; //Field offset: 0x738
	[CompilerGenerated]
	private bool <canMarkLateLatch>k__BackingField; //Field offset: 0x739
	[CompilerGenerated]
	private bool <hasMarkedLateLatch>k__BackingField; //Field offset: 0x73A
	[CompilerGenerated]
	private bool <canFoveateIntermediatePasses>k__BackingField; //Field offset: 0x73B

	internal bool canFoveateIntermediatePasses
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool canMarkLateLatch
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool hasMarkedLateLatch
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool isLateLatchEnabled
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public XRPassUniversal() { }

	public static XRPass Create(XRPassCreateInfo createInfo) { }

	[CompilerGenerated]
	internal bool get_canFoveateIntermediatePasses() { }

	[CompilerGenerated]
	internal bool get_canMarkLateLatch() { }

	[CompilerGenerated]
	internal bool get_hasMarkedLateLatch() { }

	[CompilerGenerated]
	internal bool get_isLateLatchEnabled() { }

	public virtual void Release() { }

	[CompilerGenerated]
	internal void set_canFoveateIntermediatePasses(bool value) { }

	[CompilerGenerated]
	internal void set_canMarkLateLatch(bool value) { }

	[CompilerGenerated]
	internal void set_hasMarkedLateLatch(bool value) { }

	[CompilerGenerated]
	internal void set_isLateLatchEnabled(bool value) { }

}

