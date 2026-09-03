/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/CopyTexture.h")]
	[NativeHeader("Runtime/Graphics/ColorGamut.h")]
	[NativeHeader("Runtime/Camera/LightProbeProxyVolume.h")]
	[NativeHeader("Runtime/Misc/PlayerSettings.h")]
	public class Graphics // TypeDefIndex: 7548
	{
		// Fields
		internal static readonly int kMaxDrawMeshInstanceCount; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		internal static readonly Dictionary<int, RenderInstancedDataLayout> s_RenderInstancedDataLayouts; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		internal static readonly Dictionary<int, RenderSpriteInstancedDataLayout> s_RenderSpriteInstancedDataLayouts; // 0x10
	
		// Properties
		[StaticAccessor("GetGfxDevice()", StaticAccessorType.Dot)]
		public static GraphicsTier activeTier { get; set; } // 0x00000001821A3050-0x00000001821A3080 0x00000001821A3140-0x00000001821A3180
		public static bool preserveFramebufferAlpha { get; } // 0x00000001821A30E0-0x00000001821A3140 
		public static OpenGLESVersion minOpenGLESVersion { get; } // 0x00000001821A3080-0x00000001821A30E0 
		public static RenderBuffer activeColorBuffer { get; } // 0x00000001821A2ED0-0x00000001821A2F90 
		public static RenderBuffer activeDepthBuffer { get; } // 0x00000001821A2F90-0x00000001821A3050 
	
		// Constructors
		static Graphics(); // 0x00000001821A2DB0-0x00000001821A2ED0
	
		// Methods
		[FreeFunction("GraphicsScripting::GetMaxDrawMeshInstanceCount", IsThreadSafe = true)]
		private static int Internal_GetMaxDrawMeshInstanceCount(); // 0x00000001821A20A0-0x00000001821A20D0
		[NativeMethod(Name = "GetPreserveFramebufferAlpha")]
		[StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)]
		internal static bool GetPreserveFramebufferAlpha(); // 0x00000001821A1BB0-0x00000001821A1BE0
		[NativeMethod(Name = "GetMinOpenGLESVersion")]
		[StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)]
		internal static OpenGLESVersion GetMinOpenGLESVersion(); // 0x00000001821A1B80-0x00000001821A1BB0
		[FreeFunction("GraphicsScripting::GetActiveColorBuffer")]
		private static RenderBuffer GetActiveColorBuffer(); // 0x00000001821A1A60-0x00000001821A1AD0
		[FreeFunction("GraphicsScripting::GetActiveDepthBuffer")]
		private static RenderBuffer GetActiveDepthBuffer(); // 0x00000001821A1B10-0x00000001821A1B80
		[FreeFunction("GraphicsScripting::SetNullRT")]
		private static void Internal_SetNullRT(); // 0x00000001821A20D0-0x00000001821A2100
		[NativeMethod(Name = "GraphicsScripting::SetRTSimple", IsFreeFunction = true, ThrowsException = true)]
		private static void Internal_SetRTSimple(RenderBuffer color, RenderBuffer depth, int mip, CubemapFace face, int depthSlice); // 0x00000001821A2170-0x00000001821A2210
		[FreeFunction("CopyTexture")]
		private static void CopyTexture_Slice(Texture src, int srcElement, int srcMip, Texture dst, int dstElement, int dstMip); // 0x00000001821A0C20-0x00000001821A0CE0
		[FreeFunction("CopyTextureRegion")]
		private static void CopyTexture_Region(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY); // 0x00000001821A0AF0-0x00000001821A0BC0
		[FreeFunction("GraphicsScripting::DrawTexture")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal static void Internal_DrawTexture(ref Internal_DrawTextureArguments args); // 0x00000001821A2060-0x00000001821A20A0
		[FreeFunction("GraphicsScripting::DrawMesh")]
		private static void Internal_DrawMesh(Mesh mesh, int submeshIndex, Matrix4x4 matrix, Material material, int layer, Camera camera, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor, LightProbeUsage lightProbeUsage, LightProbeProxyVolume lightProbeProxyVolume); // 0x00000001821A1F00-0x00000001821A2060
		[FreeFunction("GraphicsScripting::DrawMeshInstanced")]
		private static void Internal_DrawMeshInstanced([NotNull] Mesh mesh, int submeshIndex, [NotNull] Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera, LightProbeUsage lightProbeUsage, LightProbeProxyVolume lightProbeProxyVolume); // 0x00000001821A1C60-0x00000001821A1E80
		[FreeFunction("GraphicsScripting::Blit")]
		private static void Blit3(Texture source, RenderTexture dest, int sourceDepthSlice, int destDepthSlice); // 0x00000001821A06A0-0x00000001821A0760
		[FreeFunction("GraphicsScripting::Blit")]
		private static void Blit4(Texture source, RenderTexture dest, Vector2 scale, Vector2 offset); // 0x00000001821A07D0-0x00000001821A0880
		[NativeMethod(Name = "GraphicsScripting::ExecuteCommandBuffer", IsFreeFunction = true, ThrowsException = true)]
		public static void ExecuteCommandBuffer([NotNull] CommandBuffer buffer); // 0x00000001821A1960-0x00000001821A1A20
		internal static void SetRenderTargetImpl(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, CubemapFace face, int depthSlice); // 0x00000001821A23E0-0x00000001821A24D0
		internal static void SetRenderTargetImpl(RenderTexture rt, int mipLevel, CubemapFace face, int depthSlice); // 0x00000001821A2210-0x00000001821A23E0
		public static void SetRenderTarget(RenderTexture rt, [DefaultValue("0")] int mipLevel, [DefaultValue("CubemapFace.Unknown")] CubemapFace face, [DefaultValue("0")] int depthSlice); // 0x00000001821A2810-0x00000001821A2A20
		public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, [DefaultValue("0")] int mipLevel, [DefaultValue("CubemapFace.Unknown")] CubemapFace face, [DefaultValue("0")] int depthSlice); // 0x00000001821A2610-0x00000001821A2740
		public static void CopyTexture(Texture src, int srcElement, int srcMip, Texture dst, int dstElement, int dstMip); // 0x00000001821A0CE0-0x00000001821A0DD0
		public static void CopyTexture(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY); // 0x00000001821A0DD0-0x00000001821A0EE0
		internal static void ValidateCopyBuffer(GraphicsBuffer source, GraphicsBuffer dest); // 0x00000001821A2A20-0x00000001821A2DB0
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor, LightProbeUsage lightProbeUsage); // 0x00000001821A15B0-0x00000001821A1760
		public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, [DefaultValue("matrices.Length")] int count, [DefaultValue("null")] MaterialPropertyBlock properties, [DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("0")] int layer, [DefaultValue("null")] Camera camera, [DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage); // 0x00000001821A0EE0-0x00000001821A14E0
		public static void Blit(Texture source, RenderTexture dest, int sourceDepthSlice, int destDepthSlice); // 0x00000001821A0880-0x00000001821A0970
		public static void Blit(Texture source, RenderTexture dest, Vector2 scale, Vector2 offset); // 0x00000001821A0970-0x00000001821A0A80
		[ExcludeFromDocs]
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties); // 0x00000001821A1760-0x00000001821A1920
		[ExcludeFromDocs]
		public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera); // 0x00000001821A14E0-0x00000001821A15B0
		[ExcludeFromDocs]
		public static void SetRenderTarget(RenderTexture rt); // 0x00000001821A2740-0x00000001821A27A0
		[ExcludeFromDocs]
		public static void SetRenderTarget(RenderTexture rt, int mipLevel); // 0x00000001821A27A0-0x00000001821A2810
		[ExcludeFromDocs]
		public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer); // 0x00000001821A24D0-0x00000001821A2610
		private static void GetActiveColorBuffer_Injected(); // 0x00000001821A1A20-0x00000001821A1A60
		private static void GetActiveDepthBuffer_Injected(); // 0x00000001821A1AD0-0x00000001821A1B10
		private static void Internal_SetRTSimple_Injected(in RenderBuffer color, in RenderBuffer depth, int mip, CubemapFace face, int depthSlice); // 0x00000001821A2100-0x00000001821A2170
		private static void CopyTexture_Slice_Injected(IntPtr src, int srcElement, int srcMip, IntPtr dst, int dstElement, int dstMip); // 0x00000001821A0BC0-0x00000001821A0C20
		private static void CopyTexture_Region_Injected(IntPtr src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, IntPtr dst, int dstElement, int dstMip, int dstX, int dstY); // 0x00000001821A0A80-0x00000001821A0AF0
		private static void Internal_DrawMesh_Injected(IntPtr mesh, int submeshIndex, in Matrix4x4 matrix, IntPtr material, int layer, IntPtr camera, IntPtr properties, ShadowCastingMode castShadows, bool receiveShadows, IntPtr probeAnchor, LightProbeUsage lightProbeUsage, IntPtr lightProbeProxyVolume); // 0x00000001821A1E80-0x00000001821A1F00
		private static void Internal_DrawMeshInstanced_Injected(IntPtr mesh, int submeshIndex, IntPtr material, ref ManagedSpanWrapper matrices, int count, IntPtr properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, IntPtr camera, LightProbeUsage lightProbeUsage, IntPtr lightProbeProxyVolume); // 0x00000001821A1BE0-0x00000001821A1C60
		private static void Blit3_Injected(IntPtr source, IntPtr dest, int sourceDepthSlice, int destDepthSlice); // 0x00000001821A0630-0x00000001821A06A0
		private static void Blit4_Injected(IntPtr source, IntPtr dest, in Vector2 scale, in Vector2 offset); // 0x00000001821A0760-0x00000001821A07D0
		private static void ExecuteCommandBuffer_Injected(IntPtr buffer); // 0x00000001821A1920-0x00000001821A1960
	}
}
