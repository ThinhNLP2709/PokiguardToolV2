/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Loading.LowLevel;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 59: UnityEngine.ContentLoadModule.dll - Assembly: UnityEngine.ContentLoadModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15722-15736

namespace Unity.Loading
{
	internal static class ContentLoadingSystem // TypeDefIndex: 15728
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static LoadingResponseQueue s_ResultBuffer; // 0x00
		[NoAutoStaticsCleanup]
		private static Dictionary<ulong, ObjectLoadOperationBase> s_PendingLoadOperations; // 0x08
		[NoAutoStaticsCleanup]
		private static Dictionary<ulong, ObjectReleaseOperation> s_PendingReleaseOperations; // 0x10
		[NoAutoStaticsCleanup]
		private static bool s_Initialized; // 0x18
	
		// Nested types
		public struct ResourceOperationHandle : IEquatable<ResourceOperationHandle> // TypeDefIndex: 15729
		{
			// Fields
			[ExcludeFromDocs]
			internal ulong value; // 0x00
	
			// Methods
			[ExcludeFromDocs]
			public bool Equals(ResourceOperationHandle other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
			[ExcludeFromDocs]
			public override bool Equals(object obj); // 0x0000000182175D60-0x0000000182175DE0
			[ExcludeFromDocs]
			public override int GetHashCode(); // 0x000000018126B220-0x000000018126B230
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15730
		{
			// Fields
			public static Action _0___Initialize; // 0x00
			public static Action _1___Shutdown; // 0x08
		}
	
		// Methods
		private static void Initialize(); // 0x0000000182174BC0-0x0000000182174D30
		[ExcludeFromDocs]
		[RequiredByNativeCode(Optional = false)]
		internal static void ProcessResults(); // 0x0000000182174F50-0x00000001821751D0
		private static bool ProcessResult(AsyncResult result); // 0x0000000182174D30-0x0000000182174F50
		[RequiredByNativeCode(Optional = true)]
		private static void Shutdown(); // 0x00000001821751D0-0x0000000182175510
		[CompilerGenerated]
		internal static void Unity_Loading_ContentLoadingSystem_Initialize_RegisterLifecycleMethod(); // 0x0000000182175510-0x0000000182175660
		[CompilerGenerated]
		internal static void Unity_Loading_ContentLoadingSystem_Shutdown_RegisterLifecycleMethod(); // 0x0000000182175660-0x00000001821757B0
	}
}
