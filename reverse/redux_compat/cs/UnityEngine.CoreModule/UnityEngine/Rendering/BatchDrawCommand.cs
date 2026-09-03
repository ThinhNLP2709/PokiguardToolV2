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
	public struct BatchDrawCommand // TypeDefIndex: 8349
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
		public BatchMeshID meshID; // 0x1C
		public ushort submeshIndex; // 0x20
		public ushort activeMeshLod; // 0x22
	}
}
