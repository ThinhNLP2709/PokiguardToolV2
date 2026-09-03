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
	internal class ActiveLifecycleScope : ActiveLifecycleScopeBase // TypeDefIndex: 14835
	{
		// Fields
		[CompilerGenerated]
		private readonly LifecycleScopeKey _ScopeKey_k__BackingField; // 0x18
	
		// Properties
		public override LifecycleScopeKey ScopeKey { [CompilerGenerated] get; } // 0x0000000180A5E120-0x0000000180A5E130 
	
		// Constructors
		public ActiveLifecycleScope(LifecycleScope scope); // 0x000000018205FAF0-0x000000018205FC10
	
		// Methods
		public override void OnEnter(ScopeTransitionHelper helper); // 0x000000018205F850-0x000000018205F9A0
		public override void OnExit(ScopeTransitionHelper helper); // 0x000000018205F9A0-0x000000018205FAF0
	}
}
