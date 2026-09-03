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
	internal sealed class UDMScope : ImplicitLifecycleScope // TypeDefIndex: 14895
	{
		// Fields
		[CompilerGenerated]
		private static readonly UDMScope _Instance_k__BackingField; // 0x00
	
		// Properties
		public static UDMScope Instance { [CompilerGenerated] get; } // 0x000000018206CA60-0x000000018206CAB0 
	
		// Constructors
		private UDMScope(); // 0x000000018206CA20-0x000000018206CA60
		static UDMScope(); // 0x000000018206C990-0x000000018206CA20
	
		// Methods
		protected override void Enter(ScopeTransitionHelper scopeTransitionHelper); // 0x000000018206C8F0-0x000000018206C940
		protected override void Exit(ScopeTransitionHelper scopeTransitionHelper); // 0x000000018206C940-0x000000018206C990
	}
}
