namespace UnityEngine.Rendering.Universal;

[Obsolete("Deprecated in favor of RTHandle", True)]
public struct RenderTargetHandle
{
	public static readonly RenderTargetHandle CameraTarget; //Field offset: 0x0
	[CompilerGenerated]
	private int <id>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private RenderTargetIdentifier <rtid>k__BackingField; //Field offset: 0x8

	public int id
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		 set { } //Length: 3
	}

	private RenderTargetIdentifier rtid
	{
		[CompilerGenerated]
		[IsReadOnly]
		private get { } //Length: 29
		[CompilerGenerated]
		private set { } //Length: 26
	}

	private static RenderTargetHandle() { }

	public RenderTargetHandle(RenderTargetIdentifier renderTargetIdentifier) { }

	public RenderTargetHandle(RTHandle rtHandle) { }

	public virtual bool Equals(object obj) { }

	public bool Equals(RenderTargetHandle other) { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_id() { }

	[CompilerGenerated]
	[IsReadOnly]
	private RenderTargetIdentifier get_rtid() { }

	internal static RenderTargetHandle GetCameraTarget(ref CameraData cameraData) { }

	public virtual int GetHashCode() { }

	public bool HasInternalRenderTargetId() { }

	public RenderTargetIdentifier Identifier() { }

	public void Init(RenderTargetIdentifier renderTargetIdentifier) { }

	public void Init(string shaderProperty) { }

	public static bool op_Equality(RenderTargetHandle c1, RenderTargetHandle c2) { }

	public static bool op_Inequality(RenderTargetHandle c1, RenderTargetHandle c2) { }

	[CompilerGenerated]
	public void set_id(int value) { }

	[CompilerGenerated]
	private void set_rtid(RenderTargetIdentifier value) { }

}

