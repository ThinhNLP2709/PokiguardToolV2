/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[DebuggerDisplay("Active Scope Name = {Scope.Name}")]
	[Nullable(0)]
	[NullableContext(1)]
	internal abstract class ActiveLifecycleScopeBase // TypeDefIndex: 14834
	{
		// Fields
		[CompilerGenerated]
		private LifecycleScopeBase _Scope_k__BackingField; // 0x10
	
		// Properties
		public LifecycleScopeBase Scope { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public abstract LifecycleScopeKey ScopeKey { get; }
	
		// Constructors
		protected ActiveLifecycleScopeBase(LifecycleScopeBase scope); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public abstract void OnEnter(ScopeTransitionHelper helper);
		public abstract void OnExit(ScopeTransitionHelper helper);
	}
}
