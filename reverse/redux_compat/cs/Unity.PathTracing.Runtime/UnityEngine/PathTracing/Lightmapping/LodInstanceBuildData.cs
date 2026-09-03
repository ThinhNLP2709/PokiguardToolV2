/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PathTracing.Core;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal struct LodInstanceBuildData // TypeDefIndex: 13622
	{
		// Fields
		public int LodMask; // 0x00
		public Mesh Mesh; // 0x08
		public Handle<MaterialPool.MaterialDescriptor>[] Materials; // 0x10
		public uint[] Masks; // 0x18
		public Matrix4x4 LocalToWorldMatrix; // 0x20
		public Bounds Bounds; // 0x60
		public bool IsStatic; // 0x78
		public RenderedGameObjectsFilter Filter; // 0x7C
	}
}
