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
	internal struct TerrainDesc // TypeDefIndex: 14268
	{
		// Fields
		public Terrain terrain; // 0x00
		public Matrix4x4 localToWorldMatrix; // 0x08
		public uint mask; // 0x48
		public uint renderingLayerMask; // 0x4C
		public uint materialID; // 0x50
		public bool enableTriangleCulling; // 0x54
		public bool frontTriangleCounterClockwise; // 0x55
	
		// Constructors
		public TerrainDesc(Terrain terrain); // 0x0000000182123590-0x00000001821235F0
	}
}
