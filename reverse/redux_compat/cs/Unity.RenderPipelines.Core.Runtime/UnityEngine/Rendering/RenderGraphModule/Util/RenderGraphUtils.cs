/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.Util
{
	public static class RenderGraphUtils // TypeDefIndex: 5975
	{
		// Fields
		private static readonly MaterialPropertyBlock s_PropertyBlock; // 0x00
		private static Vector4 s_BlitScaleBias; // 0x08
	
		// Nested types
		private class CopyPassData // TypeDefIndex: 5976
		{
			// Fields
			public bool isMSAA; // 0x10
			public bool force2DForXR; // 0x11
	
			// Constructors
			public CopyPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public enum BlitFilterMode // TypeDefIndex: 5977
		{
			ClampNearest = 0,
			ClampBilinear = 1
		}
	
		private class BlitPassData // TypeDefIndex: 5978
		{
			// Fields
			public TextureHandle source; // 0x10
			public TextureHandle destination; // 0x20
			public Vector2 scale; // 0x30
			public Vector2 offset; // 0x38
			public int sourceSlice; // 0x40
			public int destinationSlice; // 0x44
			public int numSlices; // 0x48
			public int sourceMip; // 0x4C
			public int destinationMip; // 0x50
			public int numMips; // 0x54
			public BlitFilterMode filterMode; // 0x58
			public bool isXR; // 0x5C
			public bool isDepth; // 0x5D
	
			// Constructors
			public BlitPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public enum FullScreenGeometryType // TypeDefIndex: 5979
		{
			Mesh = 0,
			ProceduralTriangle = 1,
			ProceduralQuad = 2
		}
	
		public struct BlitMaterialParameters // TypeDefIndex: 5980
		{
			// Fields
			private static readonly int blitTextureProperty; // 0x00
			private static readonly int blitSliceProperty; // 0x04
			private static readonly int blitMipProperty; // 0x08
			private static readonly int blitScaleBias; // 0x0C
			public TextureHandle source; // 0x00
			public TextureHandle destination; // 0x10
			public Vector2 scale; // 0x20
			public Vector2 offset; // 0x28
			public int sourceSlice; // 0x30
			public int destinationSlice; // 0x34
			public int numSlices; // 0x38
			public int sourceMip; // 0x3C
			public int destinationMip; // 0x40
			public int numMips; // 0x44
			public Material material; // 0x48
			public int shaderPass; // 0x50
			public MaterialPropertyBlock propertyBlock; // 0x58
			public int sourceTexturePropertyID; // 0x60
			public int sourceSlicePropertyID; // 0x64
			public int sourceMipPropertyID; // 0x68
			public int scaleBiasPropertyID; // 0x6C
			public FullScreenGeometryType geometry; // 0x70
	
			// Constructors
			public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Material material, int shaderPass); // 0x0000000181ED7820-0x0000000181ED7930
			public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, Material material, int shaderPass); // 0x0000000181ED72E0-0x0000000181ED7410
			public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Material material, int shaderPass, MaterialPropertyBlock mpb, int destinationSlice, int destinationMip, int numSlices = -1 /* Metadata: 0x00662CC9 */, int numMips = 1 /* Metadata: 0x00662CCA */, int sourceSlice = -1 /* Metadata: 0x00662CCB */, int sourceMip = -1 /* Metadata: 0x00662CCC */, FullScreenGeometryType geometry = FullScreenGeometryType.Mesh /* Metadata: 0x00662CCD */, int sourceTexturePropertyID = -1 /* Metadata: 0x00662CCE */, int sourceSlicePropertyID = -1 /* Metadata: 0x00662CCF */, int sourceMipPropertyID = -1 /* Metadata: 0x00662CD0 */); // 0x0000000181ED7110-0x0000000181ED72E0
			public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, Material material, int shaderPass, MaterialPropertyBlock mpb, int destinationSlice, int destinationMip, int numSlices = -1 /* Metadata: 0x00662CD1 */, int numMips = 1 /* Metadata: 0x00662CD2 */, int sourceSlice = -1 /* Metadata: 0x00662CD3 */, int sourceMip = -1 /* Metadata: 0x00662CD4 */, FullScreenGeometryType geometry = FullScreenGeometryType.Mesh /* Metadata: 0x00662CD5 */, int sourceTexturePropertyID = -1 /* Metadata: 0x00662CD6 */, int sourceSlicePropertyID = -1 /* Metadata: 0x00662CD7 */, int sourceMipPropertyID = -1 /* Metadata: 0x00662CD8 */, int scaleBiasPropertyID = -1 /* Metadata: 0x00662CD9 */); // 0x0000000181ED76C0-0x0000000181ED7820
			public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Material material, int shaderPass, MaterialPropertyBlock mpb, FullScreenGeometryType geometry = FullScreenGeometryType.Mesh /* Metadata: 0x00662CDA */, int sourceTexturePropertyID = -1 /* Metadata: 0x00662CDB */, int sourceSlicePropertyID = -1 /* Metadata: 0x00662CDC */, int sourceMipPropertyID = -1 /* Metadata: 0x00662CDD */); // 0x0000000181ED7530-0x0000000181ED76C0
			public BlitMaterialParameters(TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, Material material, int shaderPass, MaterialPropertyBlock mpb, FullScreenGeometryType geometry = FullScreenGeometryType.Mesh /* Metadata: 0x00662CDE */, int sourceTexturePropertyID = -1 /* Metadata: 0x00662CDF */, int sourceSlicePropertyID = -1 /* Metadata: 0x00662CE0 */, int sourceMipPropertyID = -1 /* Metadata: 0x00662CE1 */, int scaleBiasPropertyID = -1 /* Metadata: 0x00662CE2 */); // 0x0000000181ED7410-0x0000000181ED7530
			static BlitMaterialParameters(); // 0x0000000181ED7040-0x0000000181ED7110
		}
	
		private class BlitMaterialPassData // TypeDefIndex: 5981
		{
			// Fields
			public int sourceTexturePropertyID; // 0x10
			public TextureHandle source; // 0x14
			public TextureHandle destination; // 0x24
			public Vector2 scale; // 0x34
			public Vector2 offset; // 0x3C
			public Material material; // 0x48
			public int shaderPass; // 0x50
			public MaterialPropertyBlock propertyBlock; // 0x58
			public int sourceSlice; // 0x60
			public int destinationSlice; // 0x64
			public int numSlices; // 0x68
			public int sourceMip; // 0x6C
			public int destinationMip; // 0x70
			public int numMips; // 0x74
			public FullScreenGeometryType geometry; // 0x78
			public int sourceSlicePropertyID; // 0x7C
			public int sourceMipPropertyID; // 0x80
			public int scaleBiasPropertyID; // 0x84
			public bool isXR; // 0x88
	
			// Constructors
			public BlitMaterialPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5982
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<CopyPassData, RasterGraphContext> __9__8_0; // 0x08
			public static BaseRenderFunc<BlitPassData, UnsafeGraphContext> __9__14_0; // 0x10
			public static BaseRenderFunc<BlitMaterialPassData, UnsafeGraphContext> __9__20_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181EF0850-0x0000000181EF08C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _AddCopyPass_b__8_0(CopyPassData data, RasterGraphContext context); // 0x0000000181EF0790-0x0000000181EF0850
			internal void _AddBlitPass_b__14_0(BlitPassData data, UnsafeGraphContext context); // 0x0000000181EF06D0-0x0000000181EF0730
			internal void _AddBlitPass_b__20_0(BlitMaterialPassData data, UnsafeGraphContext context); // 0x0000000181EF0730-0x0000000181EF0790
		}
	
		// Constructors
		static RenderGraphUtils(); // 0x0000000181EEDEB0-0x0000000181EEDF40
	
		// Methods
		public static bool CanAddCopyPassMSAA(); // 0x0000000181EED940-0x0000000181EED9D0
		public static bool CanAddCopyPassMSAA([IsReadOnly] in TextureDesc sourceDesc); // 0x0000000181EED8A0-0x0000000181EED940
		public static bool CanAddCopyPassMSAA(bool bindTextureMS); // 0x0000000181EED9D0-0x0000000181EEDA70
		internal static bool IsFramebufferFetchEmulationMSAASupportedOnCurrentPlatform(); // 0x0000000181EEDCC0-0x0000000181EEDD00
		private static void CopyRenderFunc(CopyPassData data, RasterGraphContext rgContext); // 0x0000000181EEDC40-0x0000000181EEDCC0
		internal static bool IsTextureXR(ref RenderTargetInfo destDesc, int sourceSlice, int destinationSlice, int numSlices, int numMips); // 0x0000000181EEDDD0-0x0000000181EEDEB0
		private static void BlitRenderFunc(BlitPassData data, UnsafeGraphContext context); // 0x0000000181EED280-0x0000000181EED8A0
		private static void BlitMaterialRenderFunc(BlitMaterialPassData data, UnsafeGraphContext context); // 0x0000000181EECB50-0x0000000181EED280
	
		// Extension methods
		public static bool IsFramebufferFetchSupportedOnCurrentPlatform(this RenderGraph graph, [IsReadOnly] in TextureHandle tex); // 0x0000000181EEDD00-0x0000000181EEDDD0
		public static bool CanAddCopyPass(this RenderGraph graph, TextureHandle source, TextureHandle destination); // 0x0000000181EEDA70-0x0000000181EEDC40
		public static IBaseRenderGraphBuilder AddCopyPass(this RenderGraph graph, TextureHandle source, TextureHandle destination, string passName = "Copy Pass Utility" /* Metadata: 0x00662C5B */, bool returnBuilder = false /* Metadata: 0x00662C6D */, [CallerFilePath] string file = "" /* Metadata: 0x00662C6E */, [CallerLineNumber] int line = 0 /* Metadata: 0x00662C6F */); // 0x0000000181EEC4A0-0x0000000181EECB50
		public static void AddCopyPass(this RenderGraph graph, TextureHandle source, TextureHandle destination, int sourceSlice, int destinationSlice = 0 /* Metadata: 0x00662C70 */, int sourceMip = 0 /* Metadata: 0x00662C71 */, int destinationMip = 0 /* Metadata: 0x00662C72 */, string passName = "Copy Pass Utility" /* Metadata: 0x00662C73 */, [CallerFilePath] string file = "" /* Metadata: 0x00662C85 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00662C86 */); // 0x0000000181EEC3F0-0x0000000181EEC4A0
		public static IBaseRenderGraphBuilder AddBlitPass(this RenderGraph graph, TextureHandle source, TextureHandle destination, Vector2 scale, Vector2 offset, int sourceSlice = 0 /* Metadata: 0x00662C87 */, int destinationSlice = 0 /* Metadata: 0x00662C88 */, int numSlices = -1 /* Metadata: 0x00662C89 */, int sourceMip = 0 /* Metadata: 0x00662C8A */, int destinationMip = 0 /* Metadata: 0x00662C8B */, int numMips = 1 /* Metadata: 0x00662C8C */, BlitFilterMode filterMode = BlitFilterMode.ClampBilinear /* Metadata: 0x00662C8D */, string passName = "Blit Pass Utility" /* Metadata: 0x00662C8E */, bool returnBuilder = false /* Metadata: 0x00662CA0 */, [CallerFilePath] string file = "" /* Metadata: 0x00662CA1 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00662CA2 */); // 0x0000000181EEB700-0x0000000181EEC3F0
		public static IBaseRenderGraphBuilder AddBlitPass(this RenderGraph graph, BlitMaterialParameters blitParameters, string passName = "Blit Pass Utility w. Material" /* Metadata: 0x00662CA3 */, bool returnBuilder = false /* Metadata: 0x00662CC1 */, [CallerFilePath] string file = "" /* Metadata: 0x00662CC2 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00662CC3 */); // 0x0000000181EEAA90-0x0000000181EEB700
	}
}
