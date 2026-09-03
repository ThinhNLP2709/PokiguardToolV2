/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	internal class ScreenSpaceAmbientOcclusionSettings // TypeDefIndex: 9725
	{
		// Fields
		[SerializeField]
		internal AOMethodOptions AOMethod; // 0x10
		[SerializeField]
		internal bool Downsample; // 0x14
		[SerializeField]
		internal bool AfterOpaque; // 0x15
		[SerializeField]
		internal DepthSource Source; // 0x18
		[SerializeField]
		internal NormalQuality NormalSamples; // 0x1C
		[Min(0f)]
		[SerializeField]
		internal float Intensity; // 0x20
		[SerializeField]
		internal float DirectLightingStrength; // 0x24
		[Min(0f)]
		[SerializeField]
		internal float Radius; // 0x28
		[SerializeField]
		internal AOSampleOption Samples; // 0x2C
		[SerializeField]
		internal BlurQualityOptions BlurQuality; // 0x30
		[Min(0f)]
		[SerializeField]
		internal float Falloff; // 0x34
		[SerializeField]
		internal int SampleCount; // 0x38
	
		// Nested types
		internal enum DepthSource // TypeDefIndex: 9726
		{
			Depth = 0,
			DepthNormals = 1
		}
	
		internal enum NormalQuality // TypeDefIndex: 9727
		{
			Low = 0,
			Medium = 1,
			High = 2
		}
	
		internal enum AOSampleOption // TypeDefIndex: 9728
		{
			High = 0,
			Medium = 1,
			Low = 2
		}
	
		internal enum AOMethodOptions // TypeDefIndex: 9729
		{
			BlueNoise = 0,
			InterleavedGradient = 1
		}
	
		internal enum BlurQualityOptions // TypeDefIndex: 9730
		{
			High = 0,
			Medium = 1,
			Low = 2
		}
	
		// Constructors
		public ScreenSpaceAmbientOcclusionSettings(); // 0x0000000181FCD2E0-0x0000000181FCD320
	}
}
