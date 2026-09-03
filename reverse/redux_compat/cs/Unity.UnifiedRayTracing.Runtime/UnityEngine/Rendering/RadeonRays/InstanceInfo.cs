/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal struct InstanceInfo // TypeDefIndex: 14257
	{
		// Fields
		public int blasOffset; // 0x00
		public int instanceMask; // 0x04
		public int vertexOffset; // 0x08
		public int indexOffset; // 0x0C
		public uint disableTriangleCulling; // 0x10
		public uint invertTriangleCulling; // 0x14
		public uint userInstanceID; // 0x18
		public uint isOpaque_isProcedural; // 0x1C
		public Transform worldToLocalTransform; // 0x20
		public Transform localToWorldTransform; // 0x50
	}
}
