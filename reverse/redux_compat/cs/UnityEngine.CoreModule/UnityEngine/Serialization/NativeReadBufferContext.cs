/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Serialization
{
	internal struct NativeReadBufferContext // TypeDefIndex: 7992
	{
		// Fields
		public unsafe void* reader; // 0x00
		public unsafe byte* stackBuffer; // 0x08
		public unsafe byte* readerPtr; // 0x10
		public int readerAvailable; // 0x18
		public int stackBufferSize; // 0x1C
		public IntPtr ensureReadable; // 0x20
		public IntPtr readBytesDirect; // 0x28
		public IntPtr syncReader; // 0x30
		public IntPtr resolverHandle; // 0x38
		public int flags; // 0x40
		public bool warnAboutIgnoredEntries; // 0x44
		public byte _pad0; // 0x45
		public byte _pad1; // 0x46
		public byte _pad2; // 0x47
		public IntPtr fuidContext; // 0x48
		public EntityId hostingEntityId; // 0x50
		public IntPtr transferState; // 0x58
		public IntPtr instance; // 0x60
	}
}
