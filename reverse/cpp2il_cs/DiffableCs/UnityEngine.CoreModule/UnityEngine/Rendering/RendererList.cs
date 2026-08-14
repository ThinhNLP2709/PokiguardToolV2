namespace UnityEngine.Rendering;

[MovedFrom("UnityEngine.Rendering.RendererUtils")]
[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/RendererList.h")]
public struct RendererList
{
	public static readonly RendererList nullRendererList; //Field offset: 0x0
	internal UIntPtr context; //Field offset: 0x0
	internal uint index; //Field offset: 0x8
	internal uint frame; //Field offset: 0xC
	internal uint type; //Field offset: 0x10
	internal uint contextID; //Field offset: 0x14

	public bool isValid
	{
		 get { } //Length: 51
	}

	private static RendererList() { }

	internal RendererList(UIntPtr ctx, uint indx) { }

	public bool get_isValid() { }

}

