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
	[IsReadOnly]
	[VisibleToOtherModules]
	internal struct ManagedSpanWrapper // TypeDefIndex: 15498
	{
		// Fields
		public readonly unsafe void* begin; // 0x00
		public readonly int length; // 0x08
	
		// Constructors
		public unsafe ManagedSpanWrapper(void* begin, int length); // 0x0000000180CB6EA0-0x0000000180CB6EB0
	
		// Methods
		public static ReadOnlySpan<T> ToReadOnlySpan<T>(ManagedSpanWrapper spanWrapper);
	}
}
