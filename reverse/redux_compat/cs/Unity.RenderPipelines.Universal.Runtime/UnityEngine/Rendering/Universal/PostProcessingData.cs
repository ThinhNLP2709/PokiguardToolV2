/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public struct PostProcessingData // TypeDefIndex: 9848
	{
		// Fields
		private ContextContainer frameData; // 0x00
	
		// Properties
		internal UniversalPostProcessingData universalPostProcessingData { get; } // 0x0000000181FF89A0-0x0000000181FF89F0 
		public ref ColorGradingMode gradingMode { get; } // 0x0000000181FF8860-0x0000000181FF88B0 
		public ref int lutSize { get; } // 0x0000000181FF88B0-0x0000000181FF8900 
		public ref bool useFastSRGBLinearConversion { get; } // 0x0000000181FF89F0-0x0000000181FF8A40 
		public ref bool supportScreenSpaceLensFlare { get; } // 0x0000000181FF8950-0x0000000181FF89A0 
		public ref bool supportDataDrivenLensFlare { get; } // 0x0000000181FF8900-0x0000000181FF8950 
	
		// Constructors
		internal PostProcessingData(ContextContainer frameData); // 0x0000000180E02C90-0x0000000180E02CA0
	}
}
