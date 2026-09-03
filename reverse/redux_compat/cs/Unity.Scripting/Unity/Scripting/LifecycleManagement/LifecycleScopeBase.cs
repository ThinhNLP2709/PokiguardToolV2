/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[DebuggerDisplay("Scope Name = {Name}")]
	[Nullable(0)]
	[NullableContext(1)]
	internal abstract class LifecycleScopeBase // TypeDefIndex: 14875
	{
		// Fields
		[CompilerGenerated]
		private string _Name_k__BackingField; // 0x10
		[CompilerGenerated]
		private List<string> _ExplicitRequiredOuterScopes_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _AllowNestedTransitions_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly ImplicitLifecycleScope[] _ImplicitOuterScopes_k__BackingField; // 0x28
	
		// Properties
		public string Name { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		protected List<string> ExplicitRequiredOuterScopes { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public IEnumerable<string> RequiredOuterScopes { [IteratorStateMachine(typeof(_get_RequiredOuterScopes_d__9))] get; } // 0x0000000182067580-0x0000000182067600 
		public bool AllowNestedTransitions { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public virtual ImplicitLifecycleScope[] ImplicitOuterScopes { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _get_RequiredOuterScopes_d__9 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 14876
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			[Nullable(0)]
			public LifecycleScopeBase __4__this; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			private List<string> __7__wrap1; // 0x30
			[Nullable(new byte[2] {0, 1 })]
			private ImplicitLifecycleScope[] __7__wrap2; // 0x48
			private int __7__wrap3; // 0x50
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_RequiredOuterScopes_d__9(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018206C830-0x000000018206C8D0
			private bool MoveNext(); // 0x000000018206C500-0x000000018206C750
			private void __m__Finally1(); // 0x000000018206C8D0-0x000000018206C8F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018206C7F0-0x000000018206C830
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x000000018206C750-0x000000018206C7F0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018206C750-0x000000018206C7F0
		}
	
		// Constructors
		public LifecycleScopeBase(string name); // 0x0000000182067490-0x0000000182067580
	
		// Methods
		public bool MustBeNestedInsideScope(string scopeName); // 0x0000000182067240-0x00000001820672D0
		protected abstract void Enter(ScopeTransitionHelper scopeTransitionHelper);
		protected abstract void Exit(ScopeTransitionHelper scopeTransitionHelper);
		internal void OnEnter(ScopeTransitionHelper scopeTransitionHelper); // 0x00000001820672D0-0x00000001820673B0
		internal void OnExit(ScopeTransitionHelper scopeTransitionHelper); // 0x00000001820673B0-0x0000000182067490
	}
}
