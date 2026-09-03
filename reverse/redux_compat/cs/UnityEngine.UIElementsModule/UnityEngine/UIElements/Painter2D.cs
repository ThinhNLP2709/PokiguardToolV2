/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class Painter2D : IDisposable // TypeDefIndex: 4333
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		private MeshGenerationContext m_Ctx; // 0x10
		internal DetachedAllocator m_DetachedAllocator; // 0x18
		internal SafeHandleAccess m_Handle; // 0x20
		private FillGradient m_CachedFillGradient; // 0x28
		private Texture2D m_CachedFillTexture; // 0x60
		private FillGradient m_CachedStrokeFillGradient; // 0x68
		private List<float> m_CachedDashPattern; // 0xA0
		private List<Painter2DJobData> m_JobSnapshots; // 0xA8
		private List<VectorImage> m_VectorImageToRelease; // 0xB0
		private NativeArray<Painter2DJobData> m_JobParameters; // 0xB8
		private bool m_Disposed; // 0xC8
		[CompilerGenerated]
		private static bool _isPainterActive_k__BackingField; // 0x10
		private static readonly ProfilerMarker s_StrokeMarker; // 0x18
		private static readonly ProfilerMarker s_FillMarker; // 0x20
		private static readonly ProfilerMarker s_ClipMarker; // 0x28
		private MeshGenerationCallback m_OnMeshGenerationDelegate; // 0xD0
	
		// Properties
		[NoAutoStaticsCleanup]
		internal static bool isPainterActive { [CompilerGenerated] set; } // 0x00000001824D8650-0x00000001824D86B0
	
		// Nested types
		private struct Painter2DJobData // TypeDefIndex: 4334
		{
			// Fields
			public UnsafeMeshGenerationNode node; // 0x00
			public int snapshotIndex; // 0x08
			public IntPtr vectorImagePtr; // 0x10
			public IntPtr texturePtr; // 0x18
			public int userData; // 0x20
		}
	
		private struct Painter2DJob : IJobParallelFor // TypeDefIndex: 4335
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public IntPtr painterHandle; // 0x00
			[ReadOnly]
			public TempMeshAllocator allocator; // 0x08
			[ReadOnly]
			public NativeSlice<Painter2DJobData> jobParameters; // 0x10
	
			// Methods
			public void Execute(int i); // 0x00000001824D7660-0x00000001824D7CC0
		}
	
		// Constructors
		internal Painter2D(MeshGenerationContext ctx); // 0x00000001824D84A0-0x00000001824D8650
		static Painter2D(); // 0x00000001824D8360-0x00000001824D84A0
	
		// Methods
		internal void Reset(); // 0x00000001824D7FB0-0x00000001824D8060
		public void Dispose(); // 0x00000001824D7EF0-0x00000001824D7F50
		private void Dispose(bool disposing); // 0x00000001824D7CC0-0x00000001824D7EF0
		internal void ScheduleJobs(MeshGenerationContext mgc); // 0x00000001824D8060-0x00000001824D8360
		private void OnMeshGeneration(MeshGenerationContext ctx, object data); // 0x00000001824D7F50-0x00000001824D7FB0
	}
}
