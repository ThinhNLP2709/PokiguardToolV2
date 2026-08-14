namespace UnityEngine.Rendering.RenderGraphModule;

internal struct ResourceHandle : IEquatable<ResourceHandle>
{
	private const uint kValidityMask = 4294901760; //Field offset: 0x0
	private const uint kIndexMask = 65535; //Field offset: 0x0
	private static uint s_CurrentValidBit; //Field offset: 0x0
	private static uint s_SharedResourceValidBit; //Field offset: 0x4
	private uint m_Value; //Field offset: 0x0
	private int m_Version; //Field offset: 0x4
	[CompilerGenerated]
	private RenderGraphResourceType <type>k__BackingField; //Field offset: 0x8

	public int index
	{
		 get { } //Length: 4
	}

	public bool IsVersioned
	{
		 get { } //Length: 9
	}

	public int iType
	{
		 get { } //Length: 67
	}

	public private RenderGraphResourceType type
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public int version
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	private static ResourceHandle() { }

	internal ResourceHandle(int value, RenderGraphResourceType type, bool shared) { }

	internal ResourceHandle(in ResourceHandle h, int version) { }

	public override bool Equals(ResourceHandle hdl) { }

	public int get_index() { }

	public bool get_IsVersioned() { }

	public int get_iType() { }

	[CompilerGenerated]
	[IsReadOnly]
	public RenderGraphResourceType get_type() { }

	public int get_version() { }

	public bool IsNull() { }

	public bool IsValid() { }

	public static void NewFrame(int executionIndex) { }

	[CompilerGenerated]
	private void set_type(RenderGraphResourceType value) { }

	public void set_version(int value) { }

}

