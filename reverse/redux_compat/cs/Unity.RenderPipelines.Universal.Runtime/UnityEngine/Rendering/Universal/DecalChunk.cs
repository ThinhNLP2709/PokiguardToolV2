/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal abstract class DecalChunk : IDisposable // TypeDefIndex: 9419
	{
		// Fields
		[CompilerGenerated]
		private int _count_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _capacity_k__BackingField; // 0x14
		[CompilerGenerated]
		private JobHandle _currentJobHandle_k__BackingField; // 0x18
	
		// Properties
		public int count { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int capacity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public JobHandle currentJobHandle { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180A5E120-0x0000000180A5E130 0x0000000180F9EBA0-0x0000000180F9EBB0
	
		// Constructors
		protected DecalChunk(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Push(); // 0x0000000181F73190-0x0000000181F731A0
		public abstract void RemoveAtSwapBack(int index);
		public abstract void SetCapacity(int capacity);
		public virtual void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		protected void ResizeNativeArray(ref TransformAccessArray array, DecalProjector[] decalProjectors, int capacity); // 0x0000000181F731A0-0x0000000181F73270
		protected void RemoveAtSwapBack<T>(ref NativeArray<T> array, int index, int count)
			where T : struct;
		protected void RemoveAtSwapBack<T>(ref ref T[] array, int index, int count);
	}
}
