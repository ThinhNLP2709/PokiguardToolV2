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
	internal sealed class BurstScope : ImplicitLifecycleScope // TypeDefIndex: 14849
	{
		// Fields
		[CompilerGenerated]
		private static readonly BurstScope _Instance_k__BackingField; // 0x00
	
		// Properties
		public static BurstScope Instance { [CompilerGenerated] get; } // 0x0000000182062DA0-0x0000000182062DF0 
	
		// Constructors
		private BurstScope(); // 0x0000000182062D60-0x0000000182062DA0
		static BurstScope(); // 0x0000000182062CD0-0x0000000182062D60
	
		// Methods
		protected override void Enter(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182062C30-0x0000000182062C80
		protected override void Exit(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182062C80-0x0000000182062CD0
	}
}
