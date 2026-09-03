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
	public class UniversalLightData : ContextItem // TypeDefIndex: 9478
	{
		// Fields
		public int mainLightIndex; // 0x10
		public int additionalLightsCount; // 0x14
		public int maxPerObjectAdditionalLightsCount; // 0x18
		public NativeArray<VisibleLight> visibleLights; // 0x20
		public bool shadeAdditionalLightsPerVertex; // 0x30
		public bool supportsMixedLighting; // 0x31
		public bool reflectionProbeBoxProjection; // 0x32
		public bool reflectionProbeBlending; // 0x33
		public bool reflectionProbeAtlas; // 0x34
		public bool supportsLightLayers; // 0x35
		public bool supportsAdditionalLights; // 0x36
	
		// Constructors
		public UniversalLightData(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(); // 0x0000000181F9DC90-0x0000000181F9DCB0
	}
}
