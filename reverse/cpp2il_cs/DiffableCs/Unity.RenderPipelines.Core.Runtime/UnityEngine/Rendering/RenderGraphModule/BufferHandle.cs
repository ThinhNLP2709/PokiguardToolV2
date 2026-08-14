namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("Buffer ({handle.index})")]
[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct BufferHandle
{
	private static BufferHandle s_NullHandle; //Field offset: 0x0
	internal ResourceHandle handle; //Field offset: 0x0

	public static BufferHandle nullHandle
	{
		 get { } //Length: 98
	}

	private static BufferHandle() { }

	internal BufferHandle(in ResourceHandle h) { }

	internal BufferHandle(int handle, bool shared = false) { }

	public static BufferHandle get_nullHandle() { }

	public bool IsValid() { }

	public static GraphicsBuffer op_Implicit(BufferHandle buffer) { }

}

