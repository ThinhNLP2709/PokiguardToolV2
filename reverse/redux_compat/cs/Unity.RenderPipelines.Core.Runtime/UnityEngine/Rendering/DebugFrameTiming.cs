/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DebugFrameTiming // TypeDefIndex: 5440
	{
		// Fields
		private const string k_FpsFormatString = "{0:F1}"; // Metadata: 0x006614CF
		private const string k_MsFormatString = "{0:F2}ms"; // Metadata: 0x006614D6
		private const float k_RefreshRate = 0.2f; // Metadata: 0x006614DF
		internal FrameTimeSampleHistory m_FrameHistory; // 0x10
		internal BottleneckHistory m_BottleneckHistory; // 0x18
		[CompilerGenerated]
		private int _bottleneckHistorySize_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _sampleHistorySize_k__BackingField; // 0x24
		private FrameTiming[] m_Timing; // 0x28
		private FrameTimeSample m_Sample; // 0x30
	
		// Properties
		public int bottleneckHistorySize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public int sampleHistorySize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
	
		// Constructors
		public DebugFrameTiming(); // 0x0000000181E40F40-0x0000000181E41130
	
		// Methods
		public void UpdateFrameTiming(); // 0x0000000181E40960-0x0000000181E40F40
		public void RegisterDebugUI(List<DebugUI.Widget> list); // 0x0000000181E3E8B0-0x0000000181E40390
		internal void Reset(); // 0x0000000181E40390-0x0000000181E403E0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_0(); // 0x0000000181E403E0-0x0000000181E40420
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_1(); // 0x0000000181E406A0-0x0000000181E406E0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_2(); // 0x0000000181E40760-0x0000000181E407A0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_3(); // 0x0000000181E407A0-0x0000000181E407E0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_4(); // 0x0000000181E407E0-0x0000000181E40820
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_5(); // 0x0000000181E40820-0x0000000181E40860
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_6(); // 0x0000000181E40860-0x0000000181E408A0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_7(); // 0x0000000181E408A0-0x0000000181E408E0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_8(); // 0x0000000181E408E0-0x0000000181E40920
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_9(); // 0x0000000181E40920-0x0000000181E40960
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_10(); // 0x0000000181E40420-0x0000000181E40460
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_11(); // 0x0000000181E40460-0x0000000181E404A0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_12(); // 0x0000000181E404A0-0x0000000181E404E0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_13(); // 0x0000000181E404E0-0x0000000181E40520
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_14(); // 0x0000000181E40520-0x0000000181E40560
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_15(); // 0x0000000181E40560-0x0000000181E405A0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_16(); // 0x0000000181E405A0-0x0000000181E405E0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_17(); // 0x0000000181E405E0-0x0000000181E40620
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_18(); // 0x0000000181E40620-0x0000000181E40660
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_19(); // 0x0000000181E40660-0x0000000181E406A0
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_20(); // 0x0000000181E406E0-0x0000000181E40720
		[CompilerGenerated]
		private object _RegisterDebugUI_b__17_21(); // 0x0000000181E40720-0x0000000181E40760
	}
}
