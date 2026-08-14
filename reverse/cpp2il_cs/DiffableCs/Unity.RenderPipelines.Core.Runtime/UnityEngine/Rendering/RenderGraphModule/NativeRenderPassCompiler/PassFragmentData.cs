namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassFragmentData: Res({resource.index}):{accessFlags}")]
internal struct PassFragmentData
{
	public ResourceHandle resource; //Field offset: 0x0
	public AccessFlags accessFlags; //Field offset: 0xC
	public int mipLevel; //Field offset: 0x10
	public int depthSlice; //Field offset: 0x14

	public static bool EqualForMerge(PassFragmentData x, PassFragmentData y) { }

	public virtual int GetHashCode() { }

}

