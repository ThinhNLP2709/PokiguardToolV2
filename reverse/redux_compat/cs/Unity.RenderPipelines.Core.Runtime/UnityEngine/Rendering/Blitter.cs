/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class Blitter // TypeDefIndex: 5739
	{
		// Fields
		private static Material s_Copy; // 0x00
		private static Material s_Blit; // 0x08
		private static Material s_BlitTexArray; // 0x10
		private static Material s_BlitTexArraySingleSlice; // 0x18
		private static Material s_BlitColorAndDepth; // 0x20
		private static MaterialPropertyBlock s_PropertyBlock; // 0x28
		private static Mesh s_TriangleMesh; // 0x30
		private static Mesh s_QuadMesh; // 0x38
		private static LocalKeyword s_DecodeHdrKeyword; // 0x40
		private static LocalKeyword s_ResolveDepthMSAA2X; // 0x58
		private static LocalKeyword s_ResolveDepthMSAA4X; // 0x70
		private static LocalKeyword s_ResolveDepthMSAA8X; // 0x88
		private static int[] s_BlitShaderPassIndicesMap; // 0xA0
		private static int[] s_BlitColorAndDepthShaderPassIndicesMap; // 0xA8
	
		// Nested types
		private static class BlitShaderIDs // TypeDefIndex: 5740
		{
			// Fields
			public static readonly int _BlitTexture; // 0x00
			public static readonly int _BlitCubeTexture; // 0x04
			public static readonly int _BlitScaleBias; // 0x08
			public static readonly int _BlitScaleBiasRt; // 0x0C
			public static readonly int _SourceResolution; // 0x10
			public static readonly int _BlitMipLevel; // 0x14
			public static readonly int _BlitTexArraySlice; // 0x18
			public static readonly int _BlitTextureSize; // 0x1C
			public static readonly int _BlitPaddingSize; // 0x20
			public static readonly int _BlitDecodeInstructions; // 0x24
			public static readonly int _InputDepth; // 0x28
			public static readonly int _InputDepthXR; // 0x2C
			public static readonly int _InputDepthXRMS; // 0x30
	
			// Constructors
			static BlitShaderIDs(); // 0x0000000181EA4FD0-0x0000000181EA5230
		}
	
		private enum BlitShaderPassNames // TypeDefIndex: 5741
		{
			Nearest = 0,
			Bilinear = 1,
			NearestQuad = 2,
			BilinearQuad = 3,
			NearestQuadPadding = 4,
			BilinearQuadPadding = 5,
			NearestQuadPaddingRepeat = 6,
			BilinearQuadPaddingRepeat = 7,
			BilinearQuadPaddingOctahedral = 8,
			NearestQuadPaddingAlphaBlend = 9,
			BilinearQuadPaddingAlphaBlend = 10,
			NearestQuadPaddingAlphaBlendRepeat = 11,
			BilinearQuadPaddingAlphaBlendRepeat = 12,
			BilinearQuadPaddingAlphaBlendOctahedral = 13,
			CubeToOctahedral = 14,
			CubeToOctahedralLuminance = 15,
			CubeToOctahedralAlpha = 16,
			CubeToOctahedralRed = 17,
			BilinearQuadLuminance = 18,
			BilinearQuadAlpha = 19,
			BilinearQuadRed = 20,
			NearestCubeToOctahedralPadding = 21,
			BilinearCubeToOctahedralPadding = 22,
			NearestQuadPaddingOctahedral = 23,
			NearestQuadPaddingAlphaBlendOctahedral = 24
		}
	
		private enum BlitColorAndDepthPassNames // TypeDefIndex: 5742
		{
			ColorOnly = 0,
			ColorAndDepth = 1,
			DepthOnly = 2
		}
	
		// Constructors
		static Blitter(); // 0x0000000181EAB340-0x0000000181EAB3C0
	
		// Methods
		public static void Initialize(Shader blitPS, Shader blitColorAndDepthPS); // 0x0000000181EAA310-0x0000000181EAAFB0
		public static void Cleanup(); // 0x0000000181EA9590-0x0000000181EA99B0
		public static Material GetBlitMaterial(TextureDimension dimension, bool singleSlice = false /* Metadata: 0x00661985 */); // 0x0000000181EAA1F0-0x0000000181EAA310
		internal static void DrawTriangle(RasterCommandBuffer cmd, Material material, int shaderPass); // 0x0000000181EAA170-0x0000000181EAA1F0
		internal static void DrawTriangle(CommandBuffer cmd, Material material, int shaderPass); // 0x0000000181EA9FC0-0x0000000181EAA170
		internal static void DrawTriangle(CommandBuffer cmd, Material material, int shaderPass, MaterialPropertyBlock propertyBlock); // 0x0000000181EA9E50-0x0000000181EA9FC0
		internal static void DrawQuadMesh(CommandBuffer cmd, Material material, int shaderPass, MaterialPropertyBlock propertyBlock); // 0x0000000181EA9AD0-0x0000000181EA9BC0
		internal static void DrawQuad(RasterCommandBuffer cmd, Material material, int shaderPass, MaterialPropertyBlock propertyBlock); // 0x0000000181EA9D30-0x0000000181EA9DC0
		internal static void DrawQuad(CommandBuffer cmd, Material material, int shaderPass); // 0x0000000181EA9DC0-0x0000000181EA9E50
		internal static void DrawQuad(CommandBuffer cmd, Material material, int shaderPass, MaterialPropertyBlock propertyBlock); // 0x0000000181EA9BC0-0x0000000181EA9D30
		internal static bool CanCopyMSAA(); // 0x0000000181EA93E0-0x0000000181EA9470
		internal static bool CanCopyMSAA(bool srcBindTextureMS); // 0x0000000181EA9470-0x0000000181EA9590
		internal static void CopyTexture(RasterCommandBuffer cmd, bool isMSAA, bool force2DForXR = false /* Metadata: 0x00661986 */); // 0x0000000181EA99B0-0x0000000181EA9AD0
		internal static void BlitTexture(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, float sourceMipLevel, int sourceDepthSlice, bool bilinear); // 0x0000000181EA8E40-0x0000000181EA9060
		internal static void BlitTexture(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, Material material, int pass, float sourceMipLevel, int sourceDepthSlice); // 0x0000000181EA86A0-0x0000000181EA87E0
		public static void BlitTexture(RasterCommandBuffer cmd, RTHandle source, Vector4 scaleBias, float mipLevel, bool bilinear); // 0x0000000181EA9330-0x0000000181EA93E0
		public static void BlitTexture(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, float mipLevel, bool bilinear); // 0x0000000181EA9060-0x0000000181EA9280
		public static void BlitTexture2D(RasterCommandBuffer cmd, RTHandle source, Vector4 scaleBias, float mipLevel, bool bilinear); // 0x0000000181EA7FF0-0x0000000181EA80A0
		public static void BlitTexture2D(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, float mipLevel, bool bilinear); // 0x0000000181EA80A0-0x0000000181EA8240
		public static void BlitColorAndDepth(RasterCommandBuffer cmd, Texture sourceColor, RenderTexture sourceDepth, Vector4 scaleBias, float mipLevel, bool blitDepth); // 0x0000000181EA6070-0x0000000181EA6290
		public static void BlitColorAndDepth(CommandBuffer cmd, Texture sourceColor, RenderTexture sourceDepth, Vector4 scaleBias, float mipLevel, bool blitDepth); // 0x0000000181EA6290-0x0000000181EA6470
		public static void BlitDepth(CommandBuffer cmd, RenderTexture sourceDepth, Vector4 scaleBias, float mipLevel); // 0x0000000181EA6C80-0x0000000181EA6FC0
		public static void BlitTexture(RasterCommandBuffer cmd, RTHandle source, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA8AF0-0x0000000181EA8BA0
		public static void BlitTexture(UnsafeCommandBuffer cmd, RTHandle source, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA9280-0x0000000181EA9330
		public static void BlitTexture(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA8400-0x0000000181EA8540
		public static void BlitTexture(RasterCommandBuffer cmd, RenderTargetIdentifier source, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA8BA0-0x0000000181EA8D50
		public static void BlitTexture(CommandBuffer cmd, RenderTargetIdentifier source, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA8540-0x0000000181EA86A0
		public static void BlitTexture(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material, int pass); // 0x0000000181EA8240-0x0000000181EA8400
		public static void BlitTexture(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, Material material, int pass); // 0x0000000181EA87E0-0x0000000181EA89C0
		public static void BlitTexture(CommandBuffer cmd, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA8D50-0x0000000181EA8E40
		public static void BlitTexture(RasterCommandBuffer cmd, Vector4 scaleBias, Material material, int pass); // 0x0000000181EA89C0-0x0000000181EA8AF0
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, float mipLevel = 0f /* Metadata: 0x00661987 */, bool bilinear = false /* Metadata: 0x0066198B */); // 0x0000000181EA53E0-0x0000000181EA5590
		public static void BlitCameraTexture2D(CommandBuffer cmd, RTHandle source, RTHandle destination, float mipLevel = 0f /* Metadata: 0x0066198C */, bool bilinear = false /* Metadata: 0x00661990 */); // 0x0000000181EA5230-0x0000000181EA53E0
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Material material, int pass); // 0x0000000181EA5ED0-0x0000000181EA6070
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Vector4 scaleBias, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, Material material, int pass); // 0x0000000181EA5590-0x0000000181EA5850
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, Material material, int pass); // 0x0000000181EA5B10-0x0000000181EA5ED0
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Vector4 scaleBias, float mipLevel = 0f /* Metadata: 0x00661991 */, bool bilinear = false /* Metadata: 0x00661995 */); // 0x0000000181EA5A20-0x0000000181EA5B10
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Rect destViewport, float mipLevel = 0f /* Metadata: 0x00661996 */, bool bilinear = false /* Metadata: 0x0066199A */); // 0x0000000181EA5850-0x0000000181EA5A20
		public static void BlitQuad(CommandBuffer cmd, Texture source, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear); // 0x0000000181EA7DE0-0x0000000181EA7FF0
		public static void BlitQuadWithPadding(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels); // 0x0000000181EA7AE0-0x0000000181EA7DE0
		public static void BlitQuadWithPaddingMultiply(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels); // 0x0000000181EA77E0-0x0000000181EA7AE0
		public static void BlitOctahedralWithPadding(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels); // 0x0000000181EA7280-0x0000000181EA7540
		public static void BlitOctahedralWithPaddingMultiply(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels); // 0x0000000181EA6FC0-0x0000000181EA7280
		public static void BlitCubeToOctahedral2DQuad(CommandBuffer cmd, Texture source, Vector4 scaleBiasRT, int mipLevelTex); // 0x0000000181EA6A80-0x0000000181EA6C80
		public static void BlitCubeToOctahedral2DQuadWithPadding(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels, Vector4? decodeInstructions = default); // 0x0000000181EA6710-0x0000000181EA6A80
		public static void BlitCubeToOctahedral2DQuadSingleChannel(CommandBuffer cmd, Texture source, Vector4 scaleBiasRT, int mipLevelTex); // 0x0000000181EA6470-0x0000000181EA6710
		public static void BlitQuadSingleChannel(CommandBuffer cmd, Texture source, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex); // 0x0000000181EA7540-0x0000000181EA77E0
		[CompilerGenerated]
		internal static Vector3[] _Initialize_g__GetFullScreenTriangleVertexPosition_17_0(float z); // 0x0000000181EAB0C0-0x0000000181EAB190
		[CompilerGenerated]
		internal static Vector2[] _Initialize_g__GetFullScreenTriangleTexCoord_17_1(); // 0x0000000181EAAFB0-0x0000000181EAB0C0
		[CompilerGenerated]
		internal static Vector3[] _Initialize_g__GetQuadVertexPosition_17_2(float z); // 0x0000000181EAB280-0x0000000181EAB340
		[CompilerGenerated]
		internal static Vector2[] _Initialize_g__GetQuadTexCoord_17_3(); // 0x0000000181EAB190-0x0000000181EAB280
	}
}
