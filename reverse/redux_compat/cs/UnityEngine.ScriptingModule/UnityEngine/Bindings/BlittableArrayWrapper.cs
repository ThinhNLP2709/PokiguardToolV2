/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine.Bindings
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	[VisibleToOtherModules]
	internal struct BlittableArrayWrapper // TypeDefIndex: 15490
	{
		// Fields
		internal MarshalledArray arrayWrapper; // 0x00
	
		// Constructors
		public unsafe BlittableArrayWrapper(void* data, int size); // 0x00000001822E6590-0x00000001822E65C0
	
		// Methods
		internal void Unmarshal<T>(ref ref T[] array)
			where T : struct;
	}
}
