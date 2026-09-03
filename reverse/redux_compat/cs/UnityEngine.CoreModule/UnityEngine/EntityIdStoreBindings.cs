/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/BaseClasses/BaseObject.h")]
	[NativeHeader("Runtime/BaseClasses/EntityIdStore.h")]
	internal static class EntityIdStoreBindings // TypeDefIndex: 7742
	{
		// Methods
		[NativeMethod(Name = "Object::GetOffsetOfGCHandleMember", IsFreeFunction = true, IsThreadSafe = true)]
		public static int GetOffsetOfGCHandleInCPlusPlusObject(); // 0x00000001821E6370-0x00000001821E63A0
		[NativeMethod(Name = "GetEntityIdAllocatorStore", IsFreeFunction = true, IsThreadSafe = true)]
		public static unsafe void* GetEntityIdAllocatorStore(); // 0x00000001821E6190-0x00000001821E61C0
		[NativeMethod(Name = "GetEntityIdStoreBlockShift", IsFreeFunction = true, IsThreadSafe = true)]
		public static uint GetEntityIdStoreBlockShift(); // 0x00000001821E6280-0x00000001821E62B0
		[NativeMethod(Name = "GetEntityIdStoreBlockMask", IsFreeFunction = true, IsThreadSafe = true)]
		public static uint GetEntityIdStoreBlockMask(); // 0x00000001821E6250-0x00000001821E6280
		[NativeMethod(Name = "GetEntityIdStoreBlockCount", IsFreeFunction = true, IsThreadSafe = true)]
		public static uint GetEntityIdStoreBlockCount(); // 0x00000001821E6220-0x00000001821E6250
		[NativeMethod(Name = "GetEntityIdStoreWordsPerBlock", IsFreeFunction = true, IsThreadSafe = true)]
		public static uint GetEntityIdStoreWordsPerBlock(); // 0x00000001821E6340-0x00000001821E6370
		[NativeMethod(Name = "GetEntityIdStoreEntityCount", IsFreeFunction = true, IsThreadSafe = true)]
		public static unsafe void* GetEntityIdStoreEntityCount(); // 0x00000001821E62E0-0x00000001821E6310
		[NativeMethod(Name = "GetEntityIdStoreAllocatedBits", IsFreeFunction = true, IsThreadSafe = true)]
		public static unsafe void* GetEntityIdStoreAllocatedBits(); // 0x00000001821E61C0-0x00000001821E61F0
		[NativeMethod(Name = "GetEntityIdStoreReservedBits", IsFreeFunction = true, IsThreadSafe = true)]
		public static unsafe void* GetEntityIdStoreReservedBits(); // 0x00000001821E6310-0x00000001821E6340
		[NativeMethod(Name = "GetEntityIdStoreBlockCommittedTable", IsFreeFunction = true, IsThreadSafe = true)]
		public static unsafe void* GetEntityIdStoreBlockCommittedTable(); // 0x00000001821E61F0-0x00000001821E6220
		[NativeMethod(Name = "GetEntityIdStoreCommittedIndexBoundAddress", IsFreeFunction = true, IsThreadSafe = true)]
		public static unsafe void* GetEntityIdStoreCommittedIndexBoundAddress(); // 0x00000001821E62B0-0x00000001821E62E0
		[NativeMethod(Name = "EntityIdStorePlatformSupportsVirtualMemory", IsFreeFunction = true, IsThreadSafe = true)]
		public static bool EntityIdStorePlatformSupportsVirtualMemory(); // 0x00000001821E6160-0x00000001821E6190
		[NativeMethod(Name = "EntityIdStore_OsThreadYield", IsFreeFunction = true, IsThreadSafe = true)]
		public static void OsThreadYield(); // 0x00000001821E63A0-0x00000001821E63D0
	}
}
