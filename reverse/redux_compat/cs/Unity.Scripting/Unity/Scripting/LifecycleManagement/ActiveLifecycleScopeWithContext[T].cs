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
	[Nullable(0)]
	[NullableContext(1)]
	internal class ActiveLifecycleScopeWithContext<T> : ActiveLifecycleScopeBase // TypeDefIndex: 14836
		where T : class
	{
		// Fields
		[CompilerGenerated]
		private readonly LifecycleScopeKey _ScopeKey_k__BackingField;
	
		// Properties
		public override LifecycleScopeKey ScopeKey { [CompilerGenerated] get; }
		public T Context { get; }
	
		// Constructors
		public ActiveLifecycleScopeWithContext(LifecycleScopeWithContext<T> scope);
	
		// Methods
		public override void OnEnter(ScopeTransitionHelper helper);
		public override void OnExit(ScopeTransitionHelper helper);
	}
}
