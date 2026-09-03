/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(new byte[2] {0, 1 })]
	[NullableContext(1)]
	internal abstract class AssemblyLoadedScopeBase : LifecycleScopeWithContext<Unity.Scripting.LifecycleManagement.ReadOnlyAssemblyList> // TypeDefIndex: 14845
	{
		// Fields
		public const string ScopeName = "AssemblyLoaded"; // Metadata: 0x006A98BC
		[CompilerGenerated]
		private readonly ReadOnlyAssemblyList _OrderedAssemblies_k__BackingField; // 0x38
	
		// Properties
		public ReadOnlyAssemblyList OrderedAssemblies { [CompilerGenerated] get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		protected AssemblyLoadedScopeBase(IReadOnlyList<Assembly> assemblies); // 0x0000000182062B40-0x0000000182062BD0
	
		// Methods
		public override string ToString(); // 0x0000000182062B00-0x0000000182062B40
		protected override void Enter(ScopeTransitionHelper scopeTransitionHelper); // 0x00000001820627D0-0x0000000182062920
		private void EnterManaged(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182062770-0x00000001820627D0
		protected override void Exit(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182062980-0x0000000182062B00
		private void ExitManaged(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182062920-0x0000000182062980
	}
}
