/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct GPUComponentSet : IEquatable<UnityEngine.Rendering.GPUComponentSet>, IComparable<UnityEngine.Rendering.GPUComponentSet>, IEnumerable // TypeDefIndex: 12765
	{
		// Fields
		[CompilerGenerated]
		private ulong _componentsMask_k__BackingField; // 0x00
	
		// Properties
		public ulong componentsMask { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		public bool isEmpty { get; } // 0x0000000181F08AC0-0x0000000181F08B10 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__15 : IEnumerator<object> // TypeDefIndex: 12766
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public GPUComponentSet __4__this; // 0x20
			private int _count_5__2; // 0x28
			private int _i_5__3; // 0x2C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000181F1B1D0-0x0000000181F1B480
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181F1B480-0x0000000181F1B4C0
		}
	
		// Constructors
		static GPUComponentSet(); // 0x00000001802E76C0-0x00000001802E76D0
		public GPUComponentSet(NativeArray<GPUComponentHandle> components); // 0x0000000181F08960-0x0000000181F08AC0
	
		// Methods
		public bool Equals(GPUComponentSet other); // 0x0000000181F084E0-0x0000000181F08540
		public int CompareTo(GPUComponentSet other); // 0x0000000181F08470-0x0000000181F084E0
		public override int GetHashCode(); // 0x0000000181F08900-0x0000000181F08960
		public void Add(GPUComponentHandle componentHandle); // 0x0000000181F083E0-0x0000000181F08470
		public void AddSet(GPUComponentSet componentSet); // 0x0000000181F08390-0x0000000181F083E0
		public void AddRange(NativeArray<GPUComponentHandle> components); // 0x0000000181F08280-0x0000000181F08390
		public int GetComponentsCount(); // 0x0000000181F08700-0x0000000181F087A0
		[IteratorStateMachine(typeof(_GetEnumerator_d__15))]
		public IEnumerator GetEnumerator(); // 0x0000000181F088A0-0x0000000181F08900
		public GPUComponentHandle GetComponentByIndex(int index); // 0x0000000181F08540-0x0000000181F08700
		public NativeList<GPUComponentHandle> GetComponents(Allocator allocator); // 0x0000000181F087A0-0x0000000181F088A0
	}
}
