/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 80: Unity.Profiling.Core.dll - Assembly: Unity.Profiling.Core, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15921-15933

namespace Unity.Profiling
{
	[IsReadOnly]
	public struct ProfilerCounterValue<T> // TypeDefIndex: 15925
		where T : struct
	{
		// Properties
		public T Value { get; set; }
	
		// Constructors
		public ProfilerCounterValue(string name);
		public ProfilerCounterValue(string name, ProfilerMarkerDataUnit dataUnit);
		public ProfilerCounterValue(string name, ProfilerMarkerDataUnit dataUnit, ProfilerCounterOptions counterOptions);
		public ProfilerCounterValue(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit);
		public ProfilerCounterValue(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit, ProfilerCounterOptions counterOptions);
	
		// Methods
		[Conditional("ENABLE_PROFILER")]
		public void Sample();
	}
}
