/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[IgnoredByDeepProfiler]
	public class ProfilingSampler : IDisposable // TypeDefIndex: 5515
	{
		// Fields
		[CompilerGenerated]
		private string _name_k__BackingField; // 0x10
	
		// Properties
		public string name { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool enableRecording { set; } // 0x00000001802E76C0-0x00000001802E76D0
		public float gpuElapsedTime { get; } // 0x00000001807185C0-0x00000001807185D0 
		public int gpuSampleCount { get; } // 0x00000001802E7860-0x00000001802E7870 
		public float cpuElapsedTime { get; } // 0x00000001807185C0-0x00000001807185D0 
		public int cpuSampleCount { get; } // 0x00000001802E7860-0x00000001802E7870 
		public float inlineCpuElapsedTime { get; } // 0x00000001807185C0-0x00000001807185D0 
		public int inlineCpuSampleCount { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public ProfilingSampler(string name); // 0x00000001803855F0-0x0000000180385630
		private ProfilingSampler(string name, MarkerFlags flags); // 0x00000001803855F0-0x0000000180385630
		private ProfilingSampler(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static ProfilingSampler Get<TEnum>(TEnum marker)
			where TEnum : Enum;
		public static ProfilingSampler Create(string name, MarkerFlags flags); // 0x00000001802E7860-0x00000001802E7870
		[Conditional("ENABLE_PROFILER")]
		public void Begin(CommandBuffer cmd); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_PROFILER")]
		public void Begin(CommandBuffer cmd, UnityEngine.Object contextObject); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_PROFILER")]
		public void End(CommandBuffer cmd); // 0x00000001802E76C0-0x00000001802E76D0
		internal bool IsValid(); // 0x00000001802E7840-0x00000001802E7850
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		private void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
