/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	public struct TempMeshAllocator // TypeDefIndex: 4338
	{
		// Fields
		private GCHandle m_Handle; // 0x00
	
		// Methods
		internal static void Create(GCHandle handle, out TempMeshAllocator allocator); // 0x00000001824D7560-0x00000001824D7570
		public void AllocateTempMesh(int vertexCount, int indexCount, out NativeSlice<Vertex> vertices, out NativeSlice<ushort> indices); // 0x00000001824DCF80-0x00000001824DD080
	}
}
