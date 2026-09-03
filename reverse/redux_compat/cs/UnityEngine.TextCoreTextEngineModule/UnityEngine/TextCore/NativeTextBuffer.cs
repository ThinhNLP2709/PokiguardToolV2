/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Buffers;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct NativeTextBuffer : IDisposable // TypeDefIndex: 12625
	{
		// Fields
		private NativeArray<char> m_Buffer; // 0x00
		private int m_Length; // 0x10
		private Allocator m_Allocator; // 0x14
	
		// Properties
		private Allocator effectiveAllocator { get; } // 0x00000001823074F0-0x0000000182307500 
		public NativeArray<char> buffer { get; } // 0x000000018092E600-0x000000018092E610 
		public int length { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public bool isCreated { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public char this[int index] { set {} } // 0x0000000180BF0E40-0x0000000180BF0E50
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12626
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static SpanAction<char, NativeArray<char>> __9__24_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182313040-0x0000000182313110
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Materialize_b__24_0(Span<char> span, NativeArray<char> b); // 0x0000000182312F80-0x0000000182312FD0
		}
	
		// Methods
		public static NativeTextBuffer CreateDomainScoped(); // 0x0000000182307260-0x0000000182307280
		public void EnsureCapacity(int requiredLength, bool preserveContent = false /* Metadata: 0x006A488D */); // 0x00000001823072D0-0x00000001823073C0
		public void CopyFrom(string value); // 0x0000000182307140-0x0000000182307260
		public string Materialize(); // 0x00000001823073C0-0x00000001823074F0
		public void Dispose(); // 0x0000000182307280-0x00000001823072D0
	}
}
