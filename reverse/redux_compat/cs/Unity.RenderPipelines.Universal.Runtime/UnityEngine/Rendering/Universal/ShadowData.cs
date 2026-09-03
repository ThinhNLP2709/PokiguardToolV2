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
	public struct ShadowData // TypeDefIndex: 9843
	{
		// Fields
		private ContextContainer frameData; // 0x00
	
		// Properties
		internal UniversalShadowData universalShadowData { get; } // 0x0000000181FFAE10-0x0000000181FFAE60 
		public ref bool supportsMainLightShadows { get; } // 0x0000000181FFAD70-0x0000000181FFADC0 
		internal ref bool mainLightShadowsEnabled { get; } // 0x0000000181FFABE0-0x0000000181FFAC30 
		public ref int mainLightShadowmapWidth { get; } // 0x0000000181FFAB90-0x0000000181FFABE0 
		public ref int mainLightShadowmapHeight { get; } // 0x0000000181FFAB40-0x0000000181FFAB90 
		public ref int mainLightShadowCascadesCount { get; } // 0x0000000181FFAA50-0x0000000181FFAAA0 
		public ref Vector3 mainLightShadowCascadesSplit { get; } // 0x0000000181FFAAA0-0x0000000181FFAAF0 
		public ref float mainLightShadowCascadeBorder { get; } // 0x0000000181FFAA00-0x0000000181FFAA50 
		public ref bool supportsAdditionalLightShadows { get; } // 0x0000000181FFAD20-0x0000000181FFAD70 
		internal ref bool additionalLightShadowsEnabled { get; } // 0x0000000181FFA780-0x0000000181FFA7D0 
		public ref int additionalLightsShadowmapWidth { get; } // 0x0000000181FFA820-0x0000000181FFA870 
		public ref int additionalLightsShadowmapHeight { get; } // 0x0000000181FFA7D0-0x0000000181FFA820 
		public ref bool supportsSoftShadows { get; } // 0x0000000181FFADC0-0x0000000181FFAE10 
		public ref int shadowmapDepthBufferBits { get; } // 0x0000000181FFACD0-0x0000000181FFAD20 
		public ref List<Vector4> bias { get; } // 0x0000000181FFA870-0x0000000181FFA8C0 
		public ref List<int> resolution { get; } // 0x0000000181FFAC30-0x0000000181FFAC80 
		internal ref bool isKeywordAdditionalLightShadowsEnabled { get; } // 0x0000000181FFA8C0-0x0000000181FFA910 
		internal ref bool isKeywordSoftShadowsEnabled { get; } // 0x0000000181FFA910-0x0000000181FFA960 
		internal ref int mainLightShadowResolution { get; } // 0x0000000181FFAAF0-0x0000000181FFAB40 
		internal ref int mainLightRenderTargetWidth { get; } // 0x0000000181FFA9B0-0x0000000181FFAA00 
		internal ref int mainLightRenderTargetHeight { get; } // 0x0000000181FFA960-0x0000000181FFA9B0 
		internal ref NativeArray<URPLightShadowCullingInfos> visibleLightsShadowCullingInfos { get; } // 0x0000000181FFAE60-0x0000000181FFAEB0 
		internal ref AdditionalLightsShadowAtlasLayout shadowAtlasLayout { get; } // 0x0000000181FFAC80-0x0000000181FFACD0 
	
		// Constructors
		internal ShadowData(ContextContainer frameData); // 0x0000000180E02C90-0x0000000180E02CA0
	}
}
