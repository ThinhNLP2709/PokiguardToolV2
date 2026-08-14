namespace UnityEngine.Rendering.RenderGraphModule.Util;

[Extension]
public static class RenderGraphUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<CopyPassData, RasterGraphContext> <>9__3_0; //Field offset: 0x8
		public static BaseRenderFunc<BlitPassData, UnsafeGraphContext> <>9__7_0; //Field offset: 0x10
		public static BaseRenderFunc<BlitMaterialPassData, UnsafeGraphContext> <>9__13_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <AddBlitPass>b__13_0(BlitMaterialPassData data, UnsafeGraphContext context) { }

		internal void <AddBlitPass>b__7_0(BlitPassData data, UnsafeGraphContext context) { }

		internal void <AddCopyPass>b__3_0(CopyPassData data, RasterGraphContext context) { }

	}

	internal enum BlitFilterMode
	{
		ClampNearest = 0,
		ClampBilinear = 1,
	}

	internal struct BlitMaterialParameters
	{
		private static readonly int blitTextureProperty; //Field offset: 0x0
		private static readonly int blitSliceProperty; //Field offset: 0x4
		private static readonly int blitMipProperty; //Field offset: 0x8
		private static readonly int blitScaleBias; //Field offset: 0xC
		public TextureHandle source; //Field offset: 0x0
		public TextureHandle destination; //Field offset: 0x10
		public Vector2 scale; //Field offset: 0x20
		public Vector2 offset; //Field offset: 0x28
		public int sourceSlice; //Field offset: 0x30
		public int destinationSlice; //Field offset: 0x34
		public int numSlices; //Field offset: 0x38
		public int sourceMip; //Field offset: 0x3C
		public int destinationMip; //Field offset: 0x40
		public int numMips; //Field offset: 0x44
		public Material material; //Field offset: 0x48
		public int shaderPass; //Field offset: 0x50
		public MaterialPropertyBlock propertyBlock; //Field offset: 0x58
		public int sourceTexturePropertyID; //Field offset: 0x60
		public int sourceSlicePropertyID; //Field offset: 0x64
		public int sourceMipPropertyID; //Field offset: 0x68
		public int scaleBiasPropertyID; //Field offset: 0x6C
		public FullScreenGeometryType geometry; //Field offset: 0x70

		private static BlitMaterialParameters() { }

		public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Material material, int shaderPass) { }

		public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, Material material, int shaderPass) { }

		public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Material material, int shaderPass, MaterialPropertyBlock mpb, int destinationSlice, int destinationMip, int numSlices = 1, int numMips = 1, int sourceSlice = -1, int sourceMip = -1, FullScreenGeometryType geometry = 0, int sourceTexturePropertyID = -1, int sourceSlicePropertyID = -1, int sourceMipPropertyID = -1) { }

		public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, Material material, int shaderPass, MaterialPropertyBlock mpb, int destinationSlice, int destinationMip, int numSlices = 1, int numMips = 1, int sourceSlice = -1, int sourceMip = -1, FullScreenGeometryType geometry = 0, int sourceTexturePropertyID = -1, int sourceSlicePropertyID = -1, int sourceMipPropertyID = -1, int scaleBiasPropertyID = -1) { }

		public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Material material, int shaderPass, MaterialPropertyBlock mpb, FullScreenGeometryType geometry = 0, int sourceTexturePropertyID = -1, int sourceSlicePropertyID = -1, int sourceMipPropertyID = -1) { }

		public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, Material material, int shaderPass, MaterialPropertyBlock mpb, FullScreenGeometryType geometry = 0, int sourceTexturePropertyID = -1, int sourceSlicePropertyID = -1, int sourceMipPropertyID = -1, int scaleBiasPropertyID = -1) { }

	}

	private class BlitMaterialPassData
	{
		public int sourceTexturePropertyID; //Field offset: 0x10
		public TextureHandle source; //Field offset: 0x14
		public TextureHandle destination; //Field offset: 0x24
		public Vector2 scale; //Field offset: 0x34
		public Vector2 offset; //Field offset: 0x3C
		public Material material; //Field offset: 0x48
		public int shaderPass; //Field offset: 0x50
		public MaterialPropertyBlock propertyBlock; //Field offset: 0x58
		public int sourceSlice; //Field offset: 0x60
		public int destinationSlice; //Field offset: 0x64
		public int numSlices; //Field offset: 0x68
		public int sourceMip; //Field offset: 0x6C
		public int destinationMip; //Field offset: 0x70
		public int numMips; //Field offset: 0x74
		public FullScreenGeometryType geometry; //Field offset: 0x78
		public int sourceSlicePropertyID; //Field offset: 0x7C
		public int sourceMipPropertyID; //Field offset: 0x80
		public int scaleBiasPropertyID; //Field offset: 0x84

		public BlitMaterialPassData() { }

	}

	private class BlitPassData
	{
		public TextureHandle source; //Field offset: 0x10
		public TextureHandle destination; //Field offset: 0x20
		public Vector2 scale; //Field offset: 0x30
		public Vector2 offset; //Field offset: 0x38
		public int sourceSlice; //Field offset: 0x40
		public int destinationSlice; //Field offset: 0x44
		public int numSlices; //Field offset: 0x48
		public int sourceMip; //Field offset: 0x4C
		public int destinationMip; //Field offset: 0x50
		public int numMips; //Field offset: 0x54
		public BlitFilterMode filterMode; //Field offset: 0x58

		public BlitPassData() { }

	}

	private class CopyPassData
	{
		public bool isMSAA; //Field offset: 0x10

		public CopyPassData() { }

	}

	internal enum FullScreenGeometryType
	{
		Mesh = 0,
		ProceduralTriangle = 1,
		ProceduralQuad = 2,
	}

	private static MaterialPropertyBlock s_PropertyBlock; //Field offset: 0x0
	private static Vector4 s_BlitScaleBias; //Field offset: 0x8

	private static RenderGraphUtils() { }

	[Extension]
	public static void AddBlitPass(RenderGraph graph, TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, int sourceSlice = 0, int destinationSlice = 0, int numSlices = -1, int sourceMip = 0, int destinationMip = 0, int numMips = 1, BlitFilterMode filterMode = 1, string passName = "Blit Pass Utility", string file = "", int line = 0) { }

	[Extension]
	public static void AddBlitPass(RenderGraph graph, BlitMaterialParameters blitParameters, string passName = "Blit Pass Utility w. Material", string file = "", int line = 0) { }

	[Extension]
	public static void AddCopyPass(RenderGraph graph, TextureHandle source, TextureHandle destination, int sourceSlice = 0, int destinationSlice = 0, int sourceMip = 0, int destinationMip = 0, string passName = "Copy Pass Utility", string file = "", int line = 0) { }

	private static void BlitMaterialRenderFunc(BlitMaterialPassData data, UnsafeGraphContext context) { }

	private static void BlitRenderFunc(BlitPassData data, UnsafeGraphContext context) { }

	public static bool CanAddCopyPassMSAA() { }

	private static void CopyRenderFunc(CopyPassData data, RasterGraphContext rgContext) { }

}

