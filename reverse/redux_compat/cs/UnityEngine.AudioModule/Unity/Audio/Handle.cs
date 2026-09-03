/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace Unity.Audio
{
	[NativeHeader("Modules/DSPGraph/Public/DSPGraphHandles.h")]
	[VisibleToOtherModules(new string[1] {"UnityEngine.DSPGraphModule" })]
	internal struct Handle : IEquatable<Unity.Audio.Handle> // TypeDefIndex: 14952
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		private IntPtr m_Node; // 0x00
		public int Version; // 0x08
	
		// Properties
		internal unsafe Node* AtomicNode { [IsReadOnly] get; } // 0x0000000180E85FD0-0x0000000180E85FE0 
		public bool ValidAndNotDisposed { [IsReadOnly] get; } // 0x000000018216CF40-0x000000018216CF90 
	
		// Nested types
		internal struct Node // TypeDefIndex: 14953
		{
			// Fields
			private unsafe void* Next; // 0x00
			public int Id; // 0x08
			public int Version; // 0x0C
			public int AllocationFlags; // 0x10
		}
	
		// Methods
		[IsReadOnly]
		public bool Equals(Handle other); // 0x0000000180C10DC0-0x0000000180C10DE0
		[IsReadOnly]
		public override bool Equals(object obj); // 0x000000018216CE80-0x000000018216CF10
		[IsReadOnly]
		public override int GetHashCode(); // 0x000000018216CF10-0x000000018216CF40
		[IsReadOnly]
		public void CheckValidOrThrow(); // 0x000000018216CDF0-0x000000018216CE80
	}
}
