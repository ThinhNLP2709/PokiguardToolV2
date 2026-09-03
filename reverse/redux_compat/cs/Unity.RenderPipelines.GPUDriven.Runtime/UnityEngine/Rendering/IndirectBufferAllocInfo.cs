/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct IndirectBufferAllocInfo // TypeDefIndex: 12866
	{
		// Fields
		public int drawAllocIndex; // 0x00
		public int drawCount; // 0x04
		public int instanceAllocIndex; // 0x08
		public int instanceCount; // 0x0C
	
		// Methods
		public bool IsEmpty(); // 0x0000000181CF8440-0x0000000181CF8450
		public bool IsWithinLimits([IsReadOnly] in IndirectBufferLimits limits); // 0x0000000181F389D0-0x0000000181F389F0
		public int GetExtraDrawInfoSlotIndex(); // 0x0000000181F389C0-0x0000000181F389D0
	}
}
