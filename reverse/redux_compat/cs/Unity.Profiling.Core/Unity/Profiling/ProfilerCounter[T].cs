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
	public struct ProfilerCounter<T> // TypeDefIndex: 15924
		where T : struct
	{
		// Constructors
		public ProfilerCounter(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit);
	
		// Methods
		[Conditional("ENABLE_PROFILER")]
		public void Sample(T value);
	}
}
