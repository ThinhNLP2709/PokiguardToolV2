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
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[NativeConditional("ENABLE_XR")]
	[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.h")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	[UsedByNativeCode]
	public class XRDisplaySubsystem : IntegratedSubsystem<XRDisplaySubsystemDescriptor> // TypeDefIndex: 15356
	{
		// Fields
		[CompilerGenerated]
		private Action<bool> displayFocusChanged; // 0x20
		private HDROutputSettings m_HDROutputSettings; // 0x28
		[NoAutoStaticsCleanup]
		private static readonly List<XRDisplaySubsystem> s_DisplaySubsystems; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly XRDisplaySubsystemDefault s_Default; // 0x08
	
		// Properties
		public float appliedViewportScale { get; } // 0x00000001825D7490-0x00000001825D7520 
		public float scaleOfAllRenderTargets { set; } // 0x00000001825D7890-0x00000001825D7930
		public float globalDynamicScale { get; } // 0x00000001825D7560-0x00000001825D75F0 
		public float zNear { set; } // 0x00000001825D7B50-0x00000001825D7BF0
		public float zFar { set; } // 0x00000001825D7A60-0x00000001825D7B00
		public bool sRGB { set; } // 0x00000001825D77A0-0x00000001825D7840
		public TextureLayout textureLayout { set; } // 0x00000001825D7970-0x00000001825D7A10
		public bool disableLegacyRenderer { set; } // 0x00000001825D76B0-0x00000001825D7750
		public HDROutputSettings hdrOutputSettings { get; } // 0x00000001825D75F0-0x00000001825D7660 
	
		// Nested types
		[Flags]
		public enum TextureLayout // TypeDefIndex: 15357
		{
			Texture2DArray = 1,
			SingleTexture2D = 2,
			SeparateTexture2Ds = 4
		}
	
		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRRenderParameter // TypeDefIndex: 15358
		{
			// Fields
			public Matrix4x4 view; // 0x00
			public Matrix4x4 projection; // 0x40
			public Rect viewport; // 0x80
			public Mesh occlusionMesh; // 0x90
			public Mesh visibleMesh; // 0x98
			public int textureArraySlice; // 0xA0
			public Matrix4x4 previousView; // 0xA4
			public bool isPreviousViewValid; // 0xE4
		}
	
		[NativeHeader("Runtime/Graphics/RenderTextureDesc.h")]
		[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRRenderPass // TypeDefIndex: 15359
		{
			// Fields
			private IntPtr displaySubsystemInstance; // 0x00
			public int renderPassIndex; // 0x08
			public RenderTargetIdentifier renderTarget; // 0x10
			public RenderTextureDescriptor renderTargetDesc; // 0x38
			public int renderTargetScaledWidth; // 0x6C
			public int renderTargetScaledHeight; // 0x70
			public bool hasMotionVectorPass; // 0x74
			public RenderTargetIdentifier motionVectorRenderTarget; // 0x78
			public RenderTextureDescriptor motionVectorRenderTargetDesc; // 0xA0
			public bool shouldFillOutDepth; // 0xD4
			public bool spaceWarpRightHandedNDC; // 0xD5
			public int cullingPassIndex; // 0xD8
			public IntPtr foveatedRenderingInfo; // 0xE0
	
			// Methods
			[NativeConditional("ENABLE_XR")]
			[NativeMethod(Name = "XRRenderPassScriptApi::GetRenderParameter", IsFreeFunction = true, HasExplicitThis = true, ThrowsException = true)]
			public void GetRenderParameter(Camera camera, int renderParameterIndex, out XRRenderParameter renderParameter); // 0x00000001825D8000-0x00000001825D8070
			[NativeConditional("ENABLE_XR")]
			[NativeMethod(Name = "XRRenderPassScriptApi::GetRenderParameterCount", IsFreeFunction = true, HasExplicitThis = true)]
			public int GetRenderParameterCount(); // 0x00000001825D7F50-0x00000001825D7F90
			private static void GetRenderParameter_Injected(ref XRRenderPass _unity_self, IntPtr camera, int renderParameterIndex, out XRRenderParameter renderParameter); // 0x00000001825D7F90-0x00000001825D8000
		}
	
		[NativeHeader("Runtime/Graphics/RenderTexture.h")]
		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRBlitParams // TypeDefIndex: 15360
		{
			// Fields
			public RenderTexture srcTex; // 0x00
			public int srcTexArraySlice; // 0x08
			public Rect srcRect; // 0x0C
			public Rect destRect; // 0x1C
			public IntPtr foveatedRenderingInfo; // 0x30
			public bool srcHdrEncoded; // 0x38
			public ColorGamut srcHdrColorGamut; // 0x3C
			public int srcHdrMaxLuminance; // 0x40
		}
	
		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRMirrorViewBlitDesc // TypeDefIndex: 15361
		{
			// Fields
			private IntPtr displaySubsystemInstance; // 0x00
			public bool nativeBlitAvailable; // 0x08
			public bool nativeBlitInvalidStates; // 0x09
			public int blitParamsCount; // 0x0C
	
			// Methods
			[NativeConditional("ENABLE_XR")]
			[NativeMethod(Name = "XRMirrorViewBlitDescScriptApi::GetBlitParameter", IsFreeFunction = true, HasExplicitThis = true)]
			public void GetBlitParameter(int blitParameterIndex, out XRBlitParams blitParameter); // 0x00000001825D7EF0-0x00000001825D7F40
		}
	
		internal static class BindingsMarshaller // TypeDefIndex: 15362
		{
			// Methods
			public static IntPtr ConvertToNative(XRDisplaySubsystem xrDisplaySubsystem); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public XRDisplaySubsystem(); // 0x0000000180A6DF30-0x0000000180A6DF40
		static XRDisplaySubsystem(); // 0x00000001825D72F0-0x00000001825D7450
	
		// Methods
		[RequiredByNativeCode]
		private void InvokeDisplayFocusChanged(bool focus); // 0x0000000182165B40-0x0000000182165B60
		public int ScaledTextureWidth(RenderTexture renderTexture); // 0x00000001825D7070-0x00000001825D7130
		public int ScaledTextureHeight(RenderTexture renderTexture); // 0x00000001825D6F60-0x00000001825D7020
		public void SetMSAALevel(int level); // 0x00000001825D7170-0x00000001825D7210
		public int GetRenderPassCount(); // 0x00000001825D6920-0x00000001825D69B0
		public void GetRenderPass(int renderPassIndex, out XRRenderPass renderPass); // 0x00000001825D69B0-0x00000001825D6AB0
		[NativeMethod("TryGetRenderPass")]
		private bool Internal_TryGetRenderPass(int renderPassIndex, out XRRenderPass renderPass); // 0x00000001825D6E60-0x00000001825D6F10
		public void EndRecordingIfLateLatched(Camera camera); // 0x00000001825D63F0-0x00000001825D6540
		[NativeMethod("TryEndRecordingIfLateLatched")]
		private bool Internal_TryEndRecordingIfLateLatched(Camera camera); // 0x00000001825D6C10-0x00000001825D6CD0
		public void BeginRecordingIfLateLatched(Camera camera); // 0x00000001825D62A0-0x00000001825D63F0
		[NativeMethod("TryBeginRecordingIfLateLatched")]
		private bool Internal_TryBeginRecordingIfLateLatched(Camera camera); // 0x00000001825D6B00-0x00000001825D6BC0
		public void GetCullingParameters(Camera camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters); // 0x00000001825D6540-0x00000001825D66D0
		[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
		[NativeMethod("TryGetCullingParams")]
		private bool Internal_TryGetCullingParams(Camera camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters); // 0x00000001825D6D40-0x00000001825D6E10
		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "GetPreferredMirrorViewBlitMode", IsThreadSafe = false)]
		public int GetPreferredMirrorBlitMode(); // 0x00000001825D6850-0x00000001825D68E0
		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "SetPreferredMirrorViewBlitMode", IsThreadSafe = false)]
		public void SetPreferredMirrorBlitMode(int blitMode); // 0x00000001825D7250-0x00000001825D72F0
		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "QueryMirrorViewBlitDesc", IsThreadSafe = false)]
		public bool GetMirrorViewBlitDesc(RenderTexture mirrorRt, out XRMirrorViewBlitDesc outDesc, int mode); // 0x00000001825D6740-0x00000001825D6810
		[NativeConditional("ENABLE_XR")]
		[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
		[NativeMethod(Name = "AddGraphicsThreadMirrorViewBlit", IsThreadSafe = false)]
		public bool AddGraphicsThreadMirrorViewBlit(CommandBuffer cmd, bool allowGraphicsStateInvalidate, int mode); // 0x00000001825D61D0-0x00000001825D62A0
		private static float get_appliedViewportScale_Injected(IntPtr _unity_self); // 0x00000001825D7450-0x00000001825D7490
		private static void set_scaleOfAllRenderTargets_Injected(IntPtr _unity_self, float value); // 0x00000001825D7840-0x00000001825D7890
		private static float get_globalDynamicScale_Injected(IntPtr _unity_self); // 0x00000001825D7520-0x00000001825D7560
		private static void set_zNear_Injected(IntPtr _unity_self, float value); // 0x00000001825D7B00-0x00000001825D7B50
		private static void set_zFar_Injected(IntPtr _unity_self, float value); // 0x00000001825D7A10-0x00000001825D7A60
		private static void set_sRGB_Injected(IntPtr _unity_self, bool value); // 0x00000001825D7750-0x00000001825D77A0
		private static void set_textureLayout_Injected(IntPtr _unity_self, TextureLayout value); // 0x00000001825D7930-0x00000001825D7970
		private static int ScaledTextureWidth_Injected(IntPtr _unity_self, IntPtr renderTexture); // 0x00000001825D7020-0x00000001825D7070
		private static int ScaledTextureHeight_Injected(IntPtr _unity_self, IntPtr renderTexture); // 0x00000001825D6F10-0x00000001825D6F60
		private static void SetMSAALevel_Injected(IntPtr _unity_self, int level); // 0x00000001825D7130-0x00000001825D7170
		private static void set_disableLegacyRenderer_Injected(IntPtr _unity_self, bool value); // 0x00000001825D7660-0x00000001825D76B0
		private static int GetRenderPassCount_Injected(IntPtr _unity_self); // 0x00000001825D68E0-0x00000001825D6920
		private static bool Internal_TryGetRenderPass_Injected(IntPtr _unity_self, int renderPassIndex, out XRRenderPass renderPass); // 0x00000001825D6E10-0x00000001825D6E60
		private static bool Internal_TryEndRecordingIfLateLatched_Injected(IntPtr _unity_self, IntPtr camera); // 0x00000001825D6BC0-0x00000001825D6C10
		private static bool Internal_TryBeginRecordingIfLateLatched_Injected(IntPtr _unity_self, IntPtr camera); // 0x00000001825D6AB0-0x00000001825D6B00
		private static bool Internal_TryGetCullingParams_Injected(IntPtr _unity_self, IntPtr camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters); // 0x00000001825D6CD0-0x00000001825D6D40
		private static int GetPreferredMirrorBlitMode_Injected(IntPtr _unity_self); // 0x00000001825D6810-0x00000001825D6850
		private static void SetPreferredMirrorBlitMode_Injected(IntPtr _unity_self, int blitMode); // 0x00000001825D7210-0x00000001825D7250
		private static bool GetMirrorViewBlitDesc_Injected(IntPtr _unity_self, IntPtr mirrorRt, out XRMirrorViewBlitDesc outDesc, int mode); // 0x00000001825D66D0-0x00000001825D6740
		private static bool AddGraphicsThreadMirrorViewBlit_Injected(IntPtr _unity_self, IntPtr cmd, bool allowGraphicsStateInvalidate, int mode); // 0x00000001825D6160-0x00000001825D61D0
	}
}
