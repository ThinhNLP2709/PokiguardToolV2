/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	internal class ProbeVolumeDebug : IDebugData, ISerializedDebugDisplaySettings // TypeDefIndex: 5584
	{
		// Fields
		public bool drawProbes; // 0x10
		public bool drawBricks; // 0x11
		public bool drawCells; // 0x12
		public bool realtimeSubdivision; // 0x13
		public int subdivisionCellUpdatePerFrame; // 0x14
		public float subdivisionDelayInSeconds; // 0x18
		public DebugProbeShadingMode probeShading; // 0x1C
		public float probeSize; // 0x20
		public float subdivisionViewCullingDistance; // 0x24
		public float probeCullingDistance; // 0x28
		public int maxSubdivToVisualize; // 0x2C
		public int minSubdivToVisualize; // 0x30
		public float exposureCompensation; // 0x34
		public bool drawProbeSamplingDebug; // 0x38
		public float probeSamplingDebugSize; // 0x3C
		public bool debugWithSamplingNoise; // 0x40
		public uint samplingRenderingLayer; // 0x44
		public bool drawVirtualOffsetPush; // 0x48
		public float offsetSize; // 0x4C
		public bool freezeStreaming; // 0x50
		public bool displayCellStreamingScore; // 0x51
		public bool displayIndexFragmentation; // 0x52
		public int otherStateIndex; // 0x54
		public bool verboseStreamingLog; // 0x58
		public bool debugStreaming; // 0x59
		public bool autoDrawProbes; // 0x5A
		public bool isolationProbeDebug; // 0x5B
		public byte visibleLayers; // 0x5C
		public static Vector3 currentOffset; // 0x00
		internal static int s_ActiveAdjustmentVolumes; // 0x0C
	
		// Constructors
		public ProbeVolumeDebug(); // 0x0000000181E85700-0x0000000181E857C0
	
		// Methods
		private void Init(); // 0x0000000181E85690-0x0000000181E85700
		public Action GetReset(); // 0x0000000181E85620-0x0000000181E85690
		[CompilerGenerated]
		private void _GetReset_b__32_0(); // 0x0000000181E85690-0x0000000181E85700
	}
}
