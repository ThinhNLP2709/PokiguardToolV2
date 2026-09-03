/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal class GpuTimeProvider // TypeDefIndex: 14139
	{
		// Fields
		private FrameTiming[] m_FrameTiming; // 0x10
	
		// Properties
		public float GpuFrameTime { get; } // 0x0000000182142CF0-0x0000000182142D60 
	
		// Constructors
		public GpuTimeProvider(); // 0x0000000182142C90-0x0000000182142CF0
	
		// Methods
		protected virtual uint GetLatestTimings(); // 0x0000000182142600-0x0000000182142620
		public void Measure(); // 0x0000000182142620-0x0000000182142630
	}
}
