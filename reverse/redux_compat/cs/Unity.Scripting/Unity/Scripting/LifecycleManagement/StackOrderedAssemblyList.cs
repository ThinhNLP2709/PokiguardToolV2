/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal sealed class StackOrderedAssemblyList : IReadOnlyList<Assembly> // TypeDefIndex: 14885
	{
		// Fields
		private int _count; // 0x10
		private readonly List<ReadOnlyAssemblyList> _assemblyStacks; // 0x18
	
		// Properties
		public int Count { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int StackCount { get; } // 0x00000001814EA450-0x00000001814EA470 
		public Assembly this[int index] { get => default; } // 0x000000018206A2B0-0x000000018206A450 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__11 : IEnumerator<Assembly> // TypeDefIndex: 14886
		{
			// Fields
			private int __1__state; // 0x10
			private Assembly __2__current; // 0x18
			[Nullable(0)]
			public StackOrderedAssemblyList __4__this; // 0x20
			[Nullable(new byte[2] {0, 1 })]
			private List<ReadOnlyAssemblyList> __7__wrap1; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<Assembly> __7__wrap2; // 0x40
	
			// Properties
			Assembly IEnumerator<System.Reflection.Assembly>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018206BFE0-0x000000018206C150
			private bool MoveNext(); // 0x000000018206BCE0-0x000000018206BFA0
			private void __m__Finally1(); // 0x000000018206C150-0x000000018206C170
			private void __m__Finally2(); // 0x000000018206C170-0x000000018206C1C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018206BFA0-0x000000018206BFE0
		}
	
		// Constructors
		public StackOrderedAssemblyList(); // 0x000000018206A230-0x000000018206A2B0
	
		// Methods
		public void PushStack(ReadOnlyAssemblyList assemblies); // 0x0000000182069FF0-0x000000018206A0C0
		public void PopStack(); // 0x0000000182069F30-0x0000000182069FF0
		public void Clear(); // 0x0000000182069D30-0x0000000182069D80
		[IteratorStateMachine(typeof(_GetEnumerator_d__11))]
		public IEnumerator<Assembly> GetEnumerator(); // 0x0000000182069EC0-0x0000000182069F30
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182069EC0-0x0000000182069F30
		public bool TryGetAssembly(string assemblyName, out Assembly assembly); // 0x000000018206A0C0-0x000000018206A230
		public bool Contains(string assemblyName); // 0x0000000182069D80-0x0000000182069EC0
	}
}
