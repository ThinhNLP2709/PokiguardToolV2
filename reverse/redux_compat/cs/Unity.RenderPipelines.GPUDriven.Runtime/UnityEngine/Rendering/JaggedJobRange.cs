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
	internal struct JaggedJobRange // TypeDefIndex: 12985
	{
		// Fields
		public int sectionIndex; // 0x00
		public int localStart; // 0x04
		public int absoluteStart; // 0x08
		public int length; // 0x0C
	
		// Properties
		public int localEnd { get; } // 0x000000018192E4A0-0x000000018192E4B0 
		public int absoluteEnd { get; } // 0x0000000181F4E790-0x0000000181F4E7A0 
	
		// Methods
		public static NativeList<JaggedJobRange> FromSpanWithRelaxedBatchSize<T>(JaggedSpan<T> jaggedSpan, int batchSizeHint, Allocator allocator)
			where T : struct;
		public static NativeList<JaggedJobRange> FromSpanWithMaxBatchSize<T>(JaggedSpan<T> jaggedSpan, int maxBatchSize, Allocator allocator)
			where T : struct;
		private static NativeList<JaggedJobRange> ComputeRanges<T>(JaggedSpan<T> jaggedSpan, int batchSizeHint, bool canExceedBatchSizeHint, Allocator allocator)
			where T : struct;
	}
}
