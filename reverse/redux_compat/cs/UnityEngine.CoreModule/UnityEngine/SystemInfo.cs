/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Input/GetInput.h")]
	[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
	[NativeHeader("Runtime/Camera/RenderLoops/MotionVectorRenderLoop.h")]
	[NativeHeader("Runtime/Shaders/GraphicsCapsScriptBindings.h")]
	[NativeHeader("Runtime/Misc/SystemInfoRendering.h")]
	[NativeHeader("NativeKernel/Misc/SystemInfoMemory.h")]
	[NativeHeader("Runtime/Misc/SystemInfoAudio.h")]
	[NativeHeader("Runtime/Misc/SystemInfo.h")]
	[NativeHeader("Runtime/Graphics/GraphicsFormatUtility.bindings.h")]
	public sealed class SystemInfo // TypeDefIndex: 7824
	{
		// Properties
		public static string operatingSystem { get; } // 0x000000018221E630-0x000000018221E640 
		public static OperatingSystemFamily operatingSystemFamily { get; } // 0x000000018221DC90-0x000000018221DCC0 
		public static string deviceUniqueIdentifier { get; } // 0x000000018221E600-0x000000018221E610 
		public static string deviceModel { get; } // 0x000000018221E5F0-0x000000018221E600 
		public static DeviceType deviceType { get; } // 0x000000018221D7A0-0x000000018221D7D0 
		public static string graphicsDeviceName { get; } // 0x000000018221E610-0x000000018221E620 
		public static string graphicsDeviceVendor { get; } // 0x000000018221E620-0x000000018221E630 
		public static int graphicsDeviceVendorID { get; } // 0x000000018221DA30-0x000000018221DA60 
		public static GraphicsDeviceType graphicsDeviceType { get; } // 0x000000018221DA00-0x000000018221DA30 
		public static bool graphicsUVStartsAtTop { get; } // 0x000000018221DBD0-0x000000018221DC00 
		public static int graphicsShaderLevel { get; } // 0x000000018221DBA0-0x000000018221DBD0 
		public static FoveatedRenderingCaps foveatedRenderingCaps { get; } // 0x000000018221D8D0-0x000000018221D900 
		public static bool hasHiddenSurfaceRemovalOnGPU { get; } // 0x000000018221DE80-0x000000018221DEB0 
		public static bool supportsShadows { get; } // 0x000000018221E450-0x000000018221E480 
		public static CopyTextureSupport copyTextureSupport { get; } // 0x000000018221D670-0x000000018221D6A0 
		public static bool supportsComputeShaders { get; } // 0x000000018221E050-0x000000018221E080 
		public static bool supportsRenderTargetArrayIndexFromVertexShader { get; } // 0x000000018221E320-0x000000018221E350 
		public static bool supportsInstancing { get; } // 0x000000018221E110-0x000000018221E140 
		public static int supportedRenderTargetCount { get; } // 0x000000018221DFF0-0x000000018221E020 
		public static int supportsMultisampledTextures { get; } // 0x000000018221E290-0x000000018221E2C0 
		public static bool supportsMultisampled2DArrayTextures { get; } // 0x000000018221E200-0x000000018221E230 
		public static bool supportsMultisampledBackBuffer { get; } // 0x000000018221E230-0x000000018221E260 
		public static bool supportsMemorylessTextures { get; } // 0x000000018221E140-0x000000018221E170 
		public static bool supportsMultisampleAutoResolve { get; } // 0x000000018221E170-0x000000018221E1A0 
		public static bool supportsMultisampledShaderResolve { get; } // 0x000000018221E260-0x000000018221E290 
		public static bool usesReversedZBuffer { get; } // 0x000000018221E5C0-0x000000018221E5F0 
		public static int maxTiledPixelStorageSize { get; } // 0x000000018221DFC0-0x000000018221DFF0 
		public static bool supportsBackbufferInMultipleRenderTargets { get; } // 0x000000018221E020-0x000000018221E050 
		public static int maxTextureSize { get; } // 0x000000018221DC60-0x000000018221DC90 
		internal static int maxRenderTextureSize { [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] get; } // 0x000000018221DC30-0x000000018221DC60 
		public static bool supportsGraphicsFence { get; } // 0x000000018221E0B0-0x000000018221E0E0 
		public static bool supportsRayTracing { get; } // 0x000000018221E2F0-0x000000018221E320 
		public static long maxGraphicsBufferSize { get; } // 0x000000018221DF90-0x000000018221DFC0 
		public static HDRDisplaySupportFlags hdrDisplaySupportFlags { get; } // 0x000000018221DC00-0x000000018221DC30 
		public static bool supportsMultiview { get; } // 0x000000018221E2C0-0x000000018221E2F0 
		public static bool supportsMultisampleResolveDepth { get; } // 0x000000018221E1A0-0x000000018221E1D0 
		public static bool supportsMultisampleResolveStencil { get; } // 0x000000018221E1D0-0x000000018221E200 
		public static bool supportsIndirectArgumentsBuffer { get; } // 0x000000018221E0E0-0x000000018221E110 
		public static bool supportsDepthAttachmentAsInputAttachment { get; } // 0x000000018221E080-0x000000018221E0B0 
	
		// Methods
		private static bool IsValidEnumValue(Enum value); // 0x000000018221DF30-0x000000018221DF90
		public static bool SupportsRenderTextureFormat(RenderTextureFormat format); // 0x000000018221E350-0x000000018221E450
		public static bool SupportsTextureFormat(TextureFormat format); // 0x000000018221E4C0-0x000000018221E5C0
		[FreeFunction("systeminfo::GetOperatingSystem")]
		private static string GetOperatingSystem(); // 0x000000018221DD00-0x000000018221DDC0
		[FreeFunction("systeminfo::GetOperatingSystemFamily")]
		private static OperatingSystemFamily GetOperatingSystemFamily(); // 0x000000018221DC90-0x000000018221DCC0
		[FreeFunction("systeminfo::GetDeviceUniqueIdentifier")]
		private static string GetDeviceUniqueIdentifier(); // 0x000000018221D810-0x000000018221D8D0
		[FreeFunction("systeminfo::GetDeviceModel")]
		private static string GetDeviceModel(); // 0x000000018221D6E0-0x000000018221D7A0
		[FreeFunction("systeminfo::GetDeviceType")]
		private static DeviceType GetDeviceType(); // 0x000000018221D7A0-0x000000018221D7D0
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceName")]
		private static string GetGraphicsDeviceName(); // 0x000000018221D940-0x000000018221DA00
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceVendor")]
		private static string GetGraphicsDeviceVendor(); // 0x000000018221DAA0-0x000000018221DB60
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceVendorID")]
		private static int GetGraphicsDeviceVendorID(); // 0x000000018221DA30-0x000000018221DA60
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceType")]
		private static GraphicsDeviceType GetGraphicsDeviceType(); // 0x000000018221DA00-0x000000018221DA30
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsUVStartsAtTop")]
		private static bool GetGraphicsUVStartsAtTop(); // 0x000000018221DBD0-0x000000018221DC00
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsShaderLevel")]
		private static int GetGraphicsShaderLevel(); // 0x000000018221DBA0-0x000000018221DBD0
		[FreeFunction("ScriptingGraphicsCaps::GetFoveatedRenderingCaps")]
		private static FoveatedRenderingCaps GetFoveatedRenderingCaps(); // 0x000000018221D8D0-0x000000018221D900
		[FreeFunction("ScriptingGraphicsCaps::HasHiddenSurfaceRemovalOnGPU")]
		private static bool HasHiddenSurfaceRemovalOnGPU(); // 0x000000018221DE80-0x000000018221DEB0
		[FreeFunction("ScriptingGraphicsCaps::SupportsShadows")]
		private static bool SupportsShadows(); // 0x000000018221E450-0x000000018221E480
		[FreeFunction("ScriptingGraphicsCaps::GetCopyTextureSupport")]
		private static CopyTextureSupport GetCopyTextureSupport(); // 0x000000018221D670-0x000000018221D6A0
		[FreeFunction("ScriptingGraphicsCaps::SupportsComputeShaders")]
		private static bool SupportsComputeShaders(); // 0x000000018221E050-0x000000018221E080
		[FreeFunction("ScriptingGraphicsCaps::SupportsRenderTargetArrayIndexFromVertexShader")]
		private static bool SupportsRenderTargetArrayIndexFromVertexShader(); // 0x000000018221E320-0x000000018221E350
		[FreeFunction("ScriptingGraphicsCaps::SupportsInstancing")]
		private static bool SupportsInstancing(); // 0x000000018221E110-0x000000018221E140
		[FreeFunction("ScriptingGraphicsCaps::SupportedRenderTargetCount")]
		private static int SupportedRenderTargetCount(); // 0x000000018221DFF0-0x000000018221E020
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampledTextures")]
		private static int SupportsMultisampledTextures(); // 0x000000018221E290-0x000000018221E2C0
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampled2DArrayTextures")]
		private static bool SupportsMultisampled2DArrayTextures(); // 0x000000018221E200-0x000000018221E230
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampledBackBuffer")]
		private static bool SupportsMultisampledBackBuffer(); // 0x000000018221E230-0x000000018221E260
		[FreeFunction("ScriptingGraphicsCaps::SupportsMemorylessTextures")]
		private static bool SupportsMemorylessTextures(); // 0x000000018221E140-0x000000018221E170
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampleAutoResolve")]
		private static bool SupportsMultisampleAutoResolve(); // 0x000000018221E170-0x000000018221E1A0
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampledShaderResolve")]
		private static bool SupportsMultisampledShaderResolve(); // 0x000000018221E260-0x000000018221E290
		[FreeFunction("ScriptingGraphicsCaps::UsesReversedZBuffer")]
		private static bool UsesReversedZBuffer(); // 0x000000018221E5C0-0x000000018221E5F0
		[FreeFunction("ScriptingGraphicsCaps::HasRenderTexture")]
		private static bool HasRenderTextureNative(RenderTextureFormat format); // 0x000000018221DEB0-0x000000018221DEF0
		[FreeFunction("ScriptingGraphicsCaps::SupportsTextureFormat")]
		private static bool SupportsTextureFormatNative(TextureFormat format); // 0x000000018221E480-0x000000018221E4C0
		[FreeFunction("ScriptingGraphicsCaps::GetMaxTextureSize")]
		private static int GetMaxTextureSize(); // 0x000000018221DC60-0x000000018221DC90
		[FreeFunction("ScriptingGraphicsCaps::GetMaxRenderTextureSize")]
		private static int GetMaxRenderTextureSize(); // 0x000000018221DC30-0x000000018221DC60
		[FreeFunction("ScriptingGraphicsCaps::SupportsGPUFence")]
		private static bool SupportsGPUFence(); // 0x000000018221E0B0-0x000000018221E0E0
		[FreeFunction("ScriptingGraphicsCaps::SupportsRayTracing")]
		private static bool SupportsRayTracing(); // 0x000000018221E2F0-0x000000018221E320
		[FreeFunction("ScriptingGraphicsCaps::MaxGraphicsBufferSize")]
		private static long MaxGraphicsBufferSize(); // 0x000000018221DF90-0x000000018221DFC0
		[FreeFunction("ScriptingGraphicsCaps::IsFormatSupported")]
		public static bool IsFormatSupported(GraphicsFormat format, GraphicsFormatUsage usage); // 0x000000018221DEF0-0x000000018221DF30
		[FreeFunction("ScriptingGraphicsCaps::GetCompatibleFormat")]
		public static GraphicsFormat GetCompatibleFormat(GraphicsFormat format, GraphicsFormatUsage usage); // 0x000000018221D630-0x000000018221D670
		[FreeFunction("ScriptingGraphicsCaps::GetGraphicsFormat")]
		public static GraphicsFormat GetGraphicsFormat(DefaultFormat format); // 0x000000018221DB60-0x000000018221DBA0
		[FreeFunction("ScriptingGraphicsCaps::GetRenderTextureSupportedMSAASampleCount")]
		public static int GetRenderTextureSupportedMSAASampleCount(RenderTextureDescriptor desc); // 0x000000018221DE00-0x000000018221DE40
		[FreeFunction("ScriptingGraphicsCaps::GetTiledRenderTargetStorageSize")]
		public static int GetTiledRenderTargetStorageSize(GraphicsFormat format, int sampleCount); // 0x000000018221DE40-0x000000018221DE80
		[FreeFunction("ScriptingGraphicsCaps::GetHDRDisplaySupportFlags")]
		private static HDRDisplaySupportFlags GetHDRDisplaySupportFlags(); // 0x000000018221DC00-0x000000018221DC30
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultiview")]
		private static bool SupportsMultiview(); // 0x000000018221E2C0-0x000000018221E2F0
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampleResolveDepth")]
		private static bool SupportsMultisampleResolveDepth(); // 0x000000018221E1A0-0x000000018221E1D0
		[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampleResolveStencil")]
		private static bool SupportsMultisampleResolveStencil(); // 0x000000018221E1D0-0x000000018221E200
		[FreeFunction("ScriptingGraphicsCaps::SupportsIndirectArgumentsBuffer")]
		private static bool SupportsIndirectArgumentsBuffer(); // 0x000000018221E0E0-0x000000018221E110
		[FreeFunction("ScriptingGraphicsCaps::SupportsDepthAttachmentAsInputAttachment")]
		private static bool SupportsDepthAttachmentAsInputAttachment(); // 0x000000018221E080-0x000000018221E0B0
		[FreeFunction("ScriptingGraphicsCaps::MaxTiledPixelStorageSize")]
		private static int MaxTiledPixelStorageSize(); // 0x000000018221DFC0-0x000000018221DFF0
		[FreeFunction("ScriptingGraphicsCaps::SupportsBackbufferInMultipleRenderTargets")]
		private static bool SupportsBackbufferInMultipleRenderTargets(); // 0x000000018221E020-0x000000018221E050
		private static void GetOperatingSystem_Injected(); // 0x000000018221DCC0-0x000000018221DD00
		private static void GetDeviceUniqueIdentifier_Injected(); // 0x000000018221D7D0-0x000000018221D810
		private static void GetDeviceModel_Injected(); // 0x000000018221D6A0-0x000000018221D6E0
		private static void GetGraphicsDeviceName_Injected(); // 0x000000018221D900-0x000000018221D940
		private static void GetGraphicsDeviceVendor_Injected(); // 0x000000018221DA60-0x000000018221DAA0
		private static int GetRenderTextureSupportedMSAASampleCount_Injected(in RenderTextureDescriptor desc); // 0x000000018221DDC0-0x000000018221DE00
	}
}
