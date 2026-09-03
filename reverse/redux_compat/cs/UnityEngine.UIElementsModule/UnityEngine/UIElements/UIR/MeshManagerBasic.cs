/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	internal sealed class MeshManagerBasic : MeshManager // TypeDefIndex: 5102
	{
		// Constructors
		public MeshManagerBasic(uint initialVertexCapacity, uint initialIndexCapacity, uint extrasStride, GpuUpdaterType gpuUpdaterType); // 0x00000001824200B0-0x0000000182420130
	
		// Methods
		public override void Update(MeshHandle mesh, uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset); // 0x000000018241FF20-0x00000001824200B0
		public override void Free(MeshHandle mesh); // 0x000000018241FE30-0x000000018241FF20
		protected override void Dispose(bool disposing); // 0x000000018241FD80-0x000000018241FE30
	}
}
