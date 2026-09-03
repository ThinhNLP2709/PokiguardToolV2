/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Burst;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal class EntityIdStore // TypeDefIndex: 7743
	{
		// Fields
		internal static readonly SharedStatic<ContextData> s_Context; // 0x00
		internal static readonly SharedStatic<EntityIdPool> Pool; // 0x08
	
		// Nested types
		internal struct EntitySlot // TypeDefIndex: 7744
		{
			// Fields
			public ulong versionAndChunk; // 0x00
			public IntPtr nativeObjectPtr; // 0x08
		}
	
		internal struct ContextData // TypeDefIndex: 7745
		{
			// Fields
			public bool PlatformSupportsVirtualMemory; // 0x00
			public int BlockShift; // 0x04
			public uint BlockMask; // 0x08
			public unsafe int* EntityCount; // 0x10
			public uint BlockCount; // 0x18
			public uint WordsPerBlock; // 0x1C
			public unsafe ulong* AllocatedBits; // 0x20
			public unsafe ulong* ReservedBits; // 0x28
			public unsafe byte* BlockCommitted; // 0x30
			public unsafe uint* CommittedIndexBound; // 0x38
			public unsafe void* NativeStore; // 0x40
			public EntitySlot NullSlot; // 0x48
			public int OffsetOfGCHandleInObject; // 0x58
			public bool IsInitialized; // 0x5C
		}
	
		internal struct Block // TypeDefIndex: 7746
		{
			// Fields
			private unsafe fixed /* 0x00000000-0x00000000 */ byte slotsRaw[0]; // 0x00
			public unsafe fixed /* 0x00000000-0x00000000 */ ulong allocated[0]; // 0x1000
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _allocated_e__FixedBuffer // TypeDefIndex: 7747
			{
				// Fields
				public ulong FixedElementField; // 0x00
			}
	
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _slotsRaw_e__FixedBuffer // TypeDefIndex: 7748
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
		}
	
		internal struct EntityIdPool // TypeDefIndex: 7749
		{
			// Fields
			private IntPtr m_Storage; // 0x00
			private int m_Allocating; // 0x08
	
			// Properties
			private static long PerThreadByteSize { get; } // 0x0000000180A2FBC0-0x0000000180A2FBD0 
	
			// Nested types
			private struct ArrayInfo // TypeDefIndex: 7750
			{
				// Fields
				public int m_AvailableCount; // 0x00
				public int m_NextIndex; // 0x04
			}
	
			// Methods
			internal void Drain(); // 0x00000001821E6090-0x00000001821E6160
			internal void Dispose(); // 0x00000001821E6050-0x00000001821E6090
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 7751
		{
			// Fields
			public static Action _0___Initialize; // 0x00
			public static Action _1___OnCodeUnloading; // 0x08
		}
	
		// Constructors
		static EntityIdStore(); // 0x00000001821E7040-0x00000001821E70C0
	
		// Methods
		internal static uint SlotGetVersion(ulong vac); // 0x00000001821E6D70-0x00000001821E6D80
		internal static ulong SlotSetVersion(ulong vac, uint newVersion); // 0x00000001821E6D80-0x00000001821E6DA0
		internal static void Initialize(); // 0x00000001821E6680-0x00000001821E68A0
		internal static ref EntitySlot GetSlot(uint entityIndex); // 0x00000001821E6590-0x00000001821E6680
		internal static bool BlockIsCommitted(uint blockIndex); // 0x00000001821E6450-0x00000001821E64F0
		internal static unsafe ulong* BlockAllocated(uint blockIndex); // 0x00000001821E63D0-0x00000001821E6450
		internal static void BlockSpinBackoff(ref int iter); // 0x00000001821E64F0-0x00000001821E6590
		[BurstDiscard]
		private static void ManagedSpinWait(int count); // 0x00000001821E68A0-0x00000001821E68B0
		private static void OnCodeUnloading(); // 0x00000001821E68B0-0x00000001821E6A10
		internal static unsafe void ReleaseEntityIds(EntityId* ids, int count); // 0x00000001821E6A10-0x00000001821E6D70
		[CompilerGenerated]
		internal static void UnityEngine_EntityIdStore_Initialize_RegisterLifecycleMethod(); // 0x00000001821E6DA0-0x00000001821E6EF0
		[CompilerGenerated]
		internal static void UnityEngine_EntityIdStore_OnCodeUnloading_RegisterLifecycleMethod(); // 0x00000001821E6EF0-0x00000001821E7040
	}
}
