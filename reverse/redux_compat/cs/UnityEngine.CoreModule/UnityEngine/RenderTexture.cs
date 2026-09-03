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
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("RenderTexture", PersistentTypeId = 84)]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/RenderTexture.h")]
	[NativeHeader("Runtime/Graphics/RenderBufferManager.h")]
	[NativeHeader("Runtime/Camera/Camera.h")]
	[UsedByNativeCode]
	public class RenderTexture : Texture // TypeDefIndex: 7636
	{
		// Properties
		public override int width { get; set; } // 0x00000001821D41B0-0x00000001821D4210 0x00000001821D4790-0x00000001821D47F0
		public override int height { get; set; } // 0x00000001821D3DF0-0x00000001821D3E50 0x00000001821D44F0-0x00000001821D4550
		public override TextureDimension dimension { get; set; } // 0x00000001821D3B00-0x00000001821D3B60 0x00000001821D43A0-0x00000001821D4400
		public new GraphicsFormat graphicsFormat { get; set; } // 0x00000001821D3D50-0x00000001821D3DB0 0x00000001821D25B0-0x00000001821D2610
		[NativeProperty("MipMap")]
		public bool useMipMap { get; set; } // 0x00000001821D4070-0x00000001821D40D0 0x00000001821D4650-0x00000001821D46B0
		[NativeProperty("SRGBReadWrite")]
		public bool sRGB { get; } // 0x00000001821D3E90-0x00000001821D3EF0 
		public RenderTextureFormat format { get; } // 0x00000001821D3C00-0x00000001821D3D50 
		public GraphicsFormat depthStencilFormat { get; set; } // 0x00000001821D39C0-0x00000001821D3A20 0x00000001821D4300-0x00000001821D4360
		public bool autoGenerateMips { set; } // 0x00000001821D4260-0x00000001821D42C0
		public int volumeDepth { get; set; } // 0x00000001821D4110-0x00000001821D4170 0x00000001821D46F0-0x00000001821D4750
		public int antiAliasing { get; } // 0x00000001821D3780-0x00000001821D37E0 
		public bool bindTextureMS { get; } // 0x00000001821D3820-0x00000001821D3880 
		public bool enableRandomWrite { set; } // 0x00000001821D4450-0x00000001821D44B0
		public bool useDynamicScale { get; set; } // 0x00000001821D3FD0-0x00000001821D4030 0x00000001821D45A0-0x00000001821D4600
		public bool useDynamicScaleExplicit { get; } // 0x00000001821D3F30-0x00000001821D3F90 
		public bool enableShadingRate { get; } // 0x00000001821D3BA0-0x00000001821D3C00 
		public static RenderTexture active { get; set; } // 0x00000001821D0DD0-0x00000001821D0E30 0x00000001821D2530-0x00000001821D2570
		public RenderBuffer colorBuffer { get; } // 0x00000001821D3880-0x00000001821D3900 
		public RenderBuffer depthBuffer { get; } // 0x00000001821D3900-0x00000001821D3980 
		public RenderTextureDescriptor descriptor { get; } // 0x00000001821D3A20-0x00000001821D3AC0 
	
		// Constructors
		[RequiredByNativeCode]
		protected internal RenderTexture(); // 0x00000001821D35F0-0x00000001821D3670
		public RenderTexture(RenderTextureDescriptor desc); // 0x00000001821D2F50-0x00000001821D3070
		[ExcludeFromDocs]
		public RenderTexture(int width, int height, int depth, GraphicsFormat format); // 0x00000001821D2EB0-0x00000001821D2F50
		[ExcludeFromDocs]
		public RenderTexture(int width, int height, int depth, GraphicsFormat format, int mipCount); // 0x00000001821D32B0-0x00000001821D3510
		public RenderTexture(int width, int height, int depth, [DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite); // 0x00000001821D3510-0x00000001821D35F0
		[ExcludeFromDocs]
		public RenderTexture(int width, int height, int depth, RenderTextureFormat format); // 0x00000001821D3190-0x00000001821D32B0
		[ExcludeFromDocs]
		public RenderTexture(int width, int height, int depth); // 0x00000001821D3070-0x00000001821D3190
		[ExcludeFromDocs]
		public RenderTexture(int width, int height, int depth, RenderTextureFormat format, int mipCount); // 0x00000001821D3670-0x00000001821D3740
	
		// Methods
		[NativeName("GetColorFormat")]
		private GraphicsFormat GetColorFormat(bool suppressWarnings); // 0x00000001821D0F40-0x00000001821D0FA0
		[NativeName("SetColorFormat")]
		private void SetColorFormat(GraphicsFormat format); // 0x00000001821D25B0-0x00000001821D2610
		public void ApplyDynamicScale(); // 0x00000001821D0CA0-0x00000001821D0D00
		[FreeFunction("RenderTexture::GetActiveAsRenderTexture")]
		private static RenderTexture GetActive(); // 0x00000001821D0DD0-0x00000001821D0E30
		[FreeFunction("RenderTextureScripting::SetActive")]
		private static void SetActive(RenderTexture rt); // 0x00000001821D2530-0x00000001821D2570
		[FreeFunction(Name = "RenderTextureScripting::GetColorBuffer", HasExplicitThis = true)]
		private RenderBuffer GetColorBuffer(); // 0x00000001821D0E80-0x00000001821D0EF0
		[FreeFunction(Name = "RenderTextureScripting::GetDepthBuffer", HasExplicitThis = true)]
		private RenderBuffer GetDepthBuffer(); // 0x00000001821D1120-0x00000001821D1190
		private void SetMipMapCount(int count); // 0x00000001821D2650-0x00000001821D26B0
		internal void SetShadowSamplingMode(ShadowSamplingMode samplingMode); // 0x00000001821D2850-0x00000001821D28B0
		public bool Create(); // 0x00000001821D0D40-0x00000001821D0DA0
		public void Release(); // 0x00000001821D2490-0x00000001821D24F0
		internal void SetSRGBReadWrite(bool srgb); // 0x00000001821D27B0-0x00000001821D2810
		[FreeFunction("RenderTextureScripting::Create")]
		private static void Internal_Create([Writable] RenderTexture rt); // 0x00000001821D2390-0x00000001821D23D0
		[NativeName("SetRenderTextureDescFromScript")]
		private void SetRenderTextureDescriptor(RenderTextureDescriptor desc); // 0x00000001821D2700-0x00000001821D2760
		[NativeName("GetRenderTextureDesc")]
		private RenderTextureDescriptor GetDescriptor(); // 0x00000001821D1340-0x00000001821D13C0
		[FreeFunction("GetRenderBufferManager().GetTextures().GetTempBuffer")]
		private static RenderTexture GetTemporary_Internal(RenderTextureDescriptor desc); // 0x00000001821D15D0-0x00000001821D1630
		[FreeFunction("GetRenderBufferManager().GetTextures().ReleaseTempBuffer")]
		public static void ReleaseTemporary(RenderTexture temp); // 0x00000001821D2410-0x00000001821D2450
		private void Initialize(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite readWrite, int mipCount); // 0x00000001821D2120-0x00000001821D2390
		internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, GraphicsFormat colorFormat); // 0x00000001821D12E0-0x00000001821D12F0
		internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, RenderTextureFormat format, bool disableFallback = false /* Metadata: 0x0069D3EE */); // 0x00000001821D11A0-0x00000001821D11E0
		internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, ShadowSamplingMode shadowSamplingMode); // 0x00000001821D1190-0x00000001821D11A0
		internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, bool requestedShadowMap); // 0x00000001821D11E0-0x00000001821D12E0
		private static void ValidateRenderTextureDesc(ref RenderTextureDescriptor desc); // 0x00000001821D28B0-0x00000001821D2E20
		internal static ShadowSamplingMode GetShadowSamplingModeForFormat(RenderTextureFormat format); // 0x00000001821D13C0-0x00000001821D13D0
		internal static void WarnAboutFallbackTo16BitsDepth(RenderTextureFormat format); // 0x00000001821D2E20-0x00000001821D2EB0
		internal static GraphicsFormat GetCompatibleFormat(RenderTextureFormat renderTextureFormat, RenderTextureReadWrite readWrite); // 0x00000001821D0FA0-0x00000001821D10D0
		public static RenderTexture GetTemporary(RenderTextureDescriptor desc); // 0x00000001821D1E70-0x00000001821D1F00
		private static RenderTexture GetTemporaryImpl(int width, int height, GraphicsFormat depthStencilFormat, GraphicsFormat colorFormat, int antiAliasing = 1 /* Metadata: 0x0069D3EF */, RenderTextureMemoryless memorylessMode = RenderTextureMemoryless.None /* Metadata: 0x0069D3F0 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x0069D3F1 */, bool useDynamicScale = false /* Metadata: 0x0069D3F2 */, ShadowSamplingMode shadowSamplingMode = ShadowSamplingMode.None /* Metadata: 0x0069D3F3 */); // 0x00000001821D13D0-0x00000001821D1590
		public static RenderTexture GetTemporary(int width, int height, [DefaultValue("0")] int depthBuffer, [DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite, [DefaultValue("1")] int antiAliasing, [DefaultValue("RenderTextureMemoryless.None")] RenderTextureMemoryless memorylessMode, [DefaultValue("VRTextureUsage.None")] VRTextureUsage vrUsage, [DefaultValue("false")] bool useDynamicScale); // 0x00000001821D1F00-0x00000001821D2120
		[ExcludeFromDocs]
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage); // 0x00000001821D1840-0x00000001821D1A50
		[ExcludeFromDocs]
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode); // 0x00000001821D1630-0x00000001821D1840
		[ExcludeFromDocs]
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing); // 0x00000001821D1A50-0x00000001821D1C60
		[ExcludeFromDocs]
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite); // 0x00000001821D1C60-0x00000001821D1E70
		private static int get_width_Injected(IntPtr _unity_self); // 0x00000001821D4170-0x00000001821D41B0
		private static void set_width_Injected(IntPtr _unity_self, int value); // 0x00000001821D4750-0x00000001821D4790
		private static int get_height_Injected(IntPtr _unity_self); // 0x00000001821D3DB0-0x00000001821D3DF0
		private static void set_height_Injected(IntPtr _unity_self, int value); // 0x00000001821D44B0-0x00000001821D44F0
		private static TextureDimension get_dimension_Injected(IntPtr _unity_self); // 0x00000001821D3AC0-0x00000001821D3B00
		private static void set_dimension_Injected(IntPtr _unity_self, TextureDimension value); // 0x00000001821D4360-0x00000001821D43A0
		private static GraphicsFormat GetColorFormat_Injected(IntPtr _unity_self, bool suppressWarnings); // 0x00000001821D0EF0-0x00000001821D0F40
		private static void SetColorFormat_Injected(IntPtr _unity_self, GraphicsFormat format); // 0x00000001821D2570-0x00000001821D25B0
		private static bool get_useMipMap_Injected(IntPtr _unity_self); // 0x00000001821D4030-0x00000001821D4070
		private static void set_useMipMap_Injected(IntPtr _unity_self, bool value); // 0x00000001821D4600-0x00000001821D4650
		private static bool get_sRGB_Injected(IntPtr _unity_self); // 0x00000001821D3E50-0x00000001821D3E90
		private static GraphicsFormat get_depthStencilFormat_Injected(IntPtr _unity_self); // 0x00000001821D3980-0x00000001821D39C0
		private static void set_depthStencilFormat_Injected(IntPtr _unity_self, GraphicsFormat value); // 0x00000001821D42C0-0x00000001821D4300
		private static void set_autoGenerateMips_Injected(IntPtr _unity_self, bool value); // 0x00000001821D4210-0x00000001821D4260
		private static int get_volumeDepth_Injected(IntPtr _unity_self); // 0x00000001821D40D0-0x00000001821D4110
		private static void set_volumeDepth_Injected(IntPtr _unity_self, int value); // 0x00000001821D46B0-0x00000001821D46F0
		private static int get_antiAliasing_Injected(IntPtr _unity_self); // 0x00000001821D3740-0x00000001821D3780
		private static bool get_bindTextureMS_Injected(IntPtr _unity_self); // 0x00000001821D37E0-0x00000001821D3820
		private static void set_enableRandomWrite_Injected(IntPtr _unity_self, bool value); // 0x00000001821D4400-0x00000001821D4450
		private static bool get_useDynamicScale_Injected(IntPtr _unity_self); // 0x00000001821D3F90-0x00000001821D3FD0
		private static void set_useDynamicScale_Injected(IntPtr _unity_self, bool value); // 0x00000001821D4550-0x00000001821D45A0
		private static bool get_useDynamicScaleExplicit_Injected(IntPtr _unity_self); // 0x00000001821D3EF0-0x00000001821D3F30
		private static bool get_enableShadingRate_Injected(IntPtr _unity_self); // 0x00000001821D3B60-0x00000001821D3BA0
		private static void ApplyDynamicScale_Injected(IntPtr _unity_self); // 0x00000001821D0C60-0x00000001821D0CA0
		private static IntPtr GetActive_Injected(); // 0x00000001821D0DA0-0x00000001821D0DD0
		private static void SetActive_Injected(IntPtr rt); // 0x00000001821D24F0-0x00000001821D2530
		private static void GetColorBuffer_Injected(IntPtr _unity_self, ); // 0x00000001821D0E30-0x00000001821D0E80
		private static void GetDepthBuffer_Injected(IntPtr _unity_self, ); // 0x00000001821D10D0-0x00000001821D1120
		private static void SetMipMapCount_Injected(IntPtr _unity_self, int count); // 0x00000001821D2610-0x00000001821D2650
		private static void SetShadowSamplingMode_Injected(IntPtr _unity_self, ShadowSamplingMode samplingMode); // 0x00000001821D2810-0x00000001821D2850
		private static bool Create_Injected(IntPtr _unity_self); // 0x00000001821D0D00-0x00000001821D0D40
		private static void Release_Injected(IntPtr _unity_self); // 0x00000001821D2450-0x00000001821D2490
		private static void SetSRGBReadWrite_Injected(IntPtr _unity_self, bool srgb); // 0x00000001821D2760-0x00000001821D27B0
		private static void SetRenderTextureDescriptor_Injected(IntPtr _unity_self, in RenderTextureDescriptor desc); // 0x00000001821D26B0-0x00000001821D2700
		private static void GetDescriptor_Injected(IntPtr _unity_self, ); // 0x00000001821D12F0-0x00000001821D1340
		private static IntPtr GetTemporary_Internal_Injected(in RenderTextureDescriptor desc); // 0x00000001821D1590-0x00000001821D15D0
		private static void ReleaseTemporary_Injected(IntPtr temp); // 0x00000001821D23D0-0x00000001821D2410
	}
}
