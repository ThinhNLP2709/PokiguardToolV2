/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	public class XRPass // TypeDefIndex: 5315
	{
		// Fields
		private readonly List<XRView> m_Views; // 0x10
		private readonly XROcclusionMesh m_OcclusionMesh; // 0x18
		private readonly XRVisibleMesh m_VisibleMesh; // 0x20
		[CompilerGenerated]
		private bool _copyDepth_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _hasMotionVectorPass_k__BackingField; // 0x29
		[CompilerGenerated]
		private bool _spaceWarpRightHandedNDC_k__BackingField; // 0x2A
		[CompilerGenerated]
		private XRLayoutType _xrLayoutType_k__BackingField; // 0x2C
		[CompilerGenerated]
		private Vector4 _uvScales_k__BackingField; // 0x30
		[CompilerGenerated]
		private Vector4 _uvOffsets_k__BackingField; // 0x40
		[CompilerGenerated]
		private int _multipassId_k__BackingField; // 0x50
		[CompilerGenerated]
		private int _cullingPassId_k__BackingField; // 0x54
		[CompilerGenerated]
		private int _renderTargetScaledWidth_k__BackingField; // 0x58
		[CompilerGenerated]
		private int _renderTargetScaledHeight_k__BackingField; // 0x5C
		[CompilerGenerated]
		private RenderTargetIdentifier _renderTarget_k__BackingField; // 0x60
		[CompilerGenerated]
		private RenderTextureDescriptor _renderTargetDesc_k__BackingField; // 0x88
		[CompilerGenerated]
		private RenderTargetIdentifier _motionVectorRenderTarget_k__BackingField; // 0xC0
		[CompilerGenerated]
		private RenderTextureDescriptor _motionVectorRenderTargetDesc_k__BackingField; // 0xE8
		[CompilerGenerated]
		private ScriptableCullingParameters _cullingParams_k__BackingField; // 0x120
		[CompilerGenerated]
		private IntPtr _foveatedRenderingInfo_k__BackingField; // 0x7F8
		[CompilerGenerated]
		private float _occlusionMeshScale_k__BackingField; // 0x800
	
		// Properties
		public bool enabled { get; } // 0x0000000180BDBE60-0x0000000180BDBE80 
		public bool supportsFoveatedRendering { get; } // 0x0000000181E303E0-0x0000000181E304A0 
		public bool copyDepth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public bool hasMotionVectorPass { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052D500-0x000000018052D510 0x000000018052D7C0-0x000000018052D7D0
		public bool spaceWarpRightHandedNDC { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052D510-0x000000018052D520 0x000000018052D7D0-0x000000018052D910
		public bool isFirstCameraPass { get; } // 0x0000000181E301E0-0x0000000181E301F0 
		public XRLayoutType xrLayoutType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public int totalCameraPasses { get; } // 0x0000000181E304A0-0x0000000181E304C0 
		public bool isLastCameraPass { get; } // 0x0000000181E302A0-0x0000000181E302D0 
		public bool isQuadViewInnerPass { get; } // 0x0000000181E302D0-0x0000000181E30300 
		public Vector4 uvScales { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E304D0-0x0000000181E304E0 0x0000000181E305E0-0x0000000181E305F0
		public Vector4 uvOffsets { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E304C0-0x0000000181E304D0 0x0000000181E305D0-0x0000000181E305E0
		public int multipassId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
		public int cullingPassId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181ADB600-0x0000000181ADB610
		public int renderTargetScaledWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		public int renderTargetScaledHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		public RenderTargetIdentifier renderTarget { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E303A0-0x0000000181E303C0 0x0000000181E305B0-0x0000000181E305D0
		public RenderTextureDescriptor renderTargetDesc { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E30370-0x0000000181E303A0 0x0000000181E30580-0x0000000181E305B0
		public RenderTargetIdentifier motionVectorRenderTarget { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E30330-0x0000000181E30360 0x0000000181E30540-0x0000000181E30570
		public RenderTextureDescriptor motionVectorRenderTargetDesc { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E30300-0x0000000181E30330 0x0000000181E30510-0x0000000181E30540
		public ScriptableCullingParameters cullingParams { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E2FCB0-0x0000000181E2FCE0 0x0000000181E304E0-0x0000000181E30500
		public int viewCount { get; } // 0x0000000180B5F570-0x0000000180B5F590 
		public bool singlePassEnabled { get; } // 0x0000000181E303C0-0x0000000181E303E0 
		public IntPtr foveatedRenderingInfo { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E2FCE0-0x0000000181E2FCF0 0x0000000181E30500-0x0000000181E30510
		public bool isHDRDisplayOutputActive { get; } // 0x0000000181E301F0-0x0000000181E302A0 
		public ColorGamut hdrDisplayOutputColorGamut { get; } // 0x0000000181E2FEE0-0x0000000181E2FF90 
		public HDROutputUtils.HDRDisplayInformation hdrDisplayOutputInformation { get; } // 0x0000000181E2FF90-0x0000000181E301E0 
		public float occlusionMeshScale { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E30360-0x0000000181E30370 0x0000000181E30570-0x0000000181E30580
		public bool hasValidOcclusionMesh { get; } // 0x0000000181E2FCF0-0x0000000181E2FD90 
		public bool hasValidVisibleMesh { get; } // 0x0000000181E2FD90-0x0000000181E2FEE0 
	
		// Constructors
		public XRPass(); // 0x0000000181E2FB70-0x0000000181E2FCB0
	
		// Methods
		public static XRPass CreateDefault(XRPassCreateInfo createInfo); // 0x0000000181E2E210-0x0000000181E2E6A0
		public virtual void Release(); // 0x0000000181E2F040-0x0000000181E2F150
		public Matrix4x4 GetProjMatrix(int viewIndex = 0 /* Metadata: 0x00661480 */); // 0x0000000181E2E930-0x0000000181E2EA20
		public Matrix4x4 GetViewMatrix(int viewIndex = 0 /* Metadata: 0x00661481 */); // 0x0000000181E2EAF0-0x0000000181E2EBE0
		public bool GetPrevViewValid(int viewIndex = 0 /* Metadata: 0x00661482 */); // 0x0000000181E2E860-0x0000000181E2E930
		public Matrix4x4 GetPrevViewMatrix(int viewIndex = 0 /* Metadata: 0x00661483 */); // 0x0000000181E2E770-0x0000000181E2E860
		public Rect GetViewport(int viewIndex = 0 /* Metadata: 0x00661484 */); // 0x0000000181E2EBE0-0x0000000181E2ECB0
		public Mesh GetOcclusionMesh(int viewIndex = 0 /* Metadata: 0x00661485 */); // 0x0000000181E2E6A0-0x0000000181E2E770
		public Mesh GetVisibleMesh(int viewIndex = 0 /* Metadata: 0x00661486 */); // 0x0000000181E2ECB0-0x0000000181E2ED80
		public int GetTextureArraySlice(int viewIndex = 0 /* Metadata: 0x00661487 */); // 0x0000000181E2EA20-0x0000000181E2EAF0
		public void StartSinglePass(CommandBuffer cmd); // 0x0000000181E2F820-0x0000000181E2FA20
		public void StartSinglePass(IRasterCommandBuffer cmd); // 0x0000000181E2F780-0x0000000181E2F820
		public void StopSinglePass(CommandBuffer cmd); // 0x0000000181E2FA40-0x0000000181E2FB30
		public void StopSinglePass(BaseCommandBuffer cmd); // 0x0000000181E2FA20-0x0000000181E2FA40
		public void RenderOcclusionMesh(CommandBuffer cmd, bool renderIntoTexture = false /* Metadata: 0x00661488 */); // 0x0000000181E2F6A0-0x0000000181E2F6E0
		public void RenderOcclusionMesh(RasterCommandBuffer cmd, bool renderIntoTexture = false /* Metadata: 0x00661489 */); // 0x0000000181E2F650-0x0000000181E2F6A0
		public void RenderVisibleMeshCustomMaterial(RasterCommandBuffer cmd, float occlusionMeshScale, Material material, MaterialPropertyBlock materialBlock, int shaderPass, bool renderIntoTexture = false /* Metadata: 0x0066148A */); // 0x0000000181E2F730-0x0000000181E2F780
		public void RenderVisibleMeshCustomMaterial(CommandBuffer cmd, float occlusionMeshScale, Material material, MaterialPropertyBlock materialBlock, int shaderPass = 0 /* Metadata: 0x0066148B */, bool renderIntoTexture = false /* Metadata: 0x0066148C */); // 0x0000000181E2F6E0-0x0000000181E2F730
		public void RenderDebugXRViewsFrustum(); // 0x0000000181E2F150-0x0000000181E2F650
		public Vector4 ApplyXRViewCenterOffset(Vector2 center); // 0x0000000181E2DCF0-0x0000000181E2E050
		internal void AssignView(int viewId, XRView xrView); // 0x0000000181E2E0D0-0x0000000181E2E210
		internal void AssignCullingParams(int cullingPassId, ScriptableCullingParameters cullingParams); // 0x0000000181E2E050-0x0000000181E2E0D0
		internal void UpdateCombinedOcclusionMesh(); // 0x0000000181E2FB30-0x0000000181E2FB70
		public void InitBase(XRPassCreateInfo createInfo); // 0x0000000181E2ED80-0x0000000181E2F040
		internal void AddView(XRView xrView); // 0x0000000181E2D9F0-0x0000000181E2DCF0
	}
}
