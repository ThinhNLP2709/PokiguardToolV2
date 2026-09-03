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
	public struct ProfilerMarker<TP1, TP2, TP3> // TypeDefIndex: 15930
		where TP1 : struct
		where TP2 : struct
		where TP3 : struct
	{
		// Nested types
		[IsReadOnly]
		public struct AutoScope : IDisposable // TypeDefIndex: 15931
		{
			// Constructors
			internal AutoScope(ProfilerMarker<TP1, TP2, TP3> marker, TP1 p1, TP2 p2, TP3 p3);
	
			// Methods
			public void Dispose();
		}
	
		// Constructors
		public ProfilerMarker(string name, string param1Name, string param2Name, string param3Name);
		public ProfilerMarker(ProfilerCategory category, string name, string param1Name, string param2Name, string param3Name);
	
		// Methods
		[Conditional("ENABLE_PROFILER")]
		public void Begin(TP1 p1, TP2 p2, TP3 p3);
		[Conditional("ENABLE_PROFILER")]
		public void End();
		public AutoScope Auto(TP1 p1, TP2 p2, TP3 p3);
	}
}
