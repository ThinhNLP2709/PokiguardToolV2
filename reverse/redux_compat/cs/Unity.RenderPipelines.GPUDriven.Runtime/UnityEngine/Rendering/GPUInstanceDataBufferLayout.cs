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
	internal struct GPUInstanceDataBufferLayout : IDisposable, IEnumerable, IEquatable<UnityEngine.Rendering.GPUInstanceDataBufferLayout> // TypeDefIndex: 12776
	{
		// Fields
		private NativeList<GPUArchetypeHandle> m_Archetypes; // 0x00
		private NativeList<int> m_InstancesCount; // 0x08
		private NativeList<int> m_ArchetypeIndex; // 0x10
	
		// Properties
		public NativeArray<GPUArchetypeHandle> archetypes { get; } // 0x0000000181F090A0-0x0000000181F090D0 
		public NativeArray<int> instancesCount { get; } // 0x0000000181F090D0-0x0000000181F09100 
	
		// Nested types
		public struct ReadOnly // TypeDefIndex: 12777
		{
			// Fields
			public readonly NativeArray<GPUArchetypeHandle> archetypes; // 0x00
			public readonly NativeArray<int> instancesCount; // 0x10
			public readonly NativeArray<int> archetypeIndex; // 0x20
	
			// Constructors
			public ReadOnly(GPUInstanceDataBufferLayout layout); // 0x0000000181F19BC0-0x0000000181F19C20
	
			// Methods
			public int FindArchetypeIndex(GPUArchetypeHandle archetype); // 0x0000000181F198C0-0x0000000181F19930
		}
	
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__10 : IEnumerator<object> // TypeDefIndex: 12778
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public GPUInstanceDataBufferLayout __4__this; // 0x20
			private int _i_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000181F1B0D0-0x0000000181F1B190
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181F1B190-0x0000000181F1B1D0
		}
	
		// Constructors
		public GPUInstanceDataBufferLayout(int capacity, Allocator allocator); // 0x0000000181F08E90-0x0000000181F08F40
		public GPUInstanceDataBufferLayout([IsReadOnly] in GPUInstanceDataBufferLayout otherLayout, Allocator allocator); // 0x0000000181F08F40-0x0000000181F090A0
	
		// Methods
		public void Add(GPUArchetypeHandle archetype, int instanceCount); // 0x0000000181F08B10-0x0000000181F08C90
		[IteratorStateMachine(typeof(_GetEnumerator_d__10))]
		public IEnumerator GetEnumerator(); // 0x0000000181F08E20-0x0000000181F08E90
		public void Dispose(); // 0x0000000181F08D10-0x0000000181F08D40
		public bool Equals(GPUInstanceDataBufferLayout other); // 0x0000000181F08D40-0x0000000181F08DB0
		public int FindArchetypeIndex(GPUArchetypeHandle archetype); // 0x0000000181F08DB0-0x0000000181F08E20
		public ReadOnly AsReadOnly(); // 0x0000000181F08C90-0x0000000181F08D10
	}
}
