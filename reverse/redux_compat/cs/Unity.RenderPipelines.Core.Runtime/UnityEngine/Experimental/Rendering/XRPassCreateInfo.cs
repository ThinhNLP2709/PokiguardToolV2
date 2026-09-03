/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	public struct XRPassCreateInfo // TypeDefIndex: 5314
	{
		// Fields
		internal RenderTargetIdentifier renderTarget; // 0x00
		internal RenderTextureDescriptor renderTargetDesc; // 0x28
		internal RenderTargetIdentifier motionVectorRenderTarget; // 0x60
		internal RenderTextureDescriptor motionVectorRenderTargetDesc; // 0x88
		internal ScriptableCullingParameters cullingParameters; // 0xC0
		internal Material occlusionMeshMaterial; // 0x798
		internal float occlusionMeshScale; // 0x7A0
		internal int renderTargetScaledWidth; // 0x7A4
		internal int renderTargetScaledHeight; // 0x7A8
		internal IntPtr foveatedRenderingInfo; // 0x7B0
		internal int multipassId; // 0x7B8
		internal int cullingPassId; // 0x7BC
		internal bool copyDepth; // 0x7C0
		internal bool hasMotionVectorPass; // 0x7C1
		internal bool spaceWarpRightHandedNDC; // 0x7C2
		internal XRLayoutType xrLayoutType; // 0x7C4
		internal Vector4 uvScales; // 0x7C8
		internal Vector4 uvOffsets; // 0x7D8
		internal XRDisplaySubsystem.XRRenderPass xrSdkRenderPass; // 0x7E8
	}
}
