/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class TempAllocator : IDisposable // TypeDefIndex: 5150
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		private readonly int m_ExcessMinCapacity; // 0x10
		private readonly int m_ExcessMaxCapacity; // 0x14
		private Page m_Pool; // 0x18
		private List<Page> m_Excess; // 0x30
		private List<Page> m_Dedicated; // 0x38
		private int m_NextExcessSize; // 0x40
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x44
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018180F140-0x000000018180F150 0x000000018180F150-0x000000018180F160
	
		// Nested types
		private struct Page // TypeDefIndex: 5151
		{
			// Fields
			public NativeArray<byte> array; // 0x00
			public int used; // 0x10
		}
	
		// Constructors
		public TempAllocator(int poolCapacity, int excessMinCapacity, int excessMaxCapacity); // 0x0000000182447720-0x00000001824478C0
		static TempAllocator(); // 0x0000000182447690-0x0000000182447720
	
		// Methods
		public void Dispose(); // 0x0000000182446F90-0x0000000182447040
		protected void Dispose(bool disposing); // 0x0000000182447040-0x00000001824470C0
		private static int AlignUp(int value, int alignmentPo2); // 0x0000000181C8AC90-0x0000000181C8ACA0
		public NativeSlice<T> Alloc<T>(int count)
			where T : struct;
		private NativeSlice<byte> DoSubAlloc(int byteCount, int alignment); // 0x00000001824470C0-0x00000001824473E0
		private NativeSlice<byte> AllocDedicated(int byteCount); // 0x0000000182446E20-0x0000000182446F90
		public void Reset(); // 0x0000000182447660-0x0000000182447690
		private void ReleaseExcess(); // 0x0000000182447520-0x0000000182447660
		private void ReleaseDedicated(); // 0x00000001824473E0-0x0000000182447520
	}
}
