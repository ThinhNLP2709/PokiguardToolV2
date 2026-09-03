/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class HDRDebugViewPass : ScriptableRenderPass // TypeDefIndex: 9564
	{
		// Fields
		private RTHandle m_PassthroughRT; // 0x60
		private Material m_material; // 0x68
	
		// Nested types
		private enum HDRDebugPassId // TypeDefIndex: 9565
		{
			CIExyPrepass = 0,
			DebugViewPass = 1
		}
	
		private class PassDataCIExy // TypeDefIndex: 9566
		{
			// Fields
			internal Material material; // 0x10
			internal Vector4 luminanceParameters; // 0x18
			internal TextureHandle srcColor; // 0x28
			internal TextureHandle xyBuffer; // 0x38
			internal TextureHandle passThrough; // 0x48
	
			// Constructors
			public PassDataCIExy(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class PassDataDebugView // TypeDefIndex: 9567
		{
			// Fields
			internal Material material; // 0x10
			internal HDRDebugMode hdrDebugMode; // 0x18
			internal UniversalCameraData cameraData; // 0x20
			internal Vector4 luminanceParameters; // 0x28
			internal TextureHandle xyBuffer; // 0x38
			internal TextureHandle srcColor; // 0x48
			internal TextureHandle dstColor; // 0x58
	
			// Constructors
			public PassDataDebugView(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal class ShaderConstants // TypeDefIndex: 9568
		{
			// Fields
			public static readonly int _DebugHDRModeId; // 0x00
			public static readonly int _HDRDebugParamsId; // 0x04
			public static readonly int _xyTextureId; // 0x08
			public static readonly int _SizeOfHDRXYMapping; // 0x0C
			public static readonly int _CIExyUAVIndex; // 0x10
	
			// Constructors
			public ShaderConstants(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static ShaderConstants(); // 0x0000000181FB50C0-0x0000000181FB5190
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9569
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassDataCIExy, UnsafeGraphContext> __9__12_0; // 0x08
			public static BaseRenderFunc<PassDataDebugView, RasterGraphContext> __9__12_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181FBEB20-0x0000000181FBEB90
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RenderHDRDebug_b__12_0(PassDataCIExy data, UnsafeGraphContext context); // 0x0000000181FBD8B0-0x0000000181FBD9D0
			internal void _RenderHDRDebug_b__12_1(PassDataDebugView data, RasterGraphContext context); // 0x0000000181FBD9D0-0x0000000181FBDB80
		}
	
		// Constructors
		public HDRDebugViewPass(Material mat); // 0x0000000181F91E20-0x0000000181F91EC0
	
		// Methods
		public static void ConfigureDescriptorForCIEPrepass(ref RenderTextureDescriptor descriptor); // 0x0000000181F903F0-0x0000000181F904B0
		internal static Vector4 GetLuminanceParameters(UniversalCameraData cameraData); // 0x0000000181F90C90-0x0000000181F90F30
		private static void ExecuteCIExyPrepass(CommandBuffer cmd, PassDataCIExy data, RTHandle sourceTexture, RTHandle xyTarget, RTHandle destTexture); // 0x0000000181F904D0-0x0000000181F907D0
		private static void ExecuteHDRDebugViewFinalPass(RasterCommandBuffer cmd, [IsReadOnly] in PassDataDebugView data, RTHandle source, Vector4 scaleBias, RTHandle destination, RTHandle xyTarget); // 0x0000000181F907D0-0x0000000181F90C90
		public void Dispose(); // 0x0000000181F904B0-0x0000000181F904D0
		public void Setup(UniversalCameraData cameraData, HDRDebugMode hdrdebugMode); // 0x0000000181F91CE0-0x0000000181F91E20
		internal void RenderHDRDebug(RenderGraph renderGraph, UniversalCameraData cameraData, [IsReadOnly] in TextureHandle srcColor, [IsReadOnly] in TextureHandle overlayUITexture, [IsReadOnly] in TextureHandle dstColor, HDRDebugMode hdrDebugMode); // 0x0000000181F90F30-0x0000000181F91CE0
	}
}
