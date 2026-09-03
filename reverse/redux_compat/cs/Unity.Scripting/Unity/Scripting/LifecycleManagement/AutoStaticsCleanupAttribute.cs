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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, AllowMultiple = true)]
	[Nullable(0)]
	[NullableContext(2)]
	public sealed class AutoStaticsCleanupAttribute : Attribute // TypeDefIndex: 14889
	{
		// Fields
		[CompilerGenerated]
		private Type _ScopeType_k__BackingField; // 0x10
		[CompilerGenerated]
		private ScopeTransitionType _TransitionType_k__BackingField; // 0x18
		[CompilerGenerated]
		private CleanupStrategy _CleanupStrategy_k__BackingField; // 0x1C
	
		// Properties
		internal Type ScopeType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal ScopeTransitionType TransitionType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		internal CleanupStrategy CleanupStrategy { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
	
		// Constructors
		public AutoStaticsCleanupAttribute(); // 0x00000001802F4070-0x00000001802F4080
		internal AutoStaticsCleanupAttribute(Type scopeType = null, ScopeTransitionType transitionType = ScopeTransitionType.Unset /* Metadata: 0x006A98DA */, CleanupStrategy cleanupStrategy = CleanupStrategy.Unset /* Metadata: 0x006A98DB */); // 0x0000000182062BD0-0x0000000182062C30
	}
}
