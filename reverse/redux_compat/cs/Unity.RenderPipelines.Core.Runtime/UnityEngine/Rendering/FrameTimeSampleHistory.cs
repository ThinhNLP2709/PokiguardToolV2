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
	internal class FrameTimeSampleHistory // TypeDefIndex: 5503
	{
		// Fields
		private List<FrameTimeSample> m_Samples; // 0x10
		internal FrameTimeSample SampleAverage; // 0x18
		internal FrameTimeSample SampleMin; // 0x30
		internal FrameTimeSample SampleMax; // 0x48
		private static readonly Func<float, float, float> s_SampleValueAdd; // 0x00
		private static readonly Func<float, float, float> s_SampleValueMin; // 0x08
		private static readonly Func<float, float, float> s_SampleValueMax; // 0x10
		private static readonly Func<float, float, float> s_SampleValueCountValid; // 0x18
		private static readonly Func<float, float, float> s_SampleValueEnsureValid; // 0x20
		private static readonly Func<float, float, float> s_SampleValueDivide; // 0x28
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5504
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000181E714D0-0x0000000181E71540
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _.cctor_b__15_0(float value, float other); // 0x0000000181E712A0-0x0000000181E712B0
			internal float _.cctor_b__15_1(float value, float other); // 0x0000000181E712B0-0x0000000181E712C0
			internal float _.cctor_b__15_2(float value, float other); // 0x0000000181E712C0-0x0000000181E712D0
			internal float _.cctor_b__15_3(float value, float other); // 0x0000000181E712D0-0x0000000181E712F0
			internal float _.cctor_b__15_4(float value, float other); // 0x0000000181E712F0-0x0000000181E71300
			internal float _.cctor_b__15_5(float value, float other); // 0x0000000181E71300-0x0000000181E71310
		}
	
		// Constructors
		public FrameTimeSampleHistory(int initialCapacity); // 0x0000000181E4AA20-0x0000000181E4AAD0
		static FrameTimeSampleHistory(); // 0x0000000181E4A730-0x0000000181E4AA20
	
		// Methods
		internal void Add(FrameTimeSample sample); // 0x0000000181E49BC0-0x0000000181E49C80
		internal void ComputeAggregateValues(); // 0x0000000181E49CB0-0x0000000181E4A5C0
		internal void DiscardOldSamples(int sampleHistorySize); // 0x0000000181E4A5C0-0x0000000181E4A640
		internal void Clear(); // 0x0000000181E49C80-0x0000000181E49CB0
		[CompilerGenerated]
		internal static void _ComputeAggregateValues_g__ForEachSampleMember_12_0(ref FrameTimeSample aggregate, FrameTimeSample sample, Func<float, float, float> func); // 0x0000000181E4A640-0x0000000181E4A730
	}
}
