/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal sealed class MeshManagerTracked : MeshManager // TypeDefIndex: 5103
	{
		// Fields
		private List<List<AllocToFree>> m_DeferredFrees; // 0x50
		private List<List<AllocToUpdate>> m_Updates; // 0x58
		private uint m_NextUpdateID; // 0x60
	
		// Nested types
		internal struct AllocToUpdate // TypeDefIndex: 5104
		{
			// Fields
			public uint id; // 0x00
			public uint allocTime; // 0x04
			public MeshHandle meshHandle; // 0x08
			public Alloc permAllocVerts; // 0x10
			public Alloc permAllocIndices; // 0x28
			public Page permPage; // 0x40
			public bool copyBackIndices; // 0x48
		}
	
		private struct AllocToFree // TypeDefIndex: 5105
		{
			// Fields
			public Alloc alloc; // 0x00
			public Page page; // 0x18
			public bool vertices; // 0x20
		}
	
		// Constructors
		public MeshManagerTracked(uint initialVertexCapacity, uint initialIndexCapacity, uint extrasStride); // 0x0000000182421A30-0x0000000182421CC0
	
		// Methods
		public override void Update(MeshHandle mesh, uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset); // 0x00000001824217D0-0x0000000182421A30
		private void SetCopyBackFlags(MeshHandle mesh, bool copyBackIndices); // 0x00000001824210A0-0x0000000182421190
		internal List<AllocToUpdate> ActiveUpdatesForMeshHandle(MeshHandle mesh); // 0x0000000182420130-0x0000000182420160
		private void UpdateAfterGPUUsedData(MeshHandle mesh, uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset, bool copyBackIndices); // 0x0000000182421190-0x00000001824217D0
		public override void Free(MeshHandle mesh); // 0x0000000182420A80-0x00000001824210A0
		public override void AdvanceFrame(); // 0x0000000182420160-0x00000001824209C0
		protected override void Dispose(bool disposing); // 0x00000001824209C0-0x0000000182420A80
	}
}
