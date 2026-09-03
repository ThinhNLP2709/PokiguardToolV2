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
	public struct ProfilerMarker<TP1> // TypeDefIndex: 15926
		where TP1 : struct
	{
		// Nested types
		[IsReadOnly]
		public struct AutoScope : IDisposable // TypeDefIndex: 15927
		{
			// Constructors
			internal AutoScope(ProfilerMarker<TP1> marker, TP1 p1);
	
			// Methods
			public void Dispose();
		}
	
		// Constructors
		public ProfilerMarker(string name, string param1Name);
		public ProfilerMarker(ProfilerCategory category, string name, string param1Name);
	
		// Methods
		[Conditional("ENABLE_PROFILER")]
		public void Begin(TP1 p1);
		[Conditional("ENABLE_PROFILER")]
		public void End();
		public AutoScope Auto(TP1 p1);
	}
}
