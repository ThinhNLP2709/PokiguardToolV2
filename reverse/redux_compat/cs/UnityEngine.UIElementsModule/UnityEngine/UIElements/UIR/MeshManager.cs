/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal abstract class MeshManager : IDisposable // TypeDefIndex: 5100
	{
		// Fields
		protected readonly LinkedPool<MeshHandle> m_MeshHandles; // 0x10
		protected uint m_NextPageVertexCount; // 0x18
		protected readonly uint m_LargeMeshVertexCount; // 0x1C
		protected readonly float m_IndexToVertexCountRatio; // 0x20
		protected readonly bool m_PagesGpuDataIsMapped; // 0x24
		protected readonly uint m_ExtrasStride; // 0x28
		protected uint m_FrameIndex; // 0x2C
		protected Page m_FirstPage; // 0x30
		protected GpuUpdater m_VertexUpdater; // 0x38
		protected GpuUpdater m_IndexUpdater; // 0x40
		private static readonly ProfilerMarker s_MarkerAllocate; // 0x00
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x48
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5101
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<MeshHandle> __9__16_0; // 0x08
			public static Action<MeshHandle> __9__16_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182435330-0x00000001824353A0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal MeshHandle _.ctor_b__16_0(); // 0x00000001824352E0-0x0000000182435330
			internal void _.ctor_b__16_1(MeshHandle mh); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		protected MeshManager(uint initialVertexCapacity, uint initialIndexCapacity, uint extrasStride, GpuUpdaterType gpuUpdaterType); // 0x0000000182422EE0-0x00000001824232C0
		static MeshManager(); // 0x0000000182422E70-0x0000000182422EE0
	
		// Methods
		public abstract void Update(MeshHandle mesh, uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset);
		public virtual void Free(MeshHandle mesh); // 0x0000000182422A50-0x0000000182422AC0
		public virtual void AdvanceFrame(); // 0x0000000182421CC0-0x0000000182421E30
		public void OnFrameRenderingBegin(); // 0x0000000182422AC0-0x0000000182422BF0
		public MeshHandle Allocate(uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset); // 0x00000001824228D0-0x0000000182422970
		protected void Allocate(MeshHandle meshHandle, uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, bool shortLived); // 0x0000000182421E30-0x00000001824228D0
		protected bool TryAllocFromPage(Page page, uint vertexCount, uint indexCount, ref Alloc va, ref Alloc ia, bool shortLived); // 0x0000000182422D20-0x0000000182422E70
		private void PruneUnusedPages(); // 0x0000000182422BF0-0x0000000182422D20
		public void Dispose(); // 0x00000001824229E0-0x0000000182422A50
		protected virtual void Dispose(bool disposing); // 0x0000000182422970-0x00000001824229E0
	}
}
