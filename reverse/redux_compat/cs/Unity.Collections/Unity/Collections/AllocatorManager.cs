/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	public static class AllocatorManager // TypeDefIndex: 11444
	{
		// Fields
		public static readonly AllocatorHandle Invalid; // 0x00
		public static readonly AllocatorHandle None; // 0x04
		public static readonly AllocatorHandle Temp; // 0x08
		public static readonly AllocatorHandle TempJob; // 0x0C
		public static readonly AllocatorHandle Persistent; // 0x10
		public static readonly AllocatorHandle AudioKernel; // 0x14
		public const int kErrorNone = 0; // Metadata: 0x006A1BBA
		public const int kErrorBufferOverflow = -1; // Metadata: 0x006A1BBB
		public const ushort FirstUserIndex = 64; // Metadata: 0x006A1BBC
		public const ushort MaxNumCustomAllocators = 32768; // Metadata: 0x006A1BBE
		internal static readonly ushort NumGlobalScratchAllocators; // 0x18
		internal static readonly ushort MaxNumGlobalAllocators; // 0x1A
		internal static readonly uint GlobalAllocatorBaseIndex; // 0x1C
		internal static readonly uint FirstGlobalScratchpadAllocatorIndex; // 0x20
	
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int TryFunction(IntPtr allocatorState, ref Block block); // TypeDefIndex: 11445; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public struct AllocatorHandle : IAllocator, IEquatable<AllocatorHandle>, IComparable<AllocatorHandle> // TypeDefIndex: 11446
		{
			// Fields
			public ushort Index; // 0x00
			public ushort Version; // 0x02
	
			// Properties
			internal ref TableEntry TableEntry { get; } // 0x0000000181C88BA0-0x0000000181C88C10 
			internal bool IsInstalled { get; } // 0x0000000181C88B30-0x0000000181C88BA0 
			public int Value { get; } // 0x000000018123AD30-0x000000018123AD40 
			public TryFunction Function { get; } // 0x00000001802E7860-0x00000001802E7870 
			public AllocatorHandle Handle { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
			public Allocator ToAllocator { get; } // 0x0000000181C88C10-0x0000000181C88C20 
			public bool IsCustomAllocator { get; } // 0x0000000181C88B20-0x0000000181C88B30 
			public bool IsAutoDispose { get; } // 0x0000000181C88AB0-0x0000000181C88B20 
	
			// Methods
			internal void IncrementVersion(); // 0x00000001802E76C0-0x00000001802E76D0
			internal void Rewind(); // 0x00000001802E76C0-0x00000001802E76D0
			internal void Install(TableEntry tableEntry); // 0x0000000181C889D0-0x0000000181C88A50
			public static implicit operator AllocatorHandle(Allocator a); // 0x0000000181C88C50-0x0000000181C88C70
			public int TryAllocateBlock<T>(out Block block, int items)
				where T : struct;
			public Block AllocateBlock<T>(int items)
				where T : struct;
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private static void CheckAllocatedSuccessfully(int error); // 0x0000000181C887C0-0x0000000181C88860
			public int Try(ref Block block); // 0x0000000181C88A50-0x0000000181C88AB0
			public void Dispose(); // 0x0000000181C88860-0x0000000181C888D0
			public override bool Equals(object obj); // 0x0000000181C888F0-0x0000000181C889D0
			public bool Equals(AllocatorHandle other); // 0x0000000181560960-0x0000000181560970
			public bool Equals(Allocator other); // 0x0000000181C888D0-0x0000000181C888F0
			public override int GetHashCode(); // 0x000000018123AD30-0x000000018123AD40
			public static bool operator ==(AllocatorHandle lhs, AllocatorHandle rhs); // 0x0000000181C88C20-0x0000000181C88C30
			public static bool operator !=(AllocatorHandle lhs, AllocatorHandle rhs); // 0x0000000181C88C70-0x0000000181C88C80
			public static bool operator <(AllocatorHandle lhs, AllocatorHandle rhs); // 0x0000000181C88C90-0x0000000181C88CA0
			public static bool operator >(AllocatorHandle lhs, AllocatorHandle rhs); // 0x0000000181C88C40-0x0000000181C88C50
			public static bool operator <=(AllocatorHandle lhs, AllocatorHandle rhs); // 0x0000000181C88C80-0x0000000181C88C90
			public static bool operator >=(AllocatorHandle lhs, AllocatorHandle rhs); // 0x0000000181C88C30-0x0000000181C88C40
			public int CompareTo(AllocatorHandle other); // 0x0000000181560720-0x0000000181560730
		}
	
		public struct BlockHandle // TypeDefIndex: 11447
		{
			// Fields
			public ushort Value; // 0x00
		}
	
		public struct Range : IDisposable // TypeDefIndex: 11448
		{
			// Fields
			public IntPtr Pointer; // 0x00
			public int Items; // 0x08
			public AllocatorHandle Allocator; // 0x0C
	
			// Methods
			public void Dispose(); // 0x0000000181C9EF40-0x0000000181C9EFC0
		}
	
		public struct Block : IDisposable // TypeDefIndex: 11449
		{
			// Fields
			public Range Range; // 0x00
			public int BytesPerItem; // 0x10
			public int AllocatedItems; // 0x14
			public byte Log2Alignment; // 0x18
			public byte Padding0; // 0x19
			public ushort Padding1; // 0x1A
			public uint Padding2; // 0x1C
	
			// Properties
			public long Bytes { get; } // 0x0000000181C8C660-0x0000000181C8C670 
			public long AllocatedBytes { get; } // 0x0000000181C8C650-0x0000000181C8C660 
			public int Alignment { get; set; } // 0x0000000181C8C640-0x0000000181C8C650 0x0000000181C8C670-0x0000000181C8C6C0
	
			// Methods
			public void Dispose(); // 0x0000000181C8C5F0-0x0000000181C8C640
			public int TryAllocate(); // 0x0000000181C8C420-0x0000000181C8C470
			public int TryFree(); // 0x0000000181C8C5F0-0x0000000181C8C640
			public void Allocate(); // 0x0000000181C8C420-0x0000000181C8C470
			public void Free(); // 0x0000000181C8C5F0-0x0000000181C8C640
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckFailedToAllocate(int error); // 0x0000000181C8C470-0x0000000181C8C530
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckFailedToFree(int error); // 0x0000000181C8C530-0x0000000181C8C5F0
		}
	
		public interface IAllocator : IDisposable // TypeDefIndex: 11450
		{
			// Properties
			TryFunction Function { get; }
			AllocatorHandle Handle { get; set; }
			Allocator ToAllocator { get; }
			bool IsCustomAllocator { get; }
			bool IsAutoDispose { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Methods
			int Try(ref Block block);
		}
	
		[BurstCompile]
		internal struct StackAllocator : IAllocator // TypeDefIndex: 11451
		{
			// Fields
			internal AllocatorHandle m_handle; // 0x00
			internal Block m_storage; // 0x08
			internal long m_top; // 0x28
	
			// Properties
			public AllocatorHandle Handle { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
			public Allocator ToAllocator { get; } // 0x0000000181C88C10-0x0000000181C88C20 
			public bool IsCustomAllocator { get; } // 0x0000000181C88B20-0x0000000181C88B30 
			public TryFunction Function { get; } // 0x0000000181C9FB40-0x0000000181C9FC20 
	
			// Nested types
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int Try_000000AD_PostfixBurstDelegate(IntPtr allocatorState, ref Block block); // TypeDefIndex: 11452; 0x0000000180A70FB0-0x0000000180A70FC0
	
			internal static class Try_000000AD_BurstDirectCall // TypeDefIndex: 11453
			{
				// Fields
				private static IntPtr Pointer; // 0x00
	
				// Methods
				private static void ClearFunctionPointer(); // 0x0000000181C9FD40-0x0000000181C9FD80
				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr param_000154e9); // 0x0000000181C9FD80-0x0000000181C9FEE0
				private static IntPtr GetFunctionPointer(); // 0x0000000181C9FEE0-0x0000000181CA0030
				public static int Invoke(IntPtr allocatorState, ref Block block); // 0x0000000181C9F880-0x0000000181C9FA50
			}
	
			// Methods
			public void Initialize(Block storage); // 0x0000000181C9F830-0x0000000181C9F850
			public int Try(ref Block block); // 0x0000000181C9FA50-0x0000000181C9FB40
			[BurstCompile]
			[MonoPInvokeCallback(typeof(TryFunction))]
			public static int Try(IntPtr allocatorState, ref Block block); // 0x0000000181C9F880-0x0000000181C9FA50
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			[BurstCompile]
			[MonoPInvokeCallback(typeof(TryFunction))]
			internal static int Try_BurstManaged(IntPtr allocatorState, ref Block block); // 0x0000000181C9F850-0x0000000181C9F880
		}
	
		[BurstCompile]
		internal struct SlabAllocator : IAllocator // TypeDefIndex: 11454
		{
			// Fields
			internal AllocatorHandle m_handle; // 0x00
			internal Block Storage; // 0x08
			internal int Log2SlabSizeInBytes; // 0x28
			internal FixedList4096Bytes<int> Occupied; // 0x30
			internal long budgetInBytes; // 0x1030
			internal long allocatedBytes; // 0x1038
	
			// Properties
			public AllocatorHandle Handle { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
			public Allocator ToAllocator { get; } // 0x0000000181C88C10-0x0000000181C88C20 
			public bool IsCustomAllocator { get; } // 0x0000000181C88B20-0x0000000181C88B30 
			public long BudgetInBytes { get; } // 0x0000000181C9F570-0x0000000181C9F580 
			public long AllocatedBytes { get; } // 0x0000000181C9F560-0x0000000181C9F570 
			internal int SlabSizeInBytes { get; set; } // 0x0000000181C9F660-0x0000000181C9F670 0x0000000181C9F690-0x0000000181C9F6F0
			internal int Slabs { get; } // 0x0000000181C9F670-0x0000000181C9F690 
			public TryFunction Function { get; } // 0x0000000181C9F580-0x0000000181C9F660 
	
			// Nested types
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int Try_000000BB_PostfixBurstDelegate(IntPtr allocatorState, ref Block block); // TypeDefIndex: 11455; 0x0000000180A70FB0-0x0000000180A70FC0
	
			internal static class Try_000000BB_BurstDirectCall // TypeDefIndex: 11456
			{
				// Fields
				private static IntPtr Pointer; // 0x00
	
				// Methods
				private static void ClearFunctionPointer(); // 0x0000000181CA00D0-0x0000000181CA0110
				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr param_000154ff); // 0x0000000181CA0110-0x0000000181CA0270
				private static IntPtr GetFunctionPointer(); // 0x0000000181CA0270-0x0000000181CA03C0
				public static int Invoke(IntPtr allocatorState, ref Block block); // 0x0000000181C9F0C0-0x0000000181C9F290
			}
	
			// Methods
			internal void Initialize(Block storage, int slabSizeInBytes, long budget); // 0x0000000181C9EFC0-0x0000000181C9F090
			public int Try(ref Block block); // 0x0000000181C9F290-0x0000000181C9F560
			[BurstCompile]
			[MonoPInvokeCallback(typeof(TryFunction))]
			public static int Try(IntPtr allocatorState, ref Block block); // 0x0000000181C9F0C0-0x0000000181C9F290
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			[BurstCompile]
			[MonoPInvokeCallback(typeof(TryFunction))]
			internal static int Try_BurstManaged(IntPtr allocatorState, ref Block block); // 0x0000000181C9F090-0x0000000181C9F0C0
		}
	
		internal struct TableEntry // TypeDefIndex: 11457
		{
			// Fields
			internal IntPtr function; // 0x00
			internal IntPtr state; // 0x08
		}
	
		internal struct Array16<T> // TypeDefIndex: 11458
			where T : struct
		{
			// Fields
			internal T f0;
			internal T f1;
			internal T f2;
			internal T f3;
			internal T f4;
			internal T f5;
			internal T f6;
			internal T f7;
			internal T f8;
			internal T f9;
			internal T f10;
			internal T f11;
			internal T f12;
			internal T f13;
			internal T f14;
			internal T f15;
		}
	
		internal struct Array256<T> // TypeDefIndex: 11459
			where T : struct
		{
			// Fields
			internal Array16<T> f0;
			internal Array16<T> f1;
			internal Array16<T> f2;
			internal Array16<T> f3;
			internal Array16<T> f4;
			internal Array16<T> f5;
			internal Array16<T> f6;
			internal Array16<T> f7;
			internal Array16<T> f8;
			internal Array16<T> f9;
			internal Array16<T> f10;
			internal Array16<T> f11;
			internal Array16<T> f12;
			internal Array16<T> f13;
			internal Array16<T> f14;
			internal Array16<T> f15;
		}
	
		internal struct Array4096<T> // TypeDefIndex: 11460
			where T : struct
		{
			// Fields
			internal Array256<T> f0;
			internal Array256<T> f1;
			internal Array256<T> f2;
			internal Array256<T> f3;
			internal Array256<T> f4;
			internal Array256<T> f5;
			internal Array256<T> f6;
			internal Array256<T> f7;
			internal Array256<T> f8;
			internal Array256<T> f9;
			internal Array256<T> f10;
			internal Array256<T> f11;
			internal Array256<T> f12;
			internal Array256<T> f13;
			internal Array256<T> f14;
			internal Array256<T> f15;
		}
	
		internal struct Array32768<T> : IIndexable<T> // TypeDefIndex: 11461
			where T : struct
		{
			// Fields
			internal Array4096<T> f0;
			internal Array4096<T> f1;
			internal Array4096<T> f2;
			internal Array4096<T> f3;
			internal Array4096<T> f4;
			internal Array4096<T> f5;
			internal Array4096<T> f6;
			internal Array4096<T> f7;
	
			// Properties
			public int Length { get; set; }
	
			// Methods
			public ref ref T ElementAt(int index);
		}
	
		internal sealed class SharedStatics // TypeDefIndex: 11462
		{
			// Nested types
			internal sealed class IsInstalled // TypeDefIndex: 11463
			{
				// Fields
				internal static readonly SharedStatic<Long1024> Ref; // 0x00
	
				// Constructors
				public IsInstalled(); // 0x00000001802E5CB0-0x00000001802E5CC0
				static IsInstalled(); // 0x0000000181C9EB40-0x0000000181C9EB90
			}
	
			internal sealed class TableEntry // TypeDefIndex: 11464
			{
				// Fields
				internal static readonly SharedStatic<Array32768<AllocatorManager.TableEntry>> Ref; // 0x00
	
				// Constructors
				public TableEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
				static TableEntry(); // 0x0000000181C9FC20-0x0000000181C9FC70
			}
	
			internal sealed class IsAutoDispose // TypeDefIndex: 11465
			{
				// Fields
				internal static readonly SharedStatic<Long1024> Ref; // 0x00
	
				// Constructors
				public IsAutoDispose(); // 0x00000001802E5CB0-0x00000001802E5CC0
				static IsAutoDispose(); // 0x0000000181C9EAF0-0x0000000181C9EB40
			}
	
			// Constructors
			public SharedStatics(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal static class Managed // TypeDefIndex: 11466
		{
			// Fields
			[NoAutoStaticsCleanup]
			internal static TryFunction[] TryFunctionDelegates; // 0x00
	
			// Constructors
			static Managed(); // 0x0000000181C9EED0-0x0000000181C9EF40
	
			// Methods
			[OnCodeLoaded]
			private static void Initialize(); // 0x0000000181C9EB90-0x0000000181C9EC20
			[ExcludeFromBurstCompatTesting("Uses managed delegate")]
			public static void RegisterDelegate(int index, TryFunction function); // 0x0000000181C9EC20-0x0000000181C9ED00
			[ExcludeFromBurstCompatTesting("Uses managed delegate")]
			public static void UnregisterDelegate(int index); // 0x0000000181C9EDF0-0x0000000181C9EED0
			[CompilerGenerated]
			internal static void Unity_Collections_AllocatorManager_Managed_Initialize_RegisterLifecycleMethod(); // 0x0000000181C9ED00-0x0000000181C9EDF0
		}
	
		private static class AllocatorCache<T> // TypeDefIndex: 11467
			where T : struct, IAllocator
		{
			// Fields
			[AutoStaticsCleanup]
			public static FunctionPointer<TryFunction> TryFunction;
			[AutoStaticsCleanup]
			public static TryFunction CachedFunction;
			[CompilerGenerated]
			private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both;
	
			// Constructors
			static AllocatorCache();
	
			// Methods
			[CompilerGenerated]
			private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both();
		}
	
		// Constructors
		static AllocatorManager(); // 0x0000000181C89A40-0x0000000181C89BB0
	
		// Methods
		public static unsafe void* Allocate(AllocatorHandle handle, int itemSizeInBytes, int alignmentInBytes, int items = 1 /* Metadata: 0x006A1BAD */); // 0x0000000181C88CA0-0x0000000181C88D20
		public static unsafe T* Allocate<T>(AllocatorHandle handle, int items = 1 /* Metadata: 0x006A1BAE */)
			where T : struct;
		public static unsafe void Free(AllocatorHandle handle, void* pointer, int itemSizeInBytes, int alignmentInBytes, int items = 1 /* Metadata: 0x006A1BAF */); // 0x0000000181C88E00-0x0000000181C88E90
		public static unsafe void Free(AllocatorHandle handle, void* pointer); // 0x0000000181C88E90-0x0000000181C88EF0
		public static unsafe void Free<T>(AllocatorHandle handle, T* pointer, int items = 1 /* Metadata: 0x006A1BB0 */)
			where T : struct;
		public static AllocatorHandle ConvertToAllocatorHandle(Allocator a); // 0x0000000181C88DE0-0x0000000181C88E00
		[BurstDiscard]
		private static void CheckDelegate(ref bool useDelegate); // 0x0000000180C1B6F0-0x0000000180C1B700
		private static bool UseDelegate(); // 0x0000000181C89A00-0x0000000181C89A40
		private static int allocate_block(ref Block block); // 0x0000000181C89BB0-0x0000000181C89C80
		[BurstDiscard]
		private static void forward_mono_allocate_block(ref Block block, ref int error); // 0x0000000181C89C80-0x0000000181C89DE0
		internal static Allocator LegacyOf(AllocatorHandle handle); // 0x0000000181C89250-0x0000000181C89260
		private static int TryLegacy(ref Block block); // 0x0000000181C89510-0x0000000181C89670
		public static int Try(ref Block block); // 0x0000000181C89670-0x0000000181C89A00
		public static void Initialize(); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void Install(AllocatorHandle handle, IntPtr allocatorState, FunctionPointer<TryFunction> functionPointer, TryFunction function, bool IsAutoDispose = false /* Metadata: 0x006A1BB1 */); // 0x0000000181C88EF0-0x0000000181C89180
		internal static void Install(AllocatorHandle handle, IntPtr allocatorState, TryFunction function); // 0x0000000181C89180-0x0000000181C89240
		internal static AllocatorHandle Register(IntPtr allocatorState, FunctionPointer<TryFunction> functionPointer, bool IsAutoDispose = false /* Metadata: 0x006A1BB2 */, bool isGlobal = false /* Metadata: 0x006A1BB3 */, int globalIndex = 0 /* Metadata: 0x006A1BB4 */); // 0x0000000181C89260-0x0000000181C89510
		[ExcludeFromBurstCompatTesting("Register uses managed delegate")]
		internal static ref ref T CreateAllocator<T>(AllocatorHandle backingAllocator, bool isGlobal = false /* Metadata: 0x006A1BB8 */, int globalIndex = 0 /* Metadata: 0x006A1BB9 */)
			where T : struct, IAllocator;
		public static void Shutdown(); // 0x00000001802E76C0-0x00000001802E76D0
		internal static bool IsCustomAllocator(AllocatorHandle allocator); // 0x0000000181C89240-0x0000000181C89250
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckFailedToAllocate(int error); // 0x0000000181C88D20-0x0000000181C88D80
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckFailedToFree(int error); // 0x0000000181C88D80-0x0000000181C88DE0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckValid(AllocatorHandle handle); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Extension methods
		internal static Block AllocateBlock<T>(this ref ref T t, int sizeOf, int alignOf, int items)
			where T : struct, IAllocator;
		internal static Block AllocateBlock<T, U>(this ref ref T t, U u, int items)
			where T : struct, IAllocator
			where U : struct;
		public static unsafe void* Allocate<T>(this ref ref T t, int sizeOf, int alignOf, int items = 1 /* Metadata: 0x006A1BAC */)
			where T : struct, IAllocator;
		internal static unsafe U* Allocate<T, U>(this ref ref T t, U u, int items)
			where T : struct, IAllocator
			where U : struct;
		internal static unsafe void* AllocateStruct<T, U>(this ref ref T t, U u, int items)
			where T : struct, IAllocator
			where U : struct;
		internal static void FreeBlock<T>(this ref ref T t, ref Block block)
			where T : struct, IAllocator;
		internal static unsafe void Free<T>(this ref ref T t, void* pointer, int sizeOf, int alignOf, int items)
			where T : struct, IAllocator;
		internal static unsafe void Free<T, U>(this ref ref T t, U* pointer, int items)
			where T : struct, IAllocator
			where U : struct;
		[ExcludeFromBurstCompatTesting("Uses managed delegate")]
		public static void Register<T>(this ref ref T t, bool IsAutoDispose = false /* Metadata: 0x006A1BB5 */, bool isGlobal = false /* Metadata: 0x006A1BB6 */, int globalIndex = 0 /* Metadata: 0x006A1BB7 */)
			where T : struct, IAllocator;
		public static void UnmanagedUnregister<T>(this ref ref T t)
			where T : struct, IAllocator;
		[ExcludeFromBurstCompatTesting("Uses managed delegate")]
		public static void Unregister<T>(this ref ref T t)
			where T : struct, IAllocator;
		[ExcludeFromBurstCompatTesting("Registration uses managed delegates")]
		internal static void DestroyAllocator<T>(this ref ref T t, AllocatorHandle backingAllocator)
			where T : struct, IAllocator;
	}
}
