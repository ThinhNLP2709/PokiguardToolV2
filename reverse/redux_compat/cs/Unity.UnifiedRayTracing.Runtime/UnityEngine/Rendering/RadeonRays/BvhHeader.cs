/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal struct BvhHeader // TypeDefIndex: 14255
	{
		// Fields
		public uint internalNodeCount; // 0x00
		public uint leafNodeCount; // 0x04
		public uint root; // 0x08
		public uint unused; // 0x0C
		public float3 globalAabbMin; // 0x10
		public float3 globalAabbMax; // 0x1C
		public uint3 unused3; // 0x28
		public uint3 unused4; // 0x34
	}
}
