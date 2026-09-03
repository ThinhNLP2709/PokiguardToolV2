/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class BottleneckHistory // TypeDefIndex: 5501
	{
		// Fields
		private List<PerformanceBottleneck> m_Bottlenecks; // 0x10
		internal BottleneckHistogram Histogram; // 0x18
	
		// Constructors
		public BottleneckHistory(int initialCapacity); // 0x0000000181E38920-0x0000000181E389D0
	
		// Methods
		internal void DiscardOldSamples(int historySize); // 0x0000000181E388A0-0x0000000181E38920
		internal void AddBottleneckFromAveragedSample(FrameTimeSample frameHistorySampleAverage); // 0x0000000181E38510-0x0000000181E38650
		internal void ComputeHistogram(); // 0x0000000181E38680-0x0000000181E387D0
		private static PerformanceBottleneck DetermineBottleneck(FrameTimeSample s); // 0x0000000181E387D0-0x0000000181E388A0
		internal void Clear(); // 0x0000000181E38650-0x0000000181E38680
	}
}
