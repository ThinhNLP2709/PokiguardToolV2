/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class UniversalShadowData : ContextItem // TypeDefIndex: 9484
	{
		// Fields
		public bool supportsMainLightShadows; // 0x10
		internal bool mainLightShadowsEnabled; // 0x11
		public int mainLightShadowmapWidth; // 0x14
		public int mainLightShadowmapHeight; // 0x18
		public int mainLightShadowCascadesCount; // 0x1C
		public Vector3 mainLightShadowCascadesSplit; // 0x20
		public float mainLightShadowCascadeBorder; // 0x2C
		public bool supportsAdditionalLightShadows; // 0x30
		internal bool additionalLightShadowsEnabled; // 0x31
		public int additionalLightsShadowmapWidth; // 0x34
		public int additionalLightsShadowmapHeight; // 0x38
		public bool supportsSoftShadows; // 0x3C
		public int shadowmapDepthBufferBits; // 0x40
		public List<Vector4> bias; // 0x48
		public List<int> resolution; // 0x50
		internal bool isKeywordAdditionalLightShadowsEnabled; // 0x58
		internal bool isKeywordSoftShadowsEnabled; // 0x59
		internal int mainLightShadowResolution; // 0x5C
		internal int mainLightRenderTargetWidth; // 0x60
		internal int mainLightRenderTargetHeight; // 0x64
		internal NativeArray<URPLightShadowCullingInfos> visibleLightsShadowCullingInfos; // 0x68
		internal AdditionalLightsShadowAtlasLayout shadowAtlasLayout; // 0x78
		internal GraphicsBuffer emptyAdditionalLightShadowsBuffer; // 0xB0
		internal bool useCachedShadowMap; // 0xB8
		internal bool supportShadowMapCaching; // 0xB9
	
		// Constructors
		public UniversalShadowData(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(); // 0x0000000181F9FC70-0x0000000181F9FD30
	}
}
