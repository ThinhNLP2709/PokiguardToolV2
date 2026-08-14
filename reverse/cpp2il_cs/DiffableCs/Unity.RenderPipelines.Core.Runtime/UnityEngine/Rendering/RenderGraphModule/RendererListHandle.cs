namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RendererList ({handle})")]
[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct RendererListHandle
{
	internal RendererListHandleType type; //Field offset: 0x0
	private bool m_IsValid; //Field offset: 0x4
	[CompilerGenerated]
	private int <handle>k__BackingField; //Field offset: 0x8

	internal int handle
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	internal RendererListHandle(int handle, RendererListHandleType type = 0) { }

	[CompilerGenerated]
	[IsReadOnly]
	internal int get_handle() { }

	public bool IsValid() { }

	public static int op_Implicit(RendererListHandle handle) { }

	public static RendererList op_Implicit(RendererListHandle rendererList) { }

	[CompilerGenerated]
	private void set_handle(int value) { }

}

