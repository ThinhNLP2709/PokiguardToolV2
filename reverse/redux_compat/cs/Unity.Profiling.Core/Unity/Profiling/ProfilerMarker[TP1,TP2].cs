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
	public struct ProfilerMarker<TP1, TP2> // TypeDefIndex: 15928
		where TP1 : struct
		where TP2 : struct
	{
		// Nested types
		[IsReadOnly]
		public struct AutoScope : IDisposable // TypeDefIndex: 15929
		{
			// Constructors
			internal AutoScope(ProfilerMarker<TP1, TP2> marker, TP1 p1, TP2 p2);
	
			// Methods
			public void Dispose();
		}
	
		// Constructors
		public ProfilerMarker(string name, string param1Name, string param2Name);
		public ProfilerMarker(ProfilerCategory category, string name, string param1Name, string param2Name);
	
		// Methods
		[Conditional("ENABLE_PROFILER")]
		public void Begin(TP1 p1, TP2 p2);
		[Conditional("ENABLE_PROFILER")]
		public void End();
		public AutoScope Auto(TP1 p1, TP2 p2);
	}
}
