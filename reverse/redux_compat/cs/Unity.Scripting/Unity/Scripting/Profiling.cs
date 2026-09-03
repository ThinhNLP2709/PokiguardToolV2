/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting
{
	internal static class Profiling // TypeDefIndex: 14823
	{
		// Fields
		private static ProfilerCallbacks profilerCallbacks; // 0x00
	
		// Nested types
		[IsReadOnly]
		public struct ProfilerCallbacks // TypeDefIndex: 14824
		{
			// Fields
			public readonly IntPtr profiler_marker_create; // 0x00
			public readonly IntPtr profiler_marker_get_static; // 0x08
			public readonly IntPtr profiler_marker_begin_with_string; // 0x10
			public readonly IntPtr profiler_marker_begin; // 0x18
			public readonly IntPtr profiler_marker_end; // 0x20
			public readonly IntPtr profiler_domain_reload_phase; // 0x28
	
			// Constructors
			public ProfilerCallbacks(IntPtr profiler_marker_create, IntPtr profiler_marker_get_static, IntPtr profiler_marker_begin_with_string, IntPtr profiler_marker_begin, IntPtr profiler_marker_end, IntPtr profiler_domain_reload_phase = default); // 0x00000001820681C0-0x00000001820681F0
		}
	
		internal enum DomainReloadPhase // TypeDefIndex: 14825
		{
			StartPhase1 = 1,
			EndPhase1 = 2,
			StartPhase2 = 3,
			EndPhase2 = 4
		}
	
		[IsReadOnly]
		public struct DomainReloadPhaseScope : IDisposable // TypeDefIndex: 14826
		{
			// Fields
			private readonly DomainReloadPhase _endPhase; // 0x00
	
			// Constructors
			internal DomainReloadPhaseScope(DomainReloadPhase startPhase, DomainReloadPhase endPhase); // 0x0000000182064B80-0x0000000182064BD0
	
			// Methods
			public void Dispose(); // 0x0000000182064B30-0x0000000182064B80
		}
	
		[IsReadOnly]
		[Nullable(0)]
		[NullableContext(1)]
		public struct ProfilerMarker // TypeDefIndex: 14827
		{
			// Fields
			internal readonly IntPtr ptr; // 0x00
	
			// Nested types
			[IsReadOnly]
			[NullableContext(0)]
			public struct ProfilerAuto : IDisposable // TypeDefIndex: 14828
			{
				// Fields
				private readonly IntPtr ptr; // 0x00
	
				// Constructors
				internal ProfilerAuto(IntPtr markerPtr); // 0x0000000182068160-0x00000001820681C0
				[NullableContext(1)]
				internal ProfilerAuto(IntPtr markerPtr, string param); // 0x00000001820680E0-0x0000000182068160
	
				// Methods
				public void Dispose(); // 0x0000000182068090-0x00000001820680E0
			}
	
			// Constructors
			internal ProfilerMarker(IntPtr existingPtr); // 0x0000000180CBE820-0x0000000180CBE830
			public ProfilerMarker(string name); // 0x00000001820683D0-0x0000000182068460
	
			// Methods
			public void Begin(); // 0x00000001820682C0-0x0000000182068310
			public void Begin(string param); // 0x0000000182068310-0x0000000182068380
			public void End(); // 0x0000000182068380-0x00000001820683D0
			public ProfilerAuto Auto(); // 0x00000001820681F0-0x0000000182068240
			public ProfilerAuto Auto(string param); // 0x0000000182068240-0x00000001820682C0
		}
	
		// Methods
		public static void Initialize(ProfilerCallbacks callbacks); // 0x00000001820685D0-0x0000000182068620
		public static DomainReloadPhaseScope DomainReloadPhase1(); // 0x0000000182068460-0x00000001820684B0
		public static DomainReloadPhaseScope DomainReloadPhase2(); // 0x00000001820684B0-0x0000000182068500
		private static void EmitPhase(DomainReloadPhase phase); // 0x0000000182068500-0x0000000182068550
		[NullableContext(1)]
		public static ProfilerMarker GetStaticMarker(string name); // 0x0000000182068550-0x00000001820685D0
	}
}
