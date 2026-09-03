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
	internal class CpuTimeProvider // TypeDefIndex: 14137
	{
		// Fields
		private FrameTiming[] m_FrameTimings; // 0x10
	
		// Properties
		public float CpuFrameTime { get; } // 0x0000000182142690-0x0000000182142760 
	
		// Constructors
		public CpuTimeProvider(); // 0x0000000182142630-0x0000000182142690
	
		// Methods
		protected virtual uint GetLatestTimings(); // 0x0000000182142600-0x0000000182142620
		public void Measure(); // 0x0000000182142620-0x0000000182142630
	}
}
