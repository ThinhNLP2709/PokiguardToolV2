/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class GPUBufferAllocator // TypeDefIndex: 5042
	{
		// Fields
		private BestFitAllocator m_Low; // 0x10
		private BestFitAllocator m_High; // 0x18
	
		// Properties
		public bool isEmpty { get; } // 0x0000000182410BF0-0x0000000182410C30 
	
		// Constructors
		public GPUBufferAllocator(uint maxSize); // 0x0000000182410B40-0x0000000182410BF0
	
		// Methods
		public Alloc Allocate(uint size, bool shortLived); // 0x0000000182410890-0x0000000182410A90
		public void Free(Alloc alloc); // 0x0000000182410A90-0x0000000182410B10
		private bool HighLowCollide(); // 0x0000000182410B10-0x0000000182410B40
	}
}
