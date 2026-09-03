/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine.Bindings
{
	[Il2CppEagerStaticClassConstruction]
	[VisibleToOtherModules]
	internal struct MarshalledArray // TypeDefIndex: 15485
	{
		// Fields
		[VisibleToOtherModules]
		internal unsafe void* data; // 0x00
		[VisibleToOtherModules]
		internal int size; // 0x08
		internal int capacity; // 0x0C
		internal DataOwner dataOwner; // 0x10
	
		// Nested types
		internal enum DataOwner // TypeDefIndex: 15486
		{
			PinnedBuffer = 0,
			TempAllocated = 1,
			TempAllocatedCleanupRequired = 2,
			ExternallyOwned = 3,
			NativeOwnedMemory = 4,
			Empty = 5,
			Null = 6,
			OutNullCollection = 7,
			OutWithSize = 8,
			OutWithCapacity = 9
		}
	
		// Constructors
		private unsafe MarshalledArray(void* data, int size, int capacity, DataOwner dataOwner); // 0x00000001822E6BF0-0x00000001822E6C10
	
		// Methods
		public static unsafe MarshalledArray CreateFromPinnedData(void* data, int size); // 0x00000001822E6A40-0x00000001822E6A60
		internal void UnmarshalBlittable<TBlittable, TCollectionAccessor>(ref ref TCollectionAccessor collectionAccessor)
			where TBlittable : struct
			where TCollectionAccessor : struct, ICollectionMarshallingAccessor<TBlittable>;
		internal void Free(); // 0x00000001822E6A60-0x00000001822E6B10
		private static string GetUnimplementedDataOwnerCaseMessage(); // 0x00000001822E6B10-0x00000001822E6B50
		[DoesNotReturn]
		public static void ThrowUnimplementedDataOwnerCase(DataOwner dataOwner); // 0x00000001822E6B50-0x00000001822E6BF0
	}
}
