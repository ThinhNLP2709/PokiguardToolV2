/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal struct ProbeVolumeShadingParameters // TypeDefIndex: 5588
	{
		// Fields
		public float normalBias; // 0x00
		public float viewBias; // 0x04
		public bool scaleBiasByMinDistanceBetweenProbes; // 0x08
		public float samplingNoise; // 0x0C
		public float weight; // 0x10
		public APVLeakReductionMode leakReductionMode; // 0x14
		public int frameIndexForNoise; // 0x18
		public float reflNormalizationLowerClamp; // 0x1C
		public float reflNormalizationUpperClamp; // 0x20
		public float skyOcclusionIntensity; // 0x24
		public bool skyOcclusionShadingDirection; // 0x28
		public int regionCount; // 0x2C
		public uint4 regionLayerMasks; // 0x30
		public Vector3 worldOffset; // 0x40
	}
}
