/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance.Provider
{
	public interface IDevicePerformanceLevelControl // TypeDefIndex: 14215
	{
		// Properties
		int MaxCpuPerformanceLevel { get; }
		int MaxGpuPerformanceLevel { get; }
	
		// Methods
		bool SetPerformanceLevel(ref int cpu, ref int gpu);
		bool EnableCpuBoost();
		bool EnableGpuBoost();
	}
}
