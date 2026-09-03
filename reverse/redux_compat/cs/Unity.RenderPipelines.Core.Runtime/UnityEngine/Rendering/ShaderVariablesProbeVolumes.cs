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
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\Lighting\\ProbeVolume\\ShaderVariablesProbeVolumes.cs", needAccessors = false, generateCBuffer = true, constantRegister = 6)]
	internal struct ShaderVariablesProbeVolumes // TypeDefIndex: 5630
	{
		// Fields
		public Vector4 _Offset_LayerCount; // 0x00
		public Vector4 _MinLoadedCellInEntries_IndirectionEntryDim; // 0x10
		public Vector4 _MaxLoadedCellInEntries_RcpIndirectionEntryDim; // 0x20
		public Vector4 _PoolDim_MinBrickSize; // 0x30
		public Vector4 _RcpPoolDim_XY; // 0x40
		public Vector4 _MinEntryPos_Noise; // 0x50
		public uint4 _EntryCount_X_XY_LeakReduction; // 0x60
		public Vector4 _Biases_NormalizationClamp; // 0x70
		public Vector4 _FrameIndex_Weights; // 0x80
		public uint4 _ProbeVolumeLayerMask; // 0x90
	}
}
