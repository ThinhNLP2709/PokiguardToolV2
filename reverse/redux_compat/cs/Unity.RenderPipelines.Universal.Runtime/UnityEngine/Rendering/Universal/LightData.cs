/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public struct LightData // TypeDefIndex: 9841
	{
		// Fields
		private ContextContainer frameData; // 0x00
	
		// Properties
		internal UniversalLightData universalLightData { get; } // 0x0000000181FF7B70-0x0000000181FF7BC0 
		public ref int mainLightIndex { get; } // 0x0000000181FF78A0-0x0000000181FF78F0 
		public ref int additionalLightsCount { get; } // 0x0000000181FF7850-0x0000000181FF78A0 
		public ref int maxPerObjectAdditionalLightsCount { get; } // 0x0000000181FF78F0-0x0000000181FF7940 
		public ref NativeArray<VisibleLight> visibleLights { get; } // 0x0000000181FF7BC0-0x0000000181FF7C10 
		public ref bool shadeAdditionalLightsPerVertex { get; } // 0x0000000181FF7A30-0x0000000181FF7A80 
		public ref bool supportsMixedLighting { get; } // 0x0000000181FF7B20-0x0000000181FF7B70 
		public ref bool reflectionProbeBoxProjection { get; } // 0x0000000181FF79E0-0x0000000181FF7A30 
		public ref bool reflectionProbeBlending { get; } // 0x0000000181FF7990-0x0000000181FF79E0 
		public ref bool reflectionProbeAtlas { get; } // 0x0000000181FF7940-0x0000000181FF7990 
		public ref bool supportsLightLayers { get; } // 0x0000000181FF7AD0-0x0000000181FF7B20 
		public ref bool supportsAdditionalLights { get; } // 0x0000000181FF7A80-0x0000000181FF7AD0 
	
		// Constructors
		internal LightData(ContextContainer frameData); // 0x0000000180E02C90-0x0000000180E02CA0
	}
}
