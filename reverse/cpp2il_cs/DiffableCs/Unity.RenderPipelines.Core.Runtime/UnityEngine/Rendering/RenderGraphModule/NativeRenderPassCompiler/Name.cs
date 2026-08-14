namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal struct Name
{
	public readonly string name; //Field offset: 0x0
	public readonly int utf8ByteCount; //Field offset: 0x8

	public Name(string name, bool computeUTF8ByteCount = false) { }

}

