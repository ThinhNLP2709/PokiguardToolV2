/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	internal struct GPUDrivenLODGroupDataNative // TypeDefIndex: 8380
	{
		// Fields
		public unsafe EntityId* lodGroup; // 0x00
		public unsafe Vector3* worldSpaceReferencePoint; // 0x08
		public unsafe float* worldSpaceSize; // 0x10
		public unsafe InternalLODGroupSettings* groupSettings; // 0x18
		public unsafe byte* forceLODMask; // 0x20
		public unsafe EmbeddedLODBuffer* lodBuffer; // 0x28
		public int lodGroupCount; // 0x30
		public unsafe EntityId* invalidLODGroups; // 0x38
		public int invalidLODGroupCount; // 0x40
		public bool transformOnly; // 0x44
	}
}
