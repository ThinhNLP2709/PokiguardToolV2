/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct BatchDrawCommandProcedural // TypeDefIndex: 8351
	{
		// Fields
		public BatchDrawCommandFlags flags; // 0x00
		public BatchID batchID; // 0x04
		public BatchMaterialID materialID; // 0x08
		public ushort splitVisibilityMask; // 0x0C
		public ushort lightmapIndex; // 0x0E
		public int sortingPosition; // 0x10
		public uint visibleOffset; // 0x14
		public uint visibleCount; // 0x18
		public MeshTopology topology; // 0x1C
		public GraphicsBufferHandle indexBufferHandle; // 0x20
		public uint baseVertex; // 0x24
		public uint indexOffsetBytes; // 0x28
		public uint elementCount; // 0x2C
	}
}
