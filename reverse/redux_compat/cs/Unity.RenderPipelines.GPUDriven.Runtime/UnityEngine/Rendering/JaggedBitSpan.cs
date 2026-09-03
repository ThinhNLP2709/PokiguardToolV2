/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct JaggedBitSpan // TypeDefIndex: 12991
	{
		// Fields
		private UnsafeList<UnsafeBitArray> m_Sections; // 0x00
		private int m_TotalLength; // 0x18
	
		// Properties
		public bool isCreated { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public int sectionCount { get; } // 0x00000001813033C0-0x00000001813033D0 
		public int totalLength { get; } // 0x0000000180B23260-0x0000000180B23270 
		public bool isEmpty { get; } // 0x00000001813033B0-0x00000001813033C0 
		public NativeArray<UnsafeBitArray> sections { get; } // 0x00000001813033D0-0x0000000181303430 
		public UnsafeBitArray this[int index] { get => default; set {} } // 0x0000000180BE8E10-0x0000000180BE8E40 0x0000000181F4E540-0x0000000181F4E580
	
		// Constructors
		public JaggedBitSpan(int initialCapacity, Allocator allocator); // 0x0000000181F4E4D0-0x0000000181F4E540
	
		// Methods
		public void Dispose(); // 0x0000000181F4E480-0x0000000181F4E490
		public JobHandle Dispose(JobHandle jobHandle); // 0x0000000181F4E490-0x0000000181F4E4D0
		public void Add([IsReadOnly] in NativeBitArray section); // 0x0000000181F4E3E0-0x0000000181F4E480
		public bool HasSameLayout<U>([IsReadOnly] in JaggedSpan<U> other)
			where U : struct;
	}
}
