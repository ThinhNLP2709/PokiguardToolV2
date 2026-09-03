/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	public struct MeshInstanceDesc // TypeDefIndex: 14312
	{
		// Fields
		public Mesh mesh; // 0x00
		public int subMeshIndex; // 0x08
		public Matrix4x4 localToWorldMatrix; // 0x0C
		public uint mask; // 0x4C
		public uint instanceID; // 0x50
		public bool enableTriangleCulling; // 0x54
		public bool frontTriangleCounterClockwise; // 0x55
		public bool opaqueGeometry; // 0x56
	
		// Constructors
		public MeshInstanceDesc(Mesh mesh, int subMeshIndex = 0 /* Metadata: 0x006A9636 */); // 0x0000000182126BF0-0x0000000182126C60
	}
}
