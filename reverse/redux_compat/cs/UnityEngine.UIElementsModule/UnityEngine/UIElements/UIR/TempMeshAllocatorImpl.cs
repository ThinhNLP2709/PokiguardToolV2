/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class TempMeshAllocatorImpl : IDisposable // TypeDefIndex: 5152
	{
		// Fields
		private GCHandle m_GCHandle; // 0x10
		private ThreadData[] m_ThreadData; // 0x18
		private TempAllocator m_TempAllocator; // 0x20
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x28
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
	
		// Nested types
		private struct ThreadData // TypeDefIndex: 5153
		{
			// Fields
			public List<IntPtr> allocations; // 0x00
		}
	
		// Constructors
		public TempMeshAllocatorImpl(); // 0x0000000182447EC0-0x0000000182448190
	
		// Methods
		public void CreateNativeHandle(out TempMeshAllocator allocator); // 0x0000000182447C90-0x0000000182447CA0
		private NativeSlice<T> Allocate<T>(int count, int alignment)
			where T : struct;
		public void AllocateTempMesh(int vertexCount, int indexCount, out NativeSlice<Vertex> vertices, out NativeSlice<ushort> indices); // 0x00000001824478C0-0x0000000182447B00
		public void Clear(); // 0x0000000182447B00-0x0000000182447C90
		public void Dispose(); // 0x0000000182447CA0-0x0000000182447DD0
		protected void Dispose(bool disposing); // 0x0000000182447DD0-0x0000000182447EC0
	}
}
