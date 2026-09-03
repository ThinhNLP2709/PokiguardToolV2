/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal static class ShadowCulling // TypeDefIndex: 9783
	{
		// Fields
		private static readonly ProfilingSampler computeShadowCasterCullingInfosMarker; // 0x00
	
		// Constructors
		static ShadowCulling(); // 0x0000000181FE67C0-0x0000000181FE6850
	
		// Methods
		public static NativeArray<URPLightShadowCullingInfos> CullShadowCasters(ref ScriptableRenderContext context, UniversalShadowData shadowData, ref AdditionalLightsShadowAtlasLayout shadowAtlasLayout, ref CullingResults cullResults); // 0x0000000181FE6680-0x0000000181FE67A0
		private static void ComputeShadowCasterCullingInfos(UniversalShadowData shadowData, ref AdditionalLightsShadowAtlasLayout shadowAtlasLayout, ref CullingResults cullingResults, out ShadowCastersCullingInfos shadowCullingInfos, out NativeArray<URPLightShadowCullingInfos> urpVisibleLightsShadowCullingInfos); // 0x0000000181FE5740-0x0000000181FE6680
		private static BatchCullingProjectionType GetCullingProjectionType(LightType type); // 0x0000000181FE67A0-0x0000000181FE67C0
	}
}
