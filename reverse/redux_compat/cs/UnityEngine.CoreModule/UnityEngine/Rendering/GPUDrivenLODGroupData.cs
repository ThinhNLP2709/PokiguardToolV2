/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	internal struct GPUDrivenLODGroupData // TypeDefIndex: 8387
	{
		// Fields
		public NativeArray<EntityId> lodGroup; // 0x00
		public NativeArray<Vector3> worldSpaceReferencePoint; // 0x10
		public NativeArray<float> worldSpaceSize; // 0x20
		public NativeArray<InternalLODGroupSettings> groupSettings; // 0x30
		public NativeArray<byte> forceLODMask; // 0x40
		public NativeArray<EmbeddedLODBuffer> lodBuffer; // 0x50
		public NativeArray<EntityId> invalidLODGroup; // 0x60
		public bool transformOnly; // 0x70
	}
}
