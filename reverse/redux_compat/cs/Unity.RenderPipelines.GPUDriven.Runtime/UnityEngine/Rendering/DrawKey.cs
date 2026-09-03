/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct DrawKey : IEquatable<DrawKey> // TypeDefIndex: 12834
	{
		// Fields
		public EntityId transparentInstanceID; // 0x00
		public BatchMeshID meshID; // 0x08
		public int submeshIndex; // 0x0C
		public int activeMeshLod; // 0x10
		public BatchMaterialID materialID; // 0x14
		public BatchDrawCommandFlags flags; // 0x18
		public GPUArchetypeHandle archetype; // 0x1C
		public RangeKey range; // 0x20
		public int lightmapIndex; // 0x3C
	
		// Methods
		public bool Equals(DrawKey other); // 0x0000000181F206C0-0x0000000181F20870
		public override int GetHashCode(); // 0x0000000181F20870-0x0000000181F20970
	}
}
