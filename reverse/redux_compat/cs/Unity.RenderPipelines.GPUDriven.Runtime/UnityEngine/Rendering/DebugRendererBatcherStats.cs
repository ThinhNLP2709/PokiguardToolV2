/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class DebugRendererBatcherStats : IDisposable // TypeDefIndex: 12919
	{
		// Fields
		public NativeList<InstanceCullerViewStats> instanceCullerStats; // 0x10
		public NativeList<InstanceOcclusionEventStats> instanceOcclusionEventStats; // 0x18
		public NativeList<DebugOccluderStats> occluderStats; // 0x20
		public int cameraGPUOcclusionCulled; // 0x28
	
		// Constructors
		public DebugRendererBatcherStats(); // 0x0000000181F33940-0x0000000181F339E0
	
		// Methods
		public void FinalizeInstanceCullerViewStats(); // 0x0000000181F335C0-0x0000000181F33820
		private InstanceOcclusionEventStats GetLastInstanceOcclusionEventStatsForView(int viewIndex); // 0x0000000181F33820-0x0000000181F33940
		public void Dispose(); // 0x0000000181F33570-0x0000000181F335C0
	}
}
