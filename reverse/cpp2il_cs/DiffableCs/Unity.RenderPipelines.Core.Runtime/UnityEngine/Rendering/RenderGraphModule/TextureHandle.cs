namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("Texture ({handle.index})")]
[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct TextureHandle
{
	private static TextureHandle s_NullHandle; //Field offset: 0x0
	internal ResourceHandle handle; //Field offset: 0x0
	private bool builtin; //Field offset: 0xC

	public static TextureHandle nullHandle
	{
		 get { } //Length: 90
	}

	private static TextureHandle() { }

	internal TextureHandle(in ResourceHandle h) { }

	internal TextureHandle(int handle, bool shared = false, bool builtin = false) { }

	public static TextureHandle get_nullHandle() { }

	public TextureDesc GetDescriptor(RenderGraph renderGraph) { }

	internal bool IsBuiltin() { }

	public bool IsValid() { }

	public static RenderTargetIdentifier op_Implicit(TextureHandle texture) { }

	public static Texture op_Implicit(TextureHandle texture) { }

	public static RenderTexture op_Implicit(TextureHandle texture) { }

	public static RTHandle op_Implicit(TextureHandle texture) { }

}

