/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 72: UnityEngine.AIModule.dll - Assembly: UnityEngine.AIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15866-15870

namespace UnityEngine.AI
{
	[MovedFrom("UnityEngine")]
	[NativeHeader("Modules/AI/NavMeshManager.h")]
	[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
	[StaticAccessor("NavMeshBindings", StaticAccessorType.DoubleColon)]
	public static class NavMesh // TypeDefIndex: 15869
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		public static OnNavMeshPreUpdate onPreUpdate; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Nested types
		public delegate void OnNavMeshPreUpdate(); // TypeDefIndex: 15870; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		static NavMesh(); // 0x0000000182145C80-0x00000001821463A0
	
		// Methods
		[RequiredByNativeCode]
		private static void ClearPreUpdateListeners(); // 0x0000000182145B30-0x0000000182145BA0
		[RequiredByNativeCode]
		private static void Internal_CallPreUpdateListeners(); // 0x0000000182145BA0-0x0000000182145C10
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182145C10-0x0000000182145C80
	}
}
