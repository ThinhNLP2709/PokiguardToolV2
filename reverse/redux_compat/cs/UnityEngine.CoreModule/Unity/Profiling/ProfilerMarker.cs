/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling.LowLevel;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Profiling
{
	[IgnoredByDeepProfiler]
	[UsedByNativeCode]
	public struct ProfilerMarker // TypeDefIndex: 7353
	{
		// Fields
		[NonSerialized]
		[NativeDisableUnsafePtrRestriction]
		internal readonly IntPtr m_Ptr; // 0x00
	
		// Properties
		public IntPtr Handle { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Nested types
		[IgnoredByDeepProfiler]
		[UsedByNativeCode]
		public struct AutoScope : IDisposable // TypeDefIndex: 7354
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal readonly IntPtr m_Ptr; // 0x00
	
			// Constructors
			internal AutoScope(IntPtr markerPtr); // 0x000000018217A460-0x000000018217A4B0
			internal AutoScope(IntPtr markerPtr, UnityEngine.Object contextUnityObject); // 0x000000018217A400-0x000000018217A460
	
			// Methods
			public void Dispose(); // 0x000000018217A3B0-0x000000018217A400
		}
	
		// Constructors
		public ProfilerMarker(string name); // 0x0000000182191740-0x0000000182191770
		public ProfilerMarker(ProfilerCategory category, string name); // 0x0000000182191710-0x0000000182191740
		public ProfilerMarker(ProfilerCategory category, string name, MarkerFlags flags); // 0x00000001821916D0-0x0000000182191710
	
		// Methods
		[Pure]
		public AutoScope Auto(); // 0x0000000182191630-0x0000000182191670
		[Pure]
		public AutoScope Auto(UnityEngine.Object contextUnityObject); // 0x0000000182191670-0x00000001821916D0
	}
}
