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
	public struct BatchCullingOutputDrawCommands // TypeDefIndex: 8355
	{
		// Fields
		public unsafe BatchDrawCommand* drawCommands; // 0x00
		public unsafe BatchDrawCommandIndirect* indirectDrawCommands; // 0x08
		public unsafe BatchDrawCommandProcedural* proceduralDrawCommands; // 0x10
		public unsafe BatchDrawCommandProceduralIndirect* proceduralIndirectDrawCommands; // 0x18
		public unsafe int* visibleInstances; // 0x20
		public unsafe BatchDrawRange* drawRanges; // 0x28
		public unsafe float* instanceSortingPositions; // 0x30
		public unsafe EntityId* drawCommandPickingEntityIds; // 0x38
		public int drawCommandCount; // 0x40
		public int indirectDrawCommandCount; // 0x44
		public int proceduralDrawCommandCount; // 0x48
		public int proceduralIndirectDrawCommandCount; // 0x4C
		public int visibleInstanceCount; // 0x50
		public int drawRangeCount; // 0x54
		public int instanceSortingPositionFloatCount; // 0x58
	}
}
